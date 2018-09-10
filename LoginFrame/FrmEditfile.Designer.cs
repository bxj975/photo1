namespace LoginFrame
{
    partial class FrmEditfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditfile));
            this.dtp_publishDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.Btn_Update = new System.Windows.Forms.Button();
            this.btn_bookPhoto = new System.Windows.Forms.Button();
            this.txt_bookPhoto = new System.Windows.Forms.TextBox();
            this.pictureBox_bookPhoto = new System.Windows.Forms.PictureBox();
            this.txt_publish = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_bookType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_bookName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bookPhoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_publishDate
            // 
            this.dtp_publishDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_publishDate.Location = new System.Drawing.Point(603, 614);
            this.dtp_publishDate.Name = "dtp_publishDate";
            this.dtp_publishDate.Size = new System.Drawing.Size(92, 21);
            this.dtp_publishDate.TabIndex = 37;
            this.dtp_publishDate.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(556, 618);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "日期：";
            // 
            // Btn_Update
            // 
            this.Btn_Update.Location = new System.Drawing.Point(785, 612);
            this.Btn_Update.Name = "Btn_Update";
            this.Btn_Update.Size = new System.Drawing.Size(68, 25);
            this.Btn_Update.TabIndex = 35;
            this.Btn_Update.Text = "更新";
            this.Btn_Update.UseVisualStyleBackColor = true;
            this.Btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // btn_bookPhoto
            // 
            this.btn_bookPhoto.Location = new System.Drawing.Point(272, 385);
            this.btn_bookPhoto.Name = "btn_bookPhoto";
            this.btn_bookPhoto.Size = new System.Drawing.Size(45, 26);
            this.btn_bookPhoto.TabIndex = 34;
            this.btn_bookPhoto.Text = "上 传";
            this.btn_bookPhoto.UseVisualStyleBackColor = true;
            this.btn_bookPhoto.Click += new System.EventHandler(this.btn_bookPhoto_Click);
            // 
            // txt_bookPhoto
            // 
            this.txt_bookPhoto.Location = new System.Drawing.Point(21, 385);
            this.txt_bookPhoto.Name = "txt_bookPhoto";
            this.txt_bookPhoto.ReadOnly = true;
            this.txt_bookPhoto.Size = new System.Drawing.Size(230, 21);
            this.txt_bookPhoto.TabIndex = 33;
            // 
            // pictureBox_bookPhoto
            // 
            this.pictureBox_bookPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_bookPhoto.Location = new System.Drawing.Point(21, 20);
            this.pictureBox_bookPhoto.Name = "pictureBox_bookPhoto";
            this.pictureBox_bookPhoto.Size = new System.Drawing.Size(327, 351);
            this.pictureBox_bookPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_bookPhoto.TabIndex = 32;
            this.pictureBox_bookPhoto.TabStop = false;
           
            // 
            // txt_publish
            // 
            this.txt_publish.Location = new System.Drawing.Point(11, 20);
            this.txt_publish.Multiline = true;
            this.txt_publish.Name = "txt_publish";
            this.txt_publish.Size = new System.Drawing.Size(441, 505);
            this.txt_publish.TabIndex = 30;
            
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 29;
            
            // 
            // cb_bookType
            // 
            this.cb_bookType.FormattingEnabled = true;
            this.cb_bookType.Location = new System.Drawing.Point(330, 20);
            this.cb_bookType.Name = "cb_bookType";
            this.cb_bookType.Size = new System.Drawing.Size(148, 20);
            this.cb_bookType.TabIndex = 24;
            
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "类别：";
            // 
            // txt_bookName
            // 
            this.txt_bookName.Location = new System.Drawing.Point(77, 49);
            this.txt_bookName.Name = "txt_bookName";
            this.txt_bookName.Size = new System.Drawing.Size(401, 21);
            this.txt_bookName.TabIndex = 22;
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "标题：";
            // 
            // txt_barcode
            // 
            this.txt_barcode.Location = new System.Drawing.Point(78, 20);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.ReadOnly = true;
            this.txt_barcode.Size = new System.Drawing.Size(90, 21);
            this.txt_barcode.TabIndex = 20;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "编号：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_barcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_bookName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_bookType);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(839, 83);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_publish);
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 540);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "正文";
            
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox_bookPhoto);
            this.groupBox3.Controls.Add(this.txt_bookPhoto);
            this.groupBox3.Controls.Add(this.btn_bookPhoto);
            this.groupBox3.Location = new System.Drawing.Point(487, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 437);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "图片";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(708, 612);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 25);
            this.button1.TabIndex = 36;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // FrmEditfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 664);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtp_publishDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Btn_Update);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图书编辑界面";
            this.Load += new System.EventHandler(this.FrmEditfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bookPhoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_publishDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Btn_Update;
        private System.Windows.Forms.Button btn_bookPhoto;
        private System.Windows.Forms.TextBox txt_bookPhoto;
        private System.Windows.Forms.PictureBox pictureBox_bookPhoto;
        private System.Windows.Forms.TextBox txt_publish;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_bookType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_bookName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
    }
}