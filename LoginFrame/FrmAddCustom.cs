using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Model;

namespace LoginFrame
{
    public partial class FrmAddCustom : Form
    {
        public FrmAddCustom(string state,String barcode,FrmQueryCustom frmQueryBook)
        {
            InitializeComponent();
            this.state = state;
            this.barcode = barcode;
            this.frmQueryBook = frmQueryBook;
        }
        private string state, barcode;
        private Book book = new Book();
        private FrmQueryCustom frmQueryBook;   
      
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

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("名称输入不能为空!");
                return;
            }
            if (this.cb_bookType.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("类型请选择!");
                return;
            }
            if (this.comboBox1.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("地区请选择!");
                return;
            }
            if (this.comboBox2.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("所属人请选择!");
                return;
            }
            BindData();
            if (DAL.dalBook.AddBook(book))
                MessageBox.Show("添加成功!");
            else
                MessageBox.Show("添加失败!");

            this.Close(); 
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("名称输入不能为空!");
                return;
            }
            if (this.cb_bookType.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("类型请选择!");
                return;
            }
            if (this.comboBox1.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("地区请选择!");
                return;
            }
            if (this.comboBox2.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("所属人请选择!");
                return;
            }
            BindData();
            this.Btn_Update.Visible = true ;
            this.button2.Visible = false;
            if (BLL.bllBook.EditBook(book))
                MessageBox.Show("更新成功!");
            else
                MessageBox.Show("更新失败!");
            //FrmQueryBook frmQueryBook = (FrmQueryBook)this.Parent;
            frmQueryBook.BindData("refresh");
            this.Close();
        }

        private void BindData()
        {
            book.bookName = this.textBox1.Text; //名称
            book.Name = this.textBox3.Text; //联系人
            book.bookType = Int32.Parse(this.cb_bookType.SelectedValue.ToString()); //
            book.area = Int32.Parse(this.comboBox1.SelectedValue.ToString()); //地区
            book.clerk = Int32.Parse(this.comboBox2.SelectedValue.ToString()); //归属人
            book.tele = this.txt_price.Text;  //
            //if (this.dtp_publishDate == null)
            //{
             //   this.dtp_publishDate.Value  = DateTime.Now ;
            //}
            book.publishDate = this.dtp_publishDate.Value;
            book.move = this.textBox4.Text;  //
            book.email = this.txt_count.Text;  //
            book.qq = this.textBox5.Text;  //
            book.weixin = this.textBox2.Text;  //
            book.www = this.textBox6.Text;  //
            book.address = this.txt_publish.Text;  //
            book.note = this.textBox7.Text;  //
            /*try
            {
                book.price = Convert.ToSingle(this.txt_price.Text);  //图书价格
            }
            catch
            {
                MessageBox.Show("图书价格请输入正确的格式!");
                this.txt_price.SelectAll();
                this.txt_price.Focus();
                return;
            }
            try
            {
                book.count = Convert.ToInt32(this.txt_count.Text);  //图书库存
            }
            catch
            {
                MessageBox.Show("图书库存请输入正确的格式!");
                this.txt_count.SelectAll();
                this.txt_count.Focus();
                return;
            }*/
            
        }

        private void FrmAddBook_Load(object sender, EventArgs e)
        {
            this.comboBox2.DataSource = DAL.dalCustom.getType("U_UserInfo", "U_Id", "U_Name");
            this.comboBox2.DisplayMember = "U_Name";
            this.comboBox2.ValueMember = "U_Id";

            this.cb_bookType.DataSource = DAL.dalCustom.getType("CustomType", "C_Id", "C_Name");
            this.cb_bookType.DisplayMember = "C_Name";
            this.cb_bookType.ValueMember = "C_Id";

            this.comboBox1.DataSource = DAL.dalCustom.getType("areatype", "A_Id", "A_Name");
            this.comboBox1.DisplayMember = "A_Name";
            this.comboBox1.ValueMember = "A_Id";

            if (state != "update")
            {
                pictureBox_bookPhoto.Image = Image.FromFile("pic/NoImage.jpg");
                pictureBox_bookPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                FileStream fs = new FileStream("pic/NoImage.jpg", FileMode.Open, FileAccess.Read);
                BinaryReader bw = new BinaryReader(fs);
                book.bookPhoto = bw.ReadBytes((int)fs.Length);
                this.button2.Visible = false;
                this.Btn_Update.Visible = false;
            }
            else 
            {
                this.textBox1.ReadOnly = true;
                this.textBox3.ReadOnly = true;
                this.cb_bookType.Enabled = false;
                this.comboBox1.Enabled = false;
                this.comboBox2.Enabled = false;
                this.txt_price.ReadOnly = true;
                this.dtp_publishDate.Enabled = false;
                textBox4.ReadOnly = true;
                this.txt_count.ReadOnly = true;
                this.textBox5.ReadOnly = true;
                this.textBox2.ReadOnly = true;
                this.textBox6.ReadOnly = true;
                this.txt_publish.ReadOnly = true;
                this.textBox7.ReadOnly = true;
                
                this.Btn_Update.Visible = false;
                this.Btn_Add.Visible = false;
                
                book = BLL.bllBook.getSomeBook(barcode);
                this.txt_barcode.Text = book.barcode.ToString();
                this.textBox1.Text = book.bookName;
                this.textBox3.Text = book.Name;
                this.cb_bookType.SelectedValue = book.bookType.ToString();
                this.comboBox1.SelectedValue = book.area.ToString();
                this.comboBox2.SelectedValue = book.clerk.ToString();
                this.txt_price.Text = book.tele;
                this.textBox4.Text = book.move;
                this.txt_count.Text = book.email;
                this.textBox5.Text = book.qq;
                this.textBox2.Text = book.weixin;
                this.textBox6.Text = book.www;
                this.txt_publish.Text = book.address;
                this.textBox7.Text = book.note;
                this.dtp_publishDate.Value = book.publishDate;
                byte[] bookPhoto = (byte[])(book.bookPhoto);
                MemoryStream ms = new MemoryStream(bookPhoto);
                pictureBox_bookPhoto.Image = Image.FromStream(ms);
             }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = false;
            this.textBox3.ReadOnly = false;
            this.cb_bookType.Enabled  = true ;
            this.comboBox1.Enabled = true;
            this.comboBox2.Enabled = true;
            this.txt_price.ReadOnly = false;
            this.dtp_publishDate.Enabled = true;
            textBox4.ReadOnly = false;
            this.txt_count.ReadOnly = false;
            this.textBox5.ReadOnly = false;
            this.textBox2.ReadOnly = false;
            this.textBox6.ReadOnly = false;
            this.txt_publish.ReadOnly = false;
            this.textBox7.ReadOnly = false;
            this.Btn_Update.Visible = true;
            this.button2.Visible  = false;
        }
    }
}
