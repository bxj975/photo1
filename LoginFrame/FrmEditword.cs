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
    public partial class FrmEditword : Form
    {
        public FrmEditword(string state, String barcode, FrmQueryWord frmQueryword)
        {
            InitializeComponent();
            this.state = state;
            this.barcode = barcode;
            this.frmQueryword = frmQueryword;
        }
        private Book book= new Book();
        private String state;
        public String barcode;
        private FrmQueryWord frmQueryword;

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if (DAL.dalCustom .EditWord (book))
                MessageBox.Show("更新成功!");
            else
                MessageBox.Show("更新失败!");

            //FrmQueryBook frmQueryBook = (FrmQueryBook)this.Parent;
            frmQueryword.BindData("refresh");

            this.Close(); 
        }

         private void Btn_Add_Click(object sender, EventArgs e)
        {
            BindData();
            if (DAL.dalCustom .AddWord(book))
                MessageBox.Show("添加成功!");
            else
                MessageBox.Show("添加失败!");

            this.Close();
        }
            
        private void BindData()
        {
            if (this.txt_bookName.Text == "")
            {
                MessageBox.Show("单词输入不能为空!");
                this.txt_bookName.Focus();
                return;
            }
            book.bookName = this.txt_bookName.Text; 
            book.Name = this.textBox1.Text;
            book.move = this.textBox2.Text; 
            book.address = this.txt_publish.Text;         
        }

        private void FrmEditword_Load(object sender, EventArgs e)
        {
            //查询所有的图书类别
            if (state != "update")
            {
            }

            book = BLL.bllBook.getSomeBook(barcode);

            this.txt_barcode.ReadOnly = true;
   
            this.txt_bookName.Text = book.bookName;    
        }
    }
}
