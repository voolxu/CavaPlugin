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
        bool isRunningdepois;
        bool BeenInitialized4;
        public CavaForm()
        {
            InitializeComponent();
        }
        static void Updater_Armageddoner(string f)
        {
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = "TortoiseProc.exe";
            //startInfo.Arguments = f;
            //Process.Start(startInfo);
            Process p = new Process();
            p.StartInfo.FileName = "TortoiseProc.exe";
            p.StartInfo.Arguments = f;
            p.Start();
            p.WaitForExit();
            if (p.ExitCode != 0)
            {
                CPGlobalSettings.Instance.Armageddoner = false;
                CPGlobalSettings.Instance.AllowUpdate = false;
                Directory.Delete(Path.Combine(Utilities.AssemblyDirectory + @"\Default Profiles\Cava\Scripts\Armageddoner"));
            }
        }

        private void CavaForm_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\main.png");
            pictureBox2.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\quests.png");
            pictureBox3.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\about.png");
            pictureBox4.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\donate.png");
            pictureBox5.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\about.png");
            pictureBox6.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\new.gif");
            pictureBox7.ImageLocation = Path.Combine(Utilities.AssemblyDirectory + @"\Plugins\CavaPlugin\pngs\about.png");
            BeenInitialized4 = CavaPlugin.hasBeenInitialized4;
            UpdateStuff();
        }

        public void UpdateStuff()
        {
            CPsettings.Instance.Load();
            CPGlobalSettings.Instance.Load();
            lastUseProfile = CPsettings.Instance.lastUsedPath;
            if (CPGlobalSettings.Instance.AllowUpdate)
            {
                checkBox1.Checked = true;
            }
            //if (CPGlobalSettings.Instance.Armageddoner)
            //{
            //    tabControl1.Controls.Add(tabPage9);//donators tab
            //}
            if (BeenInitialized4 == false)
            {
                listBox1.Enabled = false;
                checkBox1.Checked = false;
                groupBox6.Enabled = false;
                linkLabel4.Enabled = false;
                radioButton5.Enabled = false;
                radioButton6.Enabled = false;
                CPGlobalSettings.Instance.Armageddoner = false;
                CPGlobalSettings.Instance.Save();
            }
            tabControl1.Controls.Add(tabPage3);//ultima tab
            label4.Text = "There is no previus selected profile";
            int allRows = File.ReadAllLines(pathToDoYouKnow).Length;
            Random random = new Random();
            int myLine = random.Next(0, allRows);
            using (Stream stream = File.Open(pathToDoYouKnow, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = null;
                    for (int i = 0; i < myLine; ++i)
                    {
                        line = reader.ReadLine();
                    }
                    richTextBox1.Text = line;
                }
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


            if (lastUseProfile == 1) { label4.Text = "Leveling 1 to 90"; }
            if (lastUseProfile == 2) { label4.Text = "Leveling Pandaren 1 to 90 Horde"; }
            if (lastUseProfile == 3) { label4.Text = "Leveling Pandaren 1 to 90 Alliance"; }
            if (lastUseProfile == 4) { label4.Text = "Leveling 85 to 90 With Loot"; }
            if (lastUseProfile == 5) { label4.Text = "HORDE- Leveling 44 to 64"; }
            if (lastUseProfile == 6) { label4.Text = "HORDE- Leveling 1 to 20 (WoW 5.3)"; }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lastUseProfile = 1; //Leveling 1 to 90
            richTextBox2.Text = "This profile will level-up any char from any level till level 90, \n This is a work in progresss so far: \n Alliance can use it from level 1 til 67 and from 85 to 90 \n Horde can use it from level 1 till 44 and from 85 to 88 \n Can start profile anywhere, after start profile bot will move your char to right map";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lastUseProfile = 2; //Leveling Pandaren 1 to 90 Horde
            richTextBox2.Text = "This profile will level-up Pandaren class char from level 1 till 12. \n Selecte Horde side \n and continue with 1 to 90 profile ";

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lastUseProfile = 3; //Leveling Pandaren 1 to 90 Alliance
            richTextBox2.Text = "This profile will level-up Pandaren class char from level 1 till 12. \n Selecte Alliance side \n and continue with 1 to 90 profile ";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lastUseProfile = 4; //Leveling 85 to 90 With Loot 
            richTextBox2.Text = "This profile will level-up any char class from level 85 till 90. Looting mobs \n This profiles are not AFK and its a work in progresss so far: \n Alliance can use it from level 85 til 90 \n Horde can use it from level 85 till 88 ";
        }


        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lastUseProfile = 5; //HORDE- Leveling 44 to 64
            richTextBox2.Text = "This profile will level-up any Horde char from level 44 till level 64 \n TANARIS is non AFK (need one quest behavior)";
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                CPGlobalSettings.Instance.Armageddoner = true;
                CPGlobalSettings.Instance.AllowUpdate = true;
                if (!Directory.Exists(pathToProfiles + "/Armageddoner"))
                {
                    Directory.CreateDirectory(pathToProfiles + "Armageddoner");
                    Updater_Armageddoner("/command:\"checkout\" /url:\"https://cava.repositoryhosting.com/svn/cava_armageddoner\" /path:\"" + pathToProfiles + "Armageddoner" + "\" /closeonend:1");
                }
                MessageBox.Show("Need restart HonorBuddy for this change take effect.", "RESTART REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CPGlobalSettings.Instance.AllowUpdate = false;
            }
            CPGlobalSettings.Instance.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://cava.repositoryhosting.com/trac/cava_profiles/wiki");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://cava.repositoryhosting.com/svn_public/cava_plugin/");
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
            System.Diagnostics.Process.Start("http://cava.repositoryhosting.com/svn_public/cava_qbs");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://cava.repositoryhosting.com/svn_public/cava_profiles");
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

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lastUseProfile = 6; //HORDE- Leveling 1 to 20
            richTextBox2.Text = "This profile will level-up any Horde char from level 1 till level 20 \n Via Tirisfal Glades and Silverpine Forest";
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
        public bool Armageddoner { get; set; }
        [Setting, DefaultValue(false)]
        public bool AllowUpdate { get; set; }
        [Setting, DefaultValue(false)]
        public bool Allowlunch { get; set; }
        [Setting, DefaultValue(0)]
        public int BaseProfileToLunch { get; set; }
    }
}
