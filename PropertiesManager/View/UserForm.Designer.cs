
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
            this.cboDesign = new System.Windows.Forms.ComboBox();
            this.textCodePrefix = new System.Windows.Forms.TextBox();
            this.textPart = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cboPartType = new System.Windows.Forms.ComboBox();
            this.cboItemName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtStnNo = new System.Windows.Forms.TextBox();
            this.txtDwgCode = new System.Windows.Forms.TextBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtHRC = new System.Windows.Forms.TextBox();
            this.txtThk = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.btnThkPick = new System.Windows.Forms.Button();
            this.btnWidthPick = new System.Windows.Forms.Button();
            this.btnLengthPick = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.cboDesign);
            this.groupBox1.Controls.Add(this.textCodePrefix);
            this.groupBox1.Controls.Add(this.textPart);
            this.groupBox1.Controls.Add(this.txtModel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(709, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Information";
            // 
            // cboDesign
            // 
            this.cboDesign.FormattingEnabled = true;
            this.cboDesign.Location = new System.Drawing.Point(442, 55);
            this.cboDesign.Name = "cboDesign";
            this.cboDesign.Size = new System.Drawing.Size(200, 24);
            this.cboDesign.TabIndex = 4;
            this.cboDesign.TextChanged += new System.EventHandler(this.cboDesign_TextChanged);
            // 
            // textCodePrefix
            // 
            this.textCodePrefix.Location = new System.Drawing.Point(442, 26);
            this.textCodePrefix.Name = "textCodePrefix";
            this.textCodePrefix.Size = new System.Drawing.Size(200, 22);
            this.textCodePrefix.TabIndex = 3;
            this.textCodePrefix.TextChanged += new System.EventHandler(this.textCodePrefix_TextChanged);
            // 
            // textPart
            // 
            this.textPart.Location = new System.Drawing.Point(73, 59);
            this.textPart.Name = "textPart";
            this.textPart.Size = new System.Drawing.Size(200, 22);
            this.textPart.TabIndex = 2;
            this.textPart.TextChanged += new System.EventHandler(this.textPart_TextChanged);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(73, 26);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(200, 22);
            this.txtModel.TabIndex = 1;
            this.txtModel.TextChanged += new System.EventHandler(this.txtModel_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label4.Size = new System.Drawing.Size(75, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Design by:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label3.Size = new System.Drawing.Size(112, 27);
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
            this.label2.Size = new System.Drawing.Size(49, 27);
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
            this.label1.Size = new System.Drawing.Size(61, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "MODEL:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(442, 507);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(583, 507);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(135, 35);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 490);
            this.panel1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 317);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "QUANTITY:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(136, 307);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 22);
            this.txtQuantity.TabIndex = 19;
            // 
            // cboPartType
            // 
            this.cboPartType.FormattingEnabled = true;
            this.cboPartType.Location = new System.Drawing.Point(136, 24);
            this.cboPartType.Name = "cboPartType";
            this.cboPartType.Size = new System.Drawing.Size(200, 24);
            this.cboPartType.TabIndex = 7;
            // 
            // cboItemName
            // 
            this.cboItemName.FormattingEnabled = true;
            this.cboItemName.Location = new System.Drawing.Point(136, 88);
            this.cboItemName.Name = "cboItemName";
            this.cboItemName.Size = new System.Drawing.Size(200, 24);
            this.cboItemName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 29);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "PART TYPE:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 61);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "STATION NO.:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 93);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Size = new System.Drawing.Size(97, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "ITEM NAME:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 125);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Size = new System.Drawing.Size(131, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "DRAWING CODE:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 157);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Size = new System.Drawing.Size(90, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "MATERIAL:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 189);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Size = new System.Drawing.Size(51, 17);
            this.label11.TabIndex = 6;
            this.label11.Text = "HRC:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 221);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Size = new System.Drawing.Size(99, 17);
            this.label12.TabIndex = 6;
            this.label12.Text = "THICKNESS:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 253);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Size = new System.Drawing.Size(67, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "WIDTH:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 285);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Size = new System.Drawing.Size(79, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "LENGTH:";
            // 
            // txtStnNo
            // 
            this.txtStnNo.Location = new System.Drawing.Point(136, 57);
            this.txtStnNo.Name = "txtStnNo";
            this.txtStnNo.Size = new System.Drawing.Size(200, 22);
            this.txtStnNo.TabIndex = 8;
            // 
            // txtDwgCode
            // 
            this.txtDwgCode.Location = new System.Drawing.Point(136, 121);
            this.txtDwgCode.Name = "txtDwgCode";
            this.txtDwgCode.Size = new System.Drawing.Size(200, 22);
            this.txtDwgCode.TabIndex = 10;
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(136, 152);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(200, 22);
            this.txtMaterial.TabIndex = 11;
            // 
            // txtHRC
            // 
            this.txtHRC.Location = new System.Drawing.Point(136, 183);
            this.txtHRC.Name = "txtHRC";
            this.txtHRC.Size = new System.Drawing.Size(200, 22);
            this.txtHRC.TabIndex = 12;
            // 
            // txtThk
            // 
            this.txtThk.Location = new System.Drawing.Point(136, 214);
            this.txtThk.Name = "txtThk";
            this.txtThk.Size = new System.Drawing.Size(200, 22);
            this.txtThk.TabIndex = 13;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(136, 245);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(200, 22);
            this.txtWidth.TabIndex = 15;
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(136, 276);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(200, 22);
            this.txtLength.TabIndex = 17;
            // 
            // btnThkPick
            // 
            this.btnThkPick.Location = new System.Drawing.Point(348, 213);
            this.btnThkPick.Name = "btnThkPick";
            this.btnThkPick.Size = new System.Drawing.Size(72, 25);
            this.btnThkPick.TabIndex = 14;
            this.btnThkPick.Text = "Pick...";
            this.btnThkPick.UseVisualStyleBackColor = true;
            // 
            // btnWidthPick
            // 
            this.btnWidthPick.Location = new System.Drawing.Point(349, 244);
            this.btnWidthPick.Name = "btnWidthPick";
            this.btnWidthPick.Size = new System.Drawing.Size(72, 25);
            this.btnWidthPick.TabIndex = 16;
            this.btnWidthPick.Text = "Pick...";
            this.btnWidthPick.UseVisualStyleBackColor = true;
            // 
            // btnLengthPick
            // 
            this.btnLengthPick.Location = new System.Drawing.Point(348, 275);
            this.btnLengthPick.Name = "btnLengthPick";
            this.btnLengthPick.Size = new System.Drawing.Size(72, 25);
            this.btnLengthPick.TabIndex = 18;
            this.btnLengthPick.Text = "Pick...";
            this.btnLengthPick.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.btnLengthPick);
            this.groupBox2.Controls.Add(this.btnWidthPick);
            this.groupBox2.Controls.Add(this.txtQuantity);
            this.groupBox2.Controls.Add(this.btnThkPick);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtLength);
            this.groupBox2.Controls.Add(this.cboPartType);
            this.groupBox2.Controls.Add(this.txtWidth);
            this.groupBox2.Controls.Add(this.cboItemName);
            this.groupBox2.Controls.Add(this.txtThk);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtHRC);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtMaterial);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtDwgCode);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtStnNo);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(6, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(709, 364);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Drawing Information:";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(730, 554);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserForm";
            this.Text = "Properties Manager Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDesign;
        private System.Windows.Forms.TextBox textCodePrefix;
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
        private System.Windows.Forms.TextBox txtHRC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDwgCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStnNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}