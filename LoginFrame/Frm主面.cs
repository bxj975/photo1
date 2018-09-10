using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace LoginFrame
{
    public partial class Frm主面 : Form
    {
        public Frm主面()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm主面_Load(object sender, EventArgs e)
        {
           // DateTime time1 = DateTime.Now;
           // DateTime time2 = DateTime.Parse("2015-09-20");
            //if (time1 > time2) 
            //{
               // Application.ExitThread();
            //}
        }
      
        private void toolStripLabel_Return_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("确定要退出?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (button == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void toolStripButton_PlanSet_Click(object sender, EventArgs e)
        {
            frmIP frm = new frmIP();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("编码输入不能为空!");
                return;
            }
            string Uname=this.textBox1.Text.Trim();
            Model.Book book = DAL.dalCustom.getSomePhoto(Uname);
            if (book.bookPhoto == null)
            {
                MessageBox.Show("没有图片!");
                return;
            }
            else
            {
                byte[] bookPhoto = (byte[])(book.bookPhoto);
                MemoryStream ms = new MemoryStream(bookPhoto);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void Frm主面_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Dock = DockStyle.Fill;
            button1_Click( sender, e);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize; //picturebox的SizeMode为自动扩展
            pictureBox1.Dock = DockStyle.None;
            button1_Click(sender, e); 
        }

    }
}
