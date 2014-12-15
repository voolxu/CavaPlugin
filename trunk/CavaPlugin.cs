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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.CommonBot.Frames;
using Styx.CommonBot.POI;
using Styx.CommonBot.Profiles;
using Styx.CommonBot.Routines;
using Styx.Helpers;
using Styx.Pathing;
using Styx.Plugins;
using Styx.TreeSharp;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using Application = System.Windows.Application;
using Color = System.Drawing.Color;
using MessageBox = System.Windows.Forms.MessageBox;
using RichTextBox = System.Windows.Controls.RichTextBox;
using ThreadState = System.Threading.ThreadState;


namespace CavaPlugin
{
    public class CPsettings : Settings
    {
        public static readonly CPsettings Instance = new CPsettings();
        public CPsettings()
            : base(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"Settings\CavaPlugin\{0}\{1}.xml", Lua.GetReturnVal<string>("return GetRealmName()", 0), StyxWoW.Me.Name)))
        {
        }
        [Setting, DefaultValue(0)]
        public int LastUsedPath { get; set; }
        [Setting, DefaultValue(false)]
        public bool AntiStuckSystem { get; set; }
        [Setting, DefaultValue(false)]
        public bool CheckAllowSummonPet { get; set; }
        [Setting, DefaultValue(false)]
        public bool GuildInvitescheck { get; set; }
        [Setting, DefaultValue(false)]
        public bool refuseguildInvitescheck { get; set; }
        [Setting, DefaultValue(false)]
        public bool RefusepartyInvitescheck { get; set; }
        [Setting, DefaultValue(false)]
        public bool RefusetradeInvitescheck { get; set; }
        [Setting, DefaultValue(false)]
        public bool RefuseduelInvitescheck { get; set; }
        [Setting, DefaultValue(false)]
        public bool RessAfterDie { get; set; }
        [Setting, DefaultValue(false)]
        public bool CombatLoot { get; set; }
        [Setting, DefaultValue(false)]
        public bool OpenBox { get; set; }
        [Setting, DefaultValue(false)]
        public bool FixMountFlightVendor { get; set; }
        [Setting, DefaultValue(false)]
        public bool BlacklistflycheckBox { get; set; }
        [Setting, DefaultValue(false)]
        public bool AntigankcheckBox { get; set; }
        [Setting, DefaultValue(false)]
        public bool Playsonar { get; set; }
        [Setting, DefaultValue(false)]
        public bool Learnportal1 { get; set; }
        [Setting, DefaultValue(false)]
        public bool Learnportal2 { get; set; }
        [Setting, DefaultValue(false)]
        public bool Learnportal3 { get; set; }
        [Setting, DefaultValue(false)]
        public bool Learnportal4 { get; set; }
        [Setting, DefaultValue(false)]
        public bool Learnportal5 { get; set; }
        [Setting, DefaultValue(false)]
        public bool Learnportal6 { get; set; }
        [Setting, DefaultValue("null")]
        public string FriendoftheExarchs { get; set; }
        [Setting, DefaultValue("null")]
        public string GorgondOutpost { get; set; }
    }

    public class CPGlobalSettings : Settings
    {
        public static readonly CPGlobalSettings Instance = new CPGlobalSettings();
        public CPGlobalSettings()
            : base(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"Settings\CavaPlugin\Main-Settings.xml")))
        {
        }
        [Setting, DefaultValue(false)]
        public bool BotAllowUpdate { get; set; }
        [Setting, DefaultValue(false)]
        public bool AllowUpdate { get; set; }
        [Setting, DefaultValue(false)]
        public bool Allowlunch { get; set; }
        [Setting, DefaultValue(0)]
        public int BaseProfileToLunch { get; set; }
        [Setting, DefaultValue(false)]
        public bool AutoShutdownWhenUpdate { get; set; }
        [Setting, DefaultValue(false)]
        public bool PBMiningBlacksmithing { get; set; }
        [Setting, DefaultValue(false)]
        public bool BotPBMiningBlacksmithing { get; set; }
        [Setting, DefaultValue(0)]
        public int language { get; set; }
        [Setting, DefaultValue(false)]
        public bool Languageselected { get; set; }
        [Setting, DefaultValue("")]
        public string CpLogin { get; set; }
        [Setting, DefaultValue("")]
        public string CpPassword { get; set; }
        [Setting, DefaultValue(false)]
        public bool CpPanelBack { get; set; }
        [Setting, DefaultValue(false)]
        public bool ArmaPanelBack { get; set; }
        [Setting, DefaultValue(false)]
        public bool ProfMinBlack600 { get; set; }
        [Setting, DefaultValue(0)]
        public int UseServer { get; set; }
        [Setting, DefaultValue(true)]
        public bool DisablePlugin { get; set; }
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    public class CavaPluginLog
    {
        private static RichTextBox _rtbLog;
        private static string _normalLogHeader;
        private static string NormalHeader
        {
            get { return _normalLogHeader ?? (_normalLogHeader = string.Format("CavaPlugin V-{0}: ", CavaPlugin._version.ToString().Remove(0, 2))); }
        }
        public static void Warn(string msg)
        {
            LogInvoker(LogLevel.Verbose, Colors.DodgerBlue, "CavaPlugin Warning: ", Colors.DarkOrange, msg);
        }
        public static void Warn(string format, params object[] args)
        {
            Warn(string.Format(format, args));
        }
        public static void Fatal(string msg)
        {
            LogInvoker(LogLevel.Verbose, Colors.DodgerBlue, "CavaPlugin Fatal: ", Colors.Red, msg);
            TreeRoot.Stop();
        }
        public static void Fatal(string format, params object[] args)
        {
            Fatal(string.Format(format, args));
            TreeRoot.Stop();
        }
        public static void Debug(string msg)
        {
            LogInvoker(LogLevel.Diagnostic, Colors.DodgerBlue, NormalHeader, Colors.LimeGreen, msg);
        }
        public static void Debug(string format, params object[] args)
        {
            Debug(string.Format(format, args));
        }
        public static void Log(string msg)
        {
            LogInvoker(LogLevel.Normal, Colors.DodgerBlue, NormalHeader, Colors.LightSteelBlue, msg);
        }
        public static void Log(string format, params object[] args)
        {
            Log(string.Format(format, args));
        }
        public static void Log(Color headerColor, string header, Color msgColor, string format, params object[] args)
        {
            LogInvoker(
                LogLevel.Normal,
                System.Windows.Media.Color.FromArgb(headerColor.A, headerColor.R, headerColor.G, headerColor.B),
                header,
                System.Windows.Media.Color.FromArgb(msgColor.A, msgColor.R, msgColor.G, msgColor.B),
                string.Format(format, args));
        }
        public static void Log(
            System.Windows.Media.Color headerColor,
            string header,
            System.Windows.Media.Color msgColor,
            string format,
            params object[] args)
        {
            LogInvoker(LogLevel.Normal, headerColor, header, msgColor, string.Format(format, args));
        }

        public static void Log(
            LogLevel logLevel,
            System.Windows.Media.Color headerColor,
            string header,
            System.Windows.Media.Color msgColor,
            string format,
            params object[] args)
        {
            LogInvoker(logLevel, headerColor, header, msgColor, string.Format(format, args));
        }

        private static void LogInvoker(
            LogLevel level,
            System.Windows.Media.Color headerColor,
            string header,
            System.Windows.Media.Color msgColor,
            string msg)
        {
            if (Application.Current.Dispatcher.Thread == Thread.CurrentThread)
                LogInternal(level, headerColor, header, msgColor, msg);
            else
                Application.Current.Dispatcher.BeginInvoke(
                    new LogDelegate(LogInternal),
                    level,
                    headerColor,
                    header,
                    msgColor,
                    msg);
        }
        private static void LogInternal(
            LogLevel level,
            System.Windows.Media.Color headerColor,
            string header,
            System.Windows.Media.Color msgColor,
            string msg)
        {
            if (level == LogLevel.None)
                return;
            try
            {
                if (GlobalSettings.Instance.LogLevel >= level)
                {
                    if (_rtbLog == null)
                        _rtbLog = (RichTextBox)Application.Current.MainWindow.FindName("rtbLog");
                    var para = (Paragraph)_rtbLog.Document.Blocks.FirstBlock;
                    para.Inlines.Add(new Run(header) { Foreground = new SolidColorBrush(headerColor) });
                    para.Inlines.Add(new Run(msg + Environment.NewLine) { Foreground = new SolidColorBrush(msgColor) });
                    _rtbLog.ScrollToEnd();
                }
                try
                {
                    char abbr;
                    switch (level)
                    {
                        case LogLevel.Normal:
                            abbr = 'N';
                            break;
                        case LogLevel.Quiet:
                            abbr = 'Q';
                            break;
                        case LogLevel.Diagnostic:
                            abbr = 'D';
                            break;
                        case LogLevel.Verbose:
                            abbr = 'V';
                            break;
                        default:
                            abbr = 'N';
                            break;
                    }
                    string logMsg = string.Format(
                        "[{0} {4}]{1}{2}{3}",
                        DateTime.Now.ToString("HH:mm:ss.fff"),
                        header,
                        msg,
                        Environment.NewLine,
                        abbr);
                    File.AppendAllText(Logging.LogFilePath, logMsg);
                }
                catch { }
            }
            catch
            {
                Logging.Write(header + msg);
            }
        }

        private delegate void LogDelegate(
            LogLevel level,
            System.Windows.Media.Color headerColor,
            string header,
            System.Windows.Media.Color msgColor,
            string msg);
    }

    public class PrimumBotRevBase
    {
        public static int Revision
        {
            get
            {
                var verFile = new StreamReader(CavaPlugin.PathToCavaPlugin + "Plugin.ver");
                var verString = verFile.ReadToEnd();
                verFile.Close();
                try
                {
                    return int.Parse(verString.Replace("$Revision: ", "").Replace(" $", ""));
                }
                catch
                {
                    return 0;
                }
            }
        }
    }

    public class PrimumBotRev : PrimumBotRevBase
    {
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    internal class CavaPluginUpdater
    {
        private static WebClient _client;
        private static int _newestRev;

        public static void WriteNewRevFile(string verfilename, string revvalue)
        {
            var file = new StreamWriter(@"" + CavaPlugin.PathToCavaPlugin + verfilename);
            file.Write("$Revision: " + revvalue + " $");
            file.Close();
        }

        public static bool UpdateAvailable(string url, string namever)
        {
            return (GetNewestRev(url) > GetCurrentRev(namever));
        }

        public static int GetNewestRev(string url)
        {
            _client = new WebClient();
            var html = _client.DownloadString(url);
            var revisionMatch = Regex.Match(html, @"Revision ([A-Za-z0-9\-.]+):");
            if (revisionMatch.Success)
            {
                _newestRev = int.Parse(revisionMatch.Groups[1].Value);
                return _newestRev;
            }
            return 0;
        }

        public static int GetCurrentRev(string namever)
        {
            var verFile = new StreamReader(CavaPlugin.PathToCavaPlugin + namever);
            var verString = verFile.ReadToEnd();
            verFile.Close();
            try
            {
                var currentRev = int.Parse(verString.Replace("$Revision: ", "").Replace(" $", ""));
                return currentRev;
            }
            catch
            {
                return 0;
            }
        }
    }
    
    public class CavaPlugin : HBPlugin
    {
        #region privat vars.
        private bool _botRunning;
        private bool _hasBeenInitialized;
        private bool _hasBeenInitialized2;
        private bool _hasBeenInitialized3;
        public static int UseServer; 
        public static int LastUseProfile;//=0;
        public static bool IsRegisteredUser;
        public static bool IsArmageddonerUser;// = false;
        public static bool HaveMiningBlacksmithingAccess;// = false;
        public static bool RunPrimumBotPulse = CPGlobalSettings.Instance.DisablePlugin;
        public static bool Canceled;
        private static LocalPlayer Me { get { return StyxWoW.Me; } }
        public static readonly string BotPath = GetCavaPluginPath();
        //public static readonly string PathToCavaProfiles2 = Path.Combine(BotPath, "Default Profiles\\Cava\\");
        //public static readonly string PathToCavaPlugin2 = Path.Combine(BotPath, "Plugins\\CavaPlugin\\");
        public static readonly string SoundPath = Path.Combine(BotPath, "Sounds\\");
        public static readonly string ImagePath = Path.Combine(BotPath, "Pngs\\");

        public static readonly string PathToCavaProfiles = Path.Combine(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\");
        public static readonly string PathToCavaPlugin = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\");
        private static readonly string PathToCavaQBs = Path.Combine(Utilities.AssemblyDirectory + @"\Quest Behaviors\Cava\");
        private static Thread _recomecar;
        private readonly Stopwatch _ultimoSemStuck = new Stopwatch();
        private readonly Stopwatch _summonpettime = new Stopwatch();
        private readonly Stopwatch _mountedTime = new Stopwatch();
        private readonly Stopwatch _checkBags = new Stopwatch();
        private readonly Stopwatch _asLastSavedTimer = new Stopwatch();
        private readonly Stopwatch _antigankertimeTimer = new Stopwatch();
        private readonly Stopwatch _refuseguildtimer = new Stopwatch();
        private readonly Stopwatch _refusepartytimer = new Stopwatch();
        private readonly Stopwatch _refusetradetimer = new Stopwatch();
        private readonly Stopwatch _refusedueltimer = new Stopwatch();
        private bool _gotGuildInvite;
        private bool _gotPartyInvite;
        private bool _gotTradeinvite;
        private bool _gotDuelinvite;
        private int _refusetime;
        private WoWPoint _ultimoLocal;
        private WoWPoint _asLastSavedPosition;
        #endregion
        #region Static Members.
        public static CultureInfo _ci;
        public static readonly string Str = Assembly.GetExecutingAssembly().FullName.Remove(Assembly.GetExecutingAssembly().FullName.IndexOf(','));
        public static readonly Assembly _assembly = Assembly.Load(Str);
        public static ResourceManager _rm;
        public static Version _version;
        private bool _cavaupdateavailable;
        private bool _error;
        private static readonly Stopwatch AsLastSavedTimer = new Stopwatch();
        private static bool _asLastSavedPositionTrigger;
        private static int _nVezesBotUnstuck;
        private static int _waitgankercount;
        private static bool _oldSh;
        private static bool _gankedressatSh;
 
        #endregion
        #region Overrides
        public override void OnButtonPress() { PressedButton(); }
        public override void OnDisable() { CavaPluginDisabled(); }
        public override void OnEnable() { CavaPluginEnabled(); }
        public override void Pulse() { RunningPulse(); }
        public override string Author { get { return "Cava"; } }
        public override string ButtonText { get { return "Open CavaPlugin"; } }
        public override string Name { get { return "CavaPlugin"; } }
        public override Version Version { get { return _version ?? (_version = new Version(0, PrimumBotRevBase.Revision)); } }
        public override bool WantButton { get { return true; } }
        #endregion
        public void PressedButton()
        {
            if (TreeRoot.IsRunning)
            {
                MessageBox.Show(StrLocalization("Bot_is_running_stop_bot_before_initiate_Cava_Plugin"),
                    StrLocalization("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error.wav";
                Player.Play();
                return;
            }
            AbreJanela();
            CavaPluginLog.Debug("Closed CavaPlugin Form");
            Player.SoundLocation = PathToCavaPlugin + "Sounds\\Close.wav";
            Player.Play();
        }

        #region Quests
        private static WoWObject ObjBarricadeHorde { get { return (ObjectManager.GetObjectsOfType<WoWGameObject>().FirstOrDefault(ret => ret.Entry == 215646 && ret.Distance < 10)); } }
        private static List<WoWUnit> MobArctanus { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 34292)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobTidecrusher { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 38750 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobElectromental { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21729 && ret.IsAlive && !ret.HasAura(37136))).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobNetherWhelp { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 20021 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobProtoNetherDrake { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21821 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobAdolescentNetherDrake { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21817 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobMatureNetherDrake { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21820 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobKoiKoiSpirit { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 22226 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobWitheredCorpse { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 20561 && ret.Distance < 16 && ret.HasAura(31261))).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobSauranokMystic { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 44120 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static WoWItem ItemThisShiv { get { return (StyxWoW.Me.CarriedItems.FirstOrDefault(i => i.Entry == 55883)); } }
        private static WoWItem ItemCelebrationPack { get { return (StyxWoW.Me.CarriedItems.FirstOrDefault(i => i.Entry == 90918)); } }
        #endregion

        public void RunningPulse()
        {
            if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 300 by Cava" ||
                ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 600 by Cava")
            {
                BotEvents.OnBotStopDelegate handler = null;
                handler = args =>
                {
                    try
                    {
                        Task.Run(() =>
                        {
                            BotBase pbBotBase;
                            BotManager.Instance.Bots.TryGetValue("ProfessionBuddy", out pbBotBase);
                            CavaPluginLog.Debug("Changing to ProfessionBuddy Bot");
                            BotManager.Instance.SetCurrent(pbBotBase);
                            if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 600 by Cava")
                                ProfileManager.LoadNew(PathToCavaProfiles + "Scripts\\CavaProf\\MB\\[PB]MB(Cava).xml", false);
                            if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 300 by Cava")
                                ProfileManager.LoadNew(PathToCavaProfiles + "Scripts\\CavaProf\\MB\\Free[PB]MB(Cava).xml", false);
                            TreeRoot.Start();
                        });
                    }
                    catch (Exception ex)
                    {
                        CavaPluginLog.Warn("Failed to change to PB BotBase: " + ex.Message);
                    }
                    finally
                    {
                        BotEvents.OnBotStopped -= handler;
                    }
                };
                BotEvents.OnBotStopped += handler;
                TreeRoot.Stop("Swich to ProfessionBuddy");
            }

            if (Me.IsAlive && !Me.HasAura(132700) && !Me.IsOnTransport && !Me.OnTaxi && !Me.Mounted && !Me.IsCasting && !Me.Combat && ItemCelebrationPack != null)
            {
                CavaPluginLog.Log("Using Celebration Package 9Th Aniversary at " + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                WoWMovement.MoveStop();
                Lua.DoString("UseItemByName(90918)");
            } 
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
                StyxWoW.Sleep(500);
            }
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
                    if (Me.CurrentTarget.Distance < 6)
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
                    //Mount.Dismount();
                    // ReSharper disable once ObjectCreationAsStatement
                    new Mount.ActionLandAndDismount();
                }
                if (!Me.Combat && !CanLootMobs.Any())
                {
                    if (Me.Location.Distance(new WoWPoint(-10710.21, 1060.979, 24.15302)) < 15)
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
                        Flightor.MoveTo(Me.Location.Distance(new WoWPoint(-10863.17, 826.0938, 18.51666)) > 30
                            ? new WoWPoint(-10878.99, 826.2751, 38.5662)
                            : new WoWPoint(-10864.82, 825.9705, 19.37853));
                    }
                }
            }
            // armageddoner reserved
            if (!IsArmageddonerUser || !CPGlobalSettings.Instance.DisablePlugin)
                return;
            #region antistuck
            if (CPsettings.Instance.AntiStuckSystem)
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

                if (AsLastSavedTimer.ElapsedMilliseconds > 6000 && _mountedTime.ElapsedMilliseconds > 30000 &&
                    BotPoi.Current.Location.DistanceSqr(Me.Location) > 10 && !_asLastSavedPositionTrigger)
                {
                    //movimento menor que 35 nos ultimos 6 segundos, mounted mais de 30 segundos,a mais de 10 do objectivo
                    CavaPluginLog.Log(StrLocalization("AntiStuck_Char_is_Mounted_for_more_than_6_secs_and_stuck"),
                    DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    // ReSharper disable once ObjectCreationAsStatement
                    new Mount.ActionLandAndDismount();
                    //Mount.Dismount();
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
                    CavaPluginLog.Log(StrLocalization("AntiStuck_Char_is_Mounted_for_more_than_10_min"),
                    DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    // ReSharper disable once ObjectCreationAsStatement
                    new Mount.ActionLandAndDismount();
                    //Mount.Dismount();
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
                    CavaPluginLog.Log(StrLocalization("AntiStuck_LastPosition_reseted_bot_is_not_running"),
                    DateTime.Now.ToString(CultureInfo.InvariantCulture));
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
                if (Me.IsAlive && Me.IsAFKFlagged && !Me.IsCasting && !Me.IsMoving && !Me.Combat && !Me.OnTaxi &&
                    _nVezesBotUnstuck == 0)
                {
                    CavaPluginLog.Log(StrLocalization("AntiStuck_Im_AFK_flagged_Anti_Afking_at"),
                    DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    WoWMovement.Move(WoWMovement.MovementDirection.JumpAscend, TimeSpan.FromMilliseconds(100));
                    new Sleep(2000);
                    KeyboardManager.KeyUpDown((char)KeyboardManager.eVirtualKeyMessages.VK_SPACE);
                    new Sleep(2000);
                    KeyboardManager.AntiAfk();
                    new Sleep(2000);
                    // ReSharper disable once ObjectCreationAsStatement
                    new Mount.ActionLandAndDismount();
                    //Mount.Dismount();
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
                    CavaPluginLog.Log(StrLocalization("AntiStuck_not_moving_last_5_min"),
                    DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    // ReSharper disable once ObjectCreationAsStatement
                    new Mount.ActionLandAndDismount();
                    //Mount.Dismount();
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
                    CavaPluginLog.Log(StrLocalization("AntiStuck_not_moving_last_10_min"),
                    DateTime.Now.ToString(CultureInfo.InvariantCulture));

                    if (_recomecar.ThreadState == ThreadState.Running) _recomecar.Abort();
                    _recomecar.Start();
                    _nVezesBotUnstuck++;
                }
                if (_ultimoSemStuck.ElapsedMilliseconds > 900000 && Me.ZoneId != 1519 && Me.ZoneId != 1637)
                {
                    CavaPluginLog.Log(StrLocalization("AntiStuck_not_moving_last_15_min"),
                    DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    Lua.DoString(@"ForceQuit()");
                }
            }

            #endregion
 

        
        
        
        
        
        
        
        
        
        }

        public void CavaPluginEnabled()
        {
            if (!_hasBeenInitialized)
            {
                CPGlobalSettings.Instance.Load();
                CPsettings.Instance.Load();
                CPGlobalSettings.Instance.language = 0;
                LastUseProfile = CPsettings.Instance.LastUsedPath;
                /*if (!CPGlobalSettings.Instance.Languageselected)
                {
                    Form getlanguage = new Language();
                    getlanguage.ShowDialog();
                }*/
                switch (CPGlobalSettings.Instance.language)
                {
                    default:
                        _ci = new CultureInfo("en-US");
                        _rm = new ResourceManager("Lang.en", _assembly);
                        break;
                    case 0:
                        _ci = new CultureInfo("en-US");
                        _rm = new ResourceManager("Lang.en", _assembly);
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
                //verifica se pode iniciar
                if (!File.Exists(PathToCavaPlugin + "Plugin.ver") ||
                    !File.Exists(PathToCavaPlugin + "Profiles.ver") ||
                    !File.Exists(PathToCavaPlugin + "QuestBehaviors.ver"))
                {

                    MessageBox.Show(StrLocalization("Welcome_to_PrimumBot") + Environment.NewLine +
                                    StrLocalization("Seems_there_is_a_problem_with_your_instalation")
                                    + Environment.NewLine +
                                    StrLocalization("Run_cavaplugin")
                                    + Environment.NewLine +
                                    StrLocalization("And_Reinstall"),
                        StrLocalization("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Player.SoundLocation = SoundPath + "Information.wav";
                    Player.Play();
                    CavaPluginLog.Warn(StrLocalization("Seems_there_is_a_problem_with_your_instalation"));
                    CavaPluginLog.Warn(StrLocalization("Run_cavaplugin"));
                    CavaPluginLog.Warn(StrLocalization("And_Reinstall"));
                    CavaPluginLog.Fatal("CavaPlugin Stoped");
                    return;
                }
                CheckForUpdates();
                if (_error)
                {
                   CavaPluginLog.Fatal("Check for updates error found");
                    return;
                }
                if (!string.IsNullOrEmpty(CPGlobalSettings.Instance.CpLogin))
                {
                    CheckAccess();
                }
                else
                {
                    IsRegisteredUser = false;
                    IsArmageddonerUser = false;
                    HaveMiningBlacksmithingAccess = false;
                }
                BotEvents.OnBotStartRequested += _OnBotStart;
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
                CavaPluginLog.Debug("Restarted all timers");
                if (CPsettings.Instance.FriendoftheExarchs != "null" && !IsQuestComplete(34788) && !IsQuestComplete(37563))
                {
                    AppDomain.CurrentDomain.SetData("FriendoftheExarchs", CPsettings.Instance.FriendoftheExarchs);
                    CavaPluginLog.Debug("FriendoftheExarchs:" + CPsettings.Instance.FriendoftheExarchs);
                }
                if (CPsettings.Instance.GorgondOutpost != "null" && !IsQuestComplete(35063) && !IsQuestComplete(35151))
                {
                    AppDomain.CurrentDomain.SetData("GorgondOutpost", CPsettings.Instance.GorgondOutpost);
                    CavaPluginLog.Debug("GorgondOutpost:" + CPsettings.Instance.GorgondOutpost);
                }
                _hasBeenInitialized = true;
            }
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

        public void CavaPluginDisabled()
        {
            BotEvents.OnBotStartRequested -= _OnBotStart;
            CavaPluginLog.Log(StrLocalization("CavaPlugin_Disposed"));
            if (!_botRunning) return;
            DetachEvents();
            _botRunning = false;
        }
 
        private void _OnBotStart(EventArgs args)
        {
            _botRunning = true;
            if (ProfileManager.CurrentProfile.Name != null && !ProfileManager.CurrentProfile.Name.Contains("[Cava]") &&
                _botRunning && CPGlobalSettings.Instance.DisablePlugin)
            {
                _botRunning = false;
            }

            CavaPluginLog.Log(_botRunning ? StrLocalization("Is_now_ENABLED") : StrLocalization("Is_now_DISABLED"));
            if (_botRunning)
            { 
                if (Me.InVehicle)
                {
                    CavaPluginLog.Log("Ejecting from vehicle");
                    Lua.DoString("VehicleExit()");
                }
                CavaPluginLog.Log(CPsettings.Instance.AntiStuckSystem ? StrLocalization("System_Anti-Stuck_Enabled"): StrLocalization("System_Anti-Stuck_Disabled"));
                CavaPluginLog.Debug("Restarted _mountedTime"); 
                _mountedTime.Restart();
                CavaPluginLog.Debug("Started Thread _Recomecar"); 
                _recomecar = new Thread(_Recomecar);
                CavaPluginLog.Debug("Restarted _asLastSavedTimer");
                _asLastSavedTimer.Restart();
                if (CPsettings.Instance.OpenBox)
                {
                    CavaPluginLog.Log(StrLocalization("Open_Boxes_is_Enabled"));
                    CavaPluginLog.Debug("Restarted _checkBags");
                    _checkBags.Restart();
                }
                else
                {
                    CavaPluginLog.Log(StrLocalization("Open_Boxes_is_Disabled"));
                }
                if (CPsettings.Instance.CheckAllowSummonPet)
                {
                    var numMinipets = Lua.GetReturnVal<int>("return GetNumCompanions('CRITTER')", 0);
                    if (numMinipets > 0)
                    {
                        CavaPluginLog.Log(StrLocalization("Summon_Random_Pet_Enabled"), DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        Lua.DoString("RunMacroText('/randompet')");
                        CavaPluginLog.Debug("Restarted _summonpettime");
                        _summonpettime.Restart();
                    }
                    else
                    {
                        CavaPluginLog.Log(StrLocalization("Dont_have_any_Pet_to_summom_disabling_Summon_Random_Pet"));
                        CavaPluginLog.Log(StrLocalization("Summon_Random_Pet_Disabled"), DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        CPsettings.Instance.CheckAllowSummonPet = false;
                        CPsettings.Instance.Save();
                    }
                }
                else
                {
                    CavaPluginLog.Log(StrLocalization("Summon_Random_Pet_Disabled"), DateTime.Now.ToString(CultureInfo.InvariantCulture));
                }
                CavaPluginLog.Log(CPsettings.Instance.FixMountFlightVendor ? "Fix Mount Flight Master Bug Enabled" : "Fix Mount Flight Master Bug Disabled");
                CavaPluginLog.Log(CPsettings.Instance.AntigankcheckBox ? "Anti Gank System Enabled" : "Anti Gank System Disabled");
                if (CPsettings.Instance.GuildInvitescheck || CPsettings.Instance.refuseguildInvitescheck)
                {
                    if (CPsettings.Instance.GuildInvitescheck)
                    {
                        CavaPluginLog.Log(StrLocalization("Accept_lvl_25_guild_invite_Enabled"));
                    }
                    if (CPsettings.Instance.refuseguildInvitescheck)
                    {
                        CavaPluginLog.Log(StrLocalization("Refuse_guild_invites_Enabled"));
                    }
                }
                CavaPluginLog.Log(CPsettings.Instance.RefusepartyInvitescheck ? StrLocalization("Refuse_party_invites_Enabled") : StrLocalization("Refuse_party_invites_Disabled"));
                CavaPluginLog.Log(CPsettings.Instance.RefusetradeInvitescheck ? StrLocalization("Refuse_trade_invites_Enabled") : StrLocalization("Refuse_trade_invites_Disabled"));
                CavaPluginLog.Log(CPsettings.Instance.RefuseduelInvitescheck ? StrLocalization("Refuse_duel_invites_Enabled") : StrLocalization("Refuse_duel_invites_Disabled"));
                CavaPluginLog.Log(CPsettings.Instance.CombatLoot ? "Auto Loot in combate Enabled." : "Auto Loot in combate Disabled.");
                AttachEvents();
            }
        }

        public static string StrLocalization(string lcllocalization)
        {
            return _rm.GetString(lcllocalization, _ci);
        }

        private static void _Recomecar()
        {
            TreeRoot.Stop();
            ProfileManager.LoadNew(PathToCavaProfiles + "Cava_Starter_Profiles.xml");
            new Sleep(2000);
            TreeRoot.Start();
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
            if (CPsettings.Instance.GuildInvitescheck && guildLevel >= 25)
            {
                CavaPluginLog.Log(StrLocalization("Accepting_guild_invite_from"), guildName);
                Lua.DoString("AcceptGuild()");
                Lua.DoString("RunMacroText('/click GuildInviteFrameJoinButton')");
            }
            if (CPsettings.Instance.refuseguildInvitescheck || guildLevel < 25)
            {
                _refuseguildtimer.Reset();
                _refuseguildtimer.Start();
                CavaPluginLog.Debug("Restarted  _refuseguildtimer");
                _refusetime = RandomNumber(3000, 8000);
                _gotGuildInvite = true;
                CavaPluginLog.Log(StrLocalization("Declining_guild_invite_from"), guildName, guildLevel, _refusetime / 1000);
            }
        }

        private void RotinaPartyInvites(object sender, LuaEventArgs e)
        {
            var userInviter = e.Args[1].ToString();
            _refusepartytimer.Reset();
            _refusepartytimer.Start();
            CavaPluginLog.Debug("Restarted  _refusepartytimer");
            _refusetime = RandomNumber(3000, 8000);
            _gotPartyInvite = true;
            CavaPluginLog.Log(StrLocalization("Declining_party_invite_from"), userInviter, _refusetime / 1000);
        }

        private void RotinaTradeInvites(object sender, LuaEventArgs e)
        {
            _refusetradetimer.Reset();
            _refusetradetimer.Start();
            CavaPluginLog.Debug("Restarted  _refusetradetimer");
            _refusetime = RandomNumber(3000, 8000);
            _gotTradeinvite = true;
            CavaPluginLog.Log(StrLocalization("Declining_trade_in"), _refusetime / 1000);
        }

        private void RotinaDuelInvites(object sender, LuaEventArgs e)
        {
            var userInviter = e.Args[1].ToString();
            _refusedueltimer.Reset();
            _refusedueltimer.Start();
            CavaPluginLog.Debug("Restarted  _refusedueltimer");
            _refusetime = RandomNumber(3000, 8000);
            _gotDuelinvite = true;
            CavaPluginLog.Log(StrLocalization("Declining_duel_invite_from"), userInviter, _refusetime / 1000);
        }

        void AttachEvents()
        {
            if (CPsettings.Instance.GuildInvitescheck || CPsettings.Instance.refuseguildInvitescheck)
                Lua.Events.AttachEvent("GUILD_INVITE_REQUEST", RotinaGuildInvites);
            if (CPsettings.Instance.RefusepartyInvitescheck)
                Lua.Events.AttachEvent("PARTY_INVITE_REQUEST", RotinaPartyInvites);
            if (CPsettings.Instance.RefusetradeInvitescheck)
                Lua.Events.AttachEvent("TRADE_SHOW", RotinaTradeInvites);
            if (CPsettings.Instance.RefuseduelInvitescheck)
                Lua.Events.AttachEvent("DUEL_REQUESTED", RotinaDuelInvites);
        }

        void DetachEvents()
        {
            if (CPsettings.Instance.GuildInvitescheck || CPsettings.Instance.refuseguildInvitescheck)
                Lua.Events.DetachEvent("GUILD_INVITE_REQUEST", RotinaGuildInvites);
            if (CPsettings.Instance.RefusepartyInvitescheck)
                Lua.Events.DetachEvent("PARTY_INVITE_REQUEST", RotinaPartyInvites);
            if (CPsettings.Instance.RefusetradeInvitescheck)
                Lua.Events.DetachEvent("TRADE_SHOW", RotinaTradeInvites);
            if (CPsettings.Instance.RefuseduelInvitescheck)
                Lua.Events.DetachEvent("DUEL_REQUESTED", RotinaDuelInvites);
        }

        public static readonly SoundPlayer Player = new SoundPlayer();

        private static string GetCavaPluginPath()
        { 
            var asmName = Assembly.GetExecutingAssembly().GetName().Name;
            var len = asmName.LastIndexOf("_", StringComparison.Ordinal);
            var folderName = asmName.Substring(0, len);

            var pluginsPath = GlobalSettings.Instance.PluginsPath;
            if (!Path.IsPathRooted(pluginsPath))
            {
                pluginsPath = Path.Combine(Utilities.AssemblyDirectory, pluginsPath);
            }
            return Path.Combine(pluginsPath, folderName);
        }

        public static string Decrypt(string cipherText)
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

        public static string Encrypt(string clearText)
        {
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(Environment.UserName,
                new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor == null) return clearText;
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static void CheckAccess()
        {
            if (CPGlobalSettings.Instance.UseServer == 0)
            {
                var url = string.Format("https://cavaprofiles.net/index.php?user={0}&passw={1}", CPGlobalSettings.Instance.CpLogin,
                    Decrypt(CPGlobalSettings.Instance.CpPassword));
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.AllowAutoRedirect = false;
                request.CookieContainer = new CookieContainer();
                var response = (HttpWebResponse)request.GetResponse();
                var cookies = request.CookieContainer;
                response.Close();
                try //verifica se e user registado
                {
                    request =
                        (HttpWebRequest)
                            WebRequest.Create(
                                "https://cavaprofiles.net/index.php/profiles/profiles-list/leveling-1-to-90/leveling-60-to-90/5-reg-user/file");
                    request.AllowAutoRedirect = false;
                    request.CookieContainer = cookies;
                    response = (HttpWebResponse)request.GetResponse();
                    response.Close();
                    if (response.StatusCode.ToString() == "OK") //is reg
                    {
                        CavaPluginLog.Debug(StrLocalization("Registered_Access_Tested_and_Passed"));
                        IsRegisteredUser = true;
                    }
                    else
                    {
                        CavaPluginLog.Warn(StrLocalization("Something_Wrong_cant_confirm_you_have_registered_access"));
                        CPGlobalSettings.Instance.CpLogin = "";
                        CPGlobalSettings.Instance.CpPassword = "";
                        IsRegisteredUser = false;
                        IsArmageddonerUser = false;
                        HaveMiningBlacksmithingAccess = false;
                        var sInfo = new ProcessStartInfo("https://cavaprofiles.net/index.php");
                        Process.Start(sInfo);
                    }
                }
                catch (Exception)
                {
                    CavaPluginLog.Warn(StrLocalization("Something_Wrong_cant_confirm_you_have_registered_access"));
                    CPGlobalSettings.Instance.CpLogin = "";
                    CPGlobalSettings.Instance.CpPassword = "";
                    IsRegisteredUser = false;
                    IsArmageddonerUser = false;
                    HaveMiningBlacksmithingAccess = false;
                    var sInfo = new ProcessStartInfo("https://cavaprofiles.net/index.php");
                    Process.Start(sInfo);
                }
                if (IsRegisteredUser)
                {
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
                            HaveArmageddonerAccess();
                            StartCheckarmageddonerreservedprofiles();
                        }
                        else
                        {
                            DontHaveArmageddonerAccess();
                        }
                    }
                    catch (Exception)
                    {
                        DontHaveArmageddonerAccess();
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
                            Haveprofessionminingblacksmithing600Access();
                        }
                        else
                        {
                            DontHaveprofessionminingblacksmithing600Access();
                        }
                    }
                    catch (Exception)
                    {
                        DontHaveprofessionminingblacksmithing600Access();
                    }

                }
            }
            if (CPGlobalSettings.Instance.UseServer == 1)
            {
                var url = string.Format("https://cavaprofiles.org/index.php?user={0}&passw={1}", CPGlobalSettings.Instance.CpLogin,
                    Decrypt(CPGlobalSettings.Instance.CpPassword));
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.AllowAutoRedirect = false;
                request.CookieContainer = new CookieContainer();
                var response = (HttpWebResponse)request.GetResponse();
                var cookies = request.CookieContainer;
                response.Close();
                try //verifica se e user registado
                {
                    request =
                        (HttpWebRequest)
                            WebRequest.Create(
                                "https://cavaprofiles.org/index.php/profiles/profiles-list/leveling-1-to-90/leveling-60-to-90/5-reg-user/file");
                    request.AllowAutoRedirect = false;
                    request.CookieContainer = cookies;
                    response = (HttpWebResponse)request.GetResponse();
                    response.Close();
                    if (response.StatusCode.ToString() == "OK") //is reg
                    {
                        CavaPluginLog.Debug(StrLocalization("Registered_Access_Tested_and_Passed"));
                        IsRegisteredUser = true;
                    }
                    else
                    {
                        CavaPluginLog.Warn(StrLocalization("Something_Wrong_cant_confirm_you_have_registered_access"));
                        DontHaveArmageddonerAccess();
                        DontHaveprofessionminingblacksmithing600Access();
                        IsRegisteredUser = false;
                        IsArmageddonerUser = false;
                        HaveMiningBlacksmithingAccess = false;
                        var sInfo = new ProcessStartInfo("https://cavaprofiles.net/index.php");
                        Process.Start(sInfo);
                    }
                }
                catch (Exception)
                {
                    CavaPluginLog.Warn(StrLocalization("Something_Wrong_cant_confirm_you_have_registered_access"));
                    DontHaveArmageddonerAccess();
                    DontHaveprofessionminingblacksmithing600Access();
                    IsRegisteredUser = false;
                    IsArmageddonerUser = false;
                    HaveMiningBlacksmithingAccess = false;
                    var sInfo = new ProcessStartInfo("https://cavaprofiles.net/index.php");
                    Process.Start(sInfo);
                }
                if (IsRegisteredUser)
                {
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
                            HaveArmageddonerAccess();
                            StartCheckarmageddonerreservedprofiles();
                        }
                        else
                        {
                            DontHaveArmageddonerAccess();
                        }
                    }
                    catch (Exception)
                    {
                        DontHaveArmageddonerAccess();
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
                            Haveprofessionminingblacksmithing600Access();
                        }
                        else
                        {
                            DontHaveprofessionminingblacksmithing600Access();
                        }
                    }
                    catch (Exception)
                    {
                        DontHaveprofessionminingblacksmithing600Access();
                    }

                }
            }
        }

        private static void HaveArmageddonerAccess()
        {
            IsArmageddonerUser = true;

            CavaPluginLog.Debug(StrLocalization("Armageddoner_Access_Tested_and_Passed"));
            IsArmageddonerUser = true;
        }

        private static void DontHaveArmageddonerAccess()
        {

            CavaPluginLog.Debug(StrLocalization("Armageddoner_Access_Tested"));
            IsArmageddonerUser = false;
        }

        private static void StartCheckarmageddonerreservedprofiles()
        {
            switch (CPsettings.Instance.FriendoftheExarchs)
            {
                default:
                    AppDomain.CurrentDomain.SetData("FriendoftheExarchs", null);
                    break;
                case "null":
                    AppDomain.CurrentDomain.SetData("FriendoftheExarchs", null);
                    break;
                case "Andren":
                    AppDomain.CurrentDomain.SetData("FriendoftheExarchs", "Andren");
                    break;
                case "Chel":
                    AppDomain.CurrentDomain.SetData("FriendoftheExarchs", "Chel");
                    break;
                case "Onaala":
                    AppDomain.CurrentDomain.SetData("FriendoftheExarchs", "Onaala");
                    break;
            }
            if (StyxWoW.Me.Level >= 80 && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[25316]", 0))
            {
                AppDomain.CurrentDomain.SetData("learnportal1", CPsettings.Instance.Learnportal1 ? "true" : null);
            }
            else
            {
                AppDomain.CurrentDomain.SetData("learnportal1", null);
                CPsettings.Instance.Learnportal1 = false;
            }
            if (StyxWoW.Me.Level >= 80 && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[14182]", 0) && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[25924]", 0))
            {
                AppDomain.CurrentDomain.SetData("learnportal2", CPsettings.Instance.Learnportal2 ? "true" : null);
            }
            else
            {
                AppDomain.CurrentDomain.SetData("learnportal2", null);
                CPsettings.Instance.Learnportal2 = false;
            }
            if (StyxWoW.Me.Level >= 82 && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[27123]", 0))
            {
                AppDomain.CurrentDomain.SetData("learnportal3", CPsettings.Instance.Learnportal3 ? "true" : null);
            }
            else
            {
                AppDomain.CurrentDomain.SetData("learnportal3", null);
                CPsettings.Instance.Learnportal3 = false;
            }
            if (StyxWoW.Me.Level >= 83 && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[28112]", 0))
            {
                AppDomain.CurrentDomain.SetData("learnportal4", CPsettings.Instance.Learnportal4 ? "true" : null);
            }
            else
            {
                AppDomain.CurrentDomain.SetData("learnportal4", null);
                CPsettings.Instance.Learnportal4 = false;
            }

            if (StyxWoW.Me.Level >= 85 && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[27538]", 0))
            {
                AppDomain.CurrentDomain.SetData("learnportal5", CPsettings.Instance.Learnportal5 ? "true" : null);
            }
            else
            {
                AppDomain.CurrentDomain.SetData("learnportal5", null);
                CPsettings.Instance.Learnportal5 = false;
            }

            if (StyxWoW.Me.Level >= 85 && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[31733]", 0) && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[31766]", 0))
            {
                AppDomain.CurrentDomain.SetData("learnportal6", CPsettings.Instance.Learnportal6 ? "true" : null);
            }
            else
            {
                AppDomain.CurrentDomain.SetData("learnportal6", null);
                CPsettings.Instance.Learnportal6 = false;
            }
        }

        private static void Haveprofessionminingblacksmithing600Access()
        {

            CavaPluginLog.Debug(StrLocalization("Profession_Owner_Access_Tested_and_Passed_for_Mining_Blacksmithing"));
            HaveMiningBlacksmithingAccess = true;
            if (CPsettings.Instance.LastUsedPath == 7)
            {
                LastUseProfile = 7;
            }
        }

        private static void DontHaveprofessionminingblacksmithing600Access()
        {

            CavaPluginLog.Debug(StrLocalization("Profession_Owner_Access_Tested_for_Mining_Blacksmithing"));
            HaveMiningBlacksmithingAccess = false;
            if (LastUseProfile == 7)
                LastUseProfile = 0;
        }

        private void AbreJanela()
        {
            /*if (_cavaupdated)
            {
                // ReSharper disable LocalizableElement
                MessageBox.Show("Cava Plugin/Quest Behaviors has been updated a restart is required.", "RESTART REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // ReSharper restore LocalizableElement
                Player.SoundLocation = PathToCavaPlugin + "Sounds\\notify.wav";
                Player.Play();
                Environment.Exit(0);
            }*/
            var mainCavaForm = new CavaForm();
            mainCavaForm.ShowDialog();
        }

        private void CheckForUpdates()
        {

            CavaPluginLog.Debug(StrLocalization("Please_Wait_While_CavaPlugin_Check_For_Updates"));
            var cavaupdated = false;
            if (CavaPluginUpdater.UpdateAvailable("http://cavaplugin.googlecode.com/svn/trunk/", "Plugin.ver"))
            {
                var newrev = CavaPluginUpdater.GetNewestRev("http://cavaplugin.googlecode.com/svn/trunk/").ToString(CultureInfo.InvariantCulture);
                CavaPluginLog.Debug(StrLocalization("Cava_Plugin_Update_to_0_is_available_You_are_on_1"), newrev, CavaPluginUpdater.GetCurrentRev("Plugin.ver"));
                if (UpdaterCava("/command:\"update\" /path:\"" + PathToCavaPlugin + "\" /closeonend:1"))
                {
                    CavaPluginUpdater.WriteNewRevFile("Plugin.ver", newrev.ToString(CultureInfo.InvariantCulture));
                    CavaPluginLog.Debug(StrLocalization("its_now_updated_to_rev"), newrev);
                }
                else
                {
                    CavaPluginLog.Warn(StrLocalization("There_is_a_problem_updating") + " CavaPlugin.");
                    Player.SoundLocation = SoundPath + "Error2.wav";
                    Player.Play();
                    _error = true;
                    return;
                }
                cavaupdated = true;
            }
            if (CavaPluginUpdater.UpdateAvailable("http://cavaqbs.googlecode.com/svn/trunk/Cava/", "QuestBehaviors.ver"))
            {
                var newrev = CavaPluginUpdater.GetNewestRev("http://cavaqbs.googlecode.com/svn/trunk/Cava/").ToString(CultureInfo.InvariantCulture);
                CavaPluginLog.Debug(StrLocalization("Cava_QB_Update_to_0_is_available_You_are_on_1"), newrev, CavaPluginUpdater.GetCurrentRev("QuestBehaviors.ver"));
                if (UpdaterCava("/command:\"update\" /path:\"" + PathToCavaQBs + "\" /closeonend:1"))
                {
                    CavaPluginUpdater.WriteNewRevFile("QuestBehaviors.ver", newrev.ToString(CultureInfo.InvariantCulture));
                    CavaPluginLog.Debug(StrLocalization("its_now_updated_to_rev"), newrev);
                }
                else
                {
                    CavaPluginLog.Warn(StrLocalization("There_is_a_problem_updating") + " Cava Quest Behaviors.");
                    Player.SoundLocation = SoundPath + "Error2.wav";
                    Player.Play();
                    _error = true;
                    return;
                }
                cavaupdated = true;
            }
            if (CavaPluginUpdater.UpdateAvailable("http://cavaprofiles.googlecode.com/svn/trunk/", "Profiles.ver"))
            {
                var newrev = CavaPluginUpdater.GetNewestRev("http://cavaprofiles.googlecode.com/svn/trunk/").ToString(CultureInfo.InvariantCulture);
                CavaPluginLog.Debug(StrLocalization("Cava_QB_Update_to_0_is_available_You_are_on_1"), newrev, CavaPluginUpdater.GetCurrentRev("Profiles.ver"));
                CavaPluginUpdater.GetCurrentRev("Profiles.ver");
                if (UpdaterCava("/command:\"update\" /path:\"" + PathToCavaProfiles + "\" /closeonend:1"))
                {
                    CavaPluginUpdater.WriteNewRevFile("Profiles.ver", newrev);
                    CavaPluginLog.Debug(StrLocalization("its_now_updated_to_rev"), newrev);
                }
                else
                {
                    CavaPluginLog.Warn(StrLocalization("There_is_a_problem_updating") + " Cava Profiles.");
                    Player.SoundLocation = SoundPath + "Error2.wav";
                    Player.Play();
                    _error = true;
                    return;
                }
            }
            if (cavaupdated)
            {
                if (CPGlobalSettings.Instance.AutoShutdownWhenUpdate)
                {
                    CavaPluginLog.Warn(StrLocalization("Auto_Shutdown_in_progress_at"),
                    DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    Environment.Exit(0);
                }
                else
                {
                    MessageBox.Show(StrLocalization("CavaPlugin_Quest_Behaviors_has_been_updated_restart_required"),
                    StrLocalization("RESTART_REQUIRED"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // ReSharper restore ResourceItemNotResolved
                    Player.SoundLocation = SoundPath + "notify.wav";
                    Player.Play();

                }
            }
        }

        private static bool UpdaterCava(string f)
        {
            var p = new Process { StartInfo = { FileName = "TortoiseProc.exe", Arguments = f } };
            try
            {
                p.Start();
                p.WaitForExit();
                if (p.ExitCode == 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                CavaPluginLog.Warn(StrLocalization("Unable_to_run_TortoiseSVN"));
                CavaPluginLog.Fatal("Exception " + ex.Message);
            }
            return false;
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

        public static bool IsQuestComplete(uint questId)
        {
            return Lua.GetReturnVal<bool>(string.Format("return IsQuestFlaggedCompleted({0})", questId), 0);
        }


        private static void CavaAtackMob()
        {
            if (!Me.IsAutoAttacking)
            { Lua.DoString("StartAttack()"); }
            var spell = 0;
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

        private static IEnumerable<WoWUnit> CanLootMobs
        {
            get
            {
                return (ObjectManager.GetObjectsOfType<WoWUnit>(true, false)
                    .Where(target => (target.IsDead && target.Lootable)));
            }
        }

    }
}












