using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics; 
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Globalization;

using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.CommonBot.Frames;
using Styx.CommonBot.Profiles;
using Styx.Helpers;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

using DefaultValue = Styx.Helpers.DefaultValueAttribute;

namespace CavaPlugin
{
    public partial class CavaForm : Form
    {
        public int lastUseProfile = 0; // Ultimo Profile usado.
        public bool ArmaguedonerAllow = false;
        public int seconds = 15; // Segundos do countdown.
        public int numberBotBase;
        public string pathToCharSettings = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\Settings\Char" + StyxWoW.Me.Name + ".xml");
        public string pathToSettings = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\Settings\Main-Settings.xml");
        public string pathToProfiles = Path.Combine(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\");
        public string profileToLoad = "";
        public string pathToDoYouKnow = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\Settings\DYK.txt");
        static int TortoiseExitCode;
        bool isRunningdepois;
        public string leveling1to90txt;
        public string levelingpandahordetxt;
        public string levelingpandaallytxt;
        public string level85to90txt;
        public string levelingarmagessonertxt;
        public string mbs1300;
        public string mbs1600;
        public string mbs1300txt;
        public string mbs1600txt;

        public CavaForm()
        {
            InitializeComponent();
        }
        static void Updater_Armageddoner(string f)
        {
            Process p = new Process();
            p.StartInfo.FileName = "TortoiseProc.exe";
            p.StartInfo.Arguments = f;
            p.Start();
            p.WaitForExit();
            TortoiseExitCode = p.ExitCode;
        }
        private void getRes(CultureInfo ci, ResourceManager rm)
        {
            tabPage3.Text = rm.GetString("about", ci);
            tabPage9.Text = rm.GetString("armageddoner", ci);
            button4.Text = rm.GetString("cancel", ci);
            button3.Text = rm.GetString("close", ci);
            tabPage6.Text = rm.GetString("dailies", ci);
            tabPage5.Text = rm.GetString("farming", ci);
            groupBox12.Text = rm.GetString("goodtoknow", ci);
            label1.Text = rm.GetString("lastusedprofile", ci);
            tabPage4.Text = rm.GetString("levelinggrind", ci);
            tabPage2.Text = rm.GetString("levelingquest", ci);
            tabPage1.Text = rm.GetString("main", ci);
            ReservedTextBox.Text = rm.GetString("newtxt", ci);
            tabPage8.Text = rm.GetString("professions", ci);
            button5.Text = rm.GetString("reportabug", ci);
            tabPage7.Text = rm.GetString("reputation", ci);
            groupBox6.Text = rm.GetString("reservedfortesters", ci);
            label3.Text = rm.GetString("secondstostart", ci);
            button1.Text = rm.GetString("start", ci);
            button2.Text = rm.GetString("start", ci);
            button6.Text = rm.GetString("start", ci);
            tabPage10.Text = rm.GetString("usefulllinks", ci);
            groupBox1.Text = rm.GetString("selectoneprofile", ci);
            groupBox10.Text = rm.GetString("selectoneprofile", ci);
            radioButton1.Text = rm.GetString("leveling1to90", ci);
            radioButton2.Text = rm.GetString("levelingpandahorde", ci);
            radioButton3.Text = rm.GetString("levelingpandaally", ci);
            radioButton4.Text = rm.GetString("level85to90", ci);
            radioButton5.Text = rm.GetString("levelingarmagessoner", ci);
            leveling1to90txt = rm.GetString("leveling1to90txt", ci);
            levelingpandahordetxt = rm.GetString("levelingpandahordetxt", ci);
            levelingpandaallytxt = rm.GetString("levelingpandaallytxt", ci);
            level85to90txt = rm.GetString("level85to90txt", ci);
            levelingarmagessonertxt = rm.GetString("levelingarmagessonertxt", ci);
            mbs1300 = rm.GetString("miningbs1300", ci);
            mbs1600 = rm.GetString("miningbs1600", ci);
            mbs1300txt = rm.GetString("mbs1300txt", ci);
            mbs1600txt = rm.GetString("mbs1600txt", ci);
            groupBox4.Text = rm.GetString("reservedfortesters", ci);
            label15.Text = rm.GetString("language", ci);
            AllowDownloadCheckBox.Text = rm.GetString("autodownload", ci);
            AntiStuck_CheckBox.Text = rm.GetString("antistuck", ci);
            AutoShutDown_Checkbox.Text = rm.GetString("autoshutdown", ci);
            AllowSummonPet_Checkbox.Text = rm.GetString("summompets", ci);
            languageGroupBox.Text = rm.GetString("pbprofiles", ci);
            MiningBS_Checkbox.Text = rm.GetString("pbmbs", ci);
            ResscheckBox.Text = rm.GetString("ressafterdie", ci);
            groupBox8.Text = rm.GetString("linksrelated", ci);
            label17.Text = rm.GetString("problemsconfiguring", ci);
            label19.Text = rm.GetString("problemsquesting", ci);
            groupBox7.Text = rm.GetString("linksrelatedplugins", ci);
            groupBox9.Text = rm.GetString("cavaweb", ci);
            groupBox13.Text = rm.GetString("cavaprofessions", ci);
            groupBox2.Text = rm.GetString("specialthanks", ci);
            groupBox3.Text = rm.GetString("showursupport", ci);
            richTextBox3.Text = rm.GetString("pressdonation", ci);
            label4.Text = rm.GetString("lastusedprofiletxtdef", ci);
            if (lastUseProfile == 1) { label4.Text = rm.GetString("leveling1to90", ci); }
            if (lastUseProfile == 2) { label4.Text = rm.GetString("levelingpandahorde", ci); }
            if (lastUseProfile == 3) { label4.Text = rm.GetString("levelingpandaally", ci); }
            if (lastUseProfile == 4) { label4.Text = rm.GetString("level85to90", ci); }
            if (lastUseProfile == 5) { label4.Text = rm.GetString("levelingarmagessoner", ci); }
            if (File.Exists(pathToProfiles + "PB\\MB\\Scripts\\[PB]MB600(Cava).txt"))
            {
                MiningBlacksmithingProf.Text = rm.GetString("miningbs1600", ci);
            }
            if (!File.Exists(pathToProfiles + "PB\\MB\\Scripts\\[PB]MB600(Cava).txt"))
            {
                MiningBlacksmithingProf.Text = rm.GetString("miningbs1300", ci);
            }

            if (!File.Exists(pathToProfiles + "PB\\MB\\Scripts\\[PB]MB600(Cava).txt") && lastUseProfile == 7)
            {
                lastUseProfile = 8;
            }
            if (File.Exists(pathToProfiles + "PB\\MB\\Scripts\\[PB]MB600(Cava).txt") && lastUseProfile == 8)
            {
                lastUseProfile = 7;
            }
            if (lastUseProfile == 7)
            {
                label4.Text = rm.GetString("miningbs1600", ci);
                MiningBlacksmithingProf.Text = rm.GetString("miningbs1600", ci);
            }
            if (lastUseProfile == 8)
            {
                label4.Text = rm.GetString("miningbs1300", ci);
                MiningBlacksmithingProf.Text = rm.GetString("miningbs1300", ci);
            }
        }

        private void CavaForm_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\main.png");
            pictureBox2.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\quests.png");
            pictureBox3.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\about.png");
            pictureBox4.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\donate.png");
            pictureBox5.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\main.png");
            NewpictureBox.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\new.gif");
            pictureBox7.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\main.png");
            pictureBox6.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\main.png");
            UpdateStuff();
        }

        public void UpdateStuff()
        {
            CPsettings.Instance.Load();
            CPGlobalSettings.Instance.Load();
            lastUseProfile = CPsettings.Instance.lastUsedPath;
            AntiStuck_CheckBox.Checked = CPGlobalSettings.Instance.AntiStuckSystem;
            AutoShutDown_Checkbox.Checked = CPGlobalSettings.Instance.AutoShutdownWhenUpdate;
            AllowSummonPet_Checkbox.Checked = CPGlobalSettings.Instance.CheckAllowSummonPet;
            if (!File.Exists(pathToProfiles + "PB\\MB\\Scripts\\[PB]MB600(Cava).txt"))
            {
                CPGlobalSettings.Instance.BotPBMiningBlacksmithing = false;
                CPGlobalSettings.Instance.PBMiningBlacksmithing = false;
                CPGlobalSettings.Instance.Save();
            }
            MiningBS_Checkbox.Checked = CPGlobalSettings.Instance.PBMiningBlacksmithing;
            linkLabel29.Enabled = CPGlobalSettings.Instance.PBMiningBlacksmithing;
            AllowDownloadCheckBox.Checked = CPGlobalSettings.Instance.AllowUpdate;
            ResscheckBox.Checked = CPGlobalSettings.Instance.RessAfterDie;
            if (!CPGlobalSettings.Instance.AllowUpdate)
            {
                AntiStuck_CheckBox.Checked = false;
                AntiStuck_CheckBox.Enabled = false;
                AutoShutDown_Checkbox.Checked = false;
                AutoShutDown_Checkbox.Enabled = false;
                AllowSummonPet_Checkbox.Checked = false;
                AllowSummonPet_Checkbox.Enabled = false;
                radioButton5.Enabled = false;
                groupBox6.Enabled = false;
                linkLabel4.Enabled = false;

                
                comboBox1.Enabled = false;
                CPGlobalSettings.Instance.language = 0;
                CPGlobalSettings.Instance.BotAllowUpdate = false;
                CPGlobalSettings.Instance.AllowUpdate = false;
                CPGlobalSettings.Instance.Save();
            }
            comboBox1.SelectedIndex = CPGlobalSettings.Instance.language;
            if (comboBox1.SelectedIndex == 0)
            {
                CultureInfo ci = new CultureInfo("en-US");
                string str = Assembly.GetExecutingAssembly().FullName;
                str = str.Remove(str.IndexOf(','));
                Assembly _assembly = Assembly.Load(str);
                ResourceManager rm = new ResourceManager("Lang", _assembly);
                getRes(ci, rm);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                CultureInfo ci = new CultureInfo("pt-PT");
                string str = Assembly.GetExecutingAssembly().FullName;
                str = str.Remove(str.IndexOf(','));
                Assembly _assembly = Assembly.Load(str);
                ResourceManager rm = new ResourceManager("Lang.pt", _assembly);
                getRes(ci, rm);
            }
            
            if (lastUseProfile > 0)
            {
                button1.Visible = true;
                label3.Visible = true;
                timer1.Enabled = true;
                label6.Visible = true;
                button4.Visible = true;
            }
            else
            {
                button1.Visible = false;
                label3.Visible = false;
                label6.Visible = false;
                button4.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lastUseProfile = 1; //Leveling 1 to 90
            richTextBox2.Text = leveling1to90txt;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lastUseProfile = 2; //Leveling Pandaren 1 to 90 Horde
            richTextBox2.Text = levelingpandahordetxt;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lastUseProfile = 3; //Leveling Pandaren 1 to 90 Alliance
            richTextBox2.Text = levelingpandaallytxt;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lastUseProfile = 4; //Leveling 85 to 90 With Loot 
            richTextBox2.Text = level85to90txt;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lastUseProfile = 5; //test profiles
            richTextBox2.Text = levelingarmagessonertxt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Dispose();
            CPsettings.Instance.lastUsedPath = lastUseProfile;
            CPGlobalSettings.Instance.Save();
            CPsettings.Instance.Save();
            nomeiaprofile();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds -= 1;
            label6.Text = seconds.ToString();
            if (seconds == 0)
            {
                timer1.Enabled = false;
                nomeiaprofile();
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        private void nomeiaprofile()
        {
            if (lastUseProfile == 1) { lancaprofile(pathToProfiles + "Next[Cava].xml"); }
            if (lastUseProfile == 2) { lancaprofile(pathToProfiles + "[Quest]Pandaren-Horde1to90By[Cava].xml"); }
            if (lastUseProfile == 3) { lancaprofile(pathToProfiles + "[Quest]Pandaren-Alliance1to90By[Cava].xml"); }
            if (lastUseProfile == 4) { lancaprofile(pathToProfiles + "[Quest]MOP85to90WithLootBy[Cava].xml"); }
            if (lastUseProfile == 5) { lancaprofile(pathToProfiles + "Armageddoner\\Next[Cava].xml"); }
            if (lastUseProfile == 6) { lancaprofile(pathToProfiles + "Armageddoner\\Next[Cava].xml"); }
            if (lastUseProfile == 7) { lancaprofile(pathToProfiles + "emptymb600.xml"); }
            if (lastUseProfile == 8) { lancaprofile(pathToProfiles + "emptymb300.xml"); }
        }

        private void lancaprofile(string ProfileToLoad)
        {
            //para relogio
            timer1.Dispose();

            //verifica se bot esta para ou a trabalhar
            bool isRunningantes = TreeRoot.IsRunning;
            if (isRunningantes)
            {
                CPGlobalSettings.Instance.Allowlunch = true;
                CPGlobalSettings.Instance.BaseProfileToLunch = lastUseProfile;
                CPGlobalSettings.Instance.Save();
                Close();
            }
            else
            {
                //muda para quest bot
                Styx.Helpers.CharacterSettings.Instance.Load();
                numberBotBase = Styx.Helpers.CharacterSettings.Instance.SelectedBotIndex;
                if (numberBotBase != 9)
                {
                    var questBot = BotManager.Instance.Bots.FirstOrDefault(kvp => kvp.Key == "Questing");
                    if (questBot.Key == "Questing")
                    {
                        BotManager.Instance.SetCurrent(questBot.Value);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Logging.Write("Unable to locate Questing bot");
                    }
                }
                //carrega novo profile
                Styx.CommonBot.Profiles.ProfileManager.LoadNew(ProfileToLoad);
                //isRunningdepois = TreeRoot.IsRunning;
                //if (!isRunningdepois) { TreeRoot.Start(); }
                Close();
                Thread.Sleep(2000);
                TreeRoot.Start();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=6MCR3XWLP273A");
            Process.Start(sInfo);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CPsettings.Instance.Save();
            CPGlobalSettings.Instance.Save();
            timer1.Dispose();
            Close();
            isRunningdepois = TreeRoot.IsRunning;
            if (isRunningdepois) { TreeRoot.Stop(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CPsettings.Instance.Save();
            CPGlobalSettings.Instance.Save();
            timer1.Enabled = false;
            //timer1.Dispose();
            nomeiaprofile();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://cava.repositoryhosting.com/trac/cava_profiles/wiki");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://cavaplugin.googlecode.com/svn/trunk/");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk-post1100415.html#post1100415");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk.html#post1061397");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk.html#post1062537");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk-post1067665.html#post1067665");
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk-post1094850.html#post1094850");
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk-post1096341.html#post1096341");
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk-3.html#post1150713");
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk.html#post1061411");
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk.html#post1067322");
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk-post1087063.html#post1087063");
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk.html#post1067373");
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk.html#post1067435");
        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk-post1105561.html#post1105561");
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk.html#post1067544");
        }

        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk-post1067958.html#post1067958");
        }

        private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk-post1067983.html#post1067983");
        }

        private void linkLabel21_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk-post1070048.html#post1070048");
        }

        private void linkLabel22_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk-post1096357.html#post1096357");
        }

        private void linkLabel23_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk-post1144989.html#post1144989");
        }

        private void linkLabel24_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk.html#post1067458");
        }

        private void linkLabel25_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/honorbuddy-guides/108771-help-desk.html#post1067458");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://cavaqbs.googlecode.com/svn/trunk/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://cavaprofiles.googlecode.com/svn/trunk/");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://cava.repositoryhosting.com/svn/cava_armageddoner");
        }

        private void linkLabel26_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.thebuddyforum.com/honorbuddy-forum/submitted-profiles/68612-cava-s-profiles-lvl-1-a.html");
        }

        private void linkLabel27_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://cava.repositoryhosting.com/trac/cava_profiles");
        }

        private void AntiStuck_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CPGlobalSettings.Instance.AntiStuckSystem = AntiStuck_CheckBox.Checked;
        }

        private void AutoShutDown_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            CPGlobalSettings.Instance.AutoShutdownWhenUpdate = AutoShutDown_Checkbox.Checked;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Dispose();
            CPsettings.Instance.lastUsedPath = lastUseProfile;
            CPGlobalSettings.Instance.Save();
            CPsettings.Instance.Save();
            nomeiaprofile();
        }

        private void CheckAllowSummonPet_CheckedChanged(object sender, EventArgs e)
        {
            CPGlobalSettings.Instance.CheckAllowSummonPet = AllowSummonPet_Checkbox.Checked;
        }

        private void MiningBS_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (MiningBS_Checkbox.Checked)
            {
                if (!CPGlobalSettings.Instance.BotPBMiningBlacksmithing)
                {
                    if (!Directory.Exists(pathToProfiles + "/PB/MB"))
                    {
                        Directory.CreateDirectory(pathToProfiles + "/PB/MB");
                        Updater_Armageddoner("/command:\"checkout\" /url:\"https://cava.repositoryhosting.com/svn/cava_mining_blacksmithing\" /path:\"" + pathToProfiles + "PB/MB" + "\" /closeonend:1");
                    }
                    else
                    {
                        Updater_Armageddoner("/command:\"update\" /url:\"https://cava.repositoryhosting.com/svn/cava_mining_blacksmithing\" /path:\"" + pathToProfiles + "PB/MB" + "\" /closeonend:1");
                    }
                    if (TortoiseExitCode != 0)
                    {
                        Directory.Delete(Path.Combine(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\PB\MB"));
                        MiningBS_Checkbox.Checked = false;
                        linkLabel29.Enabled = false;
                        CPGlobalSettings.Instance.BotPBMiningBlacksmithing = false;
                        CPGlobalSettings.Instance.PBMiningBlacksmithing = false;
                    }
                    else
                    {
                        linkLabel29.Enabled = true;
                        MiningBlacksmithingProf.Text = mbs1600;
                        CPGlobalSettings.Instance.BotPBMiningBlacksmithing = true;
                        CPGlobalSettings.Instance.PBMiningBlacksmithing = true;
                        if (lastUseProfile == 8)
                        {
                            label4.Text = mbs1600;
                            lastUseProfile = 7;
                        }
                        if (MiningBlacksmithingProf.Checked)
                        {
                            ProfessionsrichTextBox.Text = mbs1600txt;
                            lastUseProfile = 7;
                        }
                    }
                }
            }
            else
            {
                MiningBS_Checkbox.Checked = false;
                linkLabel29.Enabled = false;
                CPGlobalSettings.Instance.BotPBMiningBlacksmithing = false;
                CPGlobalSettings.Instance.PBMiningBlacksmithing = false;
            }
            CPGlobalSettings.Instance.Save();
        }

        private void MiningBlacksmithingProf_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (File.Exists(pathToProfiles + "PB\\MB\\Scripts\\[PB]MB600(Cava).txt"))
            {
                ProfessionsrichTextBox.Text = mbs1600txt;
                lastUseProfile = 7; //MB 1 to 600
            }
            else
            {
                ProfessionsrichTextBox.Text = mbs1300txt;
                lastUseProfile = 8; //MB 1 to 300
            }
        }

        private void linkLabel29_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://cava.repositoryhosting.com/svn/cava_mining_blacksmithing");
        }

        private void tabPage2_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void tabPage10_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void tabPage3_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void AllowDownloadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AllowDownloadCheckBox.Checked)
            {
                if (!CPGlobalSettings.Instance.BotAllowUpdate)
                {
                    if (!Directory.Exists(pathToProfiles + "/Armageddoner"))
                    {
                        Directory.CreateDirectory(pathToProfiles + "Armageddoner");
                        Updater_Armageddoner("/command:\"checkout\" /url:\"https://cava.repositoryhosting.com/svn/cava_armageddoner\" /path:\"" + pathToProfiles + "Armageddoner" + "\" /closeonend:1");
                    }
                    else
                    {
                        Updater_Armageddoner("/command:\"update\" /url:\"https://cava.repositoryhosting.com/svn/cava_armageddoner\" /path:\"" + pathToProfiles + "Armageddoner" + "\" /closeonend:1");
                    }
                    if (TortoiseExitCode != 0)
                    {
                        Directory.Delete(Path.Combine(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\Armageddoner"));
                        AllowDownloadCheckBox.Checked = false;
                        AntiStuck_CheckBox.Checked = false;
                        AntiStuck_CheckBox.Enabled = false;
                        AutoShutDown_Checkbox.Checked = false;
                        AutoShutDown_Checkbox.Enabled = false;
                        AllowSummonPet_Checkbox.Checked = false;
                        AllowSummonPet_Checkbox.Enabled = false;
                        radioButton5.Enabled = false;
                        groupBox6.Enabled = false;
                        linkLabel4.Enabled = false;
                        CPGlobalSettings.Instance.BotAllowUpdate = false;
                        CPGlobalSettings.Instance.AllowUpdate = false;
                    }
                    else
                    {
                        AllowDownloadCheckBox.Checked = true;
                        AntiStuck_CheckBox.Enabled = true;
                        AutoShutDown_Checkbox.Enabled = true;
                        AllowSummonPet_Checkbox.Enabled = true;
                        radioButton5.Enabled = true;
                        groupBox6.Enabled = true;
                        linkLabel4.Enabled = true;
                        CPGlobalSettings.Instance.BotAllowUpdate = true;
                        CPGlobalSettings.Instance.AllowUpdate = true;
                    }
                }
            }
            else
            {
                AllowDownloadCheckBox.Checked = false;
                AntiStuck_CheckBox.Checked = false;
                AntiStuck_CheckBox.Enabled = false;
                AutoShutDown_Checkbox.Checked = false;
                AutoShutDown_Checkbox.Enabled = false;
                AllowSummonPet_Checkbox.Checked = false;
                AllowSummonPet_Checkbox.Enabled = false;
                radioButton5.Enabled = false;
                groupBox6.Enabled = false;
                linkLabel4.Enabled = false;
                CPGlobalSettings.Instance.BotAllowUpdate = false;
                CPGlobalSettings.Instance.AllowUpdate = false;
            }
            CPGlobalSettings.Instance.Save();
        }

        private void ResscheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CPGlobalSettings.Instance.RessAfterDie = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                CultureInfo ci = new CultureInfo("en-US");
                CPGlobalSettings.Instance.language = 0;
                string str = Assembly.GetExecutingAssembly().FullName;
                str = str.Remove(str.IndexOf(','));
                Assembly _assembly = Assembly.Load(str);
                ResourceManager rm = new ResourceManager("Lang", _assembly);
                richTextBox1.LoadFile(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\Langs\GoodToKnow_en.rtf");
                thanksRichText.LoadFile(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\Langs\Thanks_en.rtf");
                getRes(ci,rm);
            }
            //if (comboBox1.SelectedIndex == 1)
            //{
            //    CultureInfo ci = new CultureInfo("de");
            //    CPGlobalSettings.Instance.language = 1;
            //    string str = Assembly.GetExecutingAssembly().FullName;
            //    str = str.Remove(str.IndexOf(','));
            //    Assembly _assembly = Assembly.Load(str);
            //    ResourceManager rm = new ResourceManager("Lang.de", _assembly);
            //    richTextBox1.LoadFile(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\Langs\GoodToKnow_de.rtf");
            //    thanksRichText.LoadFile(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\Langs\Thanks_de.rtf");
            //    getRes(ci, rm);
            //}
            if (comboBox1.SelectedIndex == 1)
            {
                CultureInfo ci = new CultureInfo("pt-PT");
                CPGlobalSettings.Instance.language = 2;
                string str = Assembly.GetExecutingAssembly().FullName;
                str = str.Remove(str.IndexOf(','));
                Assembly _assembly = Assembly.Load(str);
                ResourceManager rm = new ResourceManager("Lang.pt", _assembly);
                richTextBox1.LoadFile(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\Langs\GoodToKnow_pt.rtf");
                thanksRichText.LoadFile(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\Langs\Thanks_pt.rtf");
                getRes(ci, rm);
            }
        }

  
    }
    public class CPsettings : Settings
    {
        public static readonly CPsettings Instance = new CPsettings();
        public CPsettings()
            : base(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"Plugins\CavaPlugin\Settings\Char-Settings-{0}.xml", StyxWoW.Me.Name)))
        {
        }
        [Setting, DefaultValue(0)]
        public int lastUsedPath { get; set; }
    }

    public class CPGlobalSettings : Settings 
    {
        public static readonly CPGlobalSettings Instance = new CPGlobalSettings();
        public CPGlobalSettings()
            : base(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"Plugins\CavaPlugin\Settings\Main-Settings.xml")))
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
        public bool AntiStuckSystem { get; set; }
        [Setting, DefaultValue(false)]
        public bool AutoShutdownWhenUpdate { get; set; }
        [Setting, DefaultValue(false)]
        public bool CheckAllowSummonPet { get; set; }
        [Setting, DefaultValue(false)]
        public bool PBMiningBlacksmithing { get; set; }
        [Setting, DefaultValue(false)]
        public bool BotPBMiningBlacksmithing { get; set; }
        [Setting, DefaultValue(false)]
        public bool RessAfterDie { get; set; }
        [Setting, DefaultValue(0)]
        public int language { get; set; }

    }
}
