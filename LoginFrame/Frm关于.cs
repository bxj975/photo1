/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginFrame
{
    public partial class Frm关于 : Form
    {
        public Frm关于()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm关于_Load(object sender, EventArgs e)
        {
            string version = System.Configuration.ConfigurationManager.AppSettings["version"].ToString();//窗口标题
            this.label1.Text = version;
            //string AboutImage = "../../pic/" + System.Configuration.ConfigurationManager.AppSettings["AboutImage"].ToString();//关于图片
            //AboutImage += Application.StartupPath + AboutImage;
            //this.pictureBox1.BackgroundImage = Image.FromFile(AboutImage);           
        }
    }
}*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox)
                {
                    c.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
                    c.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();//生成图形对象 
            SolidBrush BlueBrush = new SolidBrush(Color.Blue);//生成填充用的画刷 
            int x = 15;//定义外接矩形的左上角坐标和高度及宽度 
            int y = 15;
            int width = 200;
            int height = 100;
            Rectangle rect = new Rectangle(x, y, width, height);//定义矩形 
            g.FillRectangle(BlueBrush, rect);//填充矩形 
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        bool wselected = false;
        Point p = new Point();
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Cursor = Cursors.Hand; //按下鼠标时，将鼠标形状改为手型
            wselected = true;
            p.X = e.X;
            p.Y = e.Y;
        }
        int driftX = 0,
        driftY = 0;
        int mx = 0, my = 0;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (wselected)
            {
                driftX = p.X - e.X;
                driftY = p.Y - e.Y;
                mx = mx - driftX;
                my = my - driftY;
                Bitmap JPEG = new Bitmap(this.pictureBox1.Image);
                Graphics g = pictureBox1.CreateGraphics();
                g.Clear(pictureBox1.BackColor);
                g.DrawImage(JPEG, mx, my);
                p.X = e.X; p.Y = e.Y;
                JPEG.Dispose();
                g.Dispose();//图像移动的距离
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Cursor = Cursors.Default; //松开鼠标时，形状恢复为箭头  
            wselected = false;
            this.pictureBox1.Cursor = Cursors.Default;
        }
    }
}
