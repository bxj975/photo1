using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginFrame
{
    public partial class FrmAddType : Form
    {
        public FrmAddType()
        {
            InitializeComponent();
        }
        string State, barcode, Sqlname, T_Id, T_Name;
        private Frm客户分类 frm;
        public void Message(string State, string barcode, string Sqlname, string T_Id, string T_Name, Frm客户分类 frm)
        {
            this.State = State;
            this.barcode = barcode;
            this.Sqlname = Sqlname;
            this.T_Id = T_Id;
            this.T_Name = T_Name;
            this.frm = frm;
        }
        private void FrmAddType_Load(object sender, EventArgs e)
        {
            if (State == "add")
            {
                button1.Visible = false;
            }
            else 
            {
                Btn_Add.Visible = false;
                this.txt_bookTypeName.Text = DAL.dalCustom .getTypeName(barcode, Sqlname,T_Id, T_Name);
            }
            
            //dataBind();
            //this.dataGridView1.ReadOnly = true;
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (this.txt_bookTypeName.Text == "")
            {
                MessageBox.Show("分类输入不能为空!");
                this.txt_bookTypeName.Focus();
                return;
            }
            string TypeName = this.txt_bookTypeName.Text;
            if (DAL.dalCustom .createTypeName (TypeName, Sqlname,  T_Name) > 0)
                MessageBox.Show("分类添加成功!");
            else
                MessageBox.Show("分类添加失败!");         
            frm.dataBind();
            this.Close();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txt_bookTypeName.Text == "")
            {
                MessageBox.Show("分类输入不能为空!");
                this.txt_bookTypeName.Focus();
                return;
            }
            string TypeName = this.txt_bookTypeName.Text;
            if (DAL.dalCustom .udateTypeName(TypeName,Sqlname,T_Id,T_Name,barcode) > 0)
                MessageBox.Show("分类修改成功!");
            else
                MessageBox.Show("分类修改失败!");
            frm.dataBind();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
