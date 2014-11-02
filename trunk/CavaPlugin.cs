using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using Styx;
using Styx.CommonBot.Frames;
using Styx.CommonBot.Routines;
using Styx.Helpers;
using Styx.Pathing;
using Styx.Plugins;
using Styx.Common;
using Styx.CommonBot;
using Styx.CommonBot.POI;
using Styx.CommonBot.Profiles;
using Styx.TreeSharp;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using Bots.Grind;
using Action = System.Action;
using ThreadState = System.Threading.ThreadState;

namespace CavaPlugin
{
    // ReSharper disable UnusedMember.Global
    public class CavaPlugin : HBPlugin
    // ReSharper restore UnusedMember.Global
    {
        //private Dictionary<ulong, DateTime> _blackList = new Dictionary<ulong, DateTime>();
        private int UseServer = 1;
        private bool _hasBeenInitialized;
        private bool _hasBeenInitialized2;
        private bool _hasBeenInitialized3;
        private bool _cavaupdated;
        private bool _botRunning = true;
        private bool _gotGuildInvite;
        private bool _gotPartyInvite;
        private bool _gotTradeinvite;
        private bool _gotDuelinvite;
        private bool _erro;
        private int _nVezesBotUnstuck;
        private static Thread _recomecar;
        private readonly Stopwatch _ultimoSemStuck = new Stopwatch();
        private readonly Stopwatch _summonpettime = new Stopwatch();
        private readonly Stopwatch _mountedTime = new Stopwatch();
        private readonly Stopwatch _checkBags = new Stopwatch();
        private readonly Stopwatch _asLastSavedTimer = new Stopwatch();
        private readonly Stopwatch _antigankertimeTimer = new Stopwatch();
 
        private int _refusetime;
        private WoWPoint _ultimoLocal;
        private WoWPoint _asLastSavedPosition;
        private bool _asLastSavedPositionTrigger;
        //private const string VendorMountLogEntry = "Summoning vendor mount (";
        //private const string TaximapLogEntry = "Taximap failed to open. Blacklisting the flight master.";
        //private int _vendorMountSpellId;
        private int _waitgankercount;
        private bool _oldSh;
        private bool _gankedressatSh;

        private bool _onbotstart = true;
        private readonly Stopwatch _refuseguildtimer = new Stopwatch();
        private readonly Stopwatch _refusepartytimer = new Stopwatch();
        private readonly Stopwatch _refusetradetimer = new Stopwatch();
        private readonly Stopwatch _refusedueltimer = new Stopwatch();
        
        //languages
        private static CultureInfo _ci;
        private static readonly string Str = Assembly.GetExecutingAssembly().FullName.Remove(Assembly.GetExecutingAssembly().FullName.IndexOf(','));
        private readonly Assembly _assembly = Assembly.Load(Str);
        private static ResourceManager _rm;

        #region Overrides except pulse

        private static readonly SoundPlayer Player = new SoundPlayer();

        public override string Author
        {
            get { return "Cava"; }
        }

        public override Version Version
        {
            get { return new Version(4, 9, 5); }
        }

        public override string Name
        {
            get { return "CavaPlugin"; }
        }

        public override bool WantButton
        {
            get { return true; }
        }

        public override string ButtonText
        {
            get { return "Cava Profiles"; }
        }

        public override void OnButtonPress()
        {
            var isRunningantes = TreeRoot.IsRunning;
            if (isRunningantes)
            {
                // ReSharper disable ResourceItemNotResolved
                MessageBox.Show(_rm.GetString("Bot_is_running_stop_bot_before_initiate_Cava_Plugin", _ci),
                    _rm.GetString("error", _ci), MessageBoxButtons.OK, MessageBoxIcon.Error);
                // ReSharper restore ResourceItemNotResolved
                Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error.wav";
                Player.Play();
                return;
            }
            AbreJanela();
            Player.SoundLocation = PathToCavaPlugin + "Sounds\\Close.wav";
            Player.Play();
            //MessageBox.Show("To Start CavaPlugin load profile Cava_Starter_Profiles.xml", "WELCOME TO CAVAPLUGIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static readonly string PathToCavaPlugin =
        // ReSharper disable PossiblyMistakenUseOfParamsMethod
            Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\");
        private static readonly string PathToCavaProfiles =
            Path.Combine(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\");
        private static readonly string PathToCavaQBs =
            Path.Combine(Utilities.AssemblyDirectory + @"\Quest Behaviors\Cava\");
        // ReSharper restore PossiblyMistakenUseOfParamsMethod

        private readonly HashSet<uint> _boxList = new HashSet<uint>
        {
            88567, //Ghost Iron Lockbox
            43624, //Titanium Lockbox
            45986, //Tiny Titanium Lockbox
            68729, //Elementium Lockbox
            19425, //Mysterious Lockbox
            4636, //Strong Iron Lockbox
            31952, //Khorium Lockbox
            5760, //Eternium Lockbox
            43622, //Froststeel Lockbox
            5759, //Thorium Lockbox
            4638, //Reinforced Steel Lockbox
            4634, //Iron Lockbox
            5758, //Mithril Lockbox
            4637, //Steel Lockbox
            4633, //Heavy Bronze Lockbox
            4632, //Ornate Bronze Lockbox
            16885, //Heavy Junkbox
            88165, // Vine-Cracked Junkbox
            63349, // Flame-Scarred Junkbox
            29569, //Strong Junkbox
            43575, //Reinforced Junkbox
            16882, //Battered Junkbox
            16884, //Sturdy Junkbox
            16883 //Worn Junkbox
        };
        readonly List<string> _antigank = new List<string>();

        private static IEnumerable<WoWPlayer> GetAllTargetingNonFriendlyPlayers()
        {
            return ObjectManager.GetObjectsOfType<WoWPlayer>().Where(ret => (
                ret != null &&
                ret.IsPlayer &&
                !ret.IsFriendly &&
                ret.IsTargetingMeOrPet
                )).ToArray();
        }

        private void Addgankers()
        {
            foreach (var ganker in GetAllTargetingNonFriendlyPlayers())
            {
                if (CPsettings.Instance.Playsonar)
                {
                    Player.SoundLocation = PathToCavaPlugin + "Sounds\\Sonar.wav";
                    Player.Play();
                }
                _antigank.RemoveAll(x => _antigank.Contains(ganker.ToString()));
                _antigank.Add(ganker.Name + "," + DateTime.Now);
                Log("[AntiGank]: Added {0} to ganker list, at {1}.", ganker.Name, DateTime.Now);
            }
        }

        private void Delgankers()
        {
            var ganktoremove = new List<string>();
            foreach (var addedganker in _antigank)
            {
                var i = addedganker.IndexOf(',');
                var gankedtime = DateTime.Parse(addedganker.Substring(i + 1));
                if (DateTime.Now <= gankedtime.AddMinutes(15)) continue;
                Log("[AntiGank]: Removed {0} from Ganker List.", addedganker.Substring(0, i));
                ganktoremove.Add(addedganker);
            }
            foreach (var removethis in ganktoremove)
            {
               _antigank.Remove(removethis);
            }
        }

        private bool LookForGankers()
        {
            foreach (var checkplayer in ObjectManager.GetObjectsOfType<WoWPlayer>().Where(ret =>
                ret != null &&
                !ret.IsAFKFlagged &&
                ret.Distance <= 150 &&
                ret.IsHostile &&
                ret.IsPlayer &&
                _antigank.Any(checkganker => checkganker.Contains(ret.Name)) &&
                StyxWoW.Me.Location.Distance(StyxWoW.Me.CorpsePoint) < 100)
                )
            {
                Log("[AntiGank]: Detected Ganker {0} Level {1}. Starting idle time routine.", checkplayer.Name, checkplayer.Level);
                if (LevelBot.BehaviorFlags.HasFlag(BehaviorFlags.Death)) { LevelBot.BehaviorFlags &= ~BehaviorFlags.Death; }
                return true;
            }
            return false;
        }

        private static void CavaAtackMob()
        {
            if (!Me.IsAutoAttacking)
            { Lua.DoString("StartAttack()"); }
            var spell=0; 
            switch (Me.Class)
            {
                case WoWClass.Mage:
                    if (SpellManager.CanCast(2136))
                        spell = 2136;
                    if (SpellManager.CanCast(126201))
                        spell = 126201;
                    if (SpellManager.CanCast(44614))
                        spell = 44614;
                    break;
                case WoWClass.Druid:
                    if (SpellManager.CanCast(33917))
                        spell = 33917;
                    if (SpellManager.CanCast(22568))
                        spell = 22568;
                    if (SpellManager.CanCast(1822))
                        spell = 1822;
                    if (SpellManager.CanCast(768) && !Me.HasAura(768))
                        spell = 768;
                    if (SpellManager.CanCast(5176) && !Me.HasAura(768))
                        spell = 5176;
                    break;
                case WoWClass.Paladin:
                    if (SpellManager.CanCast(20271))
                        spell = 20271;
                    if (SpellManager.CanCast(35395))
                        spell = 35395;
                    break;
                case WoWClass.Priest:
                    if (SpellManager.CanCast(585))
                        spell = 585;
                    if (SpellManager.CanCast(15407))
                        spell = 15407;
                    if (SpellManager.CanCast(589) && !Me.CurrentTarget.HasAura(589))
                        spell = 589;
                    break;
                case WoWClass.Shaman:
                    if (SpellManager.CanCast(73899))
                        spell = 73899;
                    if (SpellManager.CanCast(403))
                        spell = 403;
                    if (SpellManager.CanCast(17364))
                        spell = 17364;
                    break;
                case WoWClass.Warlock:
                    spell = 686;
                    break;
                case WoWClass.DeathKnight:
                    spell = 49998;
                    break;
                case WoWClass.Hunter:
                    if (SpellManager.CanCast(56641))
                        spell = 56641;
                    if (SpellManager.CanCast(3044))
                        spell = 3044;
                    break;
                case WoWClass.Warrior:
                    if (SpellManager.CanCast(20243))
                        spell = 20243;
                    if (SpellManager.CanCast(23922))
                        spell = 23922;
                    if (SpellManager.CanCast(34428))
                        spell = 34428;
                    if (SpellManager.CanCast(78))
                        spell = 78;
                    break;
                case WoWClass.Rogue:
                    if (SpellManager.CanCast(1752))
                        spell = 1752;
                    if (SpellManager.CanCast(2098))
                        spell = 2098;
                    break;
                case WoWClass.Monk:
                    if (SpellManager.CanCast(100787))
                        spell = 100787;
                    if (SpellManager.CanCast(100780))
                        spell = 100780;
                    break;
            }
            if (spell != 0)
            {
                if (SpellManager.CanCast(spell))
                {
                    SpellManager.Cast(spell);
                }
            }
        }
        // ReSharper restore PossiblyMistakenUseOfParamsMethod
        private static bool UpdaterCava(string f, string stuff)
        {
            var p = new Process {StartInfo = {FileName = "TortoiseProc.exe", Arguments = f}};
            var t =
                ObjectManager.GetObjectsOfType<WoWGameObject>()
                    .Any(
                        o => o.Entry == 176310 && o.Location.Distance(new WoWPoint(-8650.719, 1346.051, 0.04130154)) < 3);
                
            try
            {
                p.Start();
                p.WaitForExit();
                if (p.ExitCode == 0)
                {
                    return true;
                }
                switch (stuff)
                {
                    case "AllowUpdate":
                        CPGlobalSettings.Instance.AllowUpdate = false;
                        break;
                    case "PBMiningBlacksmithing":
                        CPGlobalSettings.Instance.PBMiningBlacksmithing = false;
                        break;
                }
            }

            catch (Exception ex)
            {
                // ReSharper disable ResourceItemNotResolved
                Err(_rm.GetString("Unable_to_run_TortoiseSVN", _ci));
                // ReSharper restore ResourceItemNotResolved
                Err("Exception " + ex.Message);
            }
            return false;
        }

        private static string Decrypt(string cipherText)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(Environment.UserName,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
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

        public override void OnEnable()
        {
            //Logging.OnLogMessage += LoggingOnOnLogMessage;
            CPGlobalSettings.Instance.Load();
            CPsettings.Instance.Load();
            if (!CPGlobalSettings.Instance.Languageselected)
            {
                Form getlanguage = new Language();
                getlanguage.ShowDialog();
            }
            switch (CPGlobalSettings.Instance.language)
            {
                default:
                    _ci = new CultureInfo("en-US");
                    _rm = new ResourceManager("Lang", _assembly);
                    break;
                case 0:
                    _ci = new CultureInfo("en-US");
                    _rm = new ResourceManager("Lang", _assembly);
                    break;
                case 1:
                    _ci = new CultureInfo("da");
                    _rm = new ResourceManager("Lang.da", _assembly);
                    break;
                case 2:
                    _ci = new CultureInfo("de");
                    _rm = new ResourceManager("Lang.de", _assembly);
                    break;
                case 3:
                    _ci = new CultureInfo("fr");
                    _rm = new ResourceManager("Lang.fr", _assembly);
                    break;
                case 4:
                    _ci = new CultureInfo("pt-PT");
                    _rm = new ResourceManager("Lang.pt", _assembly);
                    break;
                case 5:
                    _ci = new CultureInfo("ru-RU");
                    _rm = new ResourceManager("Lang.ru", _assembly);
                    break;
            }

            //_ci = new CultureInfo("en-US");
            //_rm = new ResourceManager("Lang", _assembly);
            BotEvents.OnBotStartRequested += _OnBotStart;
            if (!_hasBeenInitialized)
            {
                if (File.Exists(PathToCavaPlugin + "CavaPlugin.ver") ||
                    File.Exists(PathToCavaPlugin + "Cava_Plugin_V3_Updater.ver"))
                {
                    // ReSharper disable ResourceItemNotResolved
                    MessageBox.Show(_rm.GetString("Welcome_to_CavaPlugin", _ci) + Environment.NewLine +
                                    _rm.GetString("Please_download_and_update_your_version_to_latest_one", _ci) +
                                    Environment.NewLine +
                                    _rm.GetString("This_version_have_some_problems_with_TortoiseSVN", _ci) +
                                    Environment.NewLine +
                                    _rm.GetString("Download_latest_version_from_HB_Forum", _ci),
                        _rm.GetString("information", _ci), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Player.SoundLocation = PathToCavaPlugin + "Sounds\\Information.wav";
                    Player.Play();
                    return;
                }
                Debug(_rm.GetString("Loading_CavaPlugin", _ci));
                Debug(_rm.GetString("Please_Wait_While_CavaPlugin_Check_For_Updates", _ci));
                //update Plugin
                if (CavaPluginUpdater.UpdateAvailable("http://cavaplugin.googlecode.com/svn/trunk/", "Plugin.ver"))
                {
                    var newrev =
                        CavaPluginUpdater.GetNewestRev("http://cavaplugin.googlecode.com/svn/trunk/")
                            .ToString(CultureInfo.InvariantCulture);
                    Debug(_rm.GetString("Cava_Plugin_Update_to_0_is_available_You_are_on_1", _ci), newrev,
                        CavaPluginUpdater.GetCurrentRev("Plugin.ver").ToString(CultureInfo.InvariantCulture));
                    Debug(_rm.GetString("Starting_update_process", _ci));
                    if (UpdaterCava("/command:\"update\" /path:\"" + PathToCavaPlugin + "\" /closeonend:1", ""))
                    {
                        _cavaupdated = true;
                        CavaPluginUpdater.WriteNewRevFile("Plugin.ver", newrev);
                        Debug(_rm.GetString("is_at_Rev_0_and_up_to_date", _ci), newrev);
                    }
                    else
                    {
                        Err(_rm.GetString("There_is_a_problem_updating", _ci) + " CavaPlugin.");
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                        Player.Play();
                        _erro = true;
                    }
                }
                if (!Directory.Exists(PathToCavaProfiles) || !Directory.Exists(PathToCavaQBs))
                {
                    MessageBox.Show(_rm.GetString("Theres_an_error_with_Cava_Quest_Behaviors_or_Cava_profiles", _ci),
                        _rm.GetString("information", _ci), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Player.SoundLocation = PathToCavaPlugin + "Sounds\\Information.wav";
                    Player.Play();
                    return;
                }

                //fazer update de quest behaviors
                if (CavaPluginUpdater.UpdateAvailable("http://cavaqbs.googlecode.com/svn/trunk/Cava/",
                    "QuestBehaviors.ver"))
                {
                    var newrev =
                        CavaPluginUpdater.GetNewestRev("http://cavaqbs.googlecode.com/svn/trunk/Cava/")
                            .ToString(CultureInfo.InvariantCulture);
                    Debug("Cava Quest Behaviors " + _rm.GetString("Update_to_0_are_available_You_are_on_1", _ci), newrev,
                        CavaPluginUpdater.GetCurrentRev("QuestBehaviors.ver").ToString(CultureInfo.InvariantCulture));
                    Debug(_rm.GetString("Starting_update_process", _ci));
                    if (UpdaterCava("/command:\"update\" /path:\"" + PathToCavaQBs + "\" /closeonend:1", ""))
                    {
                        _cavaupdated = true;
                        CavaPluginUpdater.WriteNewRevFile("QuestBehaviors.ver", newrev);
                        Debug("Quest Behaviors " + _rm.GetString("are_at_Rev_0_and_up_to_date", _ci), newrev);
                    }
                    else
                    {
                        Err(_rm.GetString("There_is_a_problem_updating", _ci) + " Cava Quest Behaviors.");
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                        Player.Play();
                        _erro = true;
                    }
                }

                //fazer update de profiles
                if (CavaPluginUpdater.UpdateAvailable("http://cavaprofiles.googlecode.com/svn/trunk/",
                    "Profiles.ver"))
                {
                    var newrev =
                        CavaPluginUpdater.GetNewestRev("http://cavaprofiles.googlecode.com/svn/trunk/")
                            .ToString(CultureInfo.InvariantCulture);
                    Debug("Quest Profiles " + _rm.GetString("Update_to_0_are_available_You_are_on_1", _ci), newrev,
                        CavaPluginUpdater.GetCurrentRev("Profiles.ver").ToString(CultureInfo.InvariantCulture));
                    Debug(_rm.GetString("Starting_update_process", _ci));
                    if (UpdaterCava("/command:\"update\" /path:\"" + PathToCavaProfiles + "\" /closeonend:1", ""))
                    {
                        CavaPluginUpdater.WriteNewRevFile("Profiles.ver", newrev);
                        Debug("Cava Profiles " + _rm.GetString("are_at_Rev_0_and_up_to_date", _ci), newrev);
                    }
                    else
                    {
                        Err(_rm.GetString("There_is_a_problem_updating", _ci) + " Cava Profiles.");
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                        Player.Play();
                        _erro = true;
                    }
                }
                //fazer update de Armageddoner
                UseServer = CPGlobalSettings.Instance.UseServer;
                if (UseServer==1)
                {
                    var url = string.Format("https://cavaprofiles.net/index.php?user={0}&passw={1}",
                        CPGlobalSettings.Instance.CpLogin, Decrypt(CPGlobalSettings.Instance.CpPassword));
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
                                WebRequest.Create(
                                    "https://cavaprofiles.net/index.php/profiles/profiles-list/armageddoner/6-armagedonner-user-1/file");
                        request.AllowAutoRedirect = false;
                        request.CookieContainer = cookies;
                        response = (HttpWebResponse)request.GetResponse();
                        response.Close();
                        if (response.StatusCode.ToString() == "OK") //is armageddoner
                        {
                            Log(_rm.GetString("Armageddoner_Access_Tested_and_Passed", _ci));
                            CPGlobalSettings.Instance.ArmaPanelBack = true;
                        }
                        else
                        {
                            CPGlobalSettings.Instance.ArmaPanelBack = false;
                            CPGlobalSettings.Instance.AutoShutdownWhenUpdate = false;
                            CPGlobalSettings.Instance.DisablePlugin = true;
                            CPsettings.Instance.AntiStuckSystem = false;
                            CPsettings.Instance.CheckAllowSummonPet = false;
                            CPsettings.Instance.guildInvitescheck = false;
                            CPsettings.Instance.refuseguildInvitescheck = false;
                            CPsettings.Instance.RefusepartyInvitescheck = false;
                            CPsettings.Instance.RefusetradeInvitescheck = false;
                            CPsettings.Instance.RefuseduelInvitescheck = false;
                            CPsettings.Instance.RessAfterDie = false;
                            CPsettings.Instance.CombatLoot = false;
                            CPsettings.Instance.OpenBox = false;
                            CPsettings.Instance.FixMountFlightVendor = false;
                            //CPsettings.Instance.BlacklistflycheckBox = false;
                            CPsettings.Instance.AntigankcheckBox = false;
                            CPsettings.Instance.Playsonar = false;
                        }
                    }
                    catch (Exception)
                    {
                        CPGlobalSettings.Instance.ArmaPanelBack = false;
                    }
                    try
                    {
                        request =
                            (HttpWebRequest)
                                WebRequest.Create(
                                    "https://cavaprofiles.net/index.php/profiles/profiles-list/cavaprofessions/mining/13-miningblacksmithing600/file");
                        request.AllowAutoRedirect = false;
                        request.CookieContainer = cookies;
                        response = (HttpWebResponse)request.GetResponse();
                        response.Close();
                        if (response.StatusCode.ToString() == "OK") //is profession min,bs600
                        {
                            Log(_rm.GetString("Profession_Owner_Access_Tested_and_Passed_for_MiningBlacksmithing1to600", _ci));
                            CPGlobalSettings.Instance.ProfMinBlack600 = true;
                        }
                        else
                        {
                            CPGlobalSettings.Instance.ProfMinBlack600 = false;
                        }
                    }
                    catch (Exception)
                    {
                        CPGlobalSettings.Instance.ProfMinBlack600 = false;
                    }
                }
                else
                {
                    var url = string.Format("https://cavaprofiles.org/index.php?user={0}&passw={1}",
                       CPGlobalSettings.Instance.CpLogin, Decrypt(CPGlobalSettings.Instance.CpPassword));
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
                                WebRequest.Create(
                                    "https://cavaprofiles.org/index.php/profiles/profiles-list/armageddoner/6-armagedonner-user-1/file");
                        request.AllowAutoRedirect = false;
                        request.CookieContainer = cookies;
                        response = (HttpWebResponse)request.GetResponse();
                        response.Close();
                        if (response.StatusCode.ToString() == "OK") //is armageddoner
                        {
                            Log(_rm.GetString("Armageddoner_Access_Tested_and_Passed", _ci));
                            CPGlobalSettings.Instance.ArmaPanelBack = true;
                        }
                        else
                        {
                            CPGlobalSettings.Instance.ArmaPanelBack = false;
                            CPGlobalSettings.Instance.AutoShutdownWhenUpdate = false;
                            CPGlobalSettings.Instance.DisablePlugin = true;
                            CPsettings.Instance.AntiStuckSystem = false;
                            CPsettings.Instance.CheckAllowSummonPet = false;
                            CPsettings.Instance.guildInvitescheck = false;
                            CPsettings.Instance.refuseguildInvitescheck = false;
                            CPsettings.Instance.RefusepartyInvitescheck = false;
                            CPsettings.Instance.RefusetradeInvitescheck = false;
                            CPsettings.Instance.RefuseduelInvitescheck = false;
                            CPsettings.Instance.RessAfterDie = false;
                            CPsettings.Instance.CombatLoot = false;
                            CPsettings.Instance.OpenBox = false;
                            CPsettings.Instance.FixMountFlightVendor = false;
                            //CPsettings.Instance.BlacklistflycheckBox = false;
                            CPsettings.Instance.AntigankcheckBox = false;
                            CPsettings.Instance.Playsonar = false;
                        }
                    }
                    catch (Exception)
                    {
                        CPGlobalSettings.Instance.ArmaPanelBack = false;
                    }
                    try
                    {
                        request =
                            (HttpWebRequest)
                                WebRequest.Create(
                                    "https://cavaprofiles.org/index.php/profiles/profiles-list/cavaprofessions/mining/13-miningblacksmithing600/file");
                        request.AllowAutoRedirect = false;
                        request.CookieContainer = cookies;
                        response = (HttpWebResponse)request.GetResponse();
                        response.Close();
                        if (response.StatusCode.ToString() == "OK") //is profession min,bs600
                        {
                            Log(_rm.GetString("Profession_Owner_Access_Tested_and_Passed_for_MiningBlacksmithing1to600", _ci));
                            CPGlobalSettings.Instance.ProfMinBlack600 = true;
                        }
                        else
                        {
                            CPGlobalSettings.Instance.ProfMinBlack600 = false;
                        }
                    }
                    catch (Exception)
                    {
                        CPGlobalSettings.Instance.ProfMinBlack600 = false;
                    }
                }
                /*if (File.Exists(_pathToOldPbLoadProfile))
                {
                    File.Delete(_pathToOldPbLoadProfile);
                }
                // ReSharper disable once PossiblyMistakenUseOfParamsMethod
                if(Directory.Exists(Path.Combine(Utilities.AssemblyDirectory + @"\Bots\Professionbuddy\Components")))
                {
                    var fi = new FileInfo(_pathToPbLoadProfile);
                    //Log(fi.Length.ToString(CultureInfo.InvariantCulture));
                    if (!File.Exists(_pathToPbLoadProfile) || fi.Length != 9796) //
                    {
                        var file = new StreamWriter(_pathToPbLoadProfile);
                        file.Write(Encoding.UTF8.GetString(Convert.FromBase64String(PbLoadProfile)));
                        file.Close();
                    }
                }*/

                if (!_erro)
                {
                    Debug(_cavaupdated
                        ? _rm.GetString("is_now_up_to_date_Please_reload_HB", _ci)
                        : _rm.GetString("is_up_to_date_and_ready", _ci));
                }
                if (_cavaupdated && CPGlobalSettings.Instance.AutoShutdownWhenUpdate)
                {
                    Debug(_rm.GetString("Auto_Shutdown_in_progress_at", _ci) + " " +
                          DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    new Sleep(5000);
                    Environment.Exit(0);
                }
                _hasBeenInitialized = true;
                CPGlobalSettings.Instance.Save();
                CPsettings.Instance.Save();
                _mountedTime.Reset();
                _mountedTime.Start();
                _summonpettime.Reset();
                _summonpettime.Start();
                _ultimoSemStuck.Reset();
                _ultimoSemStuck.Start();
                _asLastSavedTimer.Reset();
                _asLastSavedTimer.Start();
                _antigankertimeTimer.Reset();
                _antigankertimeTimer.Start();
                _checkBags.Reset();
                _checkBags.Start();
            }
            //duplo ignore, bot corre 2 vezes o Initialize
            if (!_hasBeenInitialized2)
            {
                _hasBeenInitialized2 = true;
                return;
            }
            if (!_hasBeenInitialized3)
            {
                _hasBeenInitialized3 = true;
                return;
            }
            AbreJanela();
        }

        public override void OnDisable()
        {
            //Logging.OnLogMessage -= LoggingOnOnLogMessage;
            BotEvents.OnBotStartRequested -= _OnBotStart;
            Log(_rm.GetString("CavaPlugin_Disposed", _ci));
            if (!_botRunning) return;
            if (CPsettings.Instance.guildInvitescheck || CPsettings.Instance.refuseguildInvitescheck)
            {
                Lua.Events.DetachEvent("GUILD_INVITE_REQUEST", RotinaGuildInvites);
            }
            if (CPsettings.Instance.RefusepartyInvitescheck)
            {
                Lua.Events.DetachEvent("PARTY_INVITE_REQUEST", RotinaPartyInvites);
            }
            if (CPsettings.Instance.RefusetradeInvitescheck)
            {
                Lua.Events.DetachEvent("TRADE_SHOW", RotinaTradeInvites);
            }
            if (CPsettings.Instance.RefuseduelInvitescheck)
            {
                Lua.Events.DetachEvent("DUEL_REQUESTED", RotinaDuelInvites);
            }
        }

        private void _OnBotStart(EventArgs args)
        {
            if (_onbotstart)
            {
                CPsettings.Instance.Load();
                _botRunning = true;
                if (ProfileManager.CurrentProfile.Name != null && !ProfileManager.CurrentProfile.Name.Contains("[Cava]") &&
                    _botRunning && CPGlobalSettings.Instance.DisablePlugin)
                {
                    _botRunning = false;
                }
                Log(_botRunning ? _rm.GetString("Is_now_ENABLED", _ci) : _rm.GetString("Is_now_DISABLED", _ci));
                if (_botRunning && !Me.InVehicle)
                {
                    Log(CPsettings.Instance.AntiStuckSystem
                        ? _rm.GetString("System_Anti-Stuck_Enabled", _ci)
                        : _rm.GetString("System_Anti-Stuck_Disabled", _ci));
                    _mountedTime.Restart();
                    _recomecar = new Thread(_Recomecar);
                    _asLastSavedTimer.Restart();

                    if (CPsettings.Instance.OpenBox)
                    {
                        Log(_rm.GetString("Open_Boxes_is_Enabled", _ci));
                        _checkBags.Restart();
                    }
                    else
                    {
                        Log(_rm.GetString("Open_Boxes_is_Disabled", _ci));
                    }

                    if (CPsettings.Instance.CheckAllowSummonPet)
                    {                                                 
                        //var numMinipets = Lua.GetReturnVal<int>("return C_PetBattles.GetNumPets(1)", 0);
                        var numMinipets = Lua.GetReturnVal<int>("return GetNumCompanions('CRITTER')", 0);
                        if (numMinipets > 0)
                        {
                            Log(_rm.GetString("Summon_Random_Pet_Enabled", _ci));
                            Lua.DoString("RunMacroText('/randompet')");
                            _summonpettime.Restart();
                        }
                        else
                        {
                            Log(_rm.GetString("Dont_have_any_Pet_to_summom_disabling_Summon_Random_Pet", _ci));
                            CPsettings.Instance.CheckAllowSummonPet = false;

                        }
                    }
                    else
                    {
                        Log(_rm.GetString("Summon_Random_Pet_Disabled", _ci));
                    }

                    Log(CPsettings.Instance.FixMountFlightVendor
                        ? "Fix Mount Flight Master Bug Enabled"
                        : "Fix Mount Flight Master Bug Disabled");
                    //Log(CPsettings.Instance.BlacklistflycheckBox
                    //    ? "Remove Blacklist Flight Master Enabled"
                    //    : "Remove Blacklist Flight Master Disabled");
                    Log(CPsettings.Instance.AntigankcheckBox
                        ? "Anti Gank System Enabled"
                        : "Anti Gank System Disabled");
                    if (CPsettings.Instance.guildInvitescheck || CPsettings.Instance.refuseguildInvitescheck)
                    {
                        if (CPsettings.Instance.guildInvitescheck)
                        {
                            Log(_rm.GetString("Accept_lvl_25_guild_invite_Enabled", _ci));
                        }
                        if (CPsettings.Instance.refuseguildInvitescheck)
                        {
                            Log(_rm.GetString("Refuse_guild_invites_Enabled", _ci));
                        }
                        Lua.Events.AttachEvent("GUILD_INVITE_REQUEST", RotinaGuildInvites);
                    }
                    if (!CPsettings.Instance.guildInvitescheck || !CPsettings.Instance.refuseguildInvitescheck)
                    {
                        if (!CPsettings.Instance.guildInvitescheck)
                        {
                            Log(_rm.GetString("Accept_lvl_25_guild_invite_Disabled", _ci));
                        }
                        if (!CPsettings.Instance.refuseguildInvitescheck)
                        {
                            Log(_rm.GetString("Refuse_guild_invites_Disabled", _ci));
                        }
                    }

                    if (CPsettings.Instance.RefusepartyInvitescheck)
                    {
                        Log(_rm.GetString("Refuse_party_invites_Enabled", _ci));
                        Lua.Events.AttachEvent("PARTY_INVITE_REQUEST", RotinaPartyInvites);
                    }
                    else
                    {
                        Log(_rm.GetString("Refuse_party_invites_Disabled", _ci));
                    }

                    if (CPsettings.Instance.RefusetradeInvitescheck)
                    {
                        Log(_rm.GetString("Refuse_trade_invites_Enabled", _ci));
                        Lua.Events.AttachEvent("TRADE_SHOW", RotinaTradeInvites);
                    }
                    else
                    {
                        Log(_rm.GetString("Refuse_trade_invites_Disabled", _ci));
                    }

                    if (CPsettings.Instance.RefuseduelInvitescheck)
                    {
                        Log(_rm.GetString("Refuse_duel_invites_Enabled", _ci));
                        Lua.Events.AttachEvent("DUEL_REQUESTED", RotinaDuelInvites);
                    }
                    else
                    {
                        Log(_rm.GetString("Refuse_duel_invites_Disabled", _ci));
                        // ReSharper restore ResourceItemNotResolved

                    }
                    Log(CPsettings.Instance.CombatLoot
                        ? "Auto Loot in combate Enabled."
                        : "Auto Loot in combate Disabled.");
                }
                _onbotstart = false;
            }
            else
            {
                _onbotstart = true;
            }
        }

        private static int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        private void RotinaGuildInvites(object sender, LuaEventArgs e)
        {
            var guildName = e.Args[1].ToString();
            var guildLevel = Convert.ToInt32(e.Args[2]);
            if (CPsettings.Instance.guildInvitescheck && guildLevel >= 25)
            {
                //ReSharper disable once ResourceItemNotResolved
                Log(_rm.GetString("Accepting_guild_invite_from", _ci), guildName);
                Lua.DoString("AcceptGuild()");
                //Lua.DoString("StaticPopup_Hide(\"GUILD_INVITE\")");
                Lua.DoString("RunMacroText('/click GuildInviteFrameJoinButton')");
            }
            if (CPsettings.Instance.refuseguildInvitescheck || guildLevel < 25)
            {
                _refuseguildtimer.Reset();
                _refuseguildtimer.Start();
                _refusetime = RandomNumber(3000, 8000);
                _gotGuildInvite = true;
                //ReSharper disable once ResourceItemNotResolved
                Log(_rm.GetString("Declining_guild_invite_from", _ci), guildName, guildLevel, _refusetime / 1000);
            }
        }

        private void RotinaPartyInvites(object sender, LuaEventArgs e)
        {
            var userInviter = e.Args[1].ToString();
            _refusepartytimer.Reset();
            _refusepartytimer.Start();
            _refusetime = RandomNumber(3000, 8000);
            _gotPartyInvite = true;
            //ReSharper disable once ResourceItemNotResolved
            Log(_rm.GetString("Declining_party_invite_from", _ci), userInviter, _refusetime / 1000);
        }

        private void RotinaTradeInvites(object sender, LuaEventArgs e)
        {
            _refusetradetimer.Reset();
            _refusetradetimer.Start();
            _refusetime = RandomNumber(3000, 8000);
            _gotTradeinvite = true;
            //ReSharper disable once ResourceItemNotResolved
            Log(_rm.GetString("Declining_trade_in", _ci), _refusetime / 1000);
        }

        private void RotinaDuelInvites(object sender, LuaEventArgs e)
        {
            var userInviter = e.Args[1].ToString();
            _refusedueltimer.Reset();
            _refusedueltimer.Start();
            _refusetime = RandomNumber(3000, 8000);
            _gotDuelinvite = true;
            //ReSharper disable once ResourceItemNotResolved
            Log(_rm.GetString("Declining_duel_invite_from", _ci), userInviter, _refusetime / 1000);
        }

        private static void _Recomecar()
        {
            /* antiga forma
            * TreeRoot.Stop();
            * new Sleep(2000);
            * TreeRoot.Start();
            */
            TreeRoot.Stop();
            ProfileManager.LoadNew(PathToCavaProfiles + "Cava_Starter_Profiles.xml");
            new Sleep(2000); 
            TreeRoot.Start();
        }

        private static bool IsObjectiveComplete(int objectiveId, uint questId)
        {
            if (Me.QuestLog.GetQuestById(questId) == null)
            {
                return false;
            }
            var returnVal = Lua.GetReturnVal<int>(string.Format("return GetQuestLogIndexByID({0})", questId), 0);
            return
                Lua.GetReturnVal<bool>(string.Format("return GetQuestLogLeaderBoard({0},{1})", objectiveId, returnVal),
                    2);
        }

        private String NewCavaProfilePath
        {
            get
            {
                var directory = Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\";
                return (Path.Combine(directory, _profileName));
            }
        }

        private String _profileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            string.Format(@"Plugins\CavaPlugin\Settings\Main-Settings.xml"));

        private static IEnumerable<WoWUnit> CanLootMobs
        {
            get
            {
                return (ObjectManager.GetObjectsOfType<WoWUnit>(true, false)
                    .Where(target => (target.IsDead && target.Lootable)));
            }
        }

        private static void UseItem(WoWItem item)
        {
            item.Use();
        }

        private static void GetLoot()
        {
            if (LootFrame.Instance == null || !LootFrame.Instance.IsVisible || Me.BagsFull) return;
            LootFrame.Instance.LootAll();
        }

        #endregion


        #region Logging
        // ReSharper disable MemberCanBePrivate.Global
        public static void Log(string format, params object[] args)
        {
            Log(Colors.SkyBlue, format, args);
        }
        public static void Log(Color color, string format, params object[] args)
        {
            // ReSharper disable LocalizableElement
            Logging.Write(color, "[CavaPlugin]:" + format, args);
        }

        public void Debug(string format, params object[] args)
        {
            Debug(Colors.Teal, format, args);
        }
        public void Debug(Color color, string format, params object[] args)
        {
            Logging.Write(color, "[CavaPlugin]" + Version + ": " + format, args);
        }
 
        public static void Err(string format, params object[] args)
        {
            Err(Colors.Red, format, args);
        }
        public static void Err(Color color, string format, params object[] args)
        {
            Logging.Write(color, "Err: " + format, args);
            Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
            Player.Play();
            

        }
        // ReSharper restore LocalizableElement
        // ReSharper restore MemberCanBePrivate.Global

        #endregion
        
        #region Utils
        #endregion

        #region Privates/Publics
        private void AbreJanela()
        {
            if (_cavaupdated)
            {
                // ReSharper disable LocalizableElement
                MessageBox.Show("Cava Plugin/Quest Behaviors has been updated a restart is required.", "RESTART REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // ReSharper restore LocalizableElement
                Player.SoundLocation = PathToCavaPlugin + "Sounds\\notify.wav";
                Player.Play();
                Environment.Exit(0);
            }
            var mainCavaForm = new CavaForm();
            mainCavaForm.ShowDialog();
        }

        private static LocalPlayer Me { get { return StyxWoW.Me; } }
        #endregion

        #region Quests
        private static WoWObject ObjBarricadeHorde { get { return (ObjectManager.GetObjectsOfType<WoWGameObject>().FirstOrDefault(ret => ret.Entry == 215646 && ret.Distance < 10)); } }
        //private static List<WoWUnit> MobKingGennGreymane { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 36332)).OrderBy(ret => ret.Distance).ToList(); } }
        //private static List<WoWUnit> MobDocZapnozzle { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 36608)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobArctanus { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 34292)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobTidecrusher { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 38750 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobElectromental { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21729 && ret.IsAlive && !ret.HasAura(37136))).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobNetherWhelp { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 20021 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobProtoNetherDrake { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21821 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobAdolescentNetherDrake { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21817 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobMatureNetherDrake { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21820 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobKoiKoiSpirit { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 22226 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobWitheredCorpse { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 20561 && ret.Distance < 16 && ret.HasAura(31261))).OrderBy(ret => ret.Distance).ToList(); } }
        //private static List<WoWUnit> MobGlacierIce { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 49233 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobSauranokMystic { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 44120 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        //private static WoWItem ItemCelebrationPack { get { return (StyxWoW.Me.CarriedItems.FirstOrDefault(i => i.Entry == 90918)); } }
        //private static WoWItem ItemHs { get { return (StyxWoW.Me.CarriedItems.FirstOrDefault(i => i.Entry == 6948)); } }
        private static WoWItem ItemThisShiv { get { return (StyxWoW.Me.CarriedItems.FirstOrDefault(i => i.Entry == 55883)); } }
        #endregion

        #region Override Pulse
        public override void Pulse()
        {
            if (StyxWoW.Me.IsGhost && CPsettings.Instance.AntigankcheckBox)
            {
                if (LookForGankers())
                {
                    _waitgankercount++;
                    if (CPsettings.Instance.Playsonar)
                    {
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Sonar.wav";
                        Player.Play();
                    }
                    if (_waitgankercount == 20)
                    {
                        Log("[AntiGank]: Going to Ress at Spirit Healer");
                        Lua.DoString("RunMacroText('/click GhostFrame')");
                        _oldSh = LevelBot.ShouldUseSpiritHealer;
                        _gankedressatSh = true;
                        new Sleep(1000);
                        LevelBot.ShouldUseSpiritHealer = true;
                        if (!LevelBot.BehaviorFlags.HasFlag(BehaviorFlags.Death)){LevelBot.BehaviorFlags |= BehaviorFlags.Death;}
                        return;
                    }
                    new Sleep(30000);
                }
                else
                {
                    if (!LevelBot.BehaviorFlags.HasFlag(BehaviorFlags.Death)){LevelBot.BehaviorFlags |= BehaviorFlags.Death;}
                }
            }
            if (!Me.IsGhost && (_waitgankercount > 0 || _gankedressatSh))
            {
                _waitgankercount = 0;
                _gankedressatSh = false;
                LevelBot.ShouldUseSpiritHealer = _oldSh;
            }
            if (Me.IsDead && CPsettings.Instance.AntigankcheckBox)
                Addgankers();
            //AppDomain.CurrentDomain.SetData("Teste1","OI");
            //Environment.SetEnvironmentVariable("Teste1","OI",EnvironmentVariableTarget.Process);
            if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 300 by Cava" ||
                ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 600 by Cava")
            {
                //ReSharper disable once ResourceItemNotResolved
                Log(_rm.GetString("loading_profile", _ci), ProfileManager.CurrentOuterProfile.Name);
                new Sleep(3000);
                BotBase pbBotBase;
                BotManager.Instance.Bots.TryGetValue("ProfessionBuddy", out pbBotBase);
                if (pbBotBase != null && BotManager.Current != pbBotBase)
                {
                    System.Windows.Application.Current.Dispatcher.BeginInvoke(
                        new Action(
                            () =>
                            {
                                TreeRoot.Stop();
                                BotManager.Instance.SetCurrent(pbBotBase);
                                new Sleep(2000);
                                if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 600 by Cava") { _profileName = "Prof\\MB\\[PB]MB(Cava).xml"; }
                                if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 300 by Cava") { _profileName = "Prof\\MB\\Free[PB]MB(Cava).xml"; }
                                ProfileManager.LoadNew(NewCavaProfilePath, false);
                                TreeRoot.Start();
                            }));
                }
                else
                {
                    if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 600 by Cava")
                    {
                        ProfileManager.LoadNew(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\Prof\MB\[PB]MB(Cava).xml", false);
                    }
                    if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 300 by Cava")
                    {
                        ProfileManager.LoadNew(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\Prof\MB\Free[PB]MB(Cava).xml", false);
                    }
                }
            }

            if (CPsettings.Instance.AntigankcheckBox && _antigankertimeTimer.ElapsedMilliseconds >= 60000)
            {
                _antigankertimeTimer.Restart();
                Delgankers();
                //Checkgankers();
            }
            if (Me.IsDead && !Me.HasAura(8326) && CPsettings.Instance.RessAfterDie)
            {
                new Sleep(5000);
                //ReSharper disable once ResourceItemNotResolved
                Log(_rm.GetString("Anti_Bug_Release_System", _ci));
                Lua.DoString("RunMacroText('/click StaticPopup1Button1')");
                Lua.DoString(string.Format("RunMacroText(\"{0}\")", "/script RepopMe()"));
            }
            if (_botRunning)
            {
                //if ()// && Me.CurrentTarget.IsFlightMaster) && Me.Mounted) && CPsettings.Instance.FixMountFlightVendor)
                if(TaxiFrame.Instance.IsVisible && Me.Mounted && CPsettings.Instance.FixMountFlightVendor)
                {
                    Log("Anti-Bug Flight Master Dismounting");
                    WoWMovement.MoveStop();
                    Lua.DoString("Dismount()");
                    Lua.DoString("RunMacroText('/cancelaura cat form\n/cancelaura bear form\n/cancelaura travel form\n/cancelaura ghost wolf\n/cancelaura Flight Form')");
                    // ReSharper disable once ObjectCreationAsStatement
                    new Mount.ActionLandAndDismount();
                }

                if (Me.Combat && !Me.IsCasting && CPsettings.Instance.CombatLoot)
                {
                    GetLoot();
                    var lootthis = CanLootMobs.FirstOrDefault();
                    /*if (lootthis != null && lootthis.Distance > lootthis.InteractRange && lootthis.Distance < 10)
                    {
                        //ReSharper disable once ResourceItemNotResolved
                        Log(_rm.GetString("CombatLoot_Moving_to_loot", _ci), lootthis.Name);
                        Navigator.MoveTo(lootthis.Location);
                    }*/
                    if (lootthis != null && lootthis.Distance <= lootthis.InteractRange)
                    {
                        // ReSharper disable once ResourceItemNotResolved
                        Log(_rm.GetString("CombatLoot_Looting", _ci), lootthis.Name);
                        lootthis.Interact();
                    }
                }
                if (CPsettings.Instance.OpenBox && _checkBags.ElapsedMilliseconds >= 600000 &&
                    !Me.Combat && !Me.IsDead && !Me.IsGhost && !Me.Mounted && !Me.IsCasting &&
                    !Me.HasAura("Food") && !Me.HasAura("Drink") && !Me.InVehicle && !Me.HasAura(1784) &&
                    !Me.HasAura(15215))
                {
                    // ReSharper disable once ResourceItemNotResolved
                    Log(_rm.GetString("OpenBoxs_Check_Started_at", _ci),
                        DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    WoWMovement.MoveStop();
                    foreach (
                        var item in
                            ObjectManager.GetObjectsOfType<WoWItem>()
                                .Where(item => item != null && item.BagSlot != -1 && _boxList.Contains(item.Entry))
                                .Where(item => StyxWoW.Me.FreeNormalBagSlots >= 2 && SpellManager.HasSpell(1804)))
                    {
                        // ReSharper disable once ResourceItemNotResolved
                        Log(_rm.GetString("OpenBoxs_Opening", _ci), item);
                        WoWMovement.MoveStop();
                        if (!item.IsOpenable)
                        {
                            SpellManager.Cast(1804);
                            UseItem(item);
                            new Sleep(6000);
                        }
                        UseItem(item);
                        GetLoot();
                    }
                    _checkBags.Restart();
                    // ReSharper disable once ResourceItemNotResolved
                    Log(_rm.GetString("OpenBoxs_Check_Finished_at", _ci),
                        DateTime.Now.ToString(CultureInfo.InvariantCulture));
                }

                if (_gotGuildInvite && _refuseguildtimer.ElapsedMilliseconds >= _refusetime)
                {
                    Lua.DoString("DeclineGuild()");
                    //Lua.DoString("StaticPopup_Hide(\"GUILD_INVITE\")");
                    Lua.DoString("RunMacroText('/click GuildInviteFrameDeclineButton')");
                    _gotGuildInvite = false;
                }

                if (_gotPartyInvite && _refusepartytimer.ElapsedMilliseconds >= _refusetime)
                {
                    Lua.DoString("DeclineGroup()");
                    Lua.DoString("StaticPopup_Hide(\"PARTY_INVITE\")");
                    _gotPartyInvite = false;
                }

                if (_gotTradeinvite && _refusetradetimer.ElapsedMilliseconds >= _refusetime)
                {
                    Lua.DoString("CancelTrade()");
                    _gotTradeinvite = false;
                }

                if (_gotDuelinvite && _refusedueltimer.ElapsedMilliseconds >= _refusetime)
                {
                    Lua.DoString("CancelDuel()");
                    Lua.DoString("StaticPopup_Hide(\"DUEL_REQUESTED\")");
                    _gotDuelinvite = false;
                }
                //Elapsed.TotalMinutes
                if (CPsettings.Instance.CheckAllowSummonPet && _summonpettime.Elapsed.Minutes > 30)
                {
                    // ReSharper disable once ResourceItemNotResolved
                    Log(_rm.GetString("Summoning_Random_pet", _ci));
                    Lua.DoString("RunMacroText('/randompet')");
                    _summonpettime.Restart();
                }

                /*if (Me.Race == WoWRace.Goblin && Me.HasAura("Near Death!") && Me.ZoneId == 4720 &&
                    MobDocZapnozzle.Count > 0)
                {
                    MobDocZapnozzle[0].Interact();
                    new Sleep(1000);
                    Lua.DoString("RunMacroText('/click QuestFrameCompleteQuestButton')");
                }
                if (Me.Race == WoWRace.Worgen && Me.HasAura(68631) && Me.ZoneId == 4714 && MobKingGennGreymane.Count > 0)
                {
                    MobKingGennGreymane[0].Interact();
                    new Sleep(1000);
                    Lua.DoString("RunMacroText('/click QuestFrameCompleteQuestButton')");
                }
                 * */
                if (Me.QuestLog.GetQuestById(13884) != null && !Me.QuestLog.GetQuestById(13884).IsCompleted &&
                    !Me.HasAura(65178) && MobArctanus.Count > 0)
                {
                    MobArctanus[0].Interact();
                    new Sleep(1000);
                }
                if (Me.QuestLog.GetQuestById(24950) != null && !Me.QuestLog.GetQuestById(24950).IsCompleted &&
                    MobTidecrusher.Count > 0)
                {
                    MobTidecrusher[0].Interact();
                    MobTidecrusher[0].Face();
                    RoutineManager.Current.Pull();
                }
                if (Me.QuestLog.GetQuestById(10584) != null && !Me.QuestLog.GetQuestById(10584).IsCompleted &&
                    MobElectromental.Count > 0)
                {
                    MobElectromental[0].Interact();
                    MobElectromental[0].Face();
                    Lua.DoString("UseItemByName(30656)");
                    new Sleep(4000);
                }
                if (Me.QuestLog.GetQuestById(10609) != null && !Me.QuestLog.GetQuestById(10609).IsCompleted &&
                    MobNetherWhelp.Count > 0)
                {
                    MobNetherWhelp[0].Interact();
                    MobNetherWhelp[0].Face();
                    Lua.DoString("UseItemByName(30742)");
                    new Sleep(4000);
                }
                if (Me.QuestLog.GetQuestById(10609) != null && !Me.QuestLog.GetQuestById(10609).IsCompleted &&
                    IsObjectiveComplete(1, 10609) && MobProtoNetherDrake.Count > 0)
                {
                    MobProtoNetherDrake[0].Interact();
                    MobProtoNetherDrake[0].Face();
                    Lua.DoString("UseItemByName(30742)");
                    new Sleep(4000);
                }
                if (Me.QuestLog.GetQuestById(10609) != null && !Me.QuestLog.GetQuestById(10609).IsCompleted &&
                    IsObjectiveComplete(2, 10609) && MobAdolescentNetherDrake.Count > 0)
                {
                    MobAdolescentNetherDrake[0].Interact();
                    MobAdolescentNetherDrake[0].Face();
                    Lua.DoString("UseItemByName(30742)");
                    new Sleep(4000);
                }
                if (Me.QuestLog.GetQuestById(10609) != null && !Me.QuestLog.GetQuestById(10609).IsCompleted &&
                    IsObjectiveComplete(3, 10609) && MobMatureNetherDrake.Count > 0)
                {
                    MobMatureNetherDrake[0].Interact();
                    MobMatureNetherDrake[0].Face();
                    Lua.DoString("UseItemByName(30742)");
                    new Sleep(4000);
                }
                if (Me.QuestLog.GetQuestById(10830) != null && !Me.QuestLog.GetQuestById(10830).IsCompleted &&
                    MobKoiKoiSpirit.Count > 0)
                {
                    MobKoiKoiSpirit[0].Interact();
                    MobKoiKoiSpirit[0].Face();
                    RoutineManager.Current.Pull();
                }
                if (Me.QuestLog.GetQuestById(10345) != null && !Me.Combat && MobWitheredCorpse.Count > 0)
                {
                    WoWMovement.MoveStop();
                    Lua.DoString("UseItemByName(29473)");
                    new Sleep(500);
                }
                /*
                if (Me.QuestLog.GetQuestById(28632) != null && !Me.QuestLog.GetQuestById(28632).IsCompleted &&
                    !Me.Combat && MobGlacierIce.Count > 0)
                {
                    MobGlacierIce[0].Interact();
                }
                */
                if (Me.QuestLog.GetQuestById(11794) != null && Me.QuestLog.GetQuestById(11794).IsCompleted && !Me.Combat &&
                    !Me.HasAura(46078))
                {
                    WoWMovement.MoveStop();
                    Lua.DoString("UseItemByName(35125)");
                    new Sleep(500);
                }
                if (Me.QuestLog.GetQuestById(26830) != null && !Me.QuestLog.GetQuestById(26830).IsCompleted &&
                    MobSauranokMystic.Count > 0)
                {
                    if (MobSauranokMystic[0].HasAura(82548) && Me.CurrentTarget != null &&
                        Me.CurrentTarget.Entry == 44120)
                        Blacklist.Add(Me.CurrentTarget, BlacklistFlags.Combat, TimeSpan.FromSeconds(180000));
                    if (MobSauranokMystic[0].Location.Distance(Me.Location) > 4 && MobSauranokMystic[0].HasAura(82531))
                    {
                        Navigator.MoveTo(MobSauranokMystic[0].Location);
                    }
                    if (MobSauranokMystic[0].Location.Distance(Me.Location) <= 4 && MobSauranokMystic[0].HasAura(82531))
                    {
                        Blacklist.Add(Me.CurrentTarget, BlacklistFlags.Combat, TimeSpan.FromSeconds(1));
                        new Sleep(10);
                        WoWMovement.MoveStop();
                        MobSauranokMystic[0].Target();
                        MobSauranokMystic[0].Face();
                        MobSauranokMystic[0].Interact();
                        CavaAtackMob();
                    }
                }

                if (Me.QuestLog.GetQuestById(31769) != null && !Me.QuestLog.GetQuestById(31769).IsCompleted && ObjBarricadeHorde != null)
                {
                    WoWMovement.MoveStop();
                    Lua.DoString("UseItemByName(89769)");
                    new Sleep(500);
                }
                if (Me.ZoneId == 616 && Me.CurrentTarget != null && Me.CurrentTarget.Entry == 41031)
                {
                    if (ItemThisShiv != null)
                    {
                        if(Me.CurrentTarget.Distance < 6)
                        {
                            WoWMovement.MoveStop();
                            Lua.DoString("UseItemByName(55883)");
                            new Sleep(500);
                        }
                    }
                    else
                    {
                         Blacklist.Add(Me.CurrentTarget, BlacklistFlags.Combat, TimeSpan.FromSeconds(120));
                    }
                }
                /*if (Me.IsAlive && !Me.HasAura(132700) && !Me.IsOnTransport && !Me.OnTaxi && !Me.Mounted && !Me.IsCasting && !Me.Combat && ItemCelebrationPack != null)
                {
                    Log("Using Celebration Package 9Th Aniversary at " + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    WoWMovement.MoveStop();
                    Lua.DoString("UseItemByName(90918)");
                    new Sleep(500);
                }
                 * */

                if (Me.IsAlive && Me.QuestLog.GetQuestById(28195) != null && !Me.QuestLog.GetQuestById(28195).IsCompleted)
                {
                    if (Me.Combat && Me.Mounted)
                    {
                        WoWMovement.MoveStop();
                        Lua.DoString("Dismount()");
                        if (Me.Class == WoWClass.Druid)
                        {
                            Lua.DoString("RunMacroText('/cancelaura Flight Form')");
                        }
                        // ReSharper disable once ObjectCreationAsStatement
                        new Mount.ActionLandAndDismount();
                    }
                    if (!Me.Combat && !CanLootMobs.Any())
                    {
                        if (Me.Location.Distance(new WoWPoint(-10710.21, 1060.979, 24.15302 )) < 15)
                        {
                            Flightor.MoveTo(new WoWPoint(-10710.26, 1061.079, 48.51095));
                        }

                        if (!IsObjectiveComplete(1, 28195))
                        {
                            Flightor.MoveTo(Me.Location.Distance(new WoWPoint(-10819.5, 1059.74, 17.47325)) > 30
                                ? new WoWPoint(-10815.69, 1081.764, 28.12389)
                                : new WoWPoint(-10819.95, 1061.831, 18.97991));
                        }
                        if (IsObjectiveComplete(1, 28195) && Me.Location.Distance(new WoWPoint(-10819.5, 1059.74, 17.47319)) < 20)
                        {
                            Flightor.MoveTo(new WoWPoint(-10846.06, 1100.449, 53.8331));
                        }
                        if (IsObjectiveComplete(1, 28195) && !IsObjectiveComplete(2, 28195) && Me.Location.Distance(new WoWPoint(-10819.5, 1059.74, 17.47319)) >= 20)
                        {
                            Flightor.MoveTo(Me.Location.Distance(new WoWPoint(-10877.22, 900.5729, 18.14129)) > 30
                                ? new WoWPoint(-10899.52, 907.2244, 27.23195)
                                : new WoWPoint(-10878.68, 901.9725, 18.79003));
                        }
                        if (IsObjectiveComplete(2, 28195) && Me.Location.Distance(new WoWPoint(-10877.22, 900.5729, 18.14095)) < 20)
                        {
                            Flightor.MoveTo(new WoWPoint(-10920.83, 875.5263, 50.85601));
                        }
                        if (IsObjectiveComplete(1, 28195) && IsObjectiveComplete(2, 28195) && !IsObjectiveComplete(3, 28195) && Me.Location.Distance(new WoWPoint(-10877.22, 900.5729, 18.14095)) >= 20)
                        {
                            Flightor.MoveTo(Me.Location.Distance(new WoWPoint(-10863.17, 826.0938,18.51666)) > 30
                                ? new WoWPoint(-10878.99, 826.2751,38.5662)
                                : new WoWPoint(-10864.82, 825.9705, 19.37853));
                        }
                    }
                }
                /*
                if ((Me.IsAlive && (Me.QuestLog.GetQuestById(28276) != null) && Me.ZoneId == 5034) ||
                    (Me.IsAlive && (Me.QuestLog.GetQuestById(28277) != null) && Me.ZoneId == 5034))
                {
                    if (Me.InVehicle)
                    {
                        return;
                    }
                    if ((Me.Location.Distance(new WoWPoint(-10606.8, -1083.83, 155.2219)) > 6) || (Me.Z < 155))
                    {
                        //5 segundos de pausa, se mantiver reseta tudo
                        new Sleep(5000);
                        if ((Me.Location.Distance(new WoWPoint(-10606.8, -1083.83, 155.2219)) > 6) || (Me.Z < 155))
                        {
                            //_movetoplace = 0;
                            Flightor.MoveTo(new WoWPoint(-10605.52, -1086.751, 169));
                            if (Me.Location.Distance(new WoWPoint(-10605.52, -1086.751, 169)) < 2)
                            {
                                WoWMovement.MoveStop();
                                Lua.DoString("Dismount()");
                                if (Me.Class == WoWClass.Druid)
                                {
                                    Lua.DoString("RunMacroText('/cancelaura Flight Form')");
                                }
                                WoWMovement.MoveStop();
                            }
                        }
                    }
                    if ((Me.Location.Distance(new WoWPoint(-10606.8, -1083.83, 155.2219)) > 6 && _movetoplace == 0) || (Me.Z < 155 && _movetoplace == 0))
                    {
                        Flightor.MoveTo(new WoWPoint(-10605.52, -1086.751, 174));
                    }
                    if (Me.Location.Distance(new WoWPoint(-10605.52, -1086.751, 174)) < 3 && _movetoplace == 0)
                    {
                        _movetoplace=1;
                    }
                    if (_movetoplace == 1)
                    {
                        Flightor.MoveTo(new WoWPoint(-10605.52, -1086.751, 164));
                    }
                    if (Me.Location.Distance(new WoWPoint(-10605.52, -1086.751, 164)) < 3 && _movetoplace == 1)
                    {
                        _movetoplace=2;
                    }
                    if (_movetoplace == 2)
                    {
                        WoWMovement.MoveStop();
                        Lua.DoString("Dismount()");
                        WoWMovement.MoveStop();
                    }
                    if (ObjectManager.GetObjectsOfType<WoWUnit>().Any(ret => ret.Entry == 48237 && ret.Distance < 4 ) && _movetoplace==2)
                    {
                        _movetoplace = 3;
                    }
                }
                */
                /*
                 * if (_vendorMountSpellId != 0 && CPsettings.Instance.FixSummonMountVendor && Me.IsAlive && !Me.Combat)
                {
                    if (Me.Mounted)
                    {
                        //VendorMountSpellId = 0;
                        if (StyxWoW.Me.HasAura(WoWSpell.FromId(_vendorMountSpellId).Name))
                        {
                            Log("[antistuck]-Summon Mound Vendor Finished");
                            _vendorMountSpellId = 0;
                        }
                        else
                            Mount.Dismount();
                    }
                    else
                    {
                        WoWMovement.MoveStop();
                        WoWSpell.FromId(_vendorMountSpellId).Cast();
                        new Sleep(6000);
                        if (!Me.Mounted)
                        {
                            //need mov
                            var randtogo = RandomNumber(1, 4);
                            switch (randtogo)
                            {
                                case 1:
                                    WoWMovement.Move(WoWMovement.MovementDirection.Forward);
                                    break;
                                case 2:
                                    WoWMovement.Move(WoWMovement.MovementDirection.Backwards);
                                    break;
                                case 3:
                                    WoWMovement.Move(WoWMovement.MovementDirection.StrafeLeft);
                                    break;
                                default:
                                    WoWMovement.Move(WoWMovement.MovementDirection.StrafeRight);
                                    break;
                            }
                            new Sleep(2000);
                            WoWMovement.MoveStop();
                        }
                    }
                }*/

                if (CPsettings.Instance.AntiStuckSystem )
                {
                    if (_asLastSavedPosition.Distance(Me.Location) > 35)
                    {
                        _asLastSavedPosition = Me.Location;
                        _asLastSavedTimer.Restart();
                        _asLastSavedPositionTrigger = false;
                    }
                    if (!Me.Mounted || Me.OnTaxi)
                    {
                        _mountedTime.Restart();
                    }

                    if (_asLastSavedTimer.ElapsedMilliseconds > 6000 && _mountedTime.ElapsedMilliseconds > 30000 && BotPoi.Current.Location.DistanceSqr(Me.Location) > 10 && !_asLastSavedPositionTrigger)
                    {  //movimento menor que 35 nos ultimos 6 segundos, mounted mais de 30 segundos,a mais de 10 do objectivo
                        // ReSharper disable once ResourceItemNotResolved
                        Log(_rm.GetString("AntiStuck_Char_is_Mounted_for_more_than_6_secs_and_stuck", _ci), DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        // ReSharper disable once ObjectCreationAsStatement
                        new Mount.ActionLandAndDismount();
                        new Sleep(2000);
                        Lua.DoString("Dismount()");
                        if (Me.Class == WoWClass.Druid)
                        {
                            Lua.DoString("RunMacroText('/cancelaura Flight Form')");
                        }
                        _mountedTime.Restart();
                        _asLastSavedPositionTrigger = true;
                    }
                    if (Me.IsAlive && Me.Mounted && !Me.OnTaxi && _mountedTime.ElapsedMilliseconds > 600000)
                    {
                        // ReSharper disable once ResourceItemNotResolved
                        Log(_rm.GetString("AntiStuck_Char_is_Mounted_for_more_than_10_min", _ci), DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        // ReSharper disable once ObjectCreationAsStatement
                        new Mount.ActionLandAndDismount();
                        new Sleep(2000);
                        Lua.DoString("Dismount()");
                        if (Me.Class == WoWClass.Druid)
                        {
                            Lua.DoString("RunMacroText('/cancelaura Flight Form')");
                        }

                        _mountedTime.Restart();
                    }
                    if (!TreeRoot.IsRunning && _ultimoSemStuck.ElapsedMilliseconds > 30000)
                    {
                        Logging.Write(@"[CavaPlugin-AntiStuck] LastPosition reseted, bot is not running (but pulse is called ???)");
                        _ultimoSemStuck.Restart();
                        return;
                    }
                    if (_ultimoLocal.Distance(Me.Location) > 10f)
                    {
                        _ultimoSemStuck.Restart();
                        _ultimoLocal = Me.Location;
                        _nVezesBotUnstuck = 0;
                        return;
                    }
                    if (Me.IsAlive && Me.IsAFKFlagged && !Me.IsCasting && !Me.IsMoving && !Me.Combat && !Me.OnTaxi && _nVezesBotUnstuck == 0)
                    {
                        // ReSharper disable once ResourceItemNotResolved
                        Log(_rm.GetString("AntiStuck_Im_AFK_flagged_Anti_Afking_at", _ci), DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        WoWMovement.Move(WoWMovement.MovementDirection.JumpAscend, TimeSpan.FromMilliseconds(100));
                        new Sleep(2000);
                        KeyboardManager.KeyUpDown((char)KeyboardManager.eVirtualKeyMessages.VK_SPACE);
                        new Sleep(2000);
                        KeyboardManager.AntiAfk();
                        new Sleep(2000);
                        // ReSharper disable once ObjectCreationAsStatement
                        new Mount.ActionLandAndDismount();
                        new Sleep(2000);
                        Lua.DoString("Dismount()");
                        if (Me.Class == WoWClass.Druid)
                        {
                            Lua.DoString("RunMacroText('/cancelaura Flight Form')");
                        }
                        new Sleep(2000);
                        StyxWoW.ResetAfk();
                        _nVezesBotUnstuck++;
                    }
                    if (AuctionFrame.Instance.IsVisible || MailFrame.Instance.IsVisible)
                    {
                        _ultimoSemStuck.Restart();
                        _ultimoLocal = Me.Location;
                        return;
                    }
                    if (Me.HasAura("Resurrection Sickness"))
                    {
                        _ultimoSemStuck.Restart();
                        return;
                    }
                    if (_ultimoSemStuck.ElapsedMilliseconds > 300000 && _nVezesBotUnstuck == 0)
                    {
                        // ReSharper disable once ResourceItemNotResolved
                        Log(_rm.GetString("AntiStuck_not_moving_last_5_min", _ci), DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        // ReSharper disable once ObjectCreationAsStatement
                        new Mount.ActionLandAndDismount();
                        new Sleep(2000);
                        Lua.DoString("Dismount()");
                        if (Me.Class == WoWClass.Druid)
                        {
                            Lua.DoString("RunMacroText('/cancelaura Flight Form')");
                        }
                        _nVezesBotUnstuck++;
                    }
                    if (_ultimoSemStuck.ElapsedMilliseconds > 600000 && _nVezesBotUnstuck == 1)
                    {
                        // ReSharper disable once ResourceItemNotResolved
                        Log(_rm.GetString("AntiStuck_not_moving_last_10_min", _ci), DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        if (_recomecar.ThreadState == ThreadState.Running) _recomecar.Abort();
                        _recomecar.Start();
                        _nVezesBotUnstuck++;
                    }
                    if (_ultimoSemStuck.ElapsedMilliseconds > 900000 && Me.ZoneId != 1519 && Me.ZoneId != 1637)
                    {
                        // ReSharper disable once ResourceItemNotResolved
                        Log(_rm.GetString("AntiStuck_not_moving_last_10_min", _ci), DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        Lua.DoString(@"ForceQuit()");
                    }
                  }
            }
        }
        #endregion
    }
}
