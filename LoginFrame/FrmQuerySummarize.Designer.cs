namespace LoginFrame
{
    partial class FrmQuerySummarize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuerySummarize));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Btn_Query = new System.Windows.Forms.Button();
            this.dtp_publishDate = new System.Windows.Forms.DateTimePicker();
            this.txt_publishDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView_Book = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.发送AAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.塔楼ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PageMes = new System.Windows.Forms.Label();
            this.LBHome = new System.Windows.Forms.Button();
            this.LBUp = new System.Windows.Forms.Button();
            this.LBNext = new System.Windows.Forms.Button();
            this.LBEnd = new System.Windows.Forms.Button();
            this.HSelectID = new System.Windows.Forms.TextBox();
            this.HWhere = new System.Windows.Forms.TextBox();
            this.HNowPage = new System.Windows.Forms.TextBox();
            this.HPageSize = new System.Windows.Forms.TextBox();
            this.HAllPage = new System.Windows.Forms.TextBox();
            this.Btn_Update = new System.Windows.Forms.Button();
            this.Btn_Del = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Book)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.Btn_Query);
            this.groupBox1.Controls.Add(this.dtp_publishDate);
            this.groupBox1.Controls.Add(this.txt_publishDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(579, 27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "未审核";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "期间：";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "今日",
            "昨日",
            "本周",
            "本月",
            "本季",
            "本年"});
            this.comboBox3.Location = new System.Drawing.Point(366, 25);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(145, 20);
            this.comboBox3.TabIndex = 18;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "部门：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(115, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 20);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "职员：";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(115, 65);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(145, 20);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Btn_Query
            // 
            this.Btn_Query.Location = new System.Drawing.Point(693, 23);
            this.Btn_Query.Name = "Btn_Query";
            this.Btn_Query.Size = new System.Drawing.Size(97, 22);
            this.Btn_Query.TabIndex = 9;
            this.Btn_Query.Text = "查询";
            this.Btn_Query.UseVisualStyleBackColor = true;
            this.Btn_Query.Click += new System.EventHandler(this.Btn_Query_Click);
            // 
            // dtp_publishDate
            // 
            this.dtp_publishDate.Location = new System.Drawing.Point(495, 62);
            this.dtp_publishDate.Name = "dtp_publishDate";
            this.dtp_publishDate.Size = new System.Drawing.Size(20, 21);
            this.dtp_publishDate.TabIndex = 8;
            this.dtp_publishDate.ValueChanged += new System.EventHandler(this.dtp_publishDate_ValueChanged);
            // 
            // txt_publishDate
            // 
            this.txt_publishDate.Location = new System.Drawing.Point(366, 61);
            this.txt_publishDate.Name = "txt_publishDate";
            this.txt_publishDate.Size = new System.Drawing.Size(130, 21);
            this.txt_publishDate.TabIndex = 7;
            this.txt_publishDate.TextChanged += new System.EventHandler(this.txt_publishDate_TextChanged);
            this.txt_publishDate.DoubleClick += new System.EventHandler(this.txt_publishDate_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "日期：";
            // 
            // dataGridView_Book
            // 
            this.dataGridView_Book.AllowUserToAddRows = false;
            this.dataGridView_Book.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Book.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView_Book.Location = new System.Drawing.Point(12, 121);
            this.dataGridView_Book.Name = "dataGridView_Book";
            this.dataGridView_Book.RowTemplate.Height = 23;
            this.dataGridView_Book.Size = new System.Drawing.Size(834, 507);
            this.dataGridView_Book.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发送AAToolStripMenuItem,
            this.塔楼ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // 发送AAToolStripMenuItem
            // 
            this.发送AAToolStripMenuItem.Name = "发送AAToolStripMenuItem";
            this.发送AAToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.发送AAToolStripMenuItem.Text = "审核";
            this.发送AAToolStripMenuItem.Click += new System.EventHandler(this.审核ToolStripMenuItem_Click);
            // 
            // 塔楼ToolStripMenuItem
            // 
            this.塔楼ToolStripMenuItem.Name = "塔楼ToolStripMenuItem";
            this.塔楼ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.塔楼ToolStripMenuItem.Text = "删除";
            this.塔楼ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // PageMes
            // 
            this.PageMes.AutoSize = true;
            this.PageMes.Location = new System.Drawing.Point(10, 648);
            this.PageMes.Name = "PageMes";
            this.PageMes.Size = new System.Drawing.Size(41, 12);
            this.PageMes.TabIndex = 2;
            this.PageMes.Text = "待查询";
            // 
            // LBHome
            // 
            this.LBHome.Enabled = false;
            this.LBHome.Location = new System.Drawing.Point(686, 637);
            this.LBHome.Name = "LBHome";
            this.LBHome.Size = new System.Drawing.Size(26, 26);
            this.LBHome.TabIndex = 3;
            this.LBHome.Text = "<<";
            this.LBHome.UseVisualStyleBackColor = true;
            this.LBHome.Click += new System.EventHandler(this.LBHome_Click);
            // 
            // LBUp
            // 
            this.LBUp.Enabled = false;
            this.LBUp.Location = new System.Drawing.Point(718, 637);
            this.LBUp.Name = "LBUp";
            this.LBUp.Size = new System.Drawing.Size(26, 26);
            this.LBUp.TabIndex = 4;
            this.LBUp.Text = "<";
            this.LBUp.UseVisualStyleBackColor = true;
            this.LBUp.Click += new System.EventHandler(this.LBUp_Click);
            // 
            // LBNext
            // 
            this.LBNext.Enabled = false;
            this.LBNext.Location = new System.Drawing.Point(750, 637);
            this.LBNext.Name = "LBNext";
            this.LBNext.Size = new System.Drawing.Size(26, 26);
            this.LBNext.TabIndex = 5;
            this.LBNext.Text = ">";
            this.LBNext.UseVisualStyleBackColor = true;
            this.LBNext.Click += new System.EventHandler(this.LBNext_Click);
            // 
            // LBEnd
            // 
            this.LBEnd.Enabled = false;
            this.LBEnd.Location = new System.Drawing.Point(782, 637);
            this.LBEnd.Name = "LBEnd";
            this.LBEnd.Size = new System.Drawing.Size(26, 26);
            this.LBEnd.TabIndex = 6;
            this.LBEnd.Text = ">>";
            this.LBEnd.UseVisualStyleBackColor = true;
            this.LBEnd.Click += new System.EventHandler(this.LBEnd_Click);
            // 
            // HSelectID
            // 
            this.HSelectID.Location = new System.Drawing.Point(82, 640);
            this.HSelectID.Name = "HSelectID";
            this.HSelectID.Size = new System.Drawing.Size(56, 21);
            this.HSelectID.TabIndex = 7;
            this.HSelectID.Visible = false;
            // 
            // HWhere
            // 
            this.HWhere.Location = new System.Drawing.Point(143, 640);
            this.HWhere.Name = "HWhere";
            this.HWhere.Size = new System.Drawing.Size(56, 21);
            this.HWhere.TabIndex = 8;
            this.HWhere.Visible = false;
            // 
            // HNowPage
            // 
            this.HNowPage.Location = new System.Drawing.Point(205, 640);
            this.HNowPage.Name = "HNowPage";
            this.HNowPage.Size = new System.Drawing.Size(56, 21);
            this.HNowPage.TabIndex = 9;
            this.HNowPage.Text = "1";
            this.HNowPage.Visible = false;
            // 
            // HPageSize
            // 
            this.HPageSize.Location = new System.Drawing.Point(267, 640);
            this.HPageSize.Name = "HPageSize";
            this.HPageSize.Size = new System.Drawing.Size(56, 21);
            this.HPageSize.TabIndex = 10;
            this.HPageSize.Text = "16";
            this.HPageSize.Visible = false;
            // 
            // HAllPage
            // 
            this.HAllPage.Location = new System.Drawing.Point(329, 640);
            this.HAllPage.Name = "HAllPage";
            this.HAllPage.Size = new System.Drawing.Size(56, 21);
            this.HAllPage.TabIndex = 11;
            this.HAllPage.Text = "0";
            this.HAllPage.Visible = false;
            // 
            // Btn_Update
            // 
            this.Btn_Update.Location = new System.Drawing.Point(415, 635);
            this.Btn_Update.Name = "Btn_Update";
            this.Btn_Update.Size = new System.Drawing.Size(84, 28);
            this.Btn_Update.TabIndex = 12;
            this.Btn_Update.Text = "查看";
            this.Btn_Update.UseVisualStyleBackColor = true;
            this.Btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // Btn_Del
            // 
            this.Btn_Del.Location = new System.Drawing.Point(520, 635);
            this.Btn_Del.Name = "Btn_Del";
            this.Btn_Del.Size = new System.Drawing.Size(78, 27);
            this.Btn_Del.TabIndex = 13;
            this.Btn_Del.Text = "删除";
            this.Btn_Del.UseVisualStyleBackColor = true;
            this.Btn_Del.Click += new System.EventHandler(this.Btn_Del_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(714, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "行数:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(755, 63);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(35, 21);
            this.textBox3.TabIndex = 23;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(579, 67);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 22;
            this.checkBox2.Text = "自动加载";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // FrmQuerySummarize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(858, 673);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.HAllPage);
            this.Controls.Add(this.dataGridView_Book);
            this.Controls.Add(this.Btn_Del);
            this.Controls.Add(this.Btn_Update);
            this.Controls.Add(this.HPageSize);
            this.Controls.Add(this.HNowPage);
            this.Controls.Add(this.HWhere);
            this.Controls.Add(this.HSelectID);
            this.Controls.Add(this.LBUp);
            this.Controls.Add(this.LBHome);
            this.Controls.Add(this.LBEnd);
            this.Controls.Add(this.PageMes);
            this.Controls.Add(this.LBNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuerySummarize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "工作日报查询";
            this.Load += new System.EventHandler(this.FrmQuerySummarize_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Book)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView_Book;
        private System.Windows.Forms.Label PageMes;
        private System.Windows.Forms.Button LBHome;
        private System.Windows.Forms.Button LBUp;
        private System.Windows.Forms.Button LBNext;
        private System.Windows.Forms.Button LBEnd;
        private System.Windows.Forms.TextBox HSelectID;
        private System.Windows.Forms.TextBox HWhere;
        private System.Windows.Forms.TextBox HNowPage;
        private System.Windows.Forms.TextBox HPageSize;
        private System.Windows.Forms.TextBox HAllPage;
        private System.Windows.Forms.Button Btn_Query;
        private System.Windows.Forms.Button Btn_Update;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 发送AAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 塔楼ToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtp_publishDate;
        private System.Windows.Forms.TextBox txt_publishDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button Btn_Del;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}