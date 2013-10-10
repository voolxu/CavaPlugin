using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;

using Styx;
using Styx.Helpers;
using Styx.Loaders;
using Styx.Patchables;
using Styx.Plugins;
using Styx.Common;
using Styx.CommonBot;
using Styx.CommonBot.Profiles;
using Styx.Pathing;
using Styx.WoWInternals;
using Styx.WoWInternals.Misc;
using Styx.WoWInternals.World;
using Styx.WoWInternals.WoWCache;
using Styx.WoWInternals.WoWObjects;

using CavaHPlugin;
using CavaHProfile;
using CavaHQB;

namespace CavaPlugin
{
    public class CavaPlugin : HBPlugin
    {
        public bool hasBeenInitialized = false;
        public bool hasBeenInitialized2 = false;
        public bool hasBeenInitialized3 = false;
        public bool cavaupdated = false;
        public bool BotRunning = true;
        public bool gotGuildInvite = false;
        public bool gotPartyInvite = false;
        public bool gotTradeinvite = false;
        public bool gotDuelinvite = false;
        private int NVezesBotUnstuck;
        private static Thread Recomecar;
        private Stopwatch UltimoSemStuck;
        private Stopwatch summonpettime;
        private Stopwatch MountedTime;
        private Stopwatch refuseguildtimer = new Stopwatch();
        private Stopwatch refusepartytimer = new Stopwatch();
        private Stopwatch refusetradetimer = new Stopwatch();
        private Stopwatch refusedueltimer = new Stopwatch();
        public int refusetime = 0;
        private WoWPoint UltimoLocal;
        private bool onbotstart = true;
        #region Overrides except pulse
        public override string Author { get { return "Cava"; } }
        public override Version Version { get { return new Version(4, 0, 6); } }
        public override string Name { get { return "CavaPlugin"; } }
        public override bool WantButton { get { return true; } }
        public override string ButtonText { get { return "Cava Profiles"; } }
        public override void OnButtonPress()
        {
            bool isRunningantes = TreeRoot.IsRunning;
            if (isRunningantes)
            {
                MessageBox.Show("Bot is running, stop bot before initiate Cava Plugin", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                abreJanela();
            }
        }
        private Cava_Plugin_Updater UpdaterPlugin;
        private Cava_QB_Updater UpdaterQB;
        private Cava_Profile_Updater UpdaterProfile;
        public string pathToCavaArmageddoner = Path.Combine(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\Armageddoner\");
        public string pathToPBMiningBS = Path.Combine(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\PB\MB\");

        static void UpdaterArmageddoner(string f)
        {
            Process p = new Process();
            p.StartInfo.FileName = "TortoiseProc.exe";
            p.StartInfo.Arguments = f;
            p.Start();
            p.WaitForExit();
            if (p.ExitCode == 0)
            {
                CPGlobalSettings.Instance.AllowUpdate = false;
            }
        }
        static void UpdaterMiningBS(string f)
        {
            Process p = new Process();
            p.StartInfo.FileName = "TortoiseProc.exe";
            p.StartInfo.Arguments = f;
            p.Start();
            p.WaitForExit();
            if (p.ExitCode == 0)
            {
                CPGlobalSettings.Instance.PBMiningBlacksmithing = false;
            }
        }

        public override void Initialize()
        {
            Styx.CommonBot.BotEvents.OnBotStart += _OnBotStart;
            if (!hasBeenInitialized)
            {
                if (!File.Exists(Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\Cava_Plugin_V3_Updater.ver")) ||
                    !File.Exists(Path.Combine(Utilities.AssemblyDirectory + @"\Quest Behaviors\Cava\CavaLoader.cs")))
                {
                    MessageBox.Show("Cava plugin is not instaled properly, please download and install CavaPlugin from zip file", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Logging.Write(Colors.Teal, "Please Wait While [Cava Plugin] Check For Updates, This Can Take Several Minutes");
                System.Threading.Thread.Sleep(2000); 
                hasBeenInitialized = true;
                try
                {
                    UpdaterPlugin = new Cava_Plugin_Updater("http://cavaplugin.googlecode.com/svn/trunk/", "CavaPlugin");
                    if (UpdaterPlugin.UpdateAvailable())
                    {
                        Logging.Write("[Cava Plugin] Update to $" + UpdaterPlugin.GetNewestRev().ToString() + " is available! You are on $" + UpdaterPlugin.CurrentRev.ToString());
                        Logging.Write("[Cava Plugin] Starting update process");
                        if (UpdaterPlugin.Update())
                        {
                            Logging.Write("[Cava Plugin] is now up to date! Please reload HB");
                            cavaupdated = true;
                        }
                        else
                        {
                            Logging.Write("[Cava Plugin] Encountered an error trying to auto-update. Please update manually");
                        }
                    }
                    else
                    {
                        Logging.Write("[Cava Plugin] is at Rev $" + UpdaterPlugin.CurrentRev.ToString() + " and up to date!");
                    }
                }
                catch (Exception ex)
                {
                    Logging.Write(Colors.Teal, "Unable to run [Cava Plugin] update process");
                    Logging.Write(LogLevel.Diagnostic, "[Cava Plugin]: Exception " + ex.Message);
                }
                try
                {
                    UpdaterQB = new Cava_QB_Updater("http://cavaqbs.googlecode.com/svn/trunk/", "");
                    if (UpdaterQB.UpdateAvailable())
                    {
                        Logging.Write("[Cava QB Updater] Update to $" + UpdaterQB.GetNewestRev().ToString() + " is available! You are on $" + UpdaterQB.CurrentRev.ToString());
                        Logging.Write("[Cava QB Updater] Starting update process");
                        if (UpdaterQB.Update())
                        {
                            Logging.Write("[Cava QB Updater] is now up to date! Please reload HB");
                            cavaupdated = true;
                        }
                        else
                        {
                            Logging.Write("[Cava QB Updater] Encountered an error trying to auto-update. Please update manually");
                        }
                    }
                    else
                    {
                        Logging.Write("[Cava QB Updater] is at Rev $" + UpdaterQB.CurrentRev.ToString() + " and up to date!");
                    }
                }
                catch (Exception ex)
                {
                    Logging.Write(Colors.Teal, "Unable to run [Cava QB Updater] update process");
                    Logging.Write(LogLevel.Diagnostic, "[Cava QB Updater]: Exception " + ex.Message);
                }
                try
                {
                    UpdaterProfile = new Cava_Profile_Updater("http://cavaprofiles.googlecode.com/svn/trunk/", "");
                    if (UpdaterProfile.UpdateAvailable())
                    {
                        Logging.Write("[Cava Profile Updater] Update to $" + UpdaterProfile.GetNewestRev().ToString() + " is available! You are on $" + UpdaterProfile.CurrentRev.ToString());
                        Logging.Write("[Cava Profile Updater] Starting update process");
                        if (UpdaterProfile.Update())
                        {
                            Logging.Write("[Cava Profile Updater] is now up to date!");
                        }
                        else
                        {
                            Logging.Write("[Cava Profile Updater] Encountered an error trying to auto-update. Please update manually");
                        }
                    }
                    else
                    {
                        Logging.Write("[Cava Profile Updater] is at Rev $" + UpdaterProfile.CurrentRev.ToString() + " and up to date!");
                    }
                }
                catch (Exception ex)
                {
                    Logging.Write(Colors.Teal,"Unable to run [Cava Profile Updater] update process");
                    Logging.Write(LogLevel.Diagnostic, "[Cava Profile Updater]: Exception " + ex.Message);
                }
                CPGlobalSettings.Instance.Load();
                if (cavaupdated && CPGlobalSettings.Instance.AutoShutdownWhenUpdate)
                {
                    Logging.Write("[Cava Plugin] Auto-Shutdown in progress at " + DateTime.Now.ToString());
                    System.Threading.Thread.Sleep(5000);
                    Environment.Exit(0); 
                }
                if (CPGlobalSettings.Instance.BotAllowUpdate && CPGlobalSettings.Instance.AllowUpdate)
                {
                    UpdaterArmageddoner("/command:\"update\" /path:\"" + pathToCavaArmageddoner + "\" /closeonend:1");
                }
                if (CPGlobalSettings.Instance.BotPBMiningBlacksmithing && CPGlobalSettings.Instance.PBMiningBlacksmithing)
                {
                    UpdaterMiningBS("/command:\"update\" /path:\"" + pathToPBMiningBS + "\" /closeonend:1");
                }
                UltimoSemStuck = new Stopwatch();
                MountedTime = new Stopwatch();
                summonpettime = new Stopwatch();
                NVezesBotUnstuck = 0;
              }
            //duplo ignore, bot corre 2 vezes o Initialize 
            if (!hasBeenInitialized2)
            {
                hasBeenInitialized2 = true;
                return;
            }
            if (!hasBeenInitialized3)
            {
                hasBeenInitialized3 = true;
                return;
            }
            abreJanela();
        }

        public override void Dispose()
        {
            Styx.CommonBot.BotEvents.OnBotStart -= _OnBotStart;
            Logging.Write(Colors.Teal, "CavaPlugin Disposed");
            if (BotRunning)
            {
                if (CPsettings.Instance.guildInvitescheck || CPsettings.Instance.refuseguildInvitescheck)
                {
                    Lua.Events.DetachEvent("GUILD_INVITE_REQUEST", RotinaGuildInvites);
                }
                if (CPsettings.Instance.refusepartyInvitescheck)
                {
                    Lua.Events.DetachEvent("PARTY_INVITE_REQUEST", RotinaPartyInvites);  
                }
                if (CPsettings.Instance.refusetradeInvitescheck)
                {
                    Lua.Events.DetachEvent("TRADE_SHOW", RotinaTradeInvites);
                }
                if (CPsettings.Instance.refuseduelInvitescheck)
                {
                    Lua.Events.DetachEvent("DUEL_REQUESTED", RotinaDuelInvites);
                }
            }
        }

        private void _OnBotStart(EventArgs args)
        {
            if (onbotstart)
            {
                CPsettings.Instance.Load();
                if (ProfileManager.CurrentProfile.Name.Contains("[Cava]") && !BotRunning)
                {
                    BotRunning = true;
                    Logging.Write(@"[CavaPlugin] Is now ENABLED");

                }
                if (!ProfileManager.CurrentProfile.Name.Contains("[Cava]") && BotRunning)
                {
                    BotRunning = false;
                    Logging.Write(@"[CavaPlugin] Is now DISABLED");
                }
                if (BotRunning)
                {
                    if (CPsettings.Instance.AntiStuckSystem)
                    {
                        Logging.Write(Colors.Teal, "[CavaPlugin - System Anti-Stuck Started]");
                    }
                    UltimoLocal = StyxWoW.Me.Location;
                    if (NVezesBotUnstuck == 0)
                    {
                        UltimoSemStuck.Restart();
                    }
                    if (Me.Mounted)
                    {
                        MountedTime.Restart();
                    }
                    Recomecar = new Thread(new ThreadStart(_Recomecar));
                    if (CPsettings.Instance.CheckAllowSummonPet)
                    {
                        Logging.Write(Colors.Teal, "[CavaPlugin - Summon Random Pet Enabled]");
                        Lua.DoString("RunMacroText('/randompet')");
                        summonpettime.Restart();
                    }
                    else
                    {
                        Logging.Write(Colors.Teal, "[CavaPlugin - Summon Random Pet Disabled]");
                    }

                    if (CPsettings.Instance.guildInvitescheck || CPsettings.Instance.refuseguildInvitescheck)
                    {
                        if (CPsettings.Instance.guildInvitescheck)
                        {
                            Logging.Write(Colors.Teal, "[CavaPlugin - Accept lvl 25 guild invite Enabled]");
                        }
                        if (CPsettings.Instance.refuseguildInvitescheck)
                        {
                            Logging.Write(Colors.Teal, "[CavaPlugin - Refuse guild invites Enabled]");
                        }
                        Lua.Events.AttachEvent("GUILD_INVITE_REQUEST", RotinaGuildInvites);
                    }
                    if (!CPsettings.Instance.guildInvitescheck || !CPsettings.Instance.refuseguildInvitescheck)
                    {
                        if (!CPsettings.Instance.guildInvitescheck)
                        {
                            Logging.Write(Colors.Teal, "[CavaPlugin - Accept lvl 25 guild invite Disabled]");
                        }
                        if (!CPsettings.Instance.refuseguildInvitescheck)
                        {
                            Logging.Write(Colors.Teal, "[CavaPlugin - Refuse guild invites Disabled]");
                        }

                    }

                    if (CPsettings.Instance.refusepartyInvitescheck)
                    {
                        Logging.Write(Colors.Teal, "[CavaPlugin - Refuse party invites Enabled]");
                        Lua.Events.AttachEvent("PARTY_INVITE_REQUEST", RotinaPartyInvites);
                    }
                    else
                    {
                        Logging.Write(Colors.Teal, "[CavaPlugin - Refuse party invites Disabled]");
                    }

                    if (CPsettings.Instance.refusetradeInvitescheck)
                    {
                        Logging.Write(Colors.Teal, "[CavaPlugin - Refuse trade invites Enabled]");
                        Lua.Events.AttachEvent("TRADE_SHOW", RotinaTradeInvites);
                    }
                    else
                    {
                        Logging.Write(Colors.Teal, "[CavaPlugin - Refuse trade invites Disabled]");
                    }

                    if (CPsettings.Instance.refuseduelInvitescheck)
                    {
                        Logging.Write(Colors.Teal, "[CavaPlugin - Refuse duel invites Enabled]");
                        Lua.Events.AttachEvent("DUEL_REQUESTED", RotinaDuelInvites);
                    }
                    else
                    {
                        Logging.Write(Colors.Teal, "[CavaPlugin - Refuse duel invites Disabled]");
                    }
                }
                onbotstart = false;
            }
            else
            { onbotstart = true; }
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        private void RotinaGuildInvites(object sender, LuaEventArgs e)
        {
            string GuildName = e.Args[1].ToString();
            int GuildLevel = Convert.ToInt32(e.Args[2]);
            if (CPsettings.Instance.guildInvitescheck && GuildLevel >= 25)
            {
                Logging.Write(Colors.Teal, "[CavaPlugin - Accepting guild invite from {0}", GuildName);
                Lua.DoString("AcceptGuild()");
                Lua.DoString("StaticPopup_Hide(\"GUILD_INVITE_REQUEST\")");
            }
            if (CPsettings.Instance.refuseguildInvitescheck || GuildLevel < 25)
            {
                refuseguildtimer.Reset();
                refuseguildtimer.Start();
                refusetime = RandomNumber(3000, 8000);
                gotGuildInvite = true;
                Logging.Write(Colors.Teal, "[CavaPlugin - Declining guild invite from {0} lvl {1} in " + refusetime / 1000 + " seconds", GuildName, GuildLevel);
            }
        }

        private void RotinaPartyInvites(object sender, LuaEventArgs e)
        {
            string UserInviter = e.Args[1].ToString();
            refusepartytimer.Reset();
            refusepartytimer.Start();
            refusetime = RandomNumber(3000, 8000);
            gotPartyInvite = true;
            Logging.Write(Colors.Teal, "[CavaPlugin - Declining party invite from {0} in " + refusetime / 1000 + " seconds", UserInviter);
        }

        private void RotinaTradeInvites(object sender, LuaEventArgs e)
        {
            refusetradetimer.Reset();
            refusetradetimer.Start();
            refusetime = RandomNumber(3000, 8000);
            gotTradeinvite = true;
            Logging.Write(Colors.Teal, "[CavaPlugin - Declining trade in " + refusetime / 1000 + " seconds");
        }

        private void RotinaDuelInvites(object sender, LuaEventArgs e)
        {
            string UserInviter = e.Args[1].ToString();
            refusedueltimer.Reset();
            refusedueltimer.Start();
            refusetime = RandomNumber(3000, 8000);
            gotDuelinvite = true;
            Logging.Write(Colors.Teal, "[CavaPlugin - Declining duel invite from {0} in " + refusetime / 1000 + " seconds", UserInviter);
        }

        private static void _Recomecar()
        {
            TreeRoot.Stop();
            Thread.Sleep(2000);
            TreeRoot.Start();
        }

        private bool IsObjectiveComplete(int objectiveId, uint questId)
        {
            if (Me.QuestLog.GetQuestById(questId) == null)
            {
                return false;
            }
            int returnVal = Lua.GetReturnVal<int>("return GetQuestLogIndexByID(" + questId + ")", 0);
            return
                Lua.GetReturnVal<bool>(
                    string.Concat(new object[] { "return GetQuestLogLeaderBoard(", objectiveId, ",", returnVal, ")" }), 2);
        }
        private String NewProfilePath
        {
            get
            {
                string directory = Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\";
                return (Path.Combine(directory, ProfileName));
            }
        }
        public String ProfileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"Plugins\CavaPlugin\Settings\Main-Settings.xml"));

        #endregion

        #region Privates/Publics
        private void abreJanela()
        {
            if (cavaupdated)
            {
                MessageBox.Show("Cava Plugin/Quest Behaviors has been updated a restart is required.", "RESTART REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            var mainCavaForm = new CavaForm();
            mainCavaForm.ShowDialog();
        }

        private static LocalPlayer Me { get { return StyxWoW.Me; } }
        #endregion

        #region Quests
        public List<WoWUnit> MobKingGennGreymane { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 36332)).OrderBy(ret => ret.Distance).ToList(); } }
        public List<WoWUnit> MobDocZapnozzle { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 36608)).OrderBy(ret => ret.Distance).ToList(); } }
        public List<WoWUnit> MobArctanus { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 34292)).OrderBy(ret => ret.Distance).ToList(); } }
        public List<WoWUnit> MobTidecrusher { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 38750 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        public List<WoWUnit> MobElectromental { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21729 && ret.IsAlive && !ret.HasAura(37136))).OrderBy(ret => ret.Distance).ToList(); } }
        public List<WoWUnit> MobNetherWhelp { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 20021 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        public List<WoWUnit> MobProtoNetherDrake { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21821 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        public List<WoWUnit> MobAdolescentNetherDrake { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21817 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        public List<WoWUnit> MobMatureNetherDrake { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21820 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        public List<WoWUnit> MobKoiKoiSpirit { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 22226 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        public List<WoWUnit> MobWitheredCorpse { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 20561 && ret.Distance < 16 && ret.HasAura(31261))).OrderBy(ret => ret.Distance).ToList(); } }
        public List<WoWUnit> MobGlacierIce { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 49233 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }

        #endregion

        #region Override Pulse
        public override void Pulse()
        {
            if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 300 by Cava" ||
                ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 600 by Cava")
            {
                Logging.Write(@"Loading '{0}'", ProfileManager.CurrentOuterProfile.Name);
                Thread.Sleep(3000);
                BotBase pbBotBase;
                BotManager.Instance.Bots.TryGetValue("ProfessionBuddy", out pbBotBase);
                if (pbBotBase != null && BotManager.Current != pbBotBase)
                {
                    System.Windows.Application.Current.Dispatcher.Invoke(
                        new Action(
                            () =>
                            {
                                TreeRoot.Stop();
                                BotManager.Instance.SetCurrent(pbBotBase);
                                Thread.Sleep(2000);
                                if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 600 by Cava") { ProfileName = "PB\\MB\\[PB]MB(Cava).xml"; }
                                if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 300 by Cava") { ProfileName = "Free_PB\\[PB]MB(Cava).xml"; }
                                ProfileManager.LoadNew(NewProfilePath, false);
                                TreeRoot.Start();
                            }));
                }
            }
            if (Me.IsDead && !Me.HasAura(8326) && CPGlobalSettings.Instance.RessAfterDie)
            {
                Thread.Sleep(5000);
                Logging.Write(@"[CavaPlugin] Anti-Bug Release System");
                Lua.DoString("RunMacroText('/click StaticPopup1Button1')");
            }
            if (BotRunning)
            {
                if (gotGuildInvite && refuseguildtimer.ElapsedMilliseconds >= refusetime)
                {
                    Lua.DoString("DeclineGuild()");
                    Lua.DoString("StaticPopup_Hide(\"GUILD_INVITE\")");
                    gotGuildInvite = false;
                }

                if (gotPartyInvite && refusepartytimer.ElapsedMilliseconds >= refusetime)
                {
                    Lua.DoString("DeclineGroup()");
                    Lua.DoString("StaticPopup_Hide(\"PARTY_INVITE\")");
                    gotPartyInvite = false;
                }

                if (gotTradeinvite && refusetradetimer.ElapsedMilliseconds >= refusetime)
                {
                    Lua.DoString("CancelTrade()");
                    gotTradeinvite = false;
                }

                if (gotDuelinvite && refusedueltimer.ElapsedMilliseconds >= refusetime)
                {
                    Lua.DoString("CancelDuel()");
                    Lua.DoString("StaticPopup_Hide(\"DUEL_REQUESTED\")");
                    gotDuelinvite = false;
                }

                if (CPsettings.Instance.CheckAllowSummonPet && summonpettime.Elapsed.TotalMinutes > 30)
                {
                    Lua.DoString("RunMacroText('/randompet')");
                    summonpettime.Restart();
                }

                if (Me.Race == WoWRace.Goblin && Me.HasAura("Near Death!") && Me.ZoneId == 4720 && MobDocZapnozzle.Count > 0)
                {
                    MobDocZapnozzle[0].Interact();
                    Thread.Sleep(1000);
                    Lua.DoString("RunMacroText('/click QuestFrameCompleteQuestButton')");
                }
                if (Me.Race == WoWRace.Worgen && Me.HasAura(68631) && Me.ZoneId == 4714 && MobKingGennGreymane.Count > 0)
                {
                    MobKingGennGreymane[0].Interact();
                    Thread.Sleep(1000);
                    Lua.DoString("RunMacroText('/click QuestFrameCompleteQuestButton')");
                }
                if (Me.QuestLog.GetQuestById(13884) != null && !Me.QuestLog.GetQuestById(13884).IsCompleted && !Me.HasAura(65178) && MobArctanus.Count > 0)
                {
                    MobArctanus[0].Interact();
                    Thread.Sleep(1000);
                }
                if (Me.QuestLog.GetQuestById(24950) != null && !Me.QuestLog.GetQuestById(24950).IsCompleted && MobTidecrusher.Count > 0)
                {
                    MobTidecrusher[0].Interact();
                    MobTidecrusher[0].Face();
                    Styx.CommonBot.Routines.RoutineManager.Current.Pull();
                }
                if (Me.QuestLog.GetQuestById(10584) != null && !Me.QuestLog.GetQuestById(10584).IsCompleted && MobElectromental.Count > 0)
                {
                    MobElectromental[0].Interact();
                    MobElectromental[0].Face();
                    Lua.DoString("UseItemByName(30656)");
                    Thread.Sleep(4000);
                }
                if (Me.QuestLog.GetQuestById(10609) != null && !Me.QuestLog.GetQuestById(10609).IsCompleted && MobNetherWhelp.Count > 0)
                {
                    MobNetherWhelp[0].Interact();
                    MobNetherWhelp[0].Face();
                    Lua.DoString("UseItemByName(30742)");
                    Thread.Sleep(4000);
                }
                if (Me.QuestLog.GetQuestById(10609) != null && !Me.QuestLog.GetQuestById(10609).IsCompleted && IsObjectiveComplete(1, 10609) && MobProtoNetherDrake.Count > 0)
                {
                    MobProtoNetherDrake[0].Interact();
                    MobProtoNetherDrake[0].Face();
                    Lua.DoString("UseItemByName(30742)");
                    Thread.Sleep(4000);
                }
                if (Me.QuestLog.GetQuestById(10609) != null && !Me.QuestLog.GetQuestById(10609).IsCompleted && IsObjectiveComplete(2, 10609) && MobAdolescentNetherDrake.Count > 0)
                {
                    MobAdolescentNetherDrake[0].Interact();
                    MobAdolescentNetherDrake[0].Face();
                    Lua.DoString("UseItemByName(30742)");
                    Thread.Sleep(4000);
                }
                if (Me.QuestLog.GetQuestById(10609) != null && !Me.QuestLog.GetQuestById(10609).IsCompleted && IsObjectiveComplete(3, 10609) && MobMatureNetherDrake.Count > 0)
                {
                    MobMatureNetherDrake[0].Interact();
                    MobMatureNetherDrake[0].Face();
                    Lua.DoString("UseItemByName(30742)");
                    Thread.Sleep(4000);
                }
                if (Me.QuestLog.GetQuestById(10830) != null && !Me.QuestLog.GetQuestById(10830).IsCompleted && MobKoiKoiSpirit.Count > 0)
                {
                    MobKoiKoiSpirit[0].Interact();
                    MobKoiKoiSpirit[0].Face();
                    Styx.CommonBot.Routines.RoutineManager.Current.Pull();
                }
                if (Me.QuestLog.GetQuestById(10345) != null && !Me.Combat && MobWitheredCorpse.Count > 0)
                {
                    WoWMovement.MoveStop();
                    Lua.DoString("UseItemByName(29473)");
                    Thread.Sleep(500);
                }
                if (Me.QuestLog.GetQuestById(28632) != null && !Me.QuestLog.GetQuestById(28632).IsCompleted && !Me.Combat && MobGlacierIce.Count > 0)
                {
                    MobGlacierIce[0].Interact();
                }
                if (Me.QuestLog.GetQuestById(11606) != null && Me.QuestLog.GetQuestById(11606).IsCompleted && Me.QuestLog.GetQuestById(11598) != null && Me.QuestLog.GetQuestById(11598).IsCompleted && Me.QuestLog.GetQuestById(11611) != null && Me.QuestLog.GetQuestById(11611).IsCompleted && Me.Combat)
                {
                    Navigator.MoveTo(new WoWPoint(2732.637f, 6132.453f, 77.65173f));
                }
                if (Me.QuestLog.GetQuestById(11794) != null && Me.QuestLog.GetQuestById(11794).IsCompleted && !Me.Combat && !Me.HasAura(46078))
                {
                    WoWMovement.MoveStop();
                    Lua.DoString("UseItemByName(35125)");
                    Thread.Sleep(500);
                }
                if (CPsettings.Instance.AntiStuckSystem)
                {
                    if (!Me.Mounted || Me.OnTaxi)
                    {
                        MountedTime.Restart();
                    }
                    if (Me.IsAlive && Me.Mounted && !Me.OnTaxi && MountedTime.ElapsedMilliseconds > 600000)
                    {
                        Logging.Write(@"[CavaPlugin-AntiStuck] Char is Mounted for more than 10 min : Forcing Dismount..." + DateTime.Now.ToString());
                        Mount.Dismount();
                        Thread.Sleep(2000);
                        Lua.DoString("Dismount()");
                        MountedTime.Restart();
                    }
                    if (!TreeRoot.IsRunning && UltimoSemStuck.ElapsedMilliseconds > 30000)
                    {
                        Logging.Write(@"[CavaPlugin-AntiStuck] LastPosition reseted, bot is not running (but pulse is called ???)");
                        UltimoSemStuck.Restart();
                        return;
                    }
                    if (UltimoLocal.Distance(Me.Location) > 10f)
                    {
                        UltimoSemStuck.Restart();
                        UltimoLocal = Me.Location;
                        NVezesBotUnstuck = 0;
                        return;
                    }
                    if (Me.IsAlive && Me.IsAFKFlagged && !Me.IsCasting && !Me.IsMoving && !Me.Combat && !Me.OnTaxi && NVezesBotUnstuck == 0)
                    {
                        Logging.Write("[CavaPlugin-AntiStuck] I'm AFK flagged, Anti-Afking at " + DateTime.Now.ToString());
                        WoWMovement.Move(WoWMovement.MovementDirection.JumpAscend, TimeSpan.FromMilliseconds(100));
                        Thread.Sleep(2000);
                        KeyboardManager.KeyUpDown((char)KeyboardManager.eVirtualKeyMessages.VK_SPACE);
                        Thread.Sleep(2000);
                        KeyboardManager.AntiAfk();
                        Thread.Sleep(2000);
                        Mount.Dismount();
                        Thread.Sleep(2000);
                        Lua.DoString("Dismount()");
                        Thread.Sleep(2000);
                        StyxWoW.ResetAfk();
                        NVezesBotUnstuck++;
                    }
                    if (Styx.CommonBot.Frames.AuctionFrame.Instance.IsVisible || Styx.CommonBot.Frames.MailFrame.Instance.IsVisible)
                    {
                        UltimoSemStuck.Restart();
                        UltimoLocal = Me.Location;
                        return;
                    }
                    if (Me.HasAura("Resurrection Sickness"))
                    {
                        UltimoSemStuck.Restart();
                        return;
                    }
                    if (UltimoSemStuck.ElapsedMilliseconds > 300000 && NVezesBotUnstuck == 0)
                    {
                        Logging.Write(@"[CavaPlugin-AntiStuck] not moving last 5 min : Forcing Dismount..." + DateTime.Now.ToString());
                        Mount.Dismount();
                        Thread.Sleep(2000);
                        Lua.DoString("Dismount()");
                        NVezesBotUnstuck++;
                    }
                    if (UltimoSemStuck.ElapsedMilliseconds > 600000 && NVezesBotUnstuck == 1)
                    {
                        Logging.Write(@"[CavaPlugin-AntiStuck] not moving last 10 min : Restarting bot..." + DateTime.Now.ToString());
                        Recomecar.Start();
                        NVezesBotUnstuck++;
                    }
                    if (UltimoSemStuck.ElapsedMilliseconds > 900000 && Me.ZoneId != 1519 && Me.ZoneId != 1637)
                    {
                        Logging.Write(@"[CavaPlugin-AntiStuck] not moving last 15 min : Closing WOW Game..." + DateTime.Now.ToString());
                        Lua.DoString(@"ForceQuit()");
                    }
                }
            }
        }
        #endregion
    }
}
