using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Styx.Common;

namespace CavaPlugin
{
    partial class CavaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lversion = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label28 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.breport = new System.Windows.Forms.Button();
            this.ReservedTextBox = new System.Windows.Forms.RichTextBox();
            this.button22 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.llastprofile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.MiningBlacksmithingProf = new System.Windows.Forms.RadioButton();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.ProfMinBlack1600radioButton = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.learnportal1checkBox = new System.Windows.Forms.CheckBox();
            this.learnportal6checkBox = new System.Windows.Forms.CheckBox();
            this.learnportal3checkBox = new System.Windows.Forms.CheckBox();
            this.learnportal4checkBox = new System.Windows.Forms.CheckBox();
            this.learnportal2checkBox = new System.Windows.Forms.CheckBox();
            this.learnportal5checkBox = new System.Windows.Forms.CheckBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.connectgroupBox = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.selectserver2radio = new System.Windows.Forms.RadioButton();
            this.selectserver1radio = new System.Windows.Forms.RadioButton();
            this.passwordlabel = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.TestAccessbutton = new System.Windows.Forms.Button();
            this.PasswordtextBox = new System.Windows.Forms.TextBox();
            this.LogintextBox = new System.Windows.Forms.TextBox();
            this.loginlabel = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.combatloot_checkBox = new System.Windows.Forms.CheckBox();
            this.refuseDuelCheckBox = new System.Windows.Forms.CheckBox();
            this.ResscheckBox = new System.Windows.Forms.CheckBox();
            this.playsoundcheckBox = new System.Windows.Forms.CheckBox();
            this.antigankcheckBox = new System.Windows.Forms.CheckBox();
            this.fixmountcheckBox1 = new System.Windows.Forms.CheckBox();
            this.OpenBox_checkBox = new System.Windows.Forms.CheckBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.charsetgroupBox = new System.Windows.Forms.GroupBox();
            this.AntiStuck_CheckBox = new System.Windows.Forms.CheckBox();
            this.AllowSummonPet_Checkbox = new System.Windows.Forms.CheckBox();
            this.refuseTradesCheckBox = new System.Windows.Forms.CheckBox();
            this.refusePartyCheckBox = new System.Windows.Forms.CheckBox();
            this.guildInvitescheckBox = new System.Windows.Forms.CheckBox();
            this.refuseGuildCheckBox = new System.Windows.Forms.CheckBox();
            this.globalsetgroupBox = new System.Windows.Forms.GroupBox();
            this.disableplugincheckBox = new System.Windows.Forms.CheckBox();
            this.AutoShutDown_Checkbox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.labelprofmb600 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button41 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.button43 = new System.Windows.Forms.Button();
            this.button44 = new System.Windows.Forms.Button();
            this.button45 = new System.Windows.Forms.Button();
            this.button46 = new System.Windows.Forms.Button();
            this.button47 = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.MainBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.connectgroupBox.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.charsetgroupBox.SuspendLayout();
            this.globalsetgroupBox.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // lversion
            // 
            this.lversion.AutoSize = true;
            this.lversion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.lversion.Location = new System.Drawing.Point(653, 339);
            this.lversion.Name = "lversion";
            this.lversion.Size = new System.Drawing.Size(108, 13);
            this.lversion.TabIndex = 0;
            this.lversion.Text = "Version 0,123456789";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(-2, -1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(867, 612);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button31);
            this.tabPage1.Controls.Add(this.button23);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.button22);
            this.tabPage1.Controls.Add(this.button21);
            this.tabPage1.Controls.Add(this.llastprofile);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.MainBox);
            this.tabPage1.Controls.Add(this.lversion);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(840, 604);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(7, 560);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 13);
            this.label28.TabIndex = 67;
            this.label28.Text = "label28";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gold;
            this.label7.Location = new System.Drawing.Point(682, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 26);
            this.label7.TabIndex = 17;
            this.label7.Text = "Main";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(652, 355);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 62);
            this.button1.TabIndex = 48;
            this.button1.TabStop = false;
            this.button1.Text = "Reserved Profiles";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(656, 421);
            this.button9.Margin = new System.Windows.Forms.Padding(0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(180, 180);
            this.button9.TabIndex = 47;
            this.button9.TabStop = false;
            this.button9.Text = "Start";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            this.button9.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(590, 355);
            this.button7.Margin = new System.Windows.Forms.Padding(0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(62, 62);
            this.button7.TabIndex = 46;
            this.button7.TabStop = false;
            this.button7.Text = "Professions";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            this.button7.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.Color.Transparent;
            this.button31.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button31.Enabled = false;
            this.button31.FlatAppearance.BorderSize = 0;
            this.button31.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button31.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button31.ForeColor = System.Drawing.Color.White;
            this.button31.Location = new System.Drawing.Point(590, 479);
            this.button31.Margin = new System.Windows.Forms.Padding(0);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(62, 62);
            this.button31.TabIndex = 45;
            this.button31.TabStop = false;
            this.button31.Text = "Main";
            this.button31.UseVisualStyleBackColor = false;
            this.button31.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.Transparent;
            this.button23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button23.FlatAppearance.BorderSize = 0;
            this.button23.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button23.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.ForeColor = System.Drawing.Color.White;
            this.button23.Location = new System.Drawing.Point(590, 417);
            this.button23.Margin = new System.Windows.Forms.Padding(0);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(62, 62);
            this.button23.TabIndex = 43;
            this.button23.TabStop = false;
            this.button23.Text = "Leveling";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            this.button23.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(590, 541);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(62, 62);
            this.button5.TabIndex = 0;
            this.button5.TabStop = false;
            this.button5.Text = "Cancel";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.breport);
            this.groupBox7.Controls.Add(this.ReservedTextBox);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(590, 96);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(247, 156);
            this.groupBox7.TabIndex = 34;
            this.groupBox7.TabStop = false;
            // 
            // breport
            // 
            this.breport.BackColor = System.Drawing.Color.Transparent;
            this.breport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.breport.FlatAppearance.BorderSize = 0;
            this.breport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.breport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.breport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.breport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breport.ForeColor = System.Drawing.Color.Gold;
            this.breport.Location = new System.Drawing.Point(29, 82);
            this.breport.Margin = new System.Windows.Forms.Padding(0);
            this.breport.Name = "breport";
            this.breport.Size = new System.Drawing.Size(195, 60);
            this.breport.TabIndex = 15;
            this.breport.Text = "Report New Bug";
            this.breport.UseVisualStyleBackColor = false;
            this.breport.Click += new System.EventHandler(this.breport_Click);
            this.breport.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // ReservedTextBox
            // 
            this.ReservedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.ReservedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ReservedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReservedTextBox.ForeColor = System.Drawing.Color.Gold;
            this.ReservedTextBox.Location = new System.Drawing.Point(38, 18);
            this.ReservedTextBox.Name = "ReservedTextBox";
            this.ReservedTextBox.ReadOnly = true;
            this.ReservedTextBox.Size = new System.Drawing.Size(172, 52);
            this.ReservedTextBox.TabIndex = 4;
            this.ReservedTextBox.Text = "Did You Found a Bug?\nHelp Us Reporting It !!!";
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.Transparent;
            this.button22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button22.FlatAppearance.BorderSize = 0;
            this.button22.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button22.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.ForeColor = System.Drawing.Color.White;
            this.button22.Location = new System.Drawing.Point(776, 355);
            this.button22.Margin = new System.Windows.Forms.Padding(0);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(62, 62);
            this.button22.TabIndex = 42;
            this.button22.TabStop = false;
            this.button22.Text = "About";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            this.button22.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Transparent;
            this.button21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button21.FlatAppearance.BorderSize = 0;
            this.button21.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button21.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.ForeColor = System.Drawing.Color.White;
            this.button21.Location = new System.Drawing.Point(714, 355);
            this.button21.Margin = new System.Windows.Forms.Padding(0);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(62, 62);
            this.button21.TabIndex = 41;
            this.button21.TabStop = false;
            this.button21.Text = "Armageddoner";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            this.button21.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // llastprofile
            // 
            this.llastprofile.AutoSize = true;
            this.llastprofile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llastprofile.Location = new System.Drawing.Point(7, 525);
            this.llastprofile.Name = "llastprofile";
            this.llastprofile.Size = new System.Drawing.Size(97, 20);
            this.llastprofile.TabIndex = 16;
            this.llastprofile.Text = "Profile name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(7, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Last Used Profile:";
            // 
            // MainBox
            // 
            this.MainBox.Controls.Add(this.richTextBox1);
            this.MainBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainBox.ForeColor = System.Drawing.Color.Gold;
            this.MainBox.Location = new System.Drawing.Point(7, 92);
            this.MainBox.Margin = new System.Windows.Forms.Padding(0);
            this.MainBox.Name = "MainBox";
            this.MainBox.Padding = new System.Windows.Forms.Padding(0);
            this.MainBox.Size = new System.Drawing.Size(580, 394);
            this.MainBox.TabIndex = 12;
            this.MainBox.TabStop = false;
            this.MainBox.Text = "Lattest News";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(4, 23);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(573, 364);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Controls.Add(this.button11);
            this.tabPage2.Controls.Add(this.button12);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(840, 604);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 560);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 63;
            this.label8.Text = "label8";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Gold;
            this.label24.Location = new System.Drawing.Point(663, 35);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(101, 26);
            this.label24.TabIndex = 17;
            this.label24.Text = "Leveling";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(652, 355);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 62);
            this.button2.TabIndex = 56;
            this.button2.TabStop = false;
            this.button2.Text = "Reserved Profiles";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(656, 421);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 180);
            this.button3.TabIndex = 55;
            this.button3.TabStop = false;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(590, 355);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(62, 62);
            this.button4.TabIndex = 54;
            this.button4.TabStop = false;
            this.button4.Text = "Professions";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(590, 479);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(62, 62);
            this.button6.TabIndex = 53;
            this.button6.TabStop = false;
            this.button6.Text = "Main";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button6.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.Enabled = false;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(590, 417);
            this.button8.Margin = new System.Windows.Forms.Padding(0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(62, 62);
            this.button8.TabIndex = 51;
            this.button8.TabStop = false;
            this.button8.Text = "Leveling";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(590, 541);
            this.button10.Margin = new System.Windows.Forms.Padding(0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(62, 62);
            this.button10.TabIndex = 52;
            this.button10.TabStop = false;
            this.button10.Text = "Cancel";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            this.button10.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(776, 355);
            this.button11.Margin = new System.Windows.Forms.Padding(0);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(62, 62);
            this.button11.TabIndex = 50;
            this.button11.TabStop = false;
            this.button11.Text = "About";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            this.button11.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Transparent;
            this.button12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(714, 355);
            this.button12.Margin = new System.Windows.Forms.Padding(0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(62, 62);
            this.button12.TabIndex = 49;
            this.button12.TabStop = false;
            this.button12.Text = "Armageddoner";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            this.button12.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 525);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Profile name";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.radioButton9);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Gold;
            this.groupBox2.Location = new System.Drawing.Point(7, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 394);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Leveling Profiles";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.Color.Red;
            this.label32.Location = new System.Drawing.Point(150, 185);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(197, 20);
            this.label32.TabIndex = 28;
            this.label32.Text = "To Implemente near future";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(13, 92);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(230, 20);
            this.label29.TabIndex = 27;
            this.label29.Text = "Testers / Armageddoner  Users";
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton9.Location = new System.Drawing.Point(16, 136);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(335, 24);
            this.radioButton9.TabIndex = 18;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "Alliance And Horde (81-100) (Fast Leveling)";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.radioButton9_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton5.Location = new System.Drawing.Point(16, 113);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(321, 24);
            this.radioButton5.TabIndex = 17;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Alliance And Horde (81-100) (Full Quests)";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            this.radioButton5.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.radioButton6);
            this.groupBox4.Controls.Add(this.radioButton4);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Enabled = false;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Gold;
            this.groupBox4.Location = new System.Drawing.Point(257, 205);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(317, 184);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RAF Leveling System";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Accept invite from:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(122, 152);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(189, 26);
            this.textBox5.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(172, 107);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(140, 26);
            this.textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(21, 107);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(140, 26);
            this.textBox4.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(172, 78);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 26);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(21, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 26);
            this.textBox1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Members to Invite";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton6.Location = new System.Drawing.Point(14, 135);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(76, 17);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Im Folower";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Enabled = false;
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton4.Location = new System.Drawing.Point(14, 40);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(113, 17);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "I am Group Leader";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(7, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Use Group RAF System";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Gold;
            this.groupBox3.Location = new System.Drawing.Point(6, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 184);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Leveling Options";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Location = new System.Drawing.Point(8, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 114);
            this.panel2.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Raise Archaeology While Leveling",
            "Raise Herbalism While Leveling",
            "Raise Mining While Leveling"});
            this.listBox1.Location = new System.Drawing.Point(3, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(225, 108);
            this.listBox1.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton8);
            this.panel1.Controls.Add(this.radioButton7);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(6, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 42);
            this.panel1.TabIndex = 0;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton8.Location = new System.Drawing.Point(3, 23);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(167, 17);
            this.radioButton8.TabIndex = 1;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Less Loot System(Quest itens)";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton7.Location = new System.Drawing.Point(3, 3);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(102, 17);
            this.radioButton7.TabIndex = 0;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Full Loot System";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton2.Location = new System.Drawing.Point(6, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(268, 24);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Leveling Pandaren 1 to 100 Horde";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            this.radioButton2.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton1.Location = new System.Drawing.Point(6, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(147, 24);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Leveling 1 to 100";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.radioButton1.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton3.Location = new System.Drawing.Point(6, 66);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(279, 24);
            this.radioButton3.TabIndex = 10;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Leveling Pandaren 1 to 100 Alliance";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            this.radioButton3.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(590, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 156);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(7, 500);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Selected Profile:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.button13);
            this.tabPage3.Controls.Add(this.button14);
            this.tabPage3.Controls.Add(this.button15);
            this.tabPage3.Controls.Add(this.button16);
            this.tabPage3.Controls.Add(this.button17);
            this.tabPage3.Controls.Add(this.button18);
            this.tabPage3.Controls.Add(this.button19);
            this.tabPage3.Controls.Add(this.button20);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(840, 604);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 560);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 64;
            this.label13.Text = "label13";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gold;
            this.label12.Location = new System.Drawing.Point(645, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 26);
            this.label12.TabIndex = 17;
            this.label12.Text = "Professions";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Transparent;
            this.button13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(652, 355);
            this.button13.Margin = new System.Windows.Forms.Padding(0);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(62, 62);
            this.button13.TabIndex = 56;
            this.button13.TabStop = false;
            this.button13.Text = "Reserved Profiles";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            this.button13.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Transparent;
            this.button14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button14.FlatAppearance.BorderSize = 0;
            this.button14.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(656, 421);
            this.button14.Margin = new System.Windows.Forms.Padding(0);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(180, 180);
            this.button14.TabIndex = 55;
            this.button14.TabStop = false;
            this.button14.Text = "Start";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            this.button14.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Transparent;
            this.button15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button15.Enabled = false;
            this.button15.FlatAppearance.BorderSize = 0;
            this.button15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(590, 355);
            this.button15.Margin = new System.Windows.Forms.Padding(0);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(62, 62);
            this.button15.TabIndex = 54;
            this.button15.TabStop = false;
            this.button15.Text = "Professions";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            this.button15.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Transparent;
            this.button16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button16.FlatAppearance.BorderSize = 0;
            this.button16.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.ForeColor = System.Drawing.Color.White;
            this.button16.Location = new System.Drawing.Point(590, 479);
            this.button16.Margin = new System.Windows.Forms.Padding(0);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(62, 62);
            this.button16.TabIndex = 53;
            this.button16.TabStop = false;
            this.button16.Text = "Main";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            this.button16.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Transparent;
            this.button17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button17.FlatAppearance.BorderSize = 0;
            this.button17.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.ForeColor = System.Drawing.Color.White;
            this.button17.Location = new System.Drawing.Point(590, 417);
            this.button17.Margin = new System.Windows.Forms.Padding(0);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(62, 62);
            this.button17.TabIndex = 51;
            this.button17.TabStop = false;
            this.button17.Text = "Leveling";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            this.button17.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Transparent;
            this.button18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button18.FlatAppearance.BorderSize = 0;
            this.button18.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button18.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.ForeColor = System.Drawing.Color.White;
            this.button18.Location = new System.Drawing.Point(590, 541);
            this.button18.Margin = new System.Windows.Forms.Padding(0);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(62, 62);
            this.button18.TabIndex = 52;
            this.button18.TabStop = false;
            this.button18.Text = "Cancel";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            this.button18.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.Transparent;
            this.button19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button19.FlatAppearance.BorderSize = 0;
            this.button19.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button19.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.ForeColor = System.Drawing.Color.White;
            this.button19.Location = new System.Drawing.Point(776, 355);
            this.button19.Margin = new System.Windows.Forms.Padding(0);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(62, 62);
            this.button19.TabIndex = 49;
            this.button19.TabStop = false;
            this.button19.Text = "About";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            this.button19.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.Transparent;
            this.button20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button20.FlatAppearance.BorderSize = 0;
            this.button20.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.ForeColor = System.Drawing.Color.White;
            this.button20.Location = new System.Drawing.Point(714, 355);
            this.button20.Margin = new System.Windows.Forms.Padding(0);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(62, 62);
            this.button20.TabIndex = 50;
            this.button20.TabStop = false;
            this.button20.Text = "Armageddoner";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            this.button20.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // groupBox6
            // 
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(590, 96);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(273, 156);
            this.groupBox6.TabIndex = 24;
            this.groupBox6.TabStop = false;
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.groupBox10.Controls.Add(this.panel4);
            this.groupBox10.Controls.Add(this.pictureBox13);
            this.groupBox10.Controls.Add(this.pictureBox14);
            this.groupBox10.Controls.Add(this.panel3);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.ForeColor = System.Drawing.Color.Gold;
            this.groupBox10.Location = new System.Drawing.Point(7, 92);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(580, 394);
            this.groupBox10.TabIndex = 42;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Select One Profile From This List Then Press Start";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.MiningBlacksmithingProf);
            this.panel4.Location = new System.Drawing.Point(9, 345);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(568, 47);
            this.panel4.TabIndex = 12;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(309, 20);
            this.label21.TabIndex = 1;
            this.label21.Text = "Free Profiles reserved to Registered Users";
            // 
            // MiningBlacksmithingProf
            // 
            this.MiningBlacksmithingProf.AutoSize = true;
            this.MiningBlacksmithingProf.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MiningBlacksmithingProf.Location = new System.Drawing.Point(7, 20);
            this.MiningBlacksmithingProf.Name = "MiningBlacksmithingProf";
            this.MiningBlacksmithingProf.Size = new System.Drawing.Size(270, 24);
            this.MiningBlacksmithingProf.TabIndex = 7;
            this.MiningBlacksmithingProf.TabStop = true;
            this.MiningBlacksmithingProf.Text = "Mining And Blacksmithing 1 to 300";
            this.MiningBlacksmithingProf.UseVisualStyleBackColor = true;
            this.MiningBlacksmithingProf.CheckedChanged += new System.EventHandler(this.MiningBlacksmithingProf_CheckedChanged);
            this.MiningBlacksmithingProf.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // pictureBox13
            // 
            this.pictureBox13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox13.Location = new System.Drawing.Point(7, 320);
            this.pictureBox13.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(110, 23);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox13.TabIndex = 9;
            this.pictureBox13.TabStop = false;
            this.pictureBox13.Click += new System.EventHandler(this.pictureBox13_Click);
            this.pictureBox13.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // pictureBox14
            // 
            this.pictureBox14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox14.Location = new System.Drawing.Point(7, 33);
            this.pictureBox14.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(110, 23);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox14.TabIndex = 10;
            this.pictureBox14.TabStop = false;
            this.pictureBox14.Click += new System.EventHandler(this.pictureBox14_Click);
            this.pictureBox14.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.ProfMinBlack1600radioButton);
            this.panel3.Location = new System.Drawing.Point(9, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(568, 257);
            this.panel3.TabIndex = 11;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(316, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "Paid Profiles reserved to Profession Owners";
            // 
            // ProfMinBlack1600radioButton
            // 
            this.ProfMinBlack1600radioButton.AutoSize = true;
            this.ProfMinBlack1600radioButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ProfMinBlack1600radioButton.Location = new System.Drawing.Point(7, 20);
            this.ProfMinBlack1600radioButton.Name = "ProfMinBlack1600radioButton";
            this.ProfMinBlack1600radioButton.Size = new System.Drawing.Size(270, 24);
            this.ProfMinBlack1600radioButton.TabIndex = 8;
            this.ProfMinBlack1600radioButton.TabStop = true;
            this.ProfMinBlack1600radioButton.Text = "Mining And Blacksmithing 1 to 600";
            this.ProfMinBlack1600radioButton.UseVisualStyleBackColor = true;
            this.ProfMinBlack1600radioButton.CheckedChanged += new System.EventHandler(this.ProfMinBlack1600radioButton_CheckedChanged);
            this.ProfMinBlack1600radioButton.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 525);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 20);
            this.label9.TabIndex = 38;
            this.label9.Text = "Profile name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gold;
            this.label10.Location = new System.Drawing.Point(7, 500);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 20);
            this.label10.TabIndex = 37;
            this.label10.Text = "Selected Profile:";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.tabPage4.Controls.Add(this.label30);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.groupBox14);
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.Controls.Add(this.button24);
            this.tabPage4.Controls.Add(this.button25);
            this.tabPage4.Controls.Add(this.button26);
            this.tabPage4.Controls.Add(this.button27);
            this.tabPage4.Controls.Add(this.button28);
            this.tabPage4.Controls.Add(this.button29);
            this.tabPage4.Controls.Add(this.button30);
            this.tabPage4.Controls.Add(this.button32);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(840, 604);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Gold;
            this.label30.Location = new System.Drawing.Point(613, 39);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(201, 26);
            this.label30.TabIndex = 66;
            this.label30.Text = "Reserved Profiles";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(7, 560);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 65;
            this.label19.Text = "label19";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.tabControl2);
            this.groupBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox14.ForeColor = System.Drawing.Color.Gold;
            this.groupBox14.Location = new System.Drawing.Point(7, 92);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox14.Size = new System.Drawing.Size(580, 394);
            this.groupBox14.TabIndex = 63;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Reserved Profiles For Armageddoner Users";
            // 
            // tabControl2
            // 
            this.tabControl2.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Location = new System.Drawing.Point(5, 24);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(570, 365);
            this.tabControl2.TabIndex = 8;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.tabPage7.Location = new System.Drawing.Point(4, 32);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(562, 329);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Dailies";
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.tabPage8.Location = new System.Drawing.Point(4, 32);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(562, 329);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Reputations";
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.tabPage9.Controls.Add(this.learnportal1checkBox);
            this.tabPage9.Controls.Add(this.learnportal6checkBox);
            this.tabPage9.Controls.Add(this.learnportal3checkBox);
            this.tabPage9.Controls.Add(this.learnportal4checkBox);
            this.tabPage9.Controls.Add(this.learnportal2checkBox);
            this.tabPage9.Controls.Add(this.learnportal5checkBox);
            this.tabPage9.Location = new System.Drawing.Point(4, 32);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(562, 329);
            this.tabPage9.TabIndex = 2;
            this.tabPage9.Text = "Specials";
            // 
            // learnportal1checkBox
            // 
            this.learnportal1checkBox.AutoSize = true;
            this.learnportal1checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.learnportal1checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learnportal1checkBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.learnportal1checkBox.Location = new System.Drawing.Point(2, 2);
            this.learnportal1checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.learnportal1checkBox.Name = "learnportal1checkBox";
            this.learnportal1checkBox.Size = new System.Drawing.Size(183, 21);
            this.learnportal1checkBox.TabIndex = 1;
            this.learnportal1checkBox.Text = "Learn Mount Hyjal Portal";
            this.learnportal1checkBox.UseVisualStyleBackColor = true;
            this.learnportal1checkBox.CheckedChanged += new System.EventHandler(this.learnportal1checkBox_CheckedChanged);
            // 
            // learnportal6checkBox
            // 
            this.learnportal6checkBox.AutoSize = true;
            this.learnportal6checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.learnportal6checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learnportal6checkBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.learnportal6checkBox.Location = new System.Drawing.Point(2, 104);
            this.learnportal6checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.learnportal6checkBox.Name = "learnportal6checkBox";
            this.learnportal6checkBox.Size = new System.Drawing.Size(213, 21);
            this.learnportal6checkBox.TabIndex = 7;
            this.learnportal6checkBox.Text = "Learn The Jade Forest Portal";
            this.learnportal6checkBox.UseVisualStyleBackColor = true;
            this.learnportal6checkBox.CheckedChanged += new System.EventHandler(this.learnportal6checkBox_CheckedChanged);
            // 
            // learnportal3checkBox
            // 
            this.learnportal3checkBox.AutoSize = true;
            this.learnportal3checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.learnportal3checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learnportal3checkBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.learnportal3checkBox.Location = new System.Drawing.Point(2, 43);
            this.learnportal3checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.learnportal3checkBox.Name = "learnportal3checkBox";
            this.learnportal3checkBox.Size = new System.Drawing.Size(175, 21);
            this.learnportal3checkBox.TabIndex = 2;
            this.learnportal3checkBox.Text = "Learn DeepHolm Portal";
            this.learnportal3checkBox.UseVisualStyleBackColor = true;
            this.learnportal3checkBox.CheckedChanged += new System.EventHandler(this.learnportal3checkBox_CheckedChanged);
            // 
            // learnportal4checkBox
            // 
            this.learnportal4checkBox.AutoSize = true;
            this.learnportal4checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.learnportal4checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learnportal4checkBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.learnportal4checkBox.Location = new System.Drawing.Point(2, 63);
            this.learnportal4checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.learnportal4checkBox.Name = "learnportal4checkBox";
            this.learnportal4checkBox.Size = new System.Drawing.Size(149, 21);
            this.learnportal4checkBox.TabIndex = 3;
            this.learnportal4checkBox.Text = "Learn Uldum Portal";
            this.learnportal4checkBox.UseVisualStyleBackColor = true;
            this.learnportal4checkBox.CheckedChanged += new System.EventHandler(this.learnportal4checkBox_CheckedChanged);
            // 
            // learnportal2checkBox
            // 
            this.learnportal2checkBox.AutoSize = true;
            this.learnportal2checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.learnportal2checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learnportal2checkBox.ForeColor = System.Drawing.Color.Magenta;
            this.learnportal2checkBox.Location = new System.Drawing.Point(2, 23);
            this.learnportal2checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.learnportal2checkBox.Name = "learnportal2checkBox";
            this.learnportal2checkBox.Size = new System.Drawing.Size(164, 21);
            this.learnportal2checkBox.TabIndex = 5;
            this.learnportal2checkBox.Text = "* Learn Vashj\'ir Portal";
            this.learnportal2checkBox.UseVisualStyleBackColor = true;
            this.learnportal2checkBox.CheckedChanged += new System.EventHandler(this.learnportal2checkBox_CheckedChanged);
            // 
            // learnportal5checkBox
            // 
            this.learnportal5checkBox.AutoSize = true;
            this.learnportal5checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.learnportal5checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learnportal5checkBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.learnportal5checkBox.Location = new System.Drawing.Point(2, 84);
            this.learnportal5checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.learnportal5checkBox.Name = "learnportal5checkBox";
            this.learnportal5checkBox.Size = new System.Drawing.Size(223, 21);
            this.learnportal5checkBox.TabIndex = 4;
            this.learnportal5checkBox.Text = "Learn Twilight Highlands Portal";
            this.learnportal5checkBox.UseVisualStyleBackColor = true;
            this.learnportal5checkBox.CheckedChanged += new System.EventHandler(this.learnportal5checkBox_CheckedChanged);
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.tabPage10.Controls.Add(this.comboBox3);
            this.tabPage10.Controls.Add(this.label33);
            this.tabPage10.Controls.Add(this.label31);
            this.tabPage10.Controls.Add(this.comboBox2);
            this.tabPage10.Location = new System.Drawing.Point(4, 32);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(562, 329);
            this.tabPage10.TabIndex = 3;
            this.tabPage10.Text = "WoD Settings";
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Select your garrison outpost",
            "Logging Camp",
            "Sparring Ring"});
            this.comboBox3.Location = new System.Drawing.Point(2, 80);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(198, 23);
            this.comboBox3.TabIndex = 3;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label33.Location = new System.Drawing.Point(5, 60);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(181, 17);
            this.label33.TabIndex = 2;
            this.label33.Text = "Gorgond Garrison Outpost ";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label31.Location = new System.Drawing.Point(5, 5);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(196, 17);
            this.label31.TabIndex = 1;
            this.label31.Text = "(SMV - FR) Follower Selection";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Select your companion",
            "Apprentice Artificer Andren",
            "Rangari Chel",
            "Vindicator Onaala"});
            this.comboBox2.Location = new System.Drawing.Point(2, 25);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(198, 23);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Magenta;
            this.label23.Location = new System.Drawing.Point(591, 325);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(124, 17);
            this.label23.TabIndex = 6;
            this.label23.Text = "* Non AFK Profiles";
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.Transparent;
            this.button24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button24.Enabled = false;
            this.button24.FlatAppearance.BorderSize = 0;
            this.button24.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button24.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.ForeColor = System.Drawing.Color.White;
            this.button24.Location = new System.Drawing.Point(652, 355);
            this.button24.Margin = new System.Windows.Forms.Padding(0);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(62, 62);
            this.button24.TabIndex = 62;
            this.button24.TabStop = false;
            this.button24.Text = "Reserved Profiles";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.Transparent;
            this.button25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button25.Enabled = false;
            this.button25.FlatAppearance.BorderSize = 0;
            this.button25.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button25.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button25.ForeColor = System.Drawing.Color.White;
            this.button25.Location = new System.Drawing.Point(656, 421);
            this.button25.Margin = new System.Windows.Forms.Padding(0);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(180, 180);
            this.button25.TabIndex = 61;
            this.button25.TabStop = false;
            this.button25.Text = "Start";
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            this.button25.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.Transparent;
            this.button26.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button26.FlatAppearance.BorderSize = 0;
            this.button26.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button26.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.ForeColor = System.Drawing.Color.White;
            this.button26.Location = new System.Drawing.Point(590, 355);
            this.button26.Margin = new System.Windows.Forms.Padding(0);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(62, 62);
            this.button26.TabIndex = 60;
            this.button26.TabStop = false;
            this.button26.Text = "Professions";
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            this.button26.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.Color.Transparent;
            this.button27.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button27.FlatAppearance.BorderSize = 0;
            this.button27.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button27.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button27.ForeColor = System.Drawing.Color.White;
            this.button27.Location = new System.Drawing.Point(590, 479);
            this.button27.Margin = new System.Windows.Forms.Padding(0);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(62, 62);
            this.button27.TabIndex = 59;
            this.button27.TabStop = false;
            this.button27.Text = "Main";
            this.button27.UseVisualStyleBackColor = false;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            this.button27.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.Color.Transparent;
            this.button28.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button28.FlatAppearance.BorderSize = 0;
            this.button28.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button28.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button28.ForeColor = System.Drawing.Color.White;
            this.button28.Location = new System.Drawing.Point(590, 417);
            this.button28.Margin = new System.Windows.Forms.Padding(0);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(62, 62);
            this.button28.TabIndex = 57;
            this.button28.TabStop = false;
            this.button28.Text = "Leveling";
            this.button28.UseVisualStyleBackColor = false;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            this.button28.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.Transparent;
            this.button29.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button29.FlatAppearance.BorderSize = 0;
            this.button29.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button29.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button29.ForeColor = System.Drawing.Color.White;
            this.button29.Location = new System.Drawing.Point(590, 541);
            this.button29.Margin = new System.Windows.Forms.Padding(0);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(62, 62);
            this.button29.TabIndex = 58;
            this.button29.TabStop = false;
            this.button29.Text = "Cancel";
            this.button29.UseVisualStyleBackColor = false;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            this.button29.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.Transparent;
            this.button30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button30.FlatAppearance.BorderSize = 0;
            this.button30.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button30.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button30.ForeColor = System.Drawing.Color.White;
            this.button30.Location = new System.Drawing.Point(776, 355);
            this.button30.Margin = new System.Windows.Forms.Padding(0);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(62, 62);
            this.button30.TabIndex = 56;
            this.button30.TabStop = false;
            this.button30.Text = "About";
            this.button30.UseVisualStyleBackColor = false;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            this.button30.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Transparent;
            this.button32.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button32.FlatAppearance.BorderSize = 0;
            this.button32.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button32.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.ForeColor = System.Drawing.Color.White;
            this.button32.Location = new System.Drawing.Point(714, 355);
            this.button32.Margin = new System.Windows.Forms.Padding(0);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(62, 62);
            this.button32.TabIndex = 55;
            this.button32.TabStop = false;
            this.button32.Text = "Armageddoner";
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            this.button32.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(7, 525);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 20);
            this.label14.TabIndex = 51;
            this.label14.Text = "Profile name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Gold;
            this.label15.Location = new System.Drawing.Point(7, 500);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 20);
            this.label15.TabIndex = 50;
            this.label15.Text = "Selected Profile:";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.tabPage5.Controls.Add(this.label25);
            this.tabPage5.Controls.Add(this.label26);
            this.tabPage5.Controls.Add(this.connectgroupBox);
            this.tabPage5.Controls.Add(this.groupBox11);
            this.tabPage5.Controls.Add(this.groupBox12);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.groupBox8);
            this.tabPage5.Controls.Add(this.button33);
            this.tabPage5.Controls.Add(this.button34);
            this.tabPage5.Controls.Add(this.button35);
            this.tabPage5.Controls.Add(this.button36);
            this.tabPage5.Controls.Add(this.button37);
            this.tabPage5.Controls.Add(this.button38);
            this.tabPage5.Controls.Add(this.button39);
            this.tabPage5.Controls.Add(this.button40);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(840, 604);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(7, 560);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 13);
            this.label25.TabIndex = 66;
            this.label25.Text = "label25";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Gold;
            this.label26.Location = new System.Drawing.Point(629, 36);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(168, 26);
            this.label26.TabIndex = 17;
            this.label26.Text = "Armageddoner";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // connectgroupBox
            // 
            this.connectgroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.connectgroupBox.Controls.Add(this.panel5);
            this.connectgroupBox.Controls.Add(this.passwordlabel);
            this.connectgroupBox.Controls.Add(this.pictureBox10);
            this.connectgroupBox.Controls.Add(this.TestAccessbutton);
            this.connectgroupBox.Controls.Add(this.PasswordtextBox);
            this.connectgroupBox.Controls.Add(this.LogintextBox);
            this.connectgroupBox.Controls.Add(this.loginlabel);
            this.connectgroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectgroupBox.ForeColor = System.Drawing.Color.Gold;
            this.connectgroupBox.Location = new System.Drawing.Point(175, 96);
            this.connectgroupBox.Name = "connectgroupBox";
            this.connectgroupBox.Size = new System.Drawing.Size(409, 125);
            this.connectgroupBox.TabIndex = 63;
            this.connectgroupBox.TabStop = false;
            this.connectgroupBox.Text = "Connect";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.selectserver2radio);
            this.panel5.Controls.Add(this.selectserver1radio);
            this.panel5.Location = new System.Drawing.Point(226, 18);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(180, 50);
            this.panel5.TabIndex = 27;
            // 
            // selectserver2radio
            // 
            this.selectserver2radio.AutoSize = true;
            this.selectserver2radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectserver2radio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.selectserver2radio.Location = new System.Drawing.Point(2, 24);
            this.selectserver2radio.Margin = new System.Windows.Forms.Padding(2);
            this.selectserver2radio.Name = "selectserver2radio";
            this.selectserver2radio.Size = new System.Drawing.Size(130, 19);
            this.selectserver2radio.TabIndex = 1;
            this.selectserver2radio.TabStop = true;
            this.selectserver2radio.Text = "Use Server 2(USA) ";
            this.selectserver2radio.UseVisualStyleBackColor = true;
            this.selectserver2radio.CheckedChanged += new System.EventHandler(this.selectserver2radio_CheckedChanged);
            this.selectserver2radio.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // selectserver1radio
            // 
            this.selectserver1radio.AutoSize = true;
            this.selectserver1radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectserver1radio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.selectserver1radio.Location = new System.Drawing.Point(2, 4);
            this.selectserver1radio.Margin = new System.Windows.Forms.Padding(2);
            this.selectserver1radio.Name = "selectserver1radio";
            this.selectserver1radio.Size = new System.Drawing.Size(143, 19);
            this.selectserver1radio.TabIndex = 0;
            this.selectserver1radio.TabStop = true;
            this.selectserver1radio.Text = "Use Server 1(Europe)";
            this.selectserver1radio.UseVisualStyleBackColor = true;
            this.selectserver1radio.CheckedChanged += new System.EventHandler(this.selectserver1radio_CheckedChanged);
            this.selectserver1radio.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // passwordlabel
            // 
            this.passwordlabel.AutoSize = true;
            this.passwordlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordlabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.passwordlabel.Location = new System.Drawing.Point(162, 53);
            this.passwordlabel.Name = "passwordlabel";
            this.passwordlabel.Size = new System.Drawing.Size(61, 15);
            this.passwordlabel.TabIndex = 31;
            this.passwordlabel.Text = "Password";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Location = new System.Drawing.Point(289, 90);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(16, 16);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox10.TabIndex = 41;
            this.pictureBox10.TabStop = false;
            // 
            // TestAccessbutton
            // 
            this.TestAccessbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TestAccessbutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TestAccessbutton.Location = new System.Drawing.Point(2, 85);
            this.TestAccessbutton.Margin = new System.Windows.Forms.Padding(2);
            this.TestAccessbutton.Name = "TestAccessbutton";
            this.TestAccessbutton.Size = new System.Drawing.Size(274, 24);
            this.TestAccessbutton.TabIndex = 30;
            this.TestAccessbutton.Text = "Save and Test Access";
            this.TestAccessbutton.UseVisualStyleBackColor = true;
            this.TestAccessbutton.Click += new System.EventHandler(this.TestAccessbutton_Click);
            this.TestAccessbutton.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // PasswordtextBox
            // 
            this.PasswordtextBox.Location = new System.Drawing.Point(2, 53);
            this.PasswordtextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordtextBox.Name = "PasswordtextBox";
            this.PasswordtextBox.PasswordChar = '*';
            this.PasswordtextBox.Size = new System.Drawing.Size(156, 26);
            this.PasswordtextBox.TabIndex = 29;
            this.PasswordtextBox.UseSystemPasswordChar = true;
            // 
            // LogintextBox
            // 
            this.LogintextBox.Location = new System.Drawing.Point(2, 20);
            this.LogintextBox.Margin = new System.Windows.Forms.Padding(2);
            this.LogintextBox.Name = "LogintextBox";
            this.LogintextBox.Size = new System.Drawing.Size(156, 26);
            this.LogintextBox.TabIndex = 28;
            // 
            // loginlabel
            // 
            this.loginlabel.AutoSize = true;
            this.loginlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginlabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loginlabel.Location = new System.Drawing.Point(162, 27);
            this.loginlabel.Name = "loginlabel";
            this.loginlabel.Size = new System.Drawing.Size(38, 15);
            this.loginlabel.TabIndex = 27;
            this.loginlabel.Text = "Login";
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.groupBox11.Controls.Add(this.comboBox1);
            this.groupBox11.Controls.Add(this.label22);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.ForeColor = System.Drawing.Color.Gold;
            this.groupBox11.Location = new System.Drawing.Point(3, 96);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(166, 125);
            this.groupBox11.TabIndex = 62;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Settings";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "English",
            "Dansk",
            "Deutsch",
            "Français",
            "Português",
            "Русский"});
            this.comboBox1.Location = new System.Drawing.Point(2, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(148, 23);
            this.comboBox1.TabIndex = 29;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(2, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 15);
            this.label22.TabIndex = 27;
            this.label22.Text = "Language";
            // 
            // groupBox12
            // 
            this.groupBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.groupBox12.Controls.Add(this.groupBox15);
            this.groupBox12.Controls.Add(this.pictureBox11);
            this.groupBox12.Controls.Add(this.pictureBox9);
            this.groupBox12.Controls.Add(this.charsetgroupBox);
            this.groupBox12.Controls.Add(this.globalsetgroupBox);
            this.groupBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.ForeColor = System.Drawing.Color.Gold;
            this.groupBox12.Location = new System.Drawing.Point(3, 225);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(581, 266);
            this.groupBox12.TabIndex = 61;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Reserved for Armagueddoners";
            // 
            // groupBox15
            // 
            this.groupBox15.BackColor = System.Drawing.Color.Transparent;
            this.groupBox15.Controls.Add(this.combatloot_checkBox);
            this.groupBox15.Controls.Add(this.refuseDuelCheckBox);
            this.groupBox15.Controls.Add(this.ResscheckBox);
            this.groupBox15.Controls.Add(this.playsoundcheckBox);
            this.groupBox15.Controls.Add(this.antigankcheckBox);
            this.groupBox15.Controls.Add(this.fixmountcheckBox1);
            this.groupBox15.Controls.Add(this.OpenBox_checkBox);
            this.groupBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox15.ForeColor = System.Drawing.Color.Gold;
            this.groupBox15.Location = new System.Drawing.Point(293, 19);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(283, 243);
            this.groupBox15.TabIndex = 42;
            this.groupBox15.TabStop = false;
            // 
            // combatloot_checkBox
            // 
            this.combatloot_checkBox.AutoSize = true;
            this.combatloot_checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.combatloot_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combatloot_checkBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.combatloot_checkBox.Location = new System.Drawing.Point(2, 56);
            this.combatloot_checkBox.Name = "combatloot_checkBox";
            this.combatloot_checkBox.Size = new System.Drawing.Size(109, 19);
            this.combatloot_checkBox.TabIndex = 35;
            this.combatloot_checkBox.Text = "Loot in Combat";
            this.combatloot_checkBox.UseVisualStyleBackColor = true;
            this.combatloot_checkBox.CheckedChanged += new System.EventHandler(this.combatloot_checkBox_CheckedChanged);
            this.combatloot_checkBox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // refuseDuelCheckBox
            // 
            this.refuseDuelCheckBox.AutoSize = true;
            this.refuseDuelCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refuseDuelCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.refuseDuelCheckBox.Location = new System.Drawing.Point(2, 14);
            this.refuseDuelCheckBox.Name = "refuseDuelCheckBox";
            this.refuseDuelCheckBox.Size = new System.Drawing.Size(131, 19);
            this.refuseDuelCheckBox.TabIndex = 34;
            this.refuseDuelCheckBox.Text = "Refuse Duel Invites";
            this.refuseDuelCheckBox.UseVisualStyleBackColor = true;
            this.refuseDuelCheckBox.CheckedChanged += new System.EventHandler(this.refuseDuelCheckBox_CheckedChanged);
            this.refuseDuelCheckBox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // ResscheckBox
            // 
            this.ResscheckBox.AutoSize = true;
            this.ResscheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResscheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResscheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ResscheckBox.Location = new System.Drawing.Point(2, 35);
            this.ResscheckBox.Name = "ResscheckBox";
            this.ResscheckBox.Size = new System.Drawing.Size(152, 19);
            this.ResscheckBox.TabIndex = 26;
            this.ResscheckBox.Text = "Ress/Release After Die";
            this.ResscheckBox.UseVisualStyleBackColor = true;
            this.ResscheckBox.CheckedChanged += new System.EventHandler(this.ResscheckBox_CheckedChanged);
            this.ResscheckBox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // playsoundcheckBox
            // 
            this.playsoundcheckBox.AutoSize = true;
            this.playsoundcheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.playsoundcheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playsoundcheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playsoundcheckBox.Location = new System.Drawing.Point(17, 138);
            this.playsoundcheckBox.Name = "playsoundcheckBox";
            this.playsoundcheckBox.Size = new System.Drawing.Size(169, 19);
            this.playsoundcheckBox.TabIndex = 26;
            this.playsoundcheckBox.Text = "Play Sound When Ganked";
            this.playsoundcheckBox.UseVisualStyleBackColor = true;
            this.playsoundcheckBox.CheckedChanged += new System.EventHandler(this.playsoundcheckBox_CheckedChanged);
            this.playsoundcheckBox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // antigankcheckBox
            // 
            this.antigankcheckBox.AutoSize = true;
            this.antigankcheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.antigankcheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antigankcheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.antigankcheckBox.Location = new System.Drawing.Point(2, 118);
            this.antigankcheckBox.Name = "antigankcheckBox";
            this.antigankcheckBox.Size = new System.Drawing.Size(121, 19);
            this.antigankcheckBox.TabIndex = 25;
            this.antigankcheckBox.Text = "Anti Gank System";
            this.antigankcheckBox.UseVisualStyleBackColor = true;
            this.antigankcheckBox.CheckedChanged += new System.EventHandler(this.antigankcheckBox_CheckedChanged);
            this.antigankcheckBox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // fixmountcheckBox1
            // 
            this.fixmountcheckBox1.AutoSize = true;
            this.fixmountcheckBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.fixmountcheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixmountcheckBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fixmountcheckBox1.Location = new System.Drawing.Point(2, 98);
            this.fixmountcheckBox1.Name = "fixmountcheckBox1";
            this.fixmountcheckBox1.Size = new System.Drawing.Size(179, 19);
            this.fixmountcheckBox1.TabIndex = 23;
            this.fixmountcheckBox1.Text = "Fix Mount Flight Master Bug";
            this.fixmountcheckBox1.UseVisualStyleBackColor = true;
            this.fixmountcheckBox1.CheckedChanged += new System.EventHandler(this.fixmountcheckBox1_CheckedChanged);
            this.fixmountcheckBox1.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // OpenBox_checkBox
            // 
            this.OpenBox_checkBox.AutoSize = true;
            this.OpenBox_checkBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.OpenBox_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenBox_checkBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OpenBox_checkBox.Location = new System.Drawing.Point(2, 77);
            this.OpenBox_checkBox.Name = "OpenBox_checkBox";
            this.OpenBox_checkBox.Size = new System.Drawing.Size(158, 19);
            this.OpenBox_checkBox.TabIndex = 22;
            this.OpenBox_checkBox.Text = "AutoOpen Boxs (Rogue)";
            this.OpenBox_checkBox.UseVisualStyleBackColor = true;
            this.OpenBox_checkBox.CheckedChanged += new System.EventHandler(this.OpenBox_checkBox_CheckedChanged);
            this.OpenBox_checkBox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Location = new System.Drawing.Point(7, 31);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(16, 16);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox11.TabIndex = 41;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox9.Location = new System.Drawing.Point(38, 27);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(112, 25);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox9.TabIndex = 40;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // charsetgroupBox
            // 
            this.charsetgroupBox.BackColor = System.Drawing.Color.Transparent;
            this.charsetgroupBox.Controls.Add(this.AntiStuck_CheckBox);
            this.charsetgroupBox.Controls.Add(this.AllowSummonPet_Checkbox);
            this.charsetgroupBox.Controls.Add(this.refuseTradesCheckBox);
            this.charsetgroupBox.Controls.Add(this.refusePartyCheckBox);
            this.charsetgroupBox.Controls.Add(this.guildInvitescheckBox);
            this.charsetgroupBox.Controls.Add(this.refuseGuildCheckBox);
            this.charsetgroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charsetgroupBox.ForeColor = System.Drawing.Color.Gold;
            this.charsetgroupBox.Location = new System.Drawing.Point(2, 116);
            this.charsetgroupBox.Name = "charsetgroupBox";
            this.charsetgroupBox.Size = new System.Drawing.Size(283, 146);
            this.charsetgroupBox.TabIndex = 37;
            this.charsetgroupBox.TabStop = false;
            this.charsetgroupBox.Text = "Character Settings";
            // 
            // AntiStuck_CheckBox
            // 
            this.AntiStuck_CheckBox.AutoSize = true;
            this.AntiStuck_CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AntiStuck_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AntiStuck_CheckBox.Location = new System.Drawing.Point(2, 20);
            this.AntiStuck_CheckBox.Name = "AntiStuck_CheckBox";
            this.AntiStuck_CheckBox.Size = new System.Drawing.Size(215, 19);
            this.AntiStuck_CheckBox.TabIndex = 22;
            this.AntiStuck_CheckBox.Text = "Anti-Stuck System(Need Relogger)";
            this.AntiStuck_CheckBox.UseVisualStyleBackColor = true;
            this.AntiStuck_CheckBox.CheckedChanged += new System.EventHandler(this.AntiStuck_CheckBox_CheckedChanged);
            this.AntiStuck_CheckBox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // AllowSummonPet_Checkbox
            // 
            this.AllowSummonPet_Checkbox.AutoSize = true;
            this.AllowSummonPet_Checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllowSummonPet_Checkbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AllowSummonPet_Checkbox.Location = new System.Drawing.Point(2, 40);
            this.AllowSummonPet_Checkbox.Name = "AllowSummonPet_Checkbox";
            this.AllowSummonPet_Checkbox.Size = new System.Drawing.Size(197, 19);
            this.AllowSummonPet_Checkbox.TabIndex = 24;
            this.AllowSummonPet_Checkbox.Text = "Enable Summon Random Pets";
            this.AllowSummonPet_Checkbox.UseVisualStyleBackColor = true;
            this.AllowSummonPet_Checkbox.CheckedChanged += new System.EventHandler(this.AllowSummonPet_Checkbox_CheckedChanged);
            this.AllowSummonPet_Checkbox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // refuseTradesCheckBox
            // 
            this.refuseTradesCheckBox.AutoSize = true;
            this.refuseTradesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refuseTradesCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.refuseTradesCheckBox.Location = new System.Drawing.Point(2, 120);
            this.refuseTradesCheckBox.Name = "refuseTradesCheckBox";
            this.refuseTradesCheckBox.Size = new System.Drawing.Size(137, 19);
            this.refuseTradesCheckBox.TabIndex = 31;
            this.refuseTradesCheckBox.Text = "Refuse Trade Invites";
            this.refuseTradesCheckBox.UseVisualStyleBackColor = true;
            this.refuseTradesCheckBox.CheckedChanged += new System.EventHandler(this.refuseTradesCheckBox_CheckedChanged);
            this.refuseTradesCheckBox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // refusePartyCheckBox
            // 
            this.refusePartyCheckBox.AutoSize = true;
            this.refusePartyCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refusePartyCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.refusePartyCheckBox.Location = new System.Drawing.Point(2, 100);
            this.refusePartyCheckBox.Name = "refusePartyCheckBox";
            this.refusePartyCheckBox.Size = new System.Drawing.Size(132, 19);
            this.refusePartyCheckBox.TabIndex = 33;
            this.refusePartyCheckBox.Text = "Refuse Party Invites";
            this.refusePartyCheckBox.UseVisualStyleBackColor = true;
            this.refusePartyCheckBox.CheckedChanged += new System.EventHandler(this.refusePartyCheckBox_CheckedChanged);
            this.refusePartyCheckBox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // guildInvitescheckBox
            // 
            this.guildInvitescheckBox.AutoSize = true;
            this.guildInvitescheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guildInvitescheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guildInvitescheckBox.Location = new System.Drawing.Point(2, 60);
            this.guildInvitescheckBox.Name = "guildInvitescheckBox";
            this.guildInvitescheckBox.Size = new System.Drawing.Size(166, 19);
            this.guildInvitescheckBox.TabIndex = 30;
            this.guildInvitescheckBox.Text = "Accept Lvl 25 Guild Invites";
            this.guildInvitescheckBox.UseVisualStyleBackColor = true;
            this.guildInvitescheckBox.CheckedChanged += new System.EventHandler(this.guildInvitescheckBox_CheckedChanged);
            this.guildInvitescheckBox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // refuseGuildCheckBox
            // 
            this.refuseGuildCheckBox.AutoSize = true;
            this.refuseGuildCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refuseGuildCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.refuseGuildCheckBox.Location = new System.Drawing.Point(2, 80);
            this.refuseGuildCheckBox.Name = "refuseGuildCheckBox";
            this.refuseGuildCheckBox.Size = new System.Drawing.Size(134, 19);
            this.refuseGuildCheckBox.TabIndex = 32;
            this.refuseGuildCheckBox.Text = "Refuse Guild Invites";
            this.refuseGuildCheckBox.UseVisualStyleBackColor = true;
            this.refuseGuildCheckBox.CheckedChanged += new System.EventHandler(this.refuseGuildCheckBox_CheckedChanged);
            this.refuseGuildCheckBox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // globalsetgroupBox
            // 
            this.globalsetgroupBox.BackColor = System.Drawing.Color.Transparent;
            this.globalsetgroupBox.Controls.Add(this.disableplugincheckBox);
            this.globalsetgroupBox.Controls.Add(this.AutoShutDown_Checkbox);
            this.globalsetgroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.globalsetgroupBox.ForeColor = System.Drawing.Color.Gold;
            this.globalsetgroupBox.Location = new System.Drawing.Point(2, 50);
            this.globalsetgroupBox.Name = "globalsetgroupBox";
            this.globalsetgroupBox.Size = new System.Drawing.Size(283, 65);
            this.globalsetgroupBox.TabIndex = 36;
            this.globalsetgroupBox.TabStop = false;
            this.globalsetgroupBox.Text = "Global Settings";
            // 
            // disableplugincheckBox
            // 
            this.disableplugincheckBox.AutoSize = true;
            this.disableplugincheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disableplugincheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.disableplugincheckBox.Location = new System.Drawing.Point(2, 40);
            this.disableplugincheckBox.Name = "disableplugincheckBox";
            this.disableplugincheckBox.Size = new System.Drawing.Size(255, 19);
            this.disableplugincheckBox.TabIndex = 24;
            this.disableplugincheckBox.Text = "Auto-Disable when not using Cava profiles";
            this.disableplugincheckBox.UseVisualStyleBackColor = true;
            this.disableplugincheckBox.CheckedChanged += new System.EventHandler(this.disableplugincheckBox_CheckedChanged);
            this.disableplugincheckBox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // AutoShutDown_Checkbox
            // 
            this.AutoShutDown_Checkbox.AutoSize = true;
            this.AutoShutDown_Checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoShutDown_Checkbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AutoShutDown_Checkbox.Location = new System.Drawing.Point(2, 20);
            this.AutoShutDown_Checkbox.Name = "AutoShutDown_Checkbox";
            this.AutoShutDown_Checkbox.Size = new System.Drawing.Size(178, 19);
            this.AutoShutDown_Checkbox.TabIndex = 23;
            this.AutoShutDown_Checkbox.Text = "Auto Shutdown After Update";
            this.AutoShutDown_Checkbox.UseVisualStyleBackColor = true;
            this.AutoShutDown_Checkbox.CheckedChanged += new System.EventHandler(this.AutoShutDown_Checkbox_CheckedChanged);
            this.AutoShutDown_Checkbox.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 525);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 20);
            this.label11.TabIndex = 60;
            this.label11.Text = "Profile name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Gold;
            this.label16.Location = new System.Drawing.Point(7, 500);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(124, 20);
            this.label16.TabIndex = 59;
            this.label16.Text = "Selected Profile:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.pictureBox12);
            this.groupBox8.Controls.Add(this.labelprofmb600);
            this.groupBox8.Controls.Add(this.pictureBox8);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(590, 96);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(247, 256);
            this.groupBox8.TabIndex = 57;
            this.groupBox8.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Location = new System.Drawing.Point(3, 12);
            this.pictureBox12.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(16, 16);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox12.TabIndex = 45;
            this.pictureBox12.TabStop = false;
            // 
            // labelprofmb600
            // 
            this.labelprofmb600.AutoSize = true;
            this.labelprofmb600.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelprofmb600.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelprofmb600.Location = new System.Drawing.Point(23, 12);
            this.labelprofmb600.Name = "labelprofmb600";
            this.labelprofmb600.Size = new System.Drawing.Size(196, 15);
            this.labelprofmb600.TabIndex = 44;
            this.labelprofmb600.Text = "Mining and Blacksmithing 1 to 600";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox8.Location = new System.Drawing.Point(41, 35);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(112, 25);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox8.TabIndex = 43;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            this.pictureBox8.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.Color.Transparent;
            this.button33.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button33.FlatAppearance.BorderSize = 0;
            this.button33.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button33.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button33.ForeColor = System.Drawing.Color.White;
            this.button33.Location = new System.Drawing.Point(652, 355);
            this.button33.Margin = new System.Windows.Forms.Padding(0);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(62, 62);
            this.button33.TabIndex = 56;
            this.button33.TabStop = false;
            this.button33.Text = "Reserved Profiles";
            this.button33.UseVisualStyleBackColor = false;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            this.button33.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.Color.Transparent;
            this.button34.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button34.FlatAppearance.BorderSize = 0;
            this.button34.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button34.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button34.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button34.ForeColor = System.Drawing.Color.White;
            this.button34.Location = new System.Drawing.Point(656, 421);
            this.button34.Margin = new System.Windows.Forms.Padding(0);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(180, 180);
            this.button34.TabIndex = 55;
            this.button34.TabStop = false;
            this.button34.Text = "Start";
            this.button34.UseVisualStyleBackColor = false;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            this.button34.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button35
            // 
            this.button35.BackColor = System.Drawing.Color.Transparent;
            this.button35.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button35.FlatAppearance.BorderSize = 0;
            this.button35.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button35.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button35.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button35.ForeColor = System.Drawing.Color.White;
            this.button35.Location = new System.Drawing.Point(590, 355);
            this.button35.Margin = new System.Windows.Forms.Padding(0);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(62, 62);
            this.button35.TabIndex = 54;
            this.button35.TabStop = false;
            this.button35.Text = "Professions";
            this.button35.UseVisualStyleBackColor = false;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            this.button35.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button36
            // 
            this.button36.BackColor = System.Drawing.Color.Transparent;
            this.button36.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button36.FlatAppearance.BorderSize = 0;
            this.button36.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button36.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button36.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button36.ForeColor = System.Drawing.Color.White;
            this.button36.Location = new System.Drawing.Point(590, 479);
            this.button36.Margin = new System.Windows.Forms.Padding(0);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(62, 62);
            this.button36.TabIndex = 53;
            this.button36.TabStop = false;
            this.button36.Text = "Main";
            this.button36.UseVisualStyleBackColor = false;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            this.button36.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.Color.Transparent;
            this.button37.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button37.FlatAppearance.BorderSize = 0;
            this.button37.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button37.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button37.ForeColor = System.Drawing.Color.White;
            this.button37.Location = new System.Drawing.Point(590, 417);
            this.button37.Margin = new System.Windows.Forms.Padding(0);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(62, 62);
            this.button37.TabIndex = 51;
            this.button37.TabStop = false;
            this.button37.Text = "Leveling";
            this.button37.UseVisualStyleBackColor = false;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            this.button37.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button38
            // 
            this.button38.BackColor = System.Drawing.Color.Transparent;
            this.button38.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button38.FlatAppearance.BorderSize = 0;
            this.button38.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button38.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button38.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button38.ForeColor = System.Drawing.Color.White;
            this.button38.Location = new System.Drawing.Point(590, 541);
            this.button38.Margin = new System.Windows.Forms.Padding(0);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(62, 62);
            this.button38.TabIndex = 52;
            this.button38.TabStop = false;
            this.button38.Text = "Cancel";
            this.button38.UseVisualStyleBackColor = false;
            this.button38.Click += new System.EventHandler(this.button38_Click);
            this.button38.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button39
            // 
            this.button39.BackColor = System.Drawing.Color.Transparent;
            this.button39.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button39.FlatAppearance.BorderSize = 0;
            this.button39.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button39.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button39.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button39.ForeColor = System.Drawing.Color.White;
            this.button39.Location = new System.Drawing.Point(776, 355);
            this.button39.Margin = new System.Windows.Forms.Padding(0);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(62, 62);
            this.button39.TabIndex = 50;
            this.button39.TabStop = false;
            this.button39.Text = "About";
            this.button39.UseVisualStyleBackColor = false;
            this.button39.Click += new System.EventHandler(this.button39_Click);
            this.button39.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button40
            // 
            this.button40.BackColor = System.Drawing.Color.Transparent;
            this.button40.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button40.Enabled = false;
            this.button40.FlatAppearance.BorderSize = 0;
            this.button40.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button40.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button40.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button40.ForeColor = System.Drawing.Color.White;
            this.button40.Location = new System.Drawing.Point(714, 355);
            this.button40.Margin = new System.Windows.Forms.Padding(0);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(62, 62);
            this.button40.TabIndex = 49;
            this.button40.TabStop = false;
            this.button40.Text = "Armageddoner";
            this.button40.UseVisualStyleBackColor = false;
            this.button40.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.tabPage6.Controls.Add(this.label2);
            this.tabPage6.Controls.Add(this.label27);
            this.tabPage6.Controls.Add(this.groupBox13);
            this.tabPage6.Controls.Add(this.label17);
            this.tabPage6.Controls.Add(this.label18);
            this.tabPage6.Controls.Add(this.groupBox9);
            this.tabPage6.Controls.Add(this.button41);
            this.tabPage6.Controls.Add(this.button42);
            this.tabPage6.Controls.Add(this.button43);
            this.tabPage6.Controls.Add(this.button44);
            this.tabPage6.Controls.Add(this.button45);
            this.tabPage6.Controls.Add(this.button46);
            this.tabPage6.Controls.Add(this.button47);
            this.tabPage6.Controls.Add(this.button48);
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(840, 604);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 560);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "label2";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Gold;
            this.label27.Location = new System.Drawing.Point(676, 43);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(74, 26);
            this.label27.TabIndex = 17;
            this.label27.Text = "About";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.richTextBox2);
            this.groupBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.ForeColor = System.Drawing.Color.Gold;
            this.groupBox13.Location = new System.Drawing.Point(7, 92);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox13.Size = new System.Drawing.Size(580, 394);
            this.groupBox13.TabIndex = 61;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Thanks";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(4, 22);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(573, 369);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(7, 525);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 20);
            this.label17.TabIndex = 59;
            this.label17.Text = "Profile name";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Gold;
            this.label18.Location = new System.Drawing.Point(7, 500);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(124, 20);
            this.label18.TabIndex = 58;
            this.label18.Text = "Selected Profile:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.pictureBox4);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(590, 96);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(247, 240);
            this.groupBox9.TabIndex = 57;
            this.groupBox9.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Location = new System.Drawing.Point(46, 170);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(160, 64);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            this.pictureBox4.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button41
            // 
            this.button41.BackColor = System.Drawing.Color.Transparent;
            this.button41.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button41.FlatAppearance.BorderSize = 0;
            this.button41.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button41.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button41.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button41.ForeColor = System.Drawing.Color.White;
            this.button41.Location = new System.Drawing.Point(652, 355);
            this.button41.Margin = new System.Windows.Forms.Padding(0);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(62, 62);
            this.button41.TabIndex = 56;
            this.button41.TabStop = false;
            this.button41.Text = "Reserved Profiles";
            this.button41.UseVisualStyleBackColor = false;
            this.button41.Click += new System.EventHandler(this.button41_Click);
            this.button41.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button42
            // 
            this.button42.BackColor = System.Drawing.Color.Transparent;
            this.button42.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button42.FlatAppearance.BorderSize = 0;
            this.button42.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button42.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button42.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button42.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button42.ForeColor = System.Drawing.Color.White;
            this.button42.Location = new System.Drawing.Point(656, 421);
            this.button42.Margin = new System.Windows.Forms.Padding(0);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(180, 180);
            this.button42.TabIndex = 55;
            this.button42.TabStop = false;
            this.button42.Text = "Start";
            this.button42.UseVisualStyleBackColor = false;
            this.button42.Click += new System.EventHandler(this.button42_Click);
            this.button42.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button43
            // 
            this.button43.BackColor = System.Drawing.Color.Transparent;
            this.button43.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button43.FlatAppearance.BorderSize = 0;
            this.button43.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button43.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button43.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button43.ForeColor = System.Drawing.Color.White;
            this.button43.Location = new System.Drawing.Point(590, 355);
            this.button43.Margin = new System.Windows.Forms.Padding(0);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(62, 62);
            this.button43.TabIndex = 54;
            this.button43.TabStop = false;
            this.button43.Text = "Professions";
            this.button43.UseVisualStyleBackColor = false;
            this.button43.Click += new System.EventHandler(this.button43_Click);
            this.button43.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button44
            // 
            this.button44.BackColor = System.Drawing.Color.Transparent;
            this.button44.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button44.FlatAppearance.BorderSize = 0;
            this.button44.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button44.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button44.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button44.ForeColor = System.Drawing.Color.White;
            this.button44.Location = new System.Drawing.Point(590, 479);
            this.button44.Margin = new System.Windows.Forms.Padding(0);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(62, 62);
            this.button44.TabIndex = 53;
            this.button44.TabStop = false;
            this.button44.Text = "Main";
            this.button44.UseVisualStyleBackColor = false;
            this.button44.Click += new System.EventHandler(this.button44_Click);
            this.button44.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button45
            // 
            this.button45.BackColor = System.Drawing.Color.Transparent;
            this.button45.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button45.FlatAppearance.BorderSize = 0;
            this.button45.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button45.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button45.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button45.ForeColor = System.Drawing.Color.White;
            this.button45.Location = new System.Drawing.Point(590, 417);
            this.button45.Margin = new System.Windows.Forms.Padding(0);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(62, 62);
            this.button45.TabIndex = 51;
            this.button45.TabStop = false;
            this.button45.Text = "Leveling";
            this.button45.UseVisualStyleBackColor = false;
            this.button45.Click += new System.EventHandler(this.button45_Click);
            this.button45.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button46
            // 
            this.button46.BackColor = System.Drawing.Color.Transparent;
            this.button46.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button46.FlatAppearance.BorderSize = 0;
            this.button46.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button46.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button46.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button46.ForeColor = System.Drawing.Color.White;
            this.button46.Location = new System.Drawing.Point(590, 541);
            this.button46.Margin = new System.Windows.Forms.Padding(0);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(62, 62);
            this.button46.TabIndex = 52;
            this.button46.TabStop = false;
            this.button46.Text = "Cancel";
            this.button46.UseVisualStyleBackColor = false;
            this.button46.Click += new System.EventHandler(this.button46_Click);
            this.button46.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button47
            // 
            this.button47.BackColor = System.Drawing.Color.Transparent;
            this.button47.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button47.Enabled = false;
            this.button47.FlatAppearance.BorderSize = 0;
            this.button47.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button47.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button47.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button47.ForeColor = System.Drawing.Color.White;
            this.button47.Location = new System.Drawing.Point(776, 355);
            this.button47.Margin = new System.Windows.Forms.Padding(0);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(62, 62);
            this.button47.TabIndex = 50;
            this.button47.TabStop = false;
            this.button47.Text = "About";
            this.button47.UseVisualStyleBackColor = false;
            this.button47.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // button48
            // 
            this.button48.BackColor = System.Drawing.Color.Transparent;
            this.button48.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button48.FlatAppearance.BorderSize = 0;
            this.button48.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button48.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.button48.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button48.ForeColor = System.Drawing.Color.White;
            this.button48.Location = new System.Drawing.Point(714, 355);
            this.button48.Margin = new System.Windows.Forms.Padding(0);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(62, 62);
            this.button48.TabIndex = 49;
            this.button48.TabStop = false;
            this.button48.Text = "Armageddoner";
            this.button48.UseVisualStyleBackColor = false;
            this.button48.Click += new System.EventHandler(this.button48_Click);
            this.button48.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CavaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(834, 603);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(850, 642);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(850, 642);
            this.Name = "CavaForm";
            this.ShowIcon = false;
            this.Text = "Cava\'s Profiles - One Profile Ahead";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.MainBox.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.connectgroupBox.ResumeLayout(false);
            this.connectgroupBox.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.charsetgroupBox.ResumeLayout(false);
            this.charsetgroupBox.PerformLayout();
            this.globalsetgroupBox.ResumeLayout(false);
            this.globalsetgroupBox.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lversion;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private RichTextBox ReservedTextBox;
        private GroupBox MainBox;
        private Button breport;
        private Label llastprofile;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private Label label5;
        private TextBox textBox5;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private RadioButton radioButton6;
        private RadioButton radioButton4;
        private CheckBox checkBox1;
        private GroupBox groupBox3;
        private Panel panel1;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RadioButton radioButton5;
        private RadioButton radioButton3;
        private GroupBox groupBox1;
        private Label label3;
        private Label label6;
        private Panel panel2;
        private ListBox listBox1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private Label label7;
        private Button button5;
        private GroupBox groupBox7;
        private Button button23;
        private Button button22;
        private Button button21;
        private GroupBox groupBox6;
        private GroupBox groupBox10;
        private PictureBox pictureBox14;
        private PictureBox pictureBox13;
        private RadioButton ProfMinBlack1600radioButton;
        private RadioButton MiningBlacksmithingProf;
        private Label label9;
        private Label label10;
        private Label label14;
        private Label label15;
        private Button button9;
        private Button button7;
        private Button button31;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button6;
        private Button button8;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button20;
        private Panel panel4;
        private Label label21;
        private Panel panel3;
        private Label label20;
        private Button button24;
        private Button button25;
        private Button button26;
        private Button button27;
        private Button button28;
        private Button button29;
        private Button button30;
        private Button button32;
        private GroupBox connectgroupBox;
        private Panel panel5;
        private RadioButton selectserver2radio;
        private RadioButton selectserver1radio;
        private Label passwordlabel;
        private PictureBox pictureBox10;
        private Button TestAccessbutton;
        private TextBox PasswordtextBox;
        private TextBox LogintextBox;
        private Label loginlabel;
        private GroupBox groupBox11;
        private ComboBox comboBox1;
        private Label label22;
        private GroupBox groupBox12;
        private GroupBox groupBox15;
        private CheckBox combatloot_checkBox;
        private CheckBox refuseDuelCheckBox;
        private CheckBox ResscheckBox;
        private CheckBox playsoundcheckBox;
        private CheckBox antigankcheckBox;
        private CheckBox fixmountcheckBox1;
        private CheckBox OpenBox_checkBox;
        private PictureBox pictureBox11;
        private PictureBox pictureBox9;
        private GroupBox charsetgroupBox;
        private CheckBox AntiStuck_CheckBox;
        private CheckBox AllowSummonPet_Checkbox;
        private CheckBox refuseTradesCheckBox;
        private CheckBox refusePartyCheckBox;
        private CheckBox guildInvitescheckBox;
        private CheckBox refuseGuildCheckBox;
        private GroupBox globalsetgroupBox;
        private CheckBox disableplugincheckBox;
        private CheckBox AutoShutDown_Checkbox;
        private Label label11;
        private Label label16;
        private GroupBox groupBox8;
        private PictureBox pictureBox12;
        private Label labelprofmb600;
        private PictureBox pictureBox8;
        private Button button33;
        private Button button34;
        private Button button35;
        private Button button36;
        private Button button37;
        private Button button38;
        private Button button39;
        private Button button40;
        private GroupBox groupBox13;
        private Label label17;
        private Label label18;
        private GroupBox groupBox9;
        private PictureBox pictureBox4;
        private Button button41;
        private Button button42;
        private Button button43;
        private Button button44;
        private Button button45;
        private Button button46;
        private Button button47;
        private Button button48;
        private GroupBox groupBox14;
        private TabControl tabControl2;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private CheckBox learnportal1checkBox;
        private CheckBox learnportal6checkBox;
        private CheckBox learnportal3checkBox;
        private CheckBox learnportal4checkBox;
        private CheckBox learnportal2checkBox;
        private CheckBox learnportal5checkBox;
        private Label label23;
        private Label label24;
        private Label label12;
        private Label label26;
        private Label label27;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Timer timer1;
        private Label label28;
        private Label label8;
        private Label label13;
        private Label label19;
        private Label label25;
        private Label label2;
        private RadioButton radioButton9;
        private Label label29;
        private Label label30;
        private TabPage tabPage10;
        private Label label31;
        private ComboBox comboBox2;
        private Label label32;
        private ComboBox comboBox3;
        private Label label33;
    }
}