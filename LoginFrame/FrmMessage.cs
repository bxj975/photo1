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
    public partial class FrmMessage : Form
    {
        public FrmMessage()
        {
            InitializeComponent();
        }
        private Book book= new Book();
        public String barcode, state, Sqlname, typeSqlname,username;


        public void FrmUserName_getUserName(string UserName)
        {
            this.textBox1.Text = UserName;
        }
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            BindData();
            //if (DAL.dalBook.Bai1EditBook(book,Sqlname))
               // MessageBox.Show("更新成功!");
            //else
                //MessageBox.Show("更新失败!");

            //FrmQueryBook frmQueryBook = (FrmQueryBook)this.Parent;
            
            this.Close(); 
        }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            BindData();
            //if (DAL.dalBook.Bai1AddBook(book,Sqlname))
               // MessageBox.Show("添加成功!");
            //else
               // MessageBox.Show("添加失败!");
            //this.Close();
        }

        private void BindData()
        {    
           
        }
        private void FrmMessage_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = username;
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            FrmUserName frm = new FrmUserName("U_UserInfo");
            frm.getUserName += new GetUserName(FrmUserName_getUserName);
            frm.ShowDialog();
        }
    }
}
