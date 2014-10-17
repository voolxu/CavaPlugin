using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bots.Professionbuddy.ComponentBase;
using Bots.Professionbuddy.PropertyGridUtilities;
using Bots.Professionbuddy.PropertyGridUtilities.Editors;
using Styx.Common.Helpers;
using Styx.CommonBot.Profiles;

// ReSharper disable once CheckNamespace
namespace Bots.Professionbuddy.Components
{
    [PBXmlElement("EnableProfileAction", new[] { "EnableProfileAction" })]
    public sealed class EnableProfileAction : PBAction
    {

        private readonly WaitTimer _loadProfileTimer = new WaitTimer(TimeSpan.FromSeconds(5));
        private bool _loadedProfile;

        public EnableProfileAction()
        {
            Properties["Path"] = new MetaProp(
                "Path",
                typeof(string),
                new EditorAttribute(
                    typeof(FileLocationEditor),
                    typeof(UITypeEditor)),
                // ReSharper disable once LocalizableElement
                new DisplayNameAttribute("Path"));

            Properties["ProfileType"] = new MetaProp(
                "ProfileType",
                typeof(LoadProfileType),
                // ReSharper disable once LocalizableElement
                new DisplayNameAttribute("Profile Type"));

            Properties["IsLocal"] = new MetaProp(
                "IsLocal",
                typeof(bool),
                // ReSharper disable once LocalizableElement
                new DisplayNameAttribute("Is Local"));

            Path = "";
            ProfileType = LoadProfileType.Honorbuddy;
            IsLocal = true;
        }

        [PBXmlAttribute]
        public LoadProfileType ProfileType
        {
            get { return Properties.GetValue<LoadProfileType>("ProfileType"); }
            set { Properties["ProfileType"].Value = value; }
        }

        [PBXmlAttribute]
        public string Path
        {
            get { return Properties.GetValue<string>("Path"); }
            set { Properties["Path"].Value = value; }
        }

        [PBXmlAttribute]
        public bool IsLocal
        {
            get { return Properties.GetValue<bool>("IsLocal"); }
            set { Properties["IsLocal"].Value = value; }
        }


        public string AbsolutePath
        {
            get
            {
                if (!IsLocal)
                    return Path;
                return string.IsNullOrEmpty(ProfessionbuddyBot.Instance.CurrentProfile.XmlPath)
                    ? string.Empty
                    // ReSharper disable once AssignNullToNotNullAttribute
                    : System.IO.Path.Combine(System.IO.Path.GetDirectoryName(ProfessionbuddyBot.Instance.CurrentProfile.XmlPath), Path);
            }
        }

        public override string Name
        {
            get { return "Load Profile"; }
        }

        public override string Title
        {
            get { return string.Format("{0}: {1}", Name, Path); }
        }

        public override string Help
        {
            get { return "CAVAPB This action will load a profile, which can be either a Honorbuddy or Professionbuddy profile. Path needs to be relative to the currently loaded Professionbuddy profile and either in same folder or in a subfolder. If Path is empty and the profile type is Honorbuddy then an empty profile will be loaded."; }
        }

        // ReSharper disable once CSharpWarnings::CS1998
        protected async override Task Run()
        {
            if (!_loadedProfile)
            {
                if (Load())
                {
                    _loadProfileTimer.Reset();
                }
                _loadedProfile = true;
            }
            // We need to wait for a profile to load because the profile might be loaded asynchronously
            if (_loadProfileTimer.IsFinished ||
                (!string.IsNullOrEmpty(ProfileManager.XmlLocation) && ProfileManager.XmlLocation.Equals(AbsolutePath)))
            {
                IsDone = true;
            }
        }

        public string Decrypt(string cipherText)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(Environment.UserName,
                new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor == null) return cipherText;
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        private static string Getdata(string settingspath, string checkit)
        {
            var d = new XmlDocument();
            d.Load(settingspath);
            var n = d.GetElementsByTagName(checkit);
            return n[0] != null ? n[0].InnerText : "";
        }
        public bool Load()
        {
            var absPath = AbsolutePath;

            if (IsLocal && !string.IsNullOrEmpty(ProfileManager.XmlLocation) &&
                ProfileManager.XmlLocation.Equals(absPath, StringComparison.CurrentCultureIgnoreCase))
                return false;
            try
            {
                // Logging.Write("Cava: {0}", "something");
                
                PBLog.Debug(
                    "CAVAPB Loading Profile :{0}, previous profile was {1}",
                    Path,
                    ProfileManager.XmlLocation ?? "[No Profile]");
                if (string.IsNullOrEmpty(Path))
                {
                    ProfileManager.LoadEmpty();
                }
                else if (!IsLocal)
                {
                    if (Path.Contains("cavaprofessions"))
                    {
                        var pathtocavasettings = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                            string.Format(@"Settings\CavaPlugin\Main-Settings.xml"));
                        var servertouse = Getdata(pathtocavasettings, "UseServer");
                        if (servertouse == "1")
                        {
                            Path = "https://cavaprofiles.net/index.php/cavapages/profiles/profiles-list/" + Path;
                            var url = string.Format("https://cavaprofiles.net/index.php?user={0}&passw={1}",
                                 Getdata(pathtocavasettings, "CpLogin"), Decrypt(Getdata(pathtocavasettings, "CpPassword")));
                            var request = (HttpWebRequest)WebRequest.Create(url);
                            request.AllowAutoRedirect = false;
                            request.CookieContainer = new CookieContainer();
                            var response = (HttpWebResponse)request.GetResponse();
                            var cookies = request.CookieContainer;
                            response.Close();
                            try
                            {
                                request =
                                    (HttpWebRequest)
                                        WebRequest.Create(Path + "/file");
                                request.AllowAutoRedirect = false;
                                request.CookieContainer = cookies;
                                response = (HttpWebResponse)request.GetResponse();
                                var data = response.GetResponseStream();
                                string html;
                                // ReSharper disable once AssignNullToNotNullAttribute
                                using (var sr = new StreamReader(data))
                                {
                                    html = sr.ReadToEnd();
                                }
                                response.Close();
                                var profilepath =
                                    new MemoryStream(
                                        Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(Convert.FromBase64String(html))));
                                ProfileManager.LoadNew(profilepath);
                            }
                            catch (Exception ex)
                            {
                                PBLog.Warn(
                                    "CAVAPB Does not have access to Profile {0}. Please check if you have Profession access Error code: {1}",
                                    Path, ex);
                                return false;
                            }
                        }
                        else
                        {
                            Path = "https://cavaprofiles.org/index.php/cavapages/profiles/profiles-list/" + Path;
                            var url = string.Format("https://cavaprofiles.org/index.php?user={0}&passw={1}",
                                 Getdata(pathtocavasettings, "CpLogin"), Decrypt(Getdata(pathtocavasettings, "CpPassword")));
                            var request = (HttpWebRequest)WebRequest.Create(url);
                            request.AllowAutoRedirect = false;
                            request.CookieContainer = new CookieContainer();
                            var response = (HttpWebResponse)request.GetResponse();
                            var cookies = request.CookieContainer;
                            response.Close();
                            try
                            {
                                request =
                                    (HttpWebRequest)
                                        WebRequest.Create(Path + "/file");
                                request.AllowAutoRedirect = false;
                                request.CookieContainer = cookies;
                                response = (HttpWebResponse)request.GetResponse();
                                var data = response.GetResponseStream();
                                string html;
                                // ReSharper disable once AssignNullToNotNullAttribute
                                using (var sr = new StreamReader(data))
                                {
                                    html = sr.ReadToEnd();
                                }
                                response.Close();
                                var profilepath =
                                    new MemoryStream(
                                        Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(Convert.FromBase64String(html))));
                                ProfileManager.LoadNew(profilepath);
                            }
                            catch (Exception ex)
                            {
                                PBLog.Warn(
                                    "CAVAPB Does not have access to Profile {0}. Please check if you have Profession access Error code: {1}",
                                    Path, ex);
                                return false;
                            }
                        }

                        

                    }
                    else
                    {
                        var req = WebRequest.Create(Path);
                        req.Proxy = null;
                        using (WebResponse res = req.GetResponse())
                        {
                            using (var stream = res.GetResponseStream())
                            {
                                ProfileManager.LoadNew(stream);
                            }
                        }
                    }
                }
                else if (File.Exists(absPath))
                {
                    ProfileManager.LoadNew(absPath);
                }
                else
                {
                    PBLog.Warn("{0}: {1}", "CAVAPB Unable to find profile", Path);
                    return false;
                }
            }
            catch (Exception ex)
            {
                PBLog.Warn("CAVAPB {0}", ex);
                return false;
            }
            return true;
        }

        public override IPBComponent DeepCopy()
        {
            return new EnableProfileAction { Path = Path, ProfileType = ProfileType, IsLocal = IsLocal };
        }

        public override void Reset()
        {
            _loadedProfile = false;
            base.Reset();
        }

    }
}