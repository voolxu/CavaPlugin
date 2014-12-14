using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using Styx;
using Styx.CommonBot;
using Styx.CommonBot.Profiles;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;


namespace CavaPlugin
{
    public partial class CavaForm : Form
    {
        private int _seconds = 15; // Segundos do countdown.

        public CavaForm()
        {
            CavaPluginLog.Debug("Started CavaPlugin Form");
            CavaPlugin.Player.SoundLocation = CavaPlugin.SoundPath + "Open.wav";
            CavaPlugin.Player.Play();
            // Language
            CPsettings.Instance.Load();
            CPGlobalSettings.Instance.Load();
            if (!CPGlobalSettings.Instance.Languageselected)
            {
                //Form getlanguage = new Language();
                //getlanguage.ShowDialog();
                CPGlobalSettings.Instance.language = 0;
            }

            InitializeComponent();
            //var imagePath = Path.Combine(CavaPlugin.BotPath, "Pngs\\");
            #region WoD settings
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            if (CavaPlugin.IsQuestComplete(34788) || CavaPlugin.IsQuestComplete(37563))
            {
                label31.Enabled = false;
                comboBox2.Enabled = false;
            }
            else
            {
                if (Me.IsHorde)
                {
                    label31.Text = "[H](90-92)FrostfireRidge";
                    comboBox2.Items.AddRange(new object[]
                    {"Select your companion", "Greatmother Geyah", "Kal'gor the Honorable", "Lokra"});
                }
                if (Me.IsAlliance)
                {
                    label31.Text = "[A](90-92)ShadowMoonValley";
                    comboBox2.Items.AddRange(new object[]
                    {"Select your companion", "Apprentice Artificer Andren", "Rangari Chel", "Vindicator Onaala"});
                }
                switch (CPsettings.Instance.FriendoftheExarchs)
                {
                    default:
                        comboBox2.SelectedIndex = 0;
                        break;
                    case "null":
                        comboBox2.SelectedIndex = 0;
                        break;
                    case "Andren":
                        comboBox2.SelectedIndex = 1;
                        break;
                    case "Geyah":
                        comboBox2.SelectedIndex = 1;
                        break;
                    case "Chel":
                        comboBox2.SelectedIndex = 2;
                        break;
                    case "Kalgor":
                        comboBox2.SelectedIndex = 2;
                        break;
                    case "Onaala":
                        comboBox2.SelectedIndex = 3;
                        break;
                    case "Lokra":
                        comboBox2.SelectedIndex = 3;
                        break;
                }
            }
            if (CavaPlugin.IsQuestComplete(35063) || CavaPlugin.IsQuestComplete(35151))
            {
                label33.Enabled = false;
                comboBox3.Enabled = false;
            }
            else
            {
                comboBox3.Items.AddRange(Me.IsAlliance
                    ? new object[] {"Select your garrison outpost", "Lumber Yard", "Sparring Arena"}
                    : new object[] {"Select your garrison outpost", "Lumber Mill", "Sparring Arena"});
                switch (CPsettings.Instance.GorgondOutpost)
                {
                    default:
                        comboBox3.SelectedIndex = 0;
                        break;
                    case "null":
                        comboBox3.SelectedIndex = 0;
                        break;
                    case "LoggingCampLumberYard":
                        comboBox3.SelectedIndex = 1;
                        break;
                    case "SparringRingSavageFightClub":
                        comboBox3.SelectedIndex = 2;
                        break;
                }
            }

            #endregion
            #region Buttons
            tabPage1.BackgroundImage = Image.FromFile(CavaPlugin.ImagePath + "bot.png");
            button1.Image = Image.FromFile(CavaPlugin.ImagePath + "amarelo60.png");
            button9.BackgroundImage = Image.FromFile(CavaPlugin.ImagePath + "all180.png");
            button7.Image = Image.FromFile(CavaPlugin.ImagePath + "laranja60.png");
            button31.Image = Image.FromFile(CavaPlugin.ImagePath + "cinza60.png");
            button23.Image = Image.FromFile(CavaPlugin.ImagePath + "azul60.png");
            button5.Image = Image.FromFile(CavaPlugin.ImagePath + "violeta60.png");
            breport.Image = Image.FromFile(CavaPlugin.ImagePath + "bigbuttonblue.png");
            button21.Image = Image.FromFile(CavaPlugin.ImagePath + "verde60.png");
            button22.Image = Image.FromFile(CavaPlugin.ImagePath + "preto60.png");
            tabPage2.BackgroundImage = Image.FromFile(CavaPlugin.ImagePath + "bot.png");
            button2.Image = Image.FromFile(CavaPlugin.ImagePath + "amarelo60.png");
            button3.BackgroundImage = Image.FromFile(CavaPlugin.ImagePath + "azul180.png");
            button4.Image = Image.FromFile(CavaPlugin.ImagePath + "laranja60.png");
            button6.Image = Image.FromFile(CavaPlugin.ImagePath + "all60.png");
            button8.Image = Image.FromFile(CavaPlugin.ImagePath + "cinza60.png");
            button10.Image = Image.FromFile(CavaPlugin.ImagePath + "violeta60.png");
            button11.Image = Image.FromFile(CavaPlugin.ImagePath + "preto60.png");
            button12.Image = Image.FromFile(CavaPlugin.ImagePath + "verde60.png");
            tabPage3.BackgroundImage = Image.FromFile(CavaPlugin.ImagePath + "bot.png");
            button13.Image = Image.FromFile(CavaPlugin.ImagePath + "amarelo60.png");
            button14.BackgroundImage = Image.FromFile(CavaPlugin.ImagePath + "laranja180.png");
            button15.Image = Image.FromFile(CavaPlugin.ImagePath + "cinza60.png");
            button16.Image = Image.FromFile(CavaPlugin.ImagePath + "all60.png");
            button17.Image = Image.FromFile(CavaPlugin.ImagePath + "azul60.png");
            button18.Image = Image.FromFile(CavaPlugin.ImagePath + "violeta60.png");
            button19.Image = Image.FromFile(CavaPlugin.ImagePath + "preto60.png");
            button20.Image = Image.FromFile(CavaPlugin.ImagePath + "verde60.png");
            tabPage4.BackgroundImage = Image.FromFile(CavaPlugin.ImagePath + "bot.png");
            button24.Image = Image.FromFile(CavaPlugin.ImagePath + "cinza60.png");
            button25.BackgroundImage = Image.FromFile(CavaPlugin.ImagePath + "amarelo180.png");
            button26.Image = Image.FromFile(CavaPlugin.ImagePath + "laranja60.png");
            button27.Image = Image.FromFile(CavaPlugin.ImagePath + "all60.png");
            button28.Image = Image.FromFile(CavaPlugin.ImagePath + "azul60.png");
            button29.Image = Image.FromFile(CavaPlugin.ImagePath + "violeta60.png");
            button30.Image = Image.FromFile(CavaPlugin.ImagePath + "preto60.png");
            button32.Image = Image.FromFile(CavaPlugin.ImagePath + "verde60.png");
            tabPage5.BackgroundImage = Image.FromFile(CavaPlugin.ImagePath + "bot.png");
            button33.Image = Image.FromFile(CavaPlugin.ImagePath + "amarelo60.png");
            button34.BackgroundImage = Image.FromFile(CavaPlugin.ImagePath + "verde180.png");
            button35.Image = Image.FromFile(CavaPlugin.ImagePath + "laranja60.png");
            button36.Image = Image.FromFile(CavaPlugin.ImagePath + "all60.png");
            button37.Image = Image.FromFile(CavaPlugin.ImagePath + "azul60.png");
            button38.Image = Image.FromFile(CavaPlugin.ImagePath + "violeta60.png");
            button39.Image = Image.FromFile(CavaPlugin.ImagePath + "preto60.png");
            button40.Image = Image.FromFile(CavaPlugin.ImagePath + "cinza60.png");
            tabPage6.BackgroundImage = Image.FromFile(CavaPlugin.ImagePath + "bot.png");
            pictureBox4.Image = Image.FromFile(CavaPlugin.ImagePath + "donate.png");
            button41.Image = Image.FromFile(CavaPlugin.ImagePath + "amarelo60.png");
            button42.BackgroundImage = Image.FromFile(CavaPlugin.ImagePath + "preto180.png");
            button43.Image = Image.FromFile(CavaPlugin.ImagePath + "laranja60.png");
            button44.Image = Image.FromFile(CavaPlugin.ImagePath + "all60.png");
            button45.Image = Image.FromFile(CavaPlugin.ImagePath + "azul60.png");
            button46.Image = Image.FromFile(CavaPlugin.ImagePath + "violeta60.png");
            button47.Image = Image.FromFile(CavaPlugin.ImagePath + "cinza60.png");
            button48.Image = Image.FromFile(CavaPlugin.ImagePath + "verde60.png");
            #endregion
            #region Language
            switch (CPGlobalSettings.Instance.language)
            {
                default:
                    CavaPlugin._rm = new ResourceManager("Lang.en", CavaPlugin._assembly);
                    richTextBox2.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "GoodToKnow_en.rtf");
                    richTextBox2.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "Thanks_en.rtf");
                    break;
                case 0:
                    CavaPlugin._rm = new ResourceManager("Lang.en", CavaPlugin._assembly);
                    richTextBox2.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "GoodToKnow_en.rtf");
                    richTextBox2.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "Thanks_en.rtf");
                    break;
                case 1:
                    CavaPlugin._rm = new ResourceManager("Lang.da", CavaPlugin._assembly);
                    richTextBox1.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "GoodToKnow_da.rtf");
                    richTextBox2.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "Thanks_da.rtf");
                    break;
                case 2:
                    CavaPlugin._rm = new ResourceManager("Lang.de", CavaPlugin._assembly);
                    richTextBox1.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "GoodToKnow_de.rtf");
                    richTextBox2.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "Thanks_de.rtf");
                    break;
                case 3:
                    CavaPlugin._rm = new ResourceManager("Lang.fr", CavaPlugin._assembly);
                    richTextBox1.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "GoodToKnow_fr.rtf");
                    richTextBox2.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "Thanks_fr.rtf");
                    break;
                case 4:
                    CavaPlugin._rm = new ResourceManager("Lang.pt", CavaPlugin._assembly);
                    richTextBox1.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "GoodToKnow_pt.rtf");
                    richTextBox2.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "Thanks_pt.rtf");
                    break;
                case 5:
                    CavaPlugin._rm = new ResourceManager("Lang.ru", CavaPlugin._assembly);
                    richTextBox1.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "GoodToKnow_ru.rtf");
                    richTextBox2.LoadFile(Path.Combine(CavaPlugin.BotPath, "Langs\\") + "Thanks_ru.rtf");
                    break;
            }
            lversion.Text = CavaPlugin.StrLocalization("cpVersion") + CavaPlugin._version.ToString().Remove(0, 2);
            #endregion
            LogintextBox.Text = CPGlobalSettings.Instance.CpLogin;
            PasswordtextBox.Text = LogintextBox.Text != "" ? CavaPlugin.Decrypt(CPGlobalSettings.Instance.CpPassword) : "";
            if (CPGlobalSettings.Instance.UseServer == 0)
                selectserver1radio.Checked = true;
            if (CPGlobalSettings.Instance.UseServer == 1)
                selectserver2radio.Checked = true;
            if (CavaPlugin.IsRegisteredUser)
            {
                pictureBox13.Visible = false;
                MiningBlacksmithingProf.Enabled = true;
                pictureBox10.Image = Image.FromFile(CavaPlugin.ImagePath + "y.png");
            }
            else
            {
                pictureBox10.Image = Image.FromFile(CavaPlugin.ImagePath + "n.png");
                pictureBox13.Image = Image.FromFile(CavaPlugin.ImagePath + "register.png");
                pictureBox13.Visible = true;
                MiningBlacksmithingProf.Checked = false;
                MiningBlacksmithingProf.Enabled = false;
                CavaPlugin.IsArmageddonerUser = false;
                CavaPlugin.HaveMiningBlacksmithingAccess = false;
            }
            if (CavaPlugin.IsArmageddonerUser)
            {
                pictureBox11.Image = Image.FromFile(CavaPlugin.ImagePath + "y.png");
                pictureBox9.Visible = false;
                AntiStuck_CheckBox.Enabled = true;
                AntiStuck_CheckBox.Checked = CPsettings.Instance.AntiStuckSystem;
                AutoShutDown_Checkbox.Enabled = true;
                AutoShutDown_Checkbox.Checked = CPGlobalSettings.Instance.AutoShutdownWhenUpdate;
                disableplugincheckBox.Enabled = true;
                disableplugincheckBox.Checked = CPGlobalSettings.Instance.DisablePlugin;
                if ((Lua.GetReturnVal<int>("return GetNumCompanions('CRITTER')", 0)) > 0)
                {
                    AllowSummonPet_Checkbox.Enabled = true;
                    AllowSummonPet_Checkbox.Checked = CPsettings.Instance.CheckAllowSummonPet;
                }
                else
                {
                    AllowSummonPet_Checkbox.Enabled = false;
                    if (CPsettings.Instance.CheckAllowSummonPet)
                    {
                        CPsettings.Instance.CheckAllowSummonPet = false;
                        CPsettings.Instance.Save();
                    }
                }
                radioButton5.Enabled = true;
                guildInvitescheckBox.Enabled = true;
                refuseGuildCheckBox.Enabled = true;
                guildInvitescheckBox.Checked = CPsettings.Instance.GuildInvitescheck;
                refuseGuildCheckBox.Checked = CPsettings.Instance.refuseguildInvitescheck;
                if (guildInvitescheckBox.Checked)
                {
                    refuseGuildCheckBox.Checked = false;
                    CPsettings.Instance.refuseguildInvitescheck = false;
                }
                if (refuseGuildCheckBox.Checked)
                {
                    guildInvitescheckBox.Checked = false;
                    CPsettings.Instance.GuildInvitescheck = false;
                }
                refusePartyCheckBox.Enabled = true;
                refusePartyCheckBox.Checked = CPsettings.Instance.RefusepartyInvitescheck;
                refuseTradesCheckBox.Enabled = true;
                refuseTradesCheckBox.Checked = CPsettings.Instance.RefusetradeInvitescheck;
                refuseDuelCheckBox.Enabled = true;
                refuseDuelCheckBox.Checked = CPsettings.Instance.RefuseduelInvitescheck;
                ResscheckBox.Enabled = true;
                ResscheckBox.Checked = CPsettings.Instance.RessAfterDie;
                combatloot_checkBox.Enabled = true;
                combatloot_checkBox.Checked = CPsettings.Instance.CombatLoot;
                fixmountcheckBox1.Enabled = true;
                fixmountcheckBox1.Checked = CPsettings.Instance.FixMountFlightVendor;
                antigankcheckBox.Enabled = true;
                playsoundcheckBox.Enabled = true;
                antigankcheckBox.Checked = CPsettings.Instance.AntigankcheckBox;
                playsoundcheckBox.Checked = CPsettings.Instance.Playsonar;
                OpenBox_checkBox.Enabled = StyxWoW.Me.Class == WoWClass.Rogue;
                OpenBox_checkBox.Checked = CPsettings.Instance.OpenBox;
                Checkarmageddonerreservedprofiles();
            }
            else
            {
                pictureBox11.Image = Image.FromFile(CavaPlugin.ImagePath + "n.png");
                pictureBox9.Image = Image.FromFile(CavaPlugin.ImagePath + "donate2.gif");
                pictureBox9.Visible = true;
                AntiStuck_CheckBox.Checked = false;
                AntiStuck_CheckBox.Enabled = false;
                AutoShutDown_Checkbox.Checked = false;
                AutoShutDown_Checkbox.Enabled = false;
                disableplugincheckBox.Checked = true;
                disableplugincheckBox.Enabled = false;
                AllowSummonPet_Checkbox.Checked = false;
                AllowSummonPet_Checkbox.Enabled = false;
                radioButton5.Enabled = false;
                if (CavaPlugin.LastUseProfile == 5)
                {
                    CavaPlugin.LastUseProfile = 0;
                    CPsettings.Instance.LastUsedPath = 0;
                }
                guildInvitescheckBox.Enabled = false;
                guildInvitescheckBox.Checked = false;
                refuseGuildCheckBox.Enabled = false;
                refuseGuildCheckBox.Checked = false;
                refusePartyCheckBox.Enabled = false;
                refusePartyCheckBox.Checked = false;
                refuseTradesCheckBox.Enabled = false;
                refuseTradesCheckBox.Checked = false;
                refuseDuelCheckBox.Enabled = false;
                refuseDuelCheckBox.Checked = false;
                ResscheckBox.Checked = false;
                ResscheckBox.Enabled = false;
                combatloot_checkBox.Checked = false;
                combatloot_checkBox.Enabled = false;
                fixmountcheckBox1.Checked = false;
                fixmountcheckBox1.Enabled = false;
                antigankcheckBox.Checked = false;
                antigankcheckBox.Enabled = false;
                playsoundcheckBox.Checked = false;
                playsoundcheckBox.Enabled = false;
                OpenBox_checkBox.Checked = false;
                OpenBox_checkBox.Enabled = false;
                learnportal1checkBox.Enabled = false;
                learnportal1checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal1", null);
                learnportal2checkBox.Enabled = false;
                learnportal2checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal2", null);
                learnportal3checkBox.Enabled = false;
                learnportal3checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal3", null);
                learnportal4checkBox.Enabled = false;
                learnportal4checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal4", null);
                learnportal5checkBox.Enabled = false;
                learnportal5checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal5", null);
                learnportal6checkBox.Enabled = false;
                learnportal6checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal6", null);
            }
            if (CavaPlugin.HaveMiningBlacksmithingAccess)
            {
                pictureBox12.Image = Image.FromFile(CavaPlugin.ImagePath + "y.png");
                pictureBox14.Visible = false;
                pictureBox8.Visible = false;
                ProfMinBlack1600radioButton.Enabled = true;
                if (CPsettings.Instance.LastUsedPath == 7)
                {
                    ProfMinBlack1600radioButton.Checked = true;
                    CavaPlugin.LastUseProfile = 7;
                }
            }
            else
            {
                pictureBox12.Image = Image.FromFile(CavaPlugin.ImagePath + "n.png");
                pictureBox14.Image = Image.FromFile(CavaPlugin.ImagePath + "donate2.gif");
                pictureBox14.Visible = true;
                pictureBox8.Image = Image.FromFile(CavaPlugin.ImagePath + "donate2.gif");
                pictureBox8.Visible = true;
                ProfMinBlack1600radioButton.Checked = false;
                ProfMinBlack1600radioButton.Enabled = false;
            }
            if (Me.Race == WoWRace.Pandaren)
            {
                if (Lua.GetReturnVal<bool>("return GetQuestsCompleted()[30899]", 0) ||
                    Lua.GetReturnVal<bool>("return GetQuestsCompleted()[31014]", 0))
                {
                    radioButton2.Enabled = false;
                    radioButton3.Enabled = false;
                    if (CavaPlugin.LastUseProfile == 2 || CavaPlugin.LastUseProfile == 3)
                        CavaPlugin.LastUseProfile = 1;
                }
                else
                {
                    {
                        radioButton1.Enabled = false;
                        if (CavaPlugin.LastUseProfile == 1)
                            CavaPlugin.LastUseProfile = 0;
                    }
                }
            }
            else
            {
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                if (CavaPlugin.LastUseProfile == 2 || CavaPlugin.LastUseProfile == 3)
                    CavaPlugin.LastUseProfile = 1;
            }
            if (Me.Level >= 100)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton5.Enabled = false;
                radioButton9.Enabled = false;
                if (CavaPlugin.LastUseProfile >= 1 && CavaPlugin.LastUseProfile <= 5)
                    CavaPlugin.LastUseProfile = 0;
            }
            switch (CavaPlugin.LastUseProfile)
            {
                default:
                    Setnoneprofile();
                    break;
                case 0:
                    Setnoneprofile();
                    break;
                case 1:
                    llastprofile.Text = CavaPlugin.StrLocalization("leveling1to90");
                    label6.Text = CavaPlugin.StrLocalization("leveling1to90");
                    label9.Text = CavaPlugin.StrLocalization("leveling1to90");
                    label14.Text = CavaPlugin.StrLocalization("leveling1to90");
                    label11.Text = CavaPlugin.StrLocalization("leveling1to90");
                    label17.Text = CavaPlugin.StrLocalization("leveling1to90");
                    //
                    label28.Text = CavaPlugin.StrLocalization("leveling1to90txt");
                    label8.Text = CavaPlugin.StrLocalization("leveling1to90txt");
                    label13.Text = CavaPlugin.StrLocalization("leveling1to90txt");
                    label19.Text = CavaPlugin.StrLocalization("leveling1to90txt");
                    label25.Text = CavaPlugin.StrLocalization("leveling1to90txt");
                    label2.Text = CavaPlugin.StrLocalization("leveling1to90txt");
                    // ReSharper restore ResourceItemNotResolved
                    EnableStartButton();
                    break;
                case 2:
                    llastprofile.Text = CavaPlugin.StrLocalization("levelingpandahorde");
                    label6.Text = CavaPlugin.StrLocalization("levelingpandahorde");
                    label9.Text = CavaPlugin.StrLocalization("levelingpandahorde");
                    label14.Text = CavaPlugin.StrLocalization("levelingpandahorde");
                    label11.Text = CavaPlugin.StrLocalization("levelingpandahorde");
                    label17.Text = CavaPlugin.StrLocalization("levelingpandahorde");
                    //
                    label28.Text = CavaPlugin.StrLocalization("levelingpandahordetxt");
                    label8.Text = CavaPlugin.StrLocalization("levelingpandahordetxt");
                    label13.Text = CavaPlugin.StrLocalization("levelingpandahordetxt");
                    label19.Text = CavaPlugin.StrLocalization("levelingpandahordetxt");
                    label25.Text = CavaPlugin.StrLocalization("levelingpandahordetxt");
                    label2.Text = CavaPlugin.StrLocalization("levelingpandahordetxt");
                    // ReSharper restore ResourceItemNotResolved
                    EnableStartButton();
                    break;
                case 3:
                    llastprofile.Text = CavaPlugin.StrLocalization("levelingpandaally");
                    label6.Text = CavaPlugin.StrLocalization("levelingpandaally");
                    label9.Text = CavaPlugin.StrLocalization("levelingpandaally");
                    label14.Text = CavaPlugin.StrLocalization("levelingpandaally");
                    label11.Text = CavaPlugin.StrLocalization("levelingpandaally");
                    label17.Text = CavaPlugin.StrLocalization("levelingpandaally");
                    //
                    label28.Text = CavaPlugin.StrLocalization("levelingpandaallytxt");
                    label8.Text = CavaPlugin.StrLocalization("levelingpandaallytxt");
                    label13.Text = CavaPlugin.StrLocalization("levelingpandaallytxt");
                    label19.Text = CavaPlugin.StrLocalization("levelingpandaallytxt");
                    label25.Text = CavaPlugin.StrLocalization("levelingpandaallytxt");
                    label2.Text = CavaPlugin.StrLocalization("levelingpandaallytxt");
                    // ReSharper restore ResourceItemNotResolved
                    EnableStartButton();
                    break;
                case 4:
                    llastprofile.Text = CavaPlugin.StrLocalization("levelingarmagessonerfast");
                    label6.Text = CavaPlugin.StrLocalization("levelingarmagessonerfast");
                    label9.Text = CavaPlugin.StrLocalization("levelingarmagessonerfast");
                    label14.Text = CavaPlugin.StrLocalization("levelingarmagessonerfast");
                    label11.Text = CavaPlugin.StrLocalization("levelingarmagessonerfast");
                    label17.Text = CavaPlugin.StrLocalization("levelingarmagessonerfast");
                    //
                    label28.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
                    label8.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
                    label13.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
                    label19.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
                    label25.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
                    label2.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
                    // ReSharper restore ResourceItemNotResolved
                    EnableStartButton();
                    break;
                case 5:
                    llastprofile.Text = CavaPlugin.StrLocalization("levelingarmagessoner");
                    label6.Text = CavaPlugin.StrLocalization("levelingarmagessoner");
                    label9.Text = CavaPlugin.StrLocalization("levelingarmagessoner");
                    label14.Text = CavaPlugin.StrLocalization("levelingarmagessoner");
                    label11.Text = CavaPlugin.StrLocalization("levelingarmagessoner");
                    label17.Text = CavaPlugin.StrLocalization("levelingarmagessoner");
                    //
                    label28.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
                    label8.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
                    label13.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
                    label19.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
                    label25.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
                    label2.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
                    // ReSharper restore ResourceItemNotResolved
                    EnableStartButton();
                    break;
                case 7:
                    llastprofile.Text = CavaPlugin.StrLocalization("miningbs1600");
                    label6.Text = CavaPlugin.StrLocalization("miningbs1600");
                    label9.Text = CavaPlugin.StrLocalization("miningbs1600");
                    label14.Text = CavaPlugin.StrLocalization("miningbs1600");
                    label11.Text = CavaPlugin.StrLocalization("miningbs1600");
                    label17.Text = CavaPlugin.StrLocalization("miningbs1600");
                    //
                    label28.Text = CavaPlugin.StrLocalization("mbs1600txt");
                    label8.Text = CavaPlugin.StrLocalization("mbs1600txt");
                    label13.Text = CavaPlugin.StrLocalization("mbs1600txt");
                    label19.Text = CavaPlugin.StrLocalization("mbs1600txt");
                    label25.Text = CavaPlugin.StrLocalization("mbs1600txt");
                    label2.Text = CavaPlugin.StrLocalization("mbs1600txt");
                    // ReSharper restore ResourceItemNotResolved
                    EnableStartButton();
                    break;
                case 8:
                    llastprofile.Text = CavaPlugin.StrLocalization("miningbs1300");
                    label6.Text = CavaPlugin.StrLocalization("miningbs1300");
                    label9.Text = CavaPlugin.StrLocalization("miningbs1300");
                    label14.Text = CavaPlugin.StrLocalization("miningbs1300");
                    label11.Text = CavaPlugin.StrLocalization("miningbs1300");
                    label17.Text = CavaPlugin.StrLocalization("miningbs1300");
                    //
                    label28.Text = CavaPlugin.StrLocalization("mbs1300txt");
                    label8.Text = CavaPlugin.StrLocalization("mbs1300txt");
                    label13.Text = CavaPlugin.StrLocalization("mbs1300txt");
                    label19.Text = CavaPlugin.StrLocalization("mbs1300txt");
                    label25.Text = CavaPlugin.StrLocalization("mbs1300txt");
                    label2.Text = CavaPlugin.StrLocalization("mbs1300txt");
                    // ReSharper restore ResourceItemNotResolved
                    EnableStartButton();
                    break;
                case 10:
                    Setspecialprofiles();
                    break;
            }

            button5.Text = CavaPlugin.StrLocalization("Close");
            button10.Text = CavaPlugin.StrLocalization("Close");
            button18.Text = CavaPlugin.StrLocalization("Close");
            button29.Text = CavaPlugin.StrLocalization("Close");
            button38.Text = CavaPlugin.StrLocalization("Close");
            button46.Text = CavaPlugin.StrLocalization("Close");
            // ReSharper restore ResourceItemNotResolved
            if (CavaPlugin.LastUseProfile > 0)
            {
                timer1.Enabled = true;
                button5.Text = CavaPlugin.StrLocalization("Cancel");
            }



        }

        private static LocalPlayer Me
        {
            get { return StyxWoW.Me; }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            _seconds -= 1;
            button9.Text = _seconds.ToString(CultureInfo.InvariantCulture);
            if (_seconds == 0)
            {
                timer1.Enabled = false;
                CPGlobalSettings.Instance.Allowlunch = true;
                CloseCavaForm();
            }
        }

        private void CloseCavaForm()
        {
            CPsettings.Instance.LastUsedPath = CavaPlugin.LastUseProfile;
            CPGlobalSettings.Instance.Save();
            CPsettings.Instance.Save();
            if (!CavaPlugin.Canceled)
            {
                timer1.Dispose();
                switch (CavaPlugin.LastUseProfile)
                {
                    default:
                        Lancaprofile(CavaPlugin.PathToCavaProfiles + "Scripts\\Next[Cava].xml");
                        break;
                    case 1:
                        Lancaprofile(CavaPlugin.PathToCavaProfiles + "Scripts\\Next[Cava].xml");
                        break;
                    case 2:
                        Lancaprofile(CavaPlugin.PathToCavaProfiles + "Scripts\\[Quest]Pandaren-Horde1to90By[Cava].xml");
                        break;
                    case 3:
                        Lancaprofile(CavaPlugin.PathToCavaProfiles + "Scripts\\[Quest]Pandaren-Alliance1to90By[Cava].xml");
                        break;
                    case 4:
                        Lancaprofile(CavaPlugin.PathToCavaProfiles + "Scripts\\ArmageddonerFast[Cava].xml");
                        break;
                    case 5:
                        Lancaprofile(CavaPlugin.PathToCavaProfiles + "Scripts\\ArmageddonerNext[Cava].xml");
                        break;
                    case 6:
                        Lancaprofile(CavaPlugin.PathToCavaProfiles + "Scripts\\ArmageddonerNext[Cava].xml");
                        break;
                    case 7:
                        Lancaprofile(CavaPlugin.PathToCavaProfiles + "Scripts\\CavaProf\\MB\\[PB]MB(Cava).xml");
                        break;
                    case 8:
                        Lancaprofile(CavaPlugin.PathToCavaProfiles + "Scripts\\CavaProf\\MB\\Free[PB]MB(Cava).xml");
                        break;
                    case 10:
                        Lancaprofile(CavaPlugin.PathToCavaProfiles + "Scripts\\[N-Quest]Armageddoner_Reserved[Cava].xml");
                        break;
                }
            }
            Close();
        }
        private void DisableStartButton()
        {
            button9.Enabled = false;
            button3.Enabled = false;
            button14.Enabled = false;
            button25.Enabled = false;
            button34.Enabled = false;
            button42.Enabled = false;
        }

        private void EnableStartButton()
        {
            button9.Enabled = true;
            button3.Enabled = true;
            button14.Enabled = true;
            button25.Enabled = true;
            button34.Enabled = true;
            button42.Enabled = true;
        }

        private bool Isanyportalchecked()
        {
            if (learnportal1checkBox.Checked || learnportal2checkBox.Checked || learnportal3checkBox.Checked || learnportal4checkBox.Checked || learnportal5checkBox.Checked || learnportal6checkBox.Checked) return true;
            return false;
        }

        private void Setspecialprofiles()
        {
            CavaPlugin.LastUseProfile = 10; //special armageddoner Profiles

            llastprofile.Text = CavaPlugin.StrLocalization("RunCheckedReservedProfiles");
            label6.Text = CavaPlugin.StrLocalization("RunCheckedReservedProfiles");
            label9.Text = CavaPlugin.StrLocalization("RunCheckedReservedProfiles");
            label14.Text = CavaPlugin.StrLocalization("RunCheckedReservedProfiles");
            label11.Text = CavaPlugin.StrLocalization("RunCheckedReservedProfiles");
            label17.Text = CavaPlugin.StrLocalization("RunCheckedReservedProfiles");
            //
            label28.Text = CavaPlugin.StrLocalization("RunCheckedReservedProfilestxt");
            label8.Text = CavaPlugin.StrLocalization("RunCheckedReservedProfilestxt");
            label13.Text = CavaPlugin.StrLocalization("RunCheckedReservedProfilestxt");
            label19.Text = CavaPlugin.StrLocalization("RunCheckedReservedProfilestxt");
            label25.Text = CavaPlugin.StrLocalization("RunCheckedReservedProfilestxt");
            label2.Text = CavaPlugin.StrLocalization("RunCheckedReservedProfilestxt");
            // ReSharper restore ResourceItemNotResolved
            EnableStartButton();
        }

        private void Setnoneprofile()
        {
            CavaPlugin.LastUseProfile = 0; //special armageddoner Profiles

            llastprofile.Text = CavaPlugin.StrLocalization("lastusedprofiletxtdef");
            label6.Text = CavaPlugin.StrLocalization("lastusedprofiletxtdef");
            label9.Text = CavaPlugin.StrLocalization("lastusedprofiletxtdef");
            label14.Text = CavaPlugin.StrLocalization("lastusedprofiletxtdef");
            label11.Text = CavaPlugin.StrLocalization("lastusedprofiletxtdef");
            label17.Text = CavaPlugin.StrLocalization("lastusedprofiletxtdef");
            //
            label28.Text = "";
            label8.Text = "";
            label13.Text = "";
            label19.Text = "";
            label25.Text = "";
            label2.Text = "";
            // ReSharper restore ResourceItemNotResolved
            DisableStartButton();
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            CavaPlugin.Player.SoundLocation = CavaPlugin.SoundPath + "Over.wav";
            CavaPlugin.Player.Play();
        }

        private void button_Click()
        {
            CavaPlugin.Player.SoundLocation = CavaPlugin.SoundPath + "Click.wav";
            CavaPlugin.Player.Play();
        }

        #region on click Buttons
        private void button23_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage2");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage3");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage4");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage5");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage6");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage3");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage4");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage5");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage6");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage1");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage2");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage4");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage5");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage6");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage1");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage2");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage3");
        }

        private void button32_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage5");
        }

        private void button30_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage6");
        }

        private void button36_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage1");
        }

        private void button37_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage2");
        }

        private void button35_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage3");
        }

        private void button33_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage4");
        }

        private void button39_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage6");
        }

        private void button44_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage1");
        }

        private void button45_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage2");
        }

        private void button43_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage3");
        }

        private void button41_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage4");
        }

        private void button48_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage5");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage3");
        }
        #endregion

        private void TestAccessbutton_Click(object sender, EventArgs e)
        {
            button_Click();
            CPGlobalSettings.Instance.CpLogin = LogintextBox.Text;
            CPGlobalSettings.Instance.CpPassword = CavaPlugin.Encrypt(PasswordtextBox.Text);
            CPGlobalSettings.Instance.Save();
            CavaPlugin.CheckAccess();
            if (CavaPlugin.IsRegisteredUser)
            {
                pictureBox13.Visible = false;
                MiningBlacksmithingProf.Enabled = true;
                pictureBox10.Image = Image.FromFile(CavaPlugin.ImagePath + "y.png");
            }
            else
            {
                pictureBox10.Image = Image.FromFile(CavaPlugin.ImagePath + "n.png");
                pictureBox13.Image = Image.FromFile(CavaPlugin.ImagePath + "register.png");
                pictureBox13.Visible = true;
                MiningBlacksmithingProf.Checked = false;
                MiningBlacksmithingProf.Enabled = false;
                CavaPlugin.IsArmageddonerUser = false;
                CavaPlugin.HaveMiningBlacksmithingAccess = false;
            }
            if (CavaPlugin.IsArmageddonerUser)
            {
                pictureBox11.Image = Image.FromFile(CavaPlugin.ImagePath + "y.png");
                pictureBox9.Visible = false;
                AntiStuck_CheckBox.Enabled = true;
                AntiStuck_CheckBox.Checked = CPsettings.Instance.AntiStuckSystem;
                AutoShutDown_Checkbox.Enabled = true;
                AutoShutDown_Checkbox.Checked = CPGlobalSettings.Instance.AutoShutdownWhenUpdate;
                disableplugincheckBox.Enabled = true;
                disableplugincheckBox.Checked = CPGlobalSettings.Instance.DisablePlugin;
                if ((Lua.GetReturnVal<int>("return GetNumCompanions('CRITTER')", 0)) > 0)
                {
                    AllowSummonPet_Checkbox.Enabled = true;
                    AllowSummonPet_Checkbox.Checked = CPsettings.Instance.CheckAllowSummonPet;
                }
                else
                {
                    AllowSummonPet_Checkbox.Enabled = false;
                    if (CPsettings.Instance.CheckAllowSummonPet)
                    {
                        CPsettings.Instance.CheckAllowSummonPet = false;
                        CPsettings.Instance.Save();
                    }
                }
                radioButton5.Enabled = true;
                guildInvitescheckBox.Enabled = true;
                refuseGuildCheckBox.Enabled = true;
                guildInvitescheckBox.Checked = CPsettings.Instance.GuildInvitescheck;
                refuseGuildCheckBox.Checked = CPsettings.Instance.refuseguildInvitescheck;
                if (guildInvitescheckBox.Checked)
                {
                    refuseGuildCheckBox.Checked = false;
                    CPsettings.Instance.refuseguildInvitescheck = false;
                }
                if (refuseGuildCheckBox.Checked)
                {
                    guildInvitescheckBox.Checked = false;
                    CPsettings.Instance.GuildInvitescheck = false;
                }
                refusePartyCheckBox.Enabled = true;
                refusePartyCheckBox.Checked = CPsettings.Instance.RefusepartyInvitescheck;
                refuseTradesCheckBox.Enabled = true;
                refuseTradesCheckBox.Checked = CPsettings.Instance.RefusetradeInvitescheck;
                refuseDuelCheckBox.Enabled = true;
                refuseDuelCheckBox.Checked = CPsettings.Instance.RefuseduelInvitescheck;
                ResscheckBox.Enabled = true;
                ResscheckBox.Checked = CPsettings.Instance.RessAfterDie;
                combatloot_checkBox.Enabled = true;
                combatloot_checkBox.Checked = CPsettings.Instance.CombatLoot;
                fixmountcheckBox1.Enabled = true;
                fixmountcheckBox1.Checked = CPsettings.Instance.FixMountFlightVendor;
                antigankcheckBox.Enabled = true;
                playsoundcheckBox.Enabled = true;
                antigankcheckBox.Checked = CPsettings.Instance.AntigankcheckBox;
                playsoundcheckBox.Checked = CPsettings.Instance.Playsonar;
                OpenBox_checkBox.Enabled = StyxWoW.Me.Class == WoWClass.Rogue;
                OpenBox_checkBox.Checked = CPsettings.Instance.OpenBox;
                Checkarmageddonerreservedprofiles();
            }
            else
            {
                pictureBox11.Image = Image.FromFile(CavaPlugin.ImagePath + "n.png");
                pictureBox9.Image = Image.FromFile(CavaPlugin.ImagePath + "donate2.gif");
                pictureBox9.Visible = true;
                AntiStuck_CheckBox.Checked = false;
                AntiStuck_CheckBox.Enabled = false;
                AutoShutDown_Checkbox.Checked = false;
                AutoShutDown_Checkbox.Enabled = false;
                disableplugincheckBox.Checked = true;
                disableplugincheckBox.Enabled = false;
                AllowSummonPet_Checkbox.Checked = false;
                AllowSummonPet_Checkbox.Enabled = false;
                radioButton5.Enabled = false;
                if (CavaPlugin.LastUseProfile == 5)
                {
                    CavaPlugin.LastUseProfile = 0;
                    CPsettings.Instance.LastUsedPath = 0;
                }
                guildInvitescheckBox.Enabled = false;
                guildInvitescheckBox.Checked = false;
                refuseGuildCheckBox.Enabled = false;
                refuseGuildCheckBox.Checked = false;
                refusePartyCheckBox.Enabled = false;
                refusePartyCheckBox.Checked = false;
                refuseTradesCheckBox.Enabled = false;
                refuseTradesCheckBox.Checked = false;
                refuseDuelCheckBox.Enabled = false;
                refuseDuelCheckBox.Checked = false;
                ResscheckBox.Checked = false;
                ResscheckBox.Enabled = false;
                combatloot_checkBox.Checked = false;
                combatloot_checkBox.Enabled = false;
                fixmountcheckBox1.Checked = false;
                fixmountcheckBox1.Enabled = false;
                antigankcheckBox.Checked = false;
                antigankcheckBox.Enabled = false;
                playsoundcheckBox.Checked = false;
                playsoundcheckBox.Enabled = false;
                OpenBox_checkBox.Checked = false;
                OpenBox_checkBox.Enabled = false;
                learnportal1checkBox.Enabled = false;
                learnportal1checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal1", null);
                learnportal2checkBox.Enabled = false;
                learnportal2checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal2", null);
                learnportal3checkBox.Enabled = false;
                learnportal3checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal3", null);
                learnportal4checkBox.Enabled = false;
                learnportal4checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal4", null);
                learnportal5checkBox.Enabled = false;
                learnportal5checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal5", null);
                learnportal6checkBox.Enabled = false;
                learnportal6checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal6", null);
            }
            if (CavaPlugin.HaveMiningBlacksmithingAccess)
            {
                pictureBox12.Image = Image.FromFile(CavaPlugin.ImagePath + "y.png");
                pictureBox14.Visible = false;
                pictureBox8.Visible = false;
                ProfMinBlack1600radioButton.Enabled = true;
                if (CPsettings.Instance.LastUsedPath == 7)
                {
                    ProfMinBlack1600radioButton.Checked = true;
                    CavaPlugin.LastUseProfile = 7;
                }
            }
            else
            {
                pictureBox12.Image = Image.FromFile(CavaPlugin.ImagePath + "n.png");
                pictureBox14.Image = Image.FromFile(CavaPlugin.ImagePath + "donate2.gif");
                pictureBox14.Visible = true;
                pictureBox8.Image = Image.FromFile(CavaPlugin.ImagePath + "donate2.gif");
                pictureBox8.Visible = true;
                ProfMinBlack1600radioButton.Checked = false;
                ProfMinBlack1600radioButton.Enabled = false;
            }
        }

        private void Checkarmageddonerreservedprofiles()
        {
            if (StyxWoW.Me.Level >= 80 && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[25316]", 0))
            {
                learnportal1checkBox.Enabled = true;
                if (CPsettings.Instance.Learnportal1)
                {
                    learnportal1checkBox.Checked = true;
                    AppDomain.CurrentDomain.SetData("learnportal1", "true");
                }
                else
                {
                    learnportal1checkBox.Checked = false;
                    AppDomain.CurrentDomain.SetData("learnportal1", null);
                }
            }
            else
            {
                learnportal1checkBox.Enabled = false;
                learnportal1checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal1", null);
                CPsettings.Instance.Learnportal1 = false;
            }
            if (StyxWoW.Me.Level >= 80 && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[14182]", 0) && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[25924]", 0))
            {
                learnportal2checkBox.Enabled = true;
                if (CPsettings.Instance.Learnportal2)
                {
                    learnportal2checkBox.Checked = true;
                    AppDomain.CurrentDomain.SetData("learnportal2", "true");
                }
                else
                {
                    learnportal2checkBox.Checked = false;
                    AppDomain.CurrentDomain.SetData("learnportal2", null);
                }
            }
            else
            {
                learnportal2checkBox.Enabled = false;
                learnportal2checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal2", null);
                CPsettings.Instance.Learnportal2 = false;
            }
            if (StyxWoW.Me.Level >= 82 && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[27123]", 0))
            {
                learnportal3checkBox.Enabled = true;
                if (CPsettings.Instance.Learnportal3)
                {
                    learnportal3checkBox.Checked = true;
                    AppDomain.CurrentDomain.SetData("learnportal3", "true");
                }
                else
                {
                    learnportal3checkBox.Checked = false;
                    AppDomain.CurrentDomain.SetData("learnportal3", null);
                }
            }
            else
            {
                learnportal3checkBox.Enabled = false;
                learnportal3checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal3", null);
                CPsettings.Instance.Learnportal3 = false;
            }
            if (StyxWoW.Me.Level >= 83 && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[28112]", 0))
            {
                learnportal4checkBox.Enabled = true;
                if (CPsettings.Instance.Learnportal4)
                {
                    learnportal4checkBox.Checked = true;
                    AppDomain.CurrentDomain.SetData("learnportal4", "true");
                }
                else
                {
                    learnportal4checkBox.Checked = false;
                    AppDomain.CurrentDomain.SetData("learnportal4", null);
                }
            }
            else
            {
                learnportal4checkBox.Enabled = false;
                learnportal4checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal4", null);
                CPsettings.Instance.Learnportal4 = false;
            }

            if (StyxWoW.Me.Level >= 85 && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[27538]", 0))
            {
                learnportal5checkBox.Enabled = true;
                if (CPsettings.Instance.Learnportal5)
                {
                    learnportal5checkBox.Checked = true;
                    AppDomain.CurrentDomain.SetData("learnportal5", "true");
                }
                else
                {
                    learnportal5checkBox.Checked = false;
                    AppDomain.CurrentDomain.SetData("learnportal5", null);
                }
            }
            else
            {
                learnportal5checkBox.Enabled = false;
                learnportal5checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal5", null);
                CPsettings.Instance.Learnportal5 = false;
            }

            if (StyxWoW.Me.Level >= 85 && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[31733]", 0) && !Lua.GetReturnVal<bool>("return GetQuestsCompleted()[31766]", 0))
            {
                learnportal6checkBox.Enabled = true;
                if (CPsettings.Instance.Learnportal6)
                {
                    learnportal6checkBox.Checked = true;
                    AppDomain.CurrentDomain.SetData("learnportal6", "true");
                }
                else
                {
                    learnportal6checkBox.Checked = false;
                    AppDomain.CurrentDomain.SetData("learnportal6", null);
                }
            }
            else
            {
                learnportal6checkBox.Enabled = false;
                learnportal6checkBox.Checked = false;
                AppDomain.CurrentDomain.SetData("learnportal6", null);
                CPsettings.Instance.Learnportal6 = false;
            }
        }

        private void selectserver1radio_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CavaPlugin.UseServer = 0;
            CPGlobalSettings.Instance.UseServer = 0;
        }

        private void selectserver2radio_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CavaPlugin.UseServer = 1;
            CPGlobalSettings.Instance.UseServer = 1;
        }

        private void AntiStuck_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CPsettings.Instance.AntiStuckSystem = AntiStuck_CheckBox.Checked;
        }

        private void AutoShutDown_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CPGlobalSettings.Instance.AutoShutdownWhenUpdate = AutoShutDown_Checkbox.Checked;

        }

        private void disableplugincheckBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CavaPlugin.RunPrimumBotPulse = disableplugincheckBox.Checked;
            CPGlobalSettings.Instance.DisablePlugin = disableplugincheckBox.Checked;
        }

        private void AllowSummonPet_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CPsettings.Instance.CheckAllowSummonPet = AllowSummonPet_Checkbox.Checked;
        }

        private void breport_Click(object sender, EventArgs e)
        {
            button_Click();
            var sInfo = new ProcessStartInfo("https://cavaprofiles.net/index.php/tickets/new-ticket");
            Process.Start(sInfo);
        }

        private void guildInvitescheckBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            refuseGuildCheckBox.Checked = false;
            CPsettings.Instance.refuseguildInvitescheck = refuseGuildCheckBox.Checked;
            CPsettings.Instance.GuildInvitescheck = guildInvitescheckBox.Checked;
        }

        private void refuseTradesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CPsettings.Instance.RefusetradeInvitescheck = refuseTradesCheckBox.Checked;

        }

        private void refuseGuildCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            guildInvitescheckBox.Checked = false;
            CPsettings.Instance.GuildInvitescheck = guildInvitescheckBox.Checked;
            CPsettings.Instance.refuseguildInvitescheck = refuseGuildCheckBox.Checked;

        }

        private void refusePartyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CPsettings.Instance.RefusepartyInvitescheck = refusePartyCheckBox.Checked;

        }

        private void refuseDuelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CPsettings.Instance.RefuseduelInvitescheck = refuseDuelCheckBox.Checked;

        }

        private void ResscheckBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CPsettings.Instance.RessAfterDie = ResscheckBox.Checked;
        }

        private void combatloot_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CPsettings.Instance.CombatLoot = combatloot_checkBox.Checked;
        }

        private void fixmountcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CPsettings.Instance.FixMountFlightVendor = fixmountcheckBox1.Checked;
        }

        private void antigankcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CPsettings.Instance.AntigankcheckBox = antigankcheckBox.Checked;
            if (!antigankcheckBox.Checked)
            {
                playsoundcheckBox.Enabled = false;
                playsoundcheckBox.Checked = false;
            }

        }

        private void playsoundcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CPsettings.Instance.Playsonar = playsoundcheckBox.Checked;
        }

        private void OpenBox_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            CPsettings.Instance.OpenBox = OpenBox_checkBox.Checked;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            button_Click();
            var sInfo = new ProcessStartInfo("https://cavaprofiles.net/index.php/access/new-user");
            Process.Start(sInfo);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            button_Click();
            var sInfo = new ProcessStartInfo("https://cavaprofiles.net/index.php/plans/plans-list/by-category/membership-plans?id=2");
            Process.Start(sInfo);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            button_Click();
            var sInfo = new ProcessStartInfo("https://cavaprofiles.net/index.php/plans/plans-list/by-category/membership-plans?id=2");
            Process.Start(sInfo);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            button_Click();
            var sInfo = new ProcessStartInfo("https://cavaprofiles.net/index.php/plans/plans-list/by-category/membership-plans?id=1");
            Process.Start(sInfo);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            button_Click();
            var sInfo = new ProcessStartInfo("http://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=5S8G78PRDGUFG");
            Process.Start(sInfo);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            CavaPlugin.LastUseProfile = 1; //Leveling 1 to 90

            llastprofile.Text = CavaPlugin.StrLocalization("leveling1to90");
            label6.Text = CavaPlugin.StrLocalization("leveling1to90");
            label9.Text = CavaPlugin.StrLocalization("leveling1to90");
            label14.Text = CavaPlugin.StrLocalization("leveling1to90");
            label11.Text = CavaPlugin.StrLocalization("leveling1to90");
            label17.Text = CavaPlugin.StrLocalization("leveling1to90");
            //
            label28.Text = CavaPlugin.StrLocalization("leveling1to90txt");
            label8.Text = CavaPlugin.StrLocalization("leveling1to90txt");
            label13.Text = CavaPlugin.StrLocalization("leveling1to90txt");
            label19.Text = CavaPlugin.StrLocalization("leveling1to90txt");
            label25.Text = CavaPlugin.StrLocalization("leveling1to90txt");
            label2.Text = CavaPlugin.StrLocalization("leveling1to90txt");
            // ReSharper restore ResourceItemNotResolved
            EnableStartButton();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            CavaPlugin.LastUseProfile = 2; //pandaren horde 1 to 12->12 to 90

            llastprofile.Text = CavaPlugin.StrLocalization("levelingpandahorde");
            label6.Text = CavaPlugin.StrLocalization("levelingpandahorde");
            label9.Text = CavaPlugin.StrLocalization("levelingpandahorde");
            label14.Text = CavaPlugin.StrLocalization("levelingpandahorde");
            label11.Text = CavaPlugin.StrLocalization("levelingpandahorde");
            label17.Text = CavaPlugin.StrLocalization("levelingpandahorde");
            //
            label28.Text = CavaPlugin.StrLocalization("levelingpandahordetxt");
            label8.Text = CavaPlugin.StrLocalization("levelingpandahordetxt");
            label13.Text = CavaPlugin.StrLocalization("levelingpandahordetxt");
            label19.Text = CavaPlugin.StrLocalization("levelingpandahordetxt");
            label25.Text = CavaPlugin.StrLocalization("levelingpandahordetxt");
            label2.Text = CavaPlugin.StrLocalization("levelingpandahordetxt");
            // ReSharper restore ResourceItemNotResolved
            EnableStartButton();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            CavaPlugin.LastUseProfile = 3; //pandaren ally 1 to 12->12 to 90

            llastprofile.Text = CavaPlugin.StrLocalization("levelingpandaally");
            label6.Text = CavaPlugin.StrLocalization("levelingpandaally");
            label9.Text = CavaPlugin.StrLocalization("levelingpandaally");
            label14.Text = CavaPlugin.StrLocalization("levelingpandaally");
            label11.Text = CavaPlugin.StrLocalization("levelingpandaally");
            label17.Text = CavaPlugin.StrLocalization("levelingpandaally");
            //
            label28.Text = CavaPlugin.StrLocalization("levelingpandaallytxt");
            label8.Text = CavaPlugin.StrLocalization("levelingpandaallytxt");
            label13.Text = CavaPlugin.StrLocalization("levelingpandaallytxt");
            label19.Text = CavaPlugin.StrLocalization("levelingpandaallytxt");
            label25.Text = CavaPlugin.StrLocalization("levelingpandaallytxt");
            label2.Text = CavaPlugin.StrLocalization("levelingpandaallytxt");
            // ReSharper restore ResourceItemNotResolved
            EnableStartButton();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            CavaPlugin.LastUseProfile = 5; //armageddoner 81 to 90

            llastprofile.Text = CavaPlugin.StrLocalization("levelingarmagessoner");
            label6.Text = CavaPlugin.StrLocalization("levelingarmagessoner");
            label9.Text = CavaPlugin.StrLocalization("levelingarmagessoner");
            label14.Text = CavaPlugin.StrLocalization("levelingarmagessoner");
            label11.Text = CavaPlugin.StrLocalization("levelingarmagessoner");
            label17.Text = CavaPlugin.StrLocalization("levelingarmagessoner");
            //
            label28.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
            label8.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
            label13.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
            label19.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
            label25.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
            label2.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
            // ReSharper restore ResourceItemNotResolved
            EnableStartButton();
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            CavaPlugin.LastUseProfile = 4; //armageddoner 81 to 90 fast

            llastprofile.Text = CavaPlugin.StrLocalization("levelingarmagessonerfast");
            label6.Text = CavaPlugin.StrLocalization("levelingarmagessonerfast");
            label9.Text = CavaPlugin.StrLocalization("levelingarmagessonerfast");
            label14.Text = CavaPlugin.StrLocalization("levelingarmagessonerfast");
            label11.Text = CavaPlugin.StrLocalization("levelingarmagessonerfast");
            label17.Text = CavaPlugin.StrLocalization("levelingarmagessonerfast");
            //
            label28.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
            label8.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
            label13.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
            label19.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
            label25.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
            label2.Text = CavaPlugin.StrLocalization("levelarmageddonerto90txt");
            // ReSharper restore ResourceItemNotResolved
            EnableStartButton();
        }

        private void ProfMinBlack1600radioButton_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            CavaPlugin.LastUseProfile = 7; //MB 1 to 600

            llastprofile.Text = CavaPlugin.StrLocalization("miningbs1600");
            label6.Text = CavaPlugin.StrLocalization("miningbs1600");
            label9.Text = CavaPlugin.StrLocalization("miningbs1600");
            label14.Text = CavaPlugin.StrLocalization("miningbs1600");
            label11.Text = CavaPlugin.StrLocalization("miningbs1600");
            label17.Text = CavaPlugin.StrLocalization("miningbs1600");
            //
            label28.Text = CavaPlugin.StrLocalization("mbs1600txt");
            label8.Text = CavaPlugin.StrLocalization("mbs1600txt");
            label13.Text = CavaPlugin.StrLocalization("mbs1600txt");
            label19.Text = CavaPlugin.StrLocalization("mbs1600txt");
            label25.Text = CavaPlugin.StrLocalization("mbs1600txt");
            label2.Text = CavaPlugin.StrLocalization("mbs1600txt");
            // ReSharper restore ResourceItemNotResolved
            EnableStartButton();
        }

        private void MiningBlacksmithingProf_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            CavaPlugin.LastUseProfile = 8; //MB 1 to 300

            llastprofile.Text = CavaPlugin.StrLocalization("miningbs1300");
            label6.Text = CavaPlugin.StrLocalization("miningbs1300");
            label9.Text = CavaPlugin.StrLocalization("miningbs1300");
            label14.Text = CavaPlugin.StrLocalization("miningbs1300");
            label11.Text = CavaPlugin.StrLocalization("miningbs1300");
            label17.Text = CavaPlugin.StrLocalization("miningbs1300");
            //
            label28.Text = CavaPlugin.StrLocalization("mbs1300txt");
            label8.Text = CavaPlugin.StrLocalization("mbs1300txt");
            label13.Text = CavaPlugin.StrLocalization("mbs1300txt");
            label19.Text = CavaPlugin.StrLocalization("mbs1300txt");
            label25.Text = CavaPlugin.StrLocalization("mbs1300txt");
            label2.Text = CavaPlugin.StrLocalization("mbs1300txt");
            // ReSharper restore ResourceItemNotResolved
            EnableStartButton();
        }

        private void learnportal1checkBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            if (Isanyportalchecked())
            {
                Setspecialprofiles();
            }
            else
            {
                Setnoneprofile();
            }
            AppDomain.CurrentDomain.SetData("learnportal1", learnportal1checkBox.Checked ? "true" : null);
            CPsettings.Instance.Learnportal1 = learnportal1checkBox.Checked;
        }

        private void learnportal2checkBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            if (Isanyportalchecked())
            {
                Setspecialprofiles();
            }
            else
            {
                Setnoneprofile();
            }
            AppDomain.CurrentDomain.SetData("learnportal2", learnportal2checkBox.Checked ? "true" : null);
            CPsettings.Instance.Learnportal2 = learnportal2checkBox.Checked;
        }

        private void learnportal3checkBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            if (Isanyportalchecked())
            {
                Setspecialprofiles();
            }
            else
            {
                Setnoneprofile();
            }
            AppDomain.CurrentDomain.SetData("learnportal3", learnportal3checkBox.Checked ? "true" : null);
            CPsettings.Instance.Learnportal3 = learnportal3checkBox.Checked;
        }

        private void learnportal4checkBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            if (Isanyportalchecked())
            {
                Setspecialprofiles();
            }
            else
            {
                Setnoneprofile();
            }
            AppDomain.CurrentDomain.SetData("learnportal4", learnportal4checkBox.Checked ? "true" : null);
            CPsettings.Instance.Learnportal4 = learnportal4checkBox.Checked;
        }

        private void learnportal5checkBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            if (Isanyportalchecked())
            {
                Setspecialprofiles();
            }
            else
            {
                Setnoneprofile();
            }
            AppDomain.CurrentDomain.SetData("learnportal5", learnportal5checkBox.Checked ? "true" : null);
            CPsettings.Instance.Learnportal5 = learnportal5checkBox.Checked;
        }

        private void learnportal6checkBox_CheckedChanged(object sender, EventArgs e)
        {
            button_Click();
            timer1.Enabled = false;
            if (Isanyportalchecked())
            {
                Setspecialprofiles();
            }
            else
            {
                Setnoneprofile();
            }
            AppDomain.CurrentDomain.SetData("learnportal6", learnportal6checkBox.Checked ? "true" : null);
            CPsettings.Instance.Learnportal6 = learnportal6checkBox.Checked;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                button_Click();
                timer1.Enabled = false;
                button5.Text = CavaPlugin.StrLocalization("Close");
                button10.Text = CavaPlugin.StrLocalization("Close");
                button9.Text = CavaPlugin.StrLocalization("Start");
                // ReSharper restore ResourceItemNotResolved
            }
            else
            {
                CavaPlugin.Canceled = true;
                CloseCavaForm();
                CavaPluginLog.Fatal("CavaPlugin Stopped");
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            CavaPlugin.Canceled = true;
            CloseCavaForm();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            CavaPlugin.Canceled = true;
            CloseCavaForm();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            CavaPlugin.Canceled = true;
            CloseCavaForm();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            CavaPlugin.Canceled = true;
            CloseCavaForm();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            CavaPlugin.Canceled = true;
            CloseCavaForm();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CPGlobalSettings.Instance.Allowlunch = true;
            CloseCavaForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CPGlobalSettings.Instance.Allowlunch = true;
            CloseCavaForm();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            CPGlobalSettings.Instance.Allowlunch = true;
            CloseCavaForm();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            CPGlobalSettings.Instance.Allowlunch = true;
            CloseCavaForm();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            CPGlobalSettings.Instance.Allowlunch = true;
            CloseCavaForm();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            CPGlobalSettings.Instance.Allowlunch = true;
            CloseCavaForm();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_Click();
            if (comboBox2.SelectedIndex == 0)
            {
                AppDomain.CurrentDomain.SetData("FriendoftheExarchs", null);
                CPsettings.Instance.FriendoftheExarchs = "null";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                if (Me.IsAlliance)
                {
                    AppDomain.CurrentDomain.SetData("FriendoftheExarchs", "Andren");
                    CPsettings.Instance.FriendoftheExarchs = "Andren";
                }
                if (Me.IsHorde)
                {
                    AppDomain.CurrentDomain.SetData("FriendoftheExarchs", "Geyah");
                    CPsettings.Instance.FriendoftheExarchs = "Geyah";
                }
            }

        
            if (comboBox2.SelectedIndex == 2)
            {
                if (Me.IsAlliance)
                {
                    AppDomain.CurrentDomain.SetData("FriendoftheExarchs", "Chel");
                    CPsettings.Instance.FriendoftheExarchs = "Chel";
                }
                if (Me.IsHorde)
                {
                    AppDomain.CurrentDomain.SetData("FriendoftheExarchs", "Kalgor");
                    CPsettings.Instance.FriendoftheExarchs = "Kalgor";
                }
            }
            if (comboBox2.SelectedIndex == 3)
            {
                if (Me.IsAlliance)
                {
                    AppDomain.CurrentDomain.SetData("FriendoftheExarchs", "Onaala");
                    CPsettings.Instance.FriendoftheExarchs = "Onaala";
                }
                if (Me.IsHorde)
                {
                    AppDomain.CurrentDomain.SetData("FriendoftheExarchs", "Lokra");
                    CPsettings.Instance.FriendoftheExarchs = "Lokra";
                }
            }
            CPsettings.Instance.Save();
        }

        private void Lancaprofile(string profileToLoad)
        {
            timer1.Dispose();
            Close();
            BotBase botBase;
            if (profileToLoad.Contains("CavaProf"))
            {
                BotManager.Instance.Bots.TryGetValue("ProfessionBuddy", out botBase);
                if (botBase != null)
                {
                    if (BotManager.Current != botBase)
                    {
                        if (TreeRoot.IsRunning)
                        {
                            CavaPluginLog.Debug("Honorbuddy Is Running");
                            TreeRoot.Stop();
                            CavaPluginLog.Debug("Honorbuddy Is now stopped");
                        }
                        CavaPluginLog.Debug("Changing to ProfessionBuddy Bot");
                        BotManager.Instance.SetCurrent(botBase);
                    }
                }
                else
                    CavaPluginLog.Fatal("Unable to locate ProfessionBuddy bot");
            }
            else
            {
                BotManager.Instance.Bots.TryGetValue("Questing", out botBase);
                if (botBase != null)
                {
                    if (BotManager.Current != botBase)
                    {
                        if (TreeRoot.IsRunning)
                        {
                            CavaPluginLog.Debug("Honorbuddy Is Running");
                            TreeRoot.Stop();
                            CavaPluginLog.Debug("Honorbuddy Is now stopped");
                        }
                        CavaPluginLog.Debug("Changing to Quest Bot");
                        BotManager.Instance.SetCurrent(botBase);
                    }
                }
                else
                    CavaPluginLog.Fatal("Unable to locate Questing bot");
            }
            CavaPluginLog.Debug("loading Profile: " + profileToLoad);
            ProfileManager.LoadNew(profileToLoad, false);
            CavaPluginLog.Debug("Starting Honorbuddy");
            TreeRoot.Start();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
       {
           button_Click();
           if (comboBox3.SelectedIndex == 0)
           {
               AppDomain.CurrentDomain.SetData("GorgondOutpost", null);
               CPsettings.Instance.GorgondOutpost = "null";
           }
           if (comboBox3.SelectedIndex == 1)
           {
               AppDomain.CurrentDomain.SetData("GorgondOutpost", "LoggingCampLumberYard");
               CPsettings.Instance.GorgondOutpost = "LoggingCampLumberYard";
           }
           if (comboBox3.SelectedIndex == 2)
           {
               AppDomain.CurrentDomain.SetData("GorgondOutpost", "SparringRingSavageFightClub");
               CPsettings.Instance.GorgondOutpost = "SparringRingSavageFightClub";
           }
           CPsettings.Instance.Save();
       }

}

} 

