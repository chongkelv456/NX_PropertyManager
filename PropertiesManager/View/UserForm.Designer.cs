
namespace PropertiesManager.View
{
    partial class UserForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveProjInfo = new System.Windows.Forms.Button();
            this.chkRetriveProjInfo = new System.Windows.Forms.CheckBox();
            this.cboDesign = new System.Windows.Forms.ComboBox();
            this.txtCodePrefix = new System.Windows.Forms.TextBox();
            this.txtPart = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericStnNo = new System.Windows.Forms.NumericUpDown();
            this.btnLengthPick = new System.Windows.Forms.Button();
            this.btnWidthPick = new System.Windows.Forms.Button();
            this.btnDwgCodeRefresh = new System.Windows.Forms.Button();
            this.btnThkPick = new System.Windows.Forms.Button();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.cboPartType = new System.Windows.Forms.ComboBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.cboHRC = new System.Windows.Forms.ComboBox();
            this.cboMaterial = new System.Windows.Forms.ComboBox();
            this.cboItemName = new System.Windows.Forms.ComboBox();
            this.txtThk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDwgCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFabrication = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.tabStandardPart = new System.Windows.Forms.TabPage();
            this.btnStdApply = new System.Windows.Forms.Button();
            this.btnStdCancel = new System.Windows.Forms.Button();
            this.cboStdItemName = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStnNo)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabFabrication.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabStandardPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.btnSaveProjInfo);
            this.groupBox1.Controls.Add(this.chkRetriveProjInfo);
            this.groupBox1.Controls.Add(this.cboDesign);
            this.groupBox1.Controls.Add(this.txtCodePrefix);
            this.groupBox1.Controls.Add(this.txtPart);
            this.groupBox1.Controls.Add(this.txtModel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Information";
            // 
            // btnSaveProjInfo
            // 
            this.btnSaveProjInfo.Enabled = false;
            this.btnSaveProjInfo.Location = new System.Drawing.Point(541, 17);
            this.btnSaveProjInfo.Name = "btnSaveProjInfo";
            this.btnSaveProjInfo.Size = new System.Drawing.Size(117, 30);
            this.btnSaveProjInfo.TabIndex = 9;
            this.btnSaveProjInfo.Text = "Save to file";
            this.btnSaveProjInfo.UseVisualStyleBackColor = true;
            this.btnSaveProjInfo.Click += new System.EventHandler(this.btnSaveProjInfo_Click);
            // 
            // chkRetriveProjInfo
            // 
            this.chkRetriveProjInfo.AutoSize = true;
            this.chkRetriveProjInfo.Location = new System.Drawing.Point(541, 61);
            this.chkRetriveProjInfo.Name = "chkRetriveProjInfo";
            this.chkRetriveProjInfo.Size = new System.Drawing.Size(151, 20);
            this.chkRetriveProjInfo.TabIndex = 8;
            this.chkRetriveProjInfo.Text = "Retrieve project info:";
            this.chkRetriveProjInfo.UseVisualStyleBackColor = true;
            this.chkRetriveProjInfo.CheckedChanged += new System.EventHandler(this.chkRetriveProjInfo_CheckedChanged);
            // 
            // cboDesign
            // 
            this.cboDesign.FormattingEnabled = true;
            this.cboDesign.Location = new System.Drawing.Point(365, 55);
            this.cboDesign.Name = "cboDesign";
            this.cboDesign.Size = new System.Drawing.Size(165, 24);
            this.cboDesign.TabIndex = 4;
            this.cboDesign.TextChanged += new System.EventHandler(this.cboDesign_TextChanged);
            // 
            // txtCodePrefix
            // 
            this.txtCodePrefix.Location = new System.Drawing.Point(365, 26);
            this.txtCodePrefix.Name = "txtCodePrefix";
            this.txtCodePrefix.Size = new System.Drawing.Size(165, 22);
            this.txtCodePrefix.TabIndex = 3;
            this.txtCodePrefix.TextChanged += new System.EventHandler(this.textCodePrefix_TextChanged);
            // 
            // txtPart
            // 
            this.txtPart.Location = new System.Drawing.Point(73, 59);
            this.txtPart.Name = "txtPart";
            this.txtPart.Size = new System.Drawing.Size(165, 22);
            this.txtPart.TabIndex = 2;
            this.txtPart.TextChanged += new System.EventHandler(this.textPart_TextChanged);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(73, 26);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(165, 22);
            this.txtModel.TabIndex = 1;
            this.txtModel.TextChanged += new System.EventHandler(this.txtModel_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label4.Size = new System.Drawing.Size(71, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Design by:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label3.Size = new System.Drawing.Size(106, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Dwg code prefix:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label2.Size = new System.Drawing.Size(47, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "PART:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label1.Size = new System.Drawing.Size(57, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "MODEL:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(409, 311);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(550, 311);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(135, 35);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 461);
            this.panel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnApply);
            this.groupBox2.Controls.Add(this.numericStnNo);
            this.groupBox2.Controls.Add(this.btnLengthPick);
            this.groupBox2.Controls.Add(this.btnWidthPick);
            this.groupBox2.Controls.Add(this.btnDwgCodeRefresh);
            this.groupBox2.Controls.Add(this.btnThkPick);
            this.groupBox2.Controls.Add(this.txtLength);
            this.groupBox2.Controls.Add(this.cboPartType);
            this.groupBox2.Controls.Add(this.txtWidth);
            this.groupBox2.Controls.Add(this.cboHRC);
            this.groupBox2.Controls.Add(this.cboMaterial);
            this.groupBox2.Controls.Add(this.cboItemName);
            this.groupBox2.Controls.Add(this.txtThk);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtDwgCode);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(5, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(691, 354);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Drawing Information:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PropertiesManager.Resource1.Other;
            this.pictureBox1.Location = new System.Drawing.Point(440, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // numericStnNo
            // 
            this.numericStnNo.Location = new System.Drawing.Point(136, 57);
            this.numericStnNo.Name = "numericStnNo";
            this.numericStnNo.Size = new System.Drawing.Size(200, 22);
            this.numericStnNo.TabIndex = 8;
            this.numericStnNo.ValueChanged += new System.EventHandler(this.numericStnNo_ValueChanged_1);
            // 
            // btnLengthPick
            // 
            this.btnLengthPick.Location = new System.Drawing.Point(348, 275);
            this.btnLengthPick.Name = "btnLengthPick";
            this.btnLengthPick.Size = new System.Drawing.Size(72, 25);
            this.btnLengthPick.TabIndex = 18;
            this.btnLengthPick.Text = "Pick...";
            this.btnLengthPick.UseVisualStyleBackColor = true;
            this.btnLengthPick.Click += new System.EventHandler(this.btnLengthPick_Click);
            // 
            // btnWidthPick
            // 
            this.btnWidthPick.Location = new System.Drawing.Point(349, 244);
            this.btnWidthPick.Name = "btnWidthPick";
            this.btnWidthPick.Size = new System.Drawing.Size(72, 25);
            this.btnWidthPick.TabIndex = 16;
            this.btnWidthPick.Text = "Pick...";
            this.btnWidthPick.UseVisualStyleBackColor = true;
            this.btnWidthPick.Click += new System.EventHandler(this.btnWidthPick_Click);
            // 
            // btnDwgCodeRefresh
            // 
            this.btnDwgCodeRefresh.Enabled = false;
            this.btnDwgCodeRefresh.Location = new System.Drawing.Point(348, 120);
            this.btnDwgCodeRefresh.Name = "btnDwgCodeRefresh";
            this.btnDwgCodeRefresh.Size = new System.Drawing.Size(72, 25);
            this.btnDwgCodeRefresh.TabIndex = 14;
            this.btnDwgCodeRefresh.Text = "Refresh...";
            this.btnDwgCodeRefresh.UseVisualStyleBackColor = true;
            this.btnDwgCodeRefresh.Click += new System.EventHandler(this.btnDwgCodeRefresh_Click);
            // 
            // btnThkPick
            // 
            this.btnThkPick.Location = new System.Drawing.Point(348, 213);
            this.btnThkPick.Name = "btnThkPick";
            this.btnThkPick.Size = new System.Drawing.Size(72, 25);
            this.btnThkPick.TabIndex = 14;
            this.btnThkPick.Text = "Pick...";
            this.btnThkPick.UseVisualStyleBackColor = true;
            this.btnThkPick.Click += new System.EventHandler(this.btnThkPick_Click);
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(136, 276);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(200, 22);
            this.txtLength.TabIndex = 17;
            this.txtLength.TextChanged += new System.EventHandler(this.txtLength_TextChanged);
            // 
            // cboPartType
            // 
            this.cboPartType.FormattingEnabled = true;
            this.cboPartType.Location = new System.Drawing.Point(136, 24);
            this.cboPartType.Name = "cboPartType";
            this.cboPartType.Size = new System.Drawing.Size(200, 24);
            this.cboPartType.TabIndex = 7;
            this.cboPartType.TextChanged += new System.EventHandler(this.cboPartType_TextChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(136, 245);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(200, 22);
            this.txtWidth.TabIndex = 15;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // cboHRC
            // 
            this.cboHRC.FormattingEnabled = true;
            this.cboHRC.Location = new System.Drawing.Point(136, 183);
            this.cboHRC.Name = "cboHRC";
            this.cboHRC.Size = new System.Drawing.Size(200, 24);
            this.cboHRC.TabIndex = 12;
            this.cboHRC.TextChanged += new System.EventHandler(this.cboHRC_TextChanged);
            // 
            // cboMaterial
            // 
            this.cboMaterial.FormattingEnabled = true;
            this.cboMaterial.Location = new System.Drawing.Point(136, 153);
            this.cboMaterial.Name = "cboMaterial";
            this.cboMaterial.Size = new System.Drawing.Size(200, 24);
            this.cboMaterial.TabIndex = 11;
            this.cboMaterial.TextChanged += new System.EventHandler(this.cboMaterial_TextChanged);
            // 
            // cboItemName
            // 
            this.cboItemName.FormattingEnabled = true;
            this.cboItemName.Location = new System.Drawing.Point(136, 88);
            this.cboItemName.Name = "cboItemName";
            this.cboItemName.Size = new System.Drawing.Size(200, 24);
            this.cboItemName.TabIndex = 9;
            this.cboItemName.TextChanged += new System.EventHandler(this.cboItemName_TextChanged);
            // 
            // txtThk
            // 
            this.txtThk.Location = new System.Drawing.Point(136, 214);
            this.txtThk.Name = "txtThk";
            this.txtThk.Size = new System.Drawing.Size(200, 22);
            this.txtThk.TabIndex = 13;
            this.txtThk.TextChanged += new System.EventHandler(this.txtThk_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 29);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "PART TYPE:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 61);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Size = new System.Drawing.Size(105, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "STATION NO.:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 93);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Size = new System.Drawing.Size(94, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "ITEM NAME:";
            // 
            // txtDwgCode
            // 
            this.txtDwgCode.Location = new System.Drawing.Point(136, 121);
            this.txtDwgCode.Name = "txtDwgCode";
            this.txtDwgCode.Size = new System.Drawing.Size(200, 22);
            this.txtDwgCode.TabIndex = 10;
            this.txtDwgCode.TextChanged += new System.EventHandler(this.txtDwgCode_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 125);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Size = new System.Drawing.Size(126, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "DRAWING CODE:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 157);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Size = new System.Drawing.Size(87, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "MATERIAL:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 285);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Size = new System.Drawing.Size(75, 16);
            this.label14.TabIndex = 6;
            this.label14.Text = "LENGTH:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 189);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Size = new System.Drawing.Size(49, 16);
            this.label11.TabIndex = 6;
            this.label11.Text = "HRC:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 253);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Size = new System.Drawing.Size(65, 16);
            this.label13.TabIndex = 6;
            this.label13.Text = "WIDTH:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 221);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Size = new System.Drawing.Size(96, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "THICKNESS:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(163, 607);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 22);
            this.txtQuantity.TabIndex = 19;
            this.txtQuantity.Text = "1";
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 609);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Size = new System.Drawing.Size(89, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "QUANTITY:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFabrication);
            this.tabControl1.Controls.Add(this.tabStandardPart);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(736, 589);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabFabrication
            // 
            this.tabFabrication.Controls.Add(this.groupBox3);
            this.tabFabrication.Controls.Add(this.panel1);
            this.tabFabrication.Location = new System.Drawing.Point(4, 25);
            this.tabFabrication.Name = "tabFabrication";
            this.tabFabrication.Padding = new System.Windows.Forms.Padding(3);
            this.tabFabrication.Size = new System.Drawing.Size(728, 560);
            this.tabFabrication.TabIndex = 0;
            this.tabFabrication.Text = "Fabrication Part";
            this.tabFabrication.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.txtPath);
            this.groupBox3.Location = new System.Drawing.Point(6, 473);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(700, 71);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Where is the project directory? Copy and paste the address here:";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Location = new System.Drawing.Point(6, 21);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(688, 22);
            this.txtPath.TabIndex = 0;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // tabStandardPart
            // 
            this.tabStandardPart.Controls.Add(this.btnStdApply);
            this.tabStandardPart.Controls.Add(this.btnStdCancel);
            this.tabStandardPart.Controls.Add(this.cboStdItemName);
            this.tabStandardPart.Controls.Add(this.label15);
            this.tabStandardPart.Location = new System.Drawing.Point(4, 25);
            this.tabStandardPart.Name = "tabStandardPart";
            this.tabStandardPart.Padding = new System.Windows.Forms.Padding(3);
            this.tabStandardPart.Size = new System.Drawing.Size(728, 560);
            this.tabStandardPart.TabIndex = 1;
            this.tabStandardPart.Text = "Standard Part";
            this.tabStandardPart.UseVisualStyleBackColor = true;
            // 
            // btnStdApply
            // 
            this.btnStdApply.Location = new System.Drawing.Point(550, 320);
            this.btnStdApply.Name = "btnStdApply";
            this.btnStdApply.Size = new System.Drawing.Size(135, 35);
            this.btnStdApply.TabIndex = 3;
            this.btnStdApply.Text = "&Apply";
            this.btnStdApply.UseVisualStyleBackColor = true;
            this.btnStdApply.Click += new System.EventHandler(this.btnStdApply_Click);
            // 
            // btnStdCancel
            // 
            this.btnStdCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStdCancel.Location = new System.Drawing.Point(409, 320);
            this.btnStdCancel.Name = "btnStdCancel";
            this.btnStdCancel.Size = new System.Drawing.Size(135, 35);
            this.btnStdCancel.TabIndex = 2;
            this.btnStdCancel.Text = "&Cancel";
            this.btnStdCancel.UseVisualStyleBackColor = true;
            this.btnStdCancel.Click += new System.EventHandler(this.btnStdCancel_Click);
            // 
            // cboStdItemName
            // 
            this.cboStdItemName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboStdItemName.FormattingEnabled = true;
            this.cboStdItemName.Location = new System.Drawing.Point(195, 58);
            this.cboStdItemName.Name = "cboStdItemName";
            this.cboStdItemName.Size = new System.Drawing.Size(254, 24);
            this.cboStdItemName.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(160, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Standard Part Item Name:";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(757, 641);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserForm";
            this.Text = "Properties Manager Form";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStnNo)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabFabrication.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabStandardPart.ResumeLayout(false);
            this.tabStandardPart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDesign;
        private System.Windows.Forms.TextBox txtCodePrefix;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLengthPick;
        private System.Windows.Forms.Button btnWidthPick;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnThkPick;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.ComboBox cboPartType;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.ComboBox cboItemName;
        private System.Windows.Forms.TextBox txtThk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDwgCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboHRC;
        private System.Windows.Forms.ComboBox cboMaterial;
        private System.Windows.Forms.NumericUpDown numericStnNo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFabrication;
        private System.Windows.Forms.TabPage tabStandardPart;
        private System.Windows.Forms.ComboBox cboStdItemName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnStdCancel;
        private System.Windows.Forms.Button btnStdApply;
        private System.Windows.Forms.Button btnSaveProjInfo;
        private System.Windows.Forms.CheckBox chkRetriveProjInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnDwgCodeRefresh;
    }
}