namespace LoginFrame
{
    partial class Frm个人信息
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm个人信息));
            this.U_Birthday = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radio_women = new System.Windows.Forms.RadioButton();
            this.radion_man = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.U_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.U_NativePlace = new System.Windows.Forms.ComboBox();
            this.U_IdCard = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.U_Address = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_pic = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.U_Telephone = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.U_Position = new System.Windows.Forms.TextBox();
            this.U_RelName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.U_PostalId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.U_Email = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // U_Birthday
            // 
            this.U_Birthday.Enabled = false;
            this.U_Birthday.Location = new System.Drawing.Point(83, 93);
            this.U_Birthday.Name = "U_Birthday";
            this.U_Birthday.Size = new System.Drawing.Size(164, 21);
            this.U_Birthday.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.radio_women);
            this.groupBox1.Controls.Add(this.radion_man);
            this.groupBox1.Controls.Add(this.U_Birthday);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.U_Name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 135);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "个人基本信息";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(309, 98);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "密保设置";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // radio_women
            // 
            this.radio_women.AutoSize = true;
            this.radio_women.Enabled = false;
            this.radio_women.ForeColor = System.Drawing.Color.Black;
            this.radio_women.Location = new System.Drawing.Point(166, 65);
            this.radio_women.Name = "radio_women";
            this.radio_women.Size = new System.Drawing.Size(35, 16);
            this.radio_women.TabIndex = 21;
            this.radio_women.Text = "女";
            this.radio_women.UseVisualStyleBackColor = true;
            // 
            // radion_man
            // 
            this.radion_man.AutoSize = true;
            this.radion_man.Checked = true;
            this.radion_man.Enabled = false;
            this.radion_man.ForeColor = System.Drawing.Color.Black;
            this.radion_man.Location = new System.Drawing.Point(87, 65);
            this.radion_man.Name = "radion_man";
            this.radion_man.Size = new System.Drawing.Size(35, 16);
            this.radion_man.TabIndex = 20;
            this.radion_man.TabStop = true;
            this.radion_man.Text = "男";
            this.radion_man.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(29, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "性  别:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(18, 102);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 6;
            this.label15.Text = "出生日期:";
            // 
            // U_Name
            // 
            this.U_Name.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.U_Name.Location = new System.Drawing.Point(82, 26);
            this.U_Name.MaxLength = 20;
            this.U_Name.Name = "U_Name";
            this.U_Name.ReadOnly = true;
            this.U_Name.Size = new System.Drawing.Size(165, 21);
            this.U_Name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(29, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名:";
            // 
            // U_NativePlace
            // 
            this.U_NativePlace.Enabled = false;
            this.U_NativePlace.ForeColor = System.Drawing.SystemColors.WindowText;
            this.U_NativePlace.FormattingEnabled = true;
            this.U_NativePlace.Location = new System.Drawing.Point(81, 154);
            this.U_NativePlace.Name = "U_NativePlace";
            this.U_NativePlace.Size = new System.Drawing.Size(167, 20);
            this.U_NativePlace.TabIndex = 18;
            // 
            // U_IdCard
            // 
            this.U_IdCard.Location = new System.Drawing.Point(80, 90);
            this.U_IdCard.MaxLength = 20;
            this.U_IdCard.Name = "U_IdCard";
            this.U_IdCard.ReadOnly = true;
            this.U_IdCard.Size = new System.Drawing.Size(166, 21);
            this.U_IdCard.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(27, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "民  族:";
            // 
            // U_Address
            // 
            this.U_Address.Location = new System.Drawing.Point(80, 158);
            this.U_Address.MaxLength = 20;
            this.U_Address.Name = "U_Address";
            this.U_Address.ReadOnly = true;
            this.U_Address.Size = new System.Drawing.Size(300, 21);
            this.U_Address.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(329, 329);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 26);
            this.button3.TabIndex = 2;
            this.button3.Text = "上 传";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_pic
            // 
            this.txt_pic.Location = new System.Drawing.Point(16, 331);
            this.txt_pic.Name = "txt_pic";
            this.txt_pic.ReadOnly = true;
            this.txt_pic.Size = new System.Drawing.Size(307, 21);
            this.txt_pic.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(16, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 289);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(17, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "家庭住址:";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(655, 540);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 14;
            this.button2.Text = "退  出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(754, 540);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 13;
            this.button1.Text = "保  存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.txt_pic);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Location = new System.Drawing.Point(417, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 368);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "生活照展示";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(15, 134);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 2;
            this.label17.Text = "E_mail:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(15, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "联系电话:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(15, 99);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 4;
            this.label16.Text = "身份证号:";
            // 
            // U_Telephone
            // 
            this.U_Telephone.Location = new System.Drawing.Point(81, 26);
            this.U_Telephone.MaxLength = 20;
            this.U_Telephone.Name = "U_Telephone";
            this.U_Telephone.ReadOnly = true;
            this.U_Telephone.Size = new System.Drawing.Size(165, 21);
            this.U_Telephone.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.U_Position);
            this.groupBox2.Controls.Add(this.U_RelName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.U_NativePlace);
            this.groupBox2.Controls.Add(this.U_IdCard);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(13, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 228);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "个人详细信息";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(80, 122);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 20);
            this.comboBox1.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(28, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "部  门:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(81, 185);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(168, 21);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(16, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "入职时间:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(28, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "职  务:";
            // 
            // U_Position
            // 
            this.U_Position.Location = new System.Drawing.Point(81, 59);
            this.U_Position.MaxLength = 20;
            this.U_Position.Name = "U_Position";
            this.U_Position.ReadOnly = true;
            this.U_Position.Size = new System.Drawing.Size(165, 21);
            this.U_Position.TabIndex = 21;
            // 
            // U_RelName
            // 
            this.U_RelName.Location = new System.Drawing.Point(81, 27);
            this.U_RelName.MaxLength = 20;
            this.U_RelName.Name = "U_RelName";
            this.U_RelName.ReadOnly = true;
            this.U_RelName.Size = new System.Drawing.Size(165, 21);
            this.U_RelName.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "真实姓名:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.U_PostalId);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.U_Email);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.U_Address);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.U_Telephone);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(13, 387);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(399, 212);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "联系方式";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 58);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(165, 21);
            this.textBox1.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(39, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "微信:";
            // 
            // U_PostalId
            // 
            this.U_PostalId.Location = new System.Drawing.Point(81, 92);
            this.U_PostalId.MaxLength = 20;
            this.U_PostalId.Name = "U_PostalId";
            this.U_PostalId.ReadOnly = true;
            this.U_PostalId.Size = new System.Drawing.Size(165, 21);
            this.U_PostalId.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(39, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Q  Q:";
            // 
            // U_Email
            // 
            this.U_Email.Location = new System.Drawing.Point(81, 125);
            this.U_Email.MaxLength = 20;
            this.U_Email.Name = "U_Email";
            this.U_Email.ReadOnly = true;
            this.U_Email.Size = new System.Drawing.Size(165, 21);
            this.U_Email.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.Location = new System.Drawing.Point(555, 540);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 29);
            this.button4.TabIndex = 16;
            this.button4.Text = "修 改";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Frm个人信息
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 611);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm个人信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人详细信息";
            this.Load += new System.EventHandler(this.Frm个人信息_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker U_Birthday;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox U_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox U_NativePlace;
        private System.Windows.Forms.TextBox U_IdCard;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox U_Address;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_pic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox U_Telephone;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton radio_women;
        private System.Windows.Forms.RadioButton radion_man;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox U_RelName;
        private System.Windows.Forms.TextBox U_Position;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox U_PostalId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox U_Email;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}