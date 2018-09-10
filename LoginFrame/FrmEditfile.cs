using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Model;

namespace LoginFrame
{
    public partial class FrmEditfile : Form
    {
        public FrmEditfile(string state, String Sqlname, string typeSqlname, string T_Id,string T_Name,String barcode, FrmQueryfile frmQueryfile)
        {
            InitializeComponent();
            this.Sqlname = Sqlname;
            this.typeSqlname = typeSqlname;
            this.T_Id = T_Id;
            this.T_Name = T_Name;
            this.barcode = barcode;
            this.state = state;
            this.frmQueryfile = frmQueryfile;
        }
        private Book book= new Book();
        public String barcode, state, Sqlname, typeSqlname,T_Id, T_Name;
        private FrmQueryfile frmQueryfile;
        /*
        public void setBarCode(String barcode)
        {
            this.barcode = barcode;
        }
        */
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            BindData();
            if (DAL.dalCustom .EditFile(book,Sqlname))
                MessageBox.Show("更新成功!");
            else
                MessageBox.Show("更新失败!");

            //FrmQueryBook frmQueryBook = (FrmQueryBook)this.Parent;
            frmQueryfile.BindData("refresh");
            this.Close(); 
        }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            BindData();
            if (DAL.dalCustom .AddFile(book,Sqlname))
                MessageBox.Show("添加成功!");
            else
                MessageBox.Show("添加失败!");
            this.Close();
        }

        private void BindData()
        {    
            if (this.txt_bookName.Text == "")
            {
                MessageBox.Show("名称输入不能为空!");
                this.txt_bookName.Focus();
                return;
            }
            book.bookName = this.txt_bookName.Text; //名称
            book.bookType = Int32.Parse(this.cb_bookType.SelectedValue.ToString()); //类别          
            book.note = this.txt_publish.Text;
            book.publishDate = this.dtp_publishDate.Value;
            //try
            //{
                //book.count = Convert.ToInt32(this.txt_count.Text);  //图书库存
            //}
            //catch
            //{
               // MessageBox.Show("图书库存请输入正确的格式!");
                //this.txt_count.SelectAll();
                //this.txt_count.Focus();
                //return;
           // }
           
        }

        private void btn_bookPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            try
            {
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                openFileDialog1.Filter = "图片（*.jpg;*.bmp;*.gif,*.png）|*.jpg;*.bmp;*.gif;*.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.txt_bookPhoto.Text = openFileDialog1.FileName;
                    pictureBox_bookPhoto.Image = Image.FromFile(txt_bookPhoto.Text);
                    pictureBox_bookPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader bw = new BinaryReader(fs);
                    book.bookPhoto = bw.ReadBytes((int)fs.Length);
                }
            }
            catch
            {
                MessageBox.Show("请选择正确的图片格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void FrmEditfile_Load(object sender, EventArgs e)
        {
            //查询所有的图书类别
            this.cb_bookType.DataSource = DAL.dalCustom.getType(typeSqlname,T_Id,T_Name);
            this.cb_bookType.DisplayMember = "T_Name";
            this.cb_bookType.ValueMember = "T_Id";  
            if (state != "update")
            {
                pictureBox_bookPhoto.Image = Image.FromFile("pic/NoImage.jpg");
                pictureBox_bookPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                FileStream fs = new FileStream("pic/NoImage.jpg", FileMode.Open, FileAccess.Read);
                BinaryReader bw = new BinaryReader(fs);
                book.bookPhoto = bw.ReadBytes((int)fs.Length);
            }
            else
            {
                book = DAL.dalCustom.getSomeFile(barcode,Sqlname);
                this.txt_barcode.Text = book.barcode.ToString();
                this.txt_bookName.Text = book.bookName;        
                this.cb_bookType.SelectedValue = book.bookType.ToString();
                this.txt_publish.Text = book.note;
                this.dtp_publishDate.Value = book.publishDate;
                byte[] bookPhoto = (byte[])(book.bookPhoto);
                MemoryStream ms = new MemoryStream(bookPhoto);
                pictureBox_bookPhoto.Image = Image.FromStream(ms);
            }           
        }
    }
}
