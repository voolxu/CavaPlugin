using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using Styx;
using Styx.Helpers;
using Styx.Plugins;
using Styx.Common;
using Styx.CommonBot;
using Styx.CommonBot.POI;
using Styx.CommonBot.Profiles;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace CavaPlugin
{
    // ReSharper disable UnusedMember.Global
    public class CavaPlugin : HBPlugin
    // ReSharper restore UnusedMember.Global
    {
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
        private Stopwatch _ultimoSemStuck;
        private Stopwatch _summonpettime;
        private Stopwatch _mountedTime;
        private int _refusetime;
        private WoWPoint _ultimoLocal;
        
        private Stopwatch _asLastSavedTimer; 
        private WoWPoint _asLastSavedPosition;
        private bool _asLastSavedPositionTrigger;
        
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
        static readonly SoundPlayer Player = new SoundPlayer();
        public override string Author { get { return "Cava"; } }
        public override Version Version { get { return new Version(4, 1, 4); } }
        public override string Name { get { return "CavaPlugin"; } }
        public override bool WantButton { get { return true; } }
        public override string ButtonText { get { return "Cava Profiles"; } }
        public override void OnButtonPress()
        {
            var isRunningantes = TreeRoot.IsRunning;
            if (isRunningantes)
            {
                // ReSharper disable ResourceItemNotResolved
                MessageBox.Show(_rm.GetString("Bot_is_running_stop_bot_before_initiate_Cava_Plugin", _ci), _rm.GetString("error", _ci), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ReSharper disable PossiblyMistakenUseOfParamsMethod
        private readonly string _pathToCavaArmageddoner = Path.Combine(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\Armageddoner\");
        private readonly string _pathToPbMiningBs = Path.Combine(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\PB\MB\");
        private static readonly string PathToCavaPlugin = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\");
        private static readonly string PathToCavaProfiles = Path.Combine(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\");
        private static readonly string PathToCavaQBs = Path.Combine(Utilities.AssemblyDirectory + @"\Quest Behaviors\Cava\");
        // ReSharper restore PossiblyMistakenUseOfParamsMethod
        static bool UpdaterCava(string f, string stuff)
        {
            var p = new Process {StartInfo = {FileName = "TortoiseProc.exe", Arguments = f}};
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

        public override void OnEnable()
        {
            CPGlobalSettings.Instance.Load();
            if (!CPGlobalSettings.Instance.languageselected)
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
                    _ci = new CultureInfo("pt-PT");
                    _rm = new ResourceManager("Lang.pt", _assembly);
                    break;
                case 4:
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
                        _rm.GetString("Please_download_and_update_your_version_to_latest_one", _ci) + Environment.NewLine +
                        _rm.GetString("This_version_have_some_problems_with_TortoiseSVN", _ci) + Environment.NewLine +
                        _rm.GetString("Download_latest_version_from_HB_Forum", _ci) , _rm.GetString("information", _ci), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Player.SoundLocation = PathToCavaPlugin + "Sounds\\Information.wav";
                    Player.Play();
                    return;
                }
                Debug(_rm.GetString("Loading_CavaPlugin", _ci));
                /*if (!File.Exists(PathToCavaPlugin + "Settings\\Instaled.txt"))
                {
                    MessageBox.Show(_rm.GetString("Welcome_to_CavaPlugin", _ci) + Environment.NewLine +
                                    _rm.GetString("CavaPlugin_use_TortoiseSVN_to_download_files_Make_sure_you_have_it", _ci) + Environment.NewLine +
                                    _rm.GetString("CavaPlugin_will_now_auto_install_required_files_to_work", _ci) + Environment.NewLine +
                                    _rm.GetString("Remove_Previus_Cava_Behaviors_or_Cava_Profiles_before_continue", _ci) + Environment.NewLine +
                                    _rm.GetString("Press_Yes_OK_when_prompt_by_TortoiseSVN_windows", _ci) + Environment.NewLine +
                                    Environment.NewLine +
                                    _rm.GetString("Press_OK_to_continue", _ci), _rm.GetString("information", _ci), MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    Player.SoundLocation = PathToCavaPlugin + "Sounds\\Information.wav";
                    Player.Play();
                    
                    if (Directory.Exists(PathToCavaQBs))
                    {
                        MessageBox.Show(_rm.GetString("There_is_an_old_folder_from_previus_instalation_remove", _ci) + Environment.NewLine + 
                            PathToCavaQBs + Environment.NewLine +
                                _rm.GetString("before_continue", _ci) , _rm.GetString("error", _ci), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error.wav";
                        Player.Play();
                        return;
                    }
                    if (Directory.Exists(PathToCavaProfiles))
                    {
                        MessageBox.Show(_rm.GetString("There_is_an_old_folder_from_previus_instalation_remove", _ci) + Environment.NewLine +
                            PathToCavaProfiles + Environment.NewLine +
                                _rm.GetString("before_continue", _ci), _rm.GetString("error", _ci), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error.wav";
                        Player.Play();
                        return;
                    }
                    //cavaplugin
                    try
                    {
                        if (UpdaterCava("/command:\"checkout\" /url:\"http://cavaplugin.googlecode.com/svn/trunk/\" /path:\"" + PathToCavaPlugin + "\" /noquestion /closeonend:1", ""))
                        {
                            Debug(_rm.GetString("Cava_Plugin_sucefull_checkout", _ci));
                        }
                        else
                        {
                            Err(_rm.GetString("There_is_a_problem_with_checkout_Cava_Plugin", _ci));
                            Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                            Player.Play();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Err(_rm.GetString("There_is_a_problem_with_checkout_Cava_Plugin", _ci));
                        Err("Exception " + ex.Message);
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                        Player.Play();
                        return;
                    }
                    Debug(_rm.GetString("Congratulations_Cava_Plugin_Sucefully_checkout", _ci));

                    //cava quest behaviors
                    try
                    {
                        Directory.CreateDirectory(PathToCavaQBs);
                    }
                    catch (Exception ex)
                    {
                        Err(_rm.GetString("Failed_to_Create_Cava_Quest_Behavior_Folder", _ci));
                        Err("Exception " + ex.Message);
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                        Player.Play();
                        return;
                    }
                    try
                    {
                        if (
                            UpdaterCava("/command:\"checkout\" /url:\"http://cavaqbs.googlecode.com/svn/trunk/Cava/\" /path:\"" + PathToCavaQBs + "\" /closeonend:1", ""))
                        {
                            Debug(_rm.GetString("Cava_Quest_Behavior_sucefull_checkout", _ci));
                        }
                        else
                        {
                            Err(_rm.GetString("There_is_a_problem_with_checkout_Cava_Quest_Behaviors", _ci));
                            Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                            Player.Play();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Err(_rm.GetString("There_is_a_problem_with_checkout_Cava_Quest_Behaviors", _ci));
                        Err("Exception " + ex.Message);
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                        Player.Play();
                        return;
                    }
                    Debug(_rm.GetString("Congratulations_Cava_Quest_Behaviors_Sucefully_Created_and_checkout", _ci));

                    //cava profiles
                    try
                    {
                        Directory.CreateDirectory(PathToCavaProfiles);
                    }
                    catch (Exception ex)
                    {
                        Err(_rm.GetString("Failed_to_Create_Cava_Profiles_Folder", _ci));
                        Err("Exception " + ex.Message);
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                        Player.Play();
                        return;
                    }

                    try
                    {
                        if (UpdaterCava("/command:\"checkout\" /url:\"http://cavaprofiles.googlecode.com/svn/trunk/\" /path:\"" + PathToCavaProfiles + "\" /closeonend:1", ""))
                        {
                            Debug(_rm.GetString("Cava_Profiles_sucefull_checkout", _ci));
                        }
                        else
                        {
                            Err(_rm.GetString("There_is_a_problem_with_checkout_Cava_Profiles", _ci));
                            Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                            Player.Play();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Err(_rm.GetString("There_is_a_problem_with_checkout_Cava_Profiles", _ci));
                        Err("Exception " + ex.Message);
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                        Player.Play();
                        return;
                    }
                    Debug(_rm.GetString("Congratulations_Cava_Profiles_Sucefully_Created_and_checkout", _ci));
                    
                    var file = new StreamWriter(PathToCavaPlugin + "Settings\\Instaled.txt");
                    file.Write("Instaled = True");
                    file.Close();
                    CPGlobalSettings.Instance.PBMiningBlacksmithing = false;
                    CPGlobalSettings.Instance.AllowUpdate = false;
                    _cavaupdated = true;
                }*/
                Debug(_rm.GetString("Please_Wait_While_CavaPlugin_Check_For_Updates", _ci));
                //update Plugin
                if (CavaPluginUpdater.UpdateAvailable("http://cavaplugin.googlecode.com/svn/trunk/", "Plugin.ver"))
                {
                    var newrev =
                    CavaPluginUpdater.GetNewestRev("http://cavaplugin.googlecode.com/svn/trunk/").ToString(CultureInfo.InvariantCulture);
                    Debug(_rm.GetString("Cava_Plugin_Update_to_0_is_available_You_are_on_1", _ci), newrev,CavaPluginUpdater.GetCurrentRev("Plugin.ver").ToString(CultureInfo.InvariantCulture));
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
                    var newrev = CavaPluginUpdater.GetNewestRev("http://cavaprofiles.googlecode.com/svn/trunk/").ToString(CultureInfo.InvariantCulture);
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
                if (CPGlobalSettings.Instance.BotAllowUpdate && CPGlobalSettings.Instance.AllowUpdate)
                {
                    if (UpdaterCava("/command:\"update\" /path:\"" + _pathToCavaArmageddoner + "\" /closeonend:1",
                                    "AllowUpdate"))
                    {
                        Debug(_rm.GetString("Armageddoner_are_up_to_date", _ci));
                    }
                    else
                    {
                        Err(_rm.GetString("There_is_a_problem_updating", _ci) + " Armageddoner.");
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                        Player.Play();
                    }
                }
                //fazer update de PBs
                if (CPGlobalSettings.Instance.BotPBMiningBlacksmithing &&
                    CPGlobalSettings.Instance.PBMiningBlacksmithing)
                {
                    if (UpdaterCava("/command:\"update\" /path:\"" + _pathToPbMiningBs + "\" /closeonend:1",
                                    "AllowUpdate"))
                    {
                        Debug(_rm.GetString("Mining_and_Blacksmithing_1_to_600_are_up_to_date", _ci));
                    }
                    else
                    {
                        Err(_rm.GetString("There_is_a_problem_updating_Mining_Blacksmithing_1_to_600", _ci));
                        Player.SoundLocation = PathToCavaPlugin + "Sounds\\Error2.wav";
                        Player.Play();
                    }
                }
                if (!_erro)
                {
                    Debug(_cavaupdated ? _rm.GetString("is_now_up_to_date_Please_reload_HB", _ci) : _rm.GetString("is_up_to_date_and_ready", _ci));
                }
                _hasBeenInitialized = true;
                CPGlobalSettings.Instance.Save();
                 if (_cavaupdated && CPGlobalSettings.Instance.AutoShutdownWhenUpdate)
                {
                    Debug(_rm.GetString("Auto_Shutdown_in_progress_at", _ci) + " " + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
                _mountedTime = new Stopwatch();
                _summonpettime = new Stopwatch();
                _ultimoSemStuck = new Stopwatch();
                _asLastSavedTimer = new Stopwatch();
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
            BotEvents.OnBotStartRequested -= _OnBotStart;
            Log(_rm.GetString("CavaPlugin_Disposed", _ci));
            if (!_botRunning) return;
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

        private void _OnBotStart(EventArgs args)
        {
            if (_onbotstart)
            {
                CPsettings.Instance.Load();
                if (ProfileManager.CurrentProfile.Name.Contains("[Cava]") && !_botRunning)
                {
                    _botRunning = true;
                    Log(_rm.GetString("Is_now_ENABLED", _ci));
                }
                if (!ProfileManager.CurrentProfile.Name.Contains("[Cava]") && _botRunning)
                {
                    _botRunning = false;
                    Log(_rm.GetString("Is_now_DISABLED", _ci));
                }
                if (_botRunning)
                {
                    Log(CPsettings.Instance.AntiStuckSystem
                            ? _rm.GetString("System_Anti-Stuck_Enabled", _ci)
                            : _rm.GetString("System_Anti-Stuck_Disabled", _ci));
                    _mountedTime.Restart();
                    _recomecar = new Thread(_Recomecar);
                    _asLastSavedTimer.Restart();

                    if (CPsettings.Instance.CheckAllowSummonPet)
                    {
                        var numMinipets = Lua.GetReturnVal<int>("return C_PetBattles.GetNumPets(1)", 0);
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

                    if (CPsettings.Instance.refusepartyInvitescheck)
                    {
                        Log(_rm.GetString("Refuse_party_invites_Enabled", _ci));
                        Lua.Events.AttachEvent("PARTY_INVITE_REQUEST", RotinaPartyInvites);
                    }
                    else 
                    {
                        Log(_rm.GetString("Refuse_party_invites_Disabled", _ci));
                    }

                    if (CPsettings.Instance.refusetradeInvitescheck)
                    {
                        Log(_rm.GetString("Refuse_trade_invites_Enabled", _ci));
                        Lua.Events.AttachEvent("TRADE_SHOW", RotinaTradeInvites);
                    }
                    else 
                    {
                        Log(_rm.GetString("Refuse_trade_invites_Disabled", _ci));
                    }

                    if (CPsettings.Instance.refuseduelInvitescheck)
                    {
                        Log(_rm.GetString("Refuse_duel_invites_Enabled", _ci));
                        Lua.Events.AttachEvent("DUEL_REQUESTED", RotinaDuelInvites);
                    }
                    else 
                    {
                        Log(_rm.GetString("Refuse_duel_invites_Disabled", _ci));
                        // ReSharper restore ResourceItemNotResolved
 
                    }
                }
                _onbotstart = false;
            }
            else
            { _onbotstart = true; }
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
                Log("Accepting guild invite from {0}", guildName);
                Lua.DoString("AcceptGuild()");
                Lua.DoString("StaticPopup_Hide(\"GUILD_INVITE_REQUEST\")");
            }
            if (CPsettings.Instance.refuseguildInvitescheck || guildLevel < 25)
            {
                _refuseguildtimer.Reset();
                _refuseguildtimer.Start();
                _refusetime = RandomNumber(3000, 8000);
                _gotGuildInvite = true;
                Log("Declining guild invite from {0} lvl {1} in " + _refusetime / 1000 + " seconds", guildName, guildLevel);
            }
        }

        private void RotinaPartyInvites(object sender, LuaEventArgs e)
        {
            var userInviter = e.Args[1].ToString();
            _refusepartytimer.Reset();
            _refusepartytimer.Start();
            _refusetime = RandomNumber(3000, 8000);
            _gotPartyInvite = true;
            Log("[CavaPlugin - Declining party invite from {0} in " + _refusetime / 1000 + " seconds", userInviter);
        }

        private void RotinaTradeInvites(object sender, LuaEventArgs e)
        {
            _refusetradetimer.Reset();
            _refusetradetimer.Start();
            _refusetime = RandomNumber(3000, 8000);
            _gotTradeinvite = true;
            Log("[CavaPlugin - Declining trade in " + _refusetime / 1000 + " seconds");
        }

        private void RotinaDuelInvites(object sender, LuaEventArgs e)
        {
            var userInviter = e.Args[1].ToString();
            _refusedueltimer.Reset();
            _refusedueltimer.Start();
            _refusetime = RandomNumber(3000, 8000);
            _gotDuelinvite = true;
            Log("[CavaPlugin - Declining duel invite from {0} in " + _refusetime / 1000 + " seconds", userInviter);
        }

        private static void _Recomecar()
        {
            TreeRoot.Stop();
            Thread.Sleep(2000);
            TreeRoot.Start();
        }

        private static bool IsObjectiveComplete(int objectiveId, uint questId)
        {
            if (Me.QuestLog.GetQuestById(questId) == null)
            {
                return false;
            }
            var returnVal = Lua.GetReturnVal<int>(string.Format("return GetQuestLogIndexByID({0})", questId), 0);
            return Lua.GetReturnVal<bool>(string.Format("return GetQuestLogLeaderBoard({0},{1})", objectiveId, returnVal), 2);
        }

        private String NewProfilePath
        {
            get
            {
                var directory = Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\";
                return (Path.Combine(directory, _profileName));
            }
        }

        private String _profileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"Plugins\CavaPlugin\Settings\Main-Settings.xml"));
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

        private static List<WoWUnit> MobKingGennGreymane { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 36332)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobDocZapnozzle { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 36608)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobArctanus { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 34292)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobTidecrusher { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 38750 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobElectromental { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21729 && ret.IsAlive && !ret.HasAura(37136))).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobNetherWhelp { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 20021 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobProtoNetherDrake { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21821 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobAdolescentNetherDrake { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21817 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobMatureNetherDrake { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 21820 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobKoiKoiSpirit { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 22226 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobWitheredCorpse { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 20561 && ret.Distance < 16 && ret.HasAura(31261))).OrderBy(ret => ret.Distance).ToList(); } }
        private static List<WoWUnit> MobGlacierIce { get { return ObjectManager.GetObjectsOfType<WoWUnit>().Where(ret => (ret.Entry == 49233 && ret.IsAlive)).OrderBy(ret => ret.Distance).ToList(); } }
        private static WoWItem ItemCelebrationPack { get { return (StyxWoW.Me.CarriedItems.FirstOrDefault(i => i.Entry == 90918)); } }
        //private static WoWItem ItemHs { get { return (StyxWoW.Me.CarriedItems.FirstOrDefault(i => i.Entry == 6948)); } }

        #endregion

        #region Override Pulse
        public override void Pulse()
        {
            if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 300 by Cava" ||
                ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 600 by Cava")
            {
                Log("Loading '{0}'", ProfileManager.CurrentOuterProfile.Name);
                Thread.Sleep(3000);
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
                                Thread.Sleep(2000);
                                if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 600 by Cava") { _profileName = "PB\\MB\\[PB]MB(Cava).xml"; }
                                if (ProfileManager.CurrentOuterProfile.Name == "Mining Blacksmithing 1 to 300 by Cava") { _profileName = "Free_PB\\[PB]MB(Cava).xml"; }
                                ProfileManager.LoadNew(NewProfilePath, false);
                                TreeRoot.Start();
                            }));
                }
            }
            if (Me.IsDead && !Me.HasAura(8326) && CPGlobalSettings.Instance.RessAfterDie)
            {
                Thread.Sleep(5000);
                Log("Anti-Bug Release System");
                Lua.DoString("RunMacroText('/click StaticPopup1Button1')");
            }
            if (_botRunning)
            {
                if (_gotGuildInvite && _refuseguildtimer.ElapsedMilliseconds >= _refusetime)
                {
                    Lua.DoString("DeclineGuild()");
                    Lua.DoString("StaticPopup_Hide(\"GUILD_INVITE\")");
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

                if (CPsettings.Instance.CheckAllowSummonPet && _summonpettime.Elapsed.TotalMinutes > 30)
                {
                    Log("Summoning Random pet.");
                    Lua.DoString("RunMacroText('/randompet')");
                    _summonpettime.Restart();
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
                if (Me.QuestLog.GetQuestById(11794) != null && Me.QuestLog.GetQuestById(11794).IsCompleted && !Me.Combat && !Me.HasAura(46078))
                {
                    WoWMovement.MoveStop();
                    Lua.DoString("UseItemByName(35125)");
                    Thread.Sleep(500);
                }
                if (Me.IsAlive && !Me.HasAura(132700) && !Me.IsOnTransport && !Me.OnTaxi && !Me.Mounted && !Me.IsCasting && !Me.Combat && ItemCelebrationPack != null)
                {
                    Log("Using Celebration Package 9Th Aniversary at " + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    WoWMovement.MoveStop();
                    Lua.DoString("UseItemByName(90918)");
                    Thread.Sleep(500);
                }
                
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
                        Log("[AntiStuck] Char is Mounted for more than 6 secs and stuck : Forcing Dismount..." + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        Mount.Dismount();
                        Thread.Sleep(2000);
                        Lua.DoString("Dismount()");
                        _mountedTime.Restart();
                        _asLastSavedPositionTrigger = true;
                    }
                    if (Me.IsAlive && Me.Mounted && !Me.OnTaxi && _mountedTime.ElapsedMilliseconds > 600000)
                    {
                        Log("[AntiStuck] Char is Mounted for more than 10 min : Forcing Dismount..." + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        Mount.Dismount();
                        Thread.Sleep(2000);
                        Lua.DoString("Dismount()");
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
                        Log("[CavaPlugin-AntiStuck] I'm AFK flagged, Anti-Afking at " + DateTime.Now.ToString(CultureInfo.InvariantCulture));
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
                        _nVezesBotUnstuck++;
                    }
                    if (Styx.CommonBot.Frames.AuctionFrame.Instance.IsVisible || Styx.CommonBot.Frames.MailFrame.Instance.IsVisible)
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
                        Log("[CavaPlugin-AntiStuck] not moving last 5 min : Forcing Dismount..." + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        Mount.Dismount();
                        Thread.Sleep(2000);
                        Lua.DoString("Dismount()");
                        _nVezesBotUnstuck++;
                    }
                    if (_ultimoSemStuck.ElapsedMilliseconds > 600000 && _nVezesBotUnstuck == 1)
                    {
                        Log("[CavaPlugin-AntiStuck] not moving last 10 min : Restarting bot..." + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        _recomecar.Start();
                        _nVezesBotUnstuck++;
                    }
                    if (_ultimoSemStuck.ElapsedMilliseconds > 900000 && Me.ZoneId != 1519 && Me.ZoneId != 1637)
                    {
                        Log("[CavaPlugin-AntiStuck] not moving last 15 min : Closing WOW Game..." + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        Lua.DoString(@"ForceQuit()");
                    }
                  }
            }
        }
        #endregion
    }
}
