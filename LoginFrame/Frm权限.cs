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
    public partial class Frm权限 : Form
    {
        public Frm权限()
        {
            InitializeComponent();
        }
        public int U_Id, Dep, barcode;
        public string Pos;
        private void Frm权限_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = DAL.dalCustom.getType("U_UserInfo", "U_Id", "U_Name");
            this.comboBox1.DisplayMember = "U_Name";
            this.comboBox1.ValueMember = "U_Id";

            this.comboBox3.Items.Add("总经理");
            this.comboBox3.Items.Add("部门经理");
            this.comboBox3.Items.Add("职员");
            
            this.comboBox2.DataSource = DAL.dalCustom.getType("DepartmentType", "D_Id", "D_Name");
            this.comboBox2.DisplayMember = "D_Name";
            this.comboBox2.ValueMember = "D_Id";
        }
       private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedValue.ToString() == "0")      
            {
                MessageBox.Show("用户未选择!");
                return;
            }
            if (this.comboBox3.Text.ToString() == "")
            {
                MessageBox.Show("职务未选择!");
                return;
            }
            DAL.DU_UserInfo user = new DAL.DU_UserInfo();
            U_Id = int.Parse(this.comboBox1.SelectedValue.ToString());
            Dep = int.Parse(this.comboBox2.SelectedValue.ToString());
            Pos = this.comboBox3.Text;
            if (user.JurisdictionUpdate(Dep,Pos,U_Id))
                MessageBox.Show("权限修改成功!");
            else
                MessageBox.Show("权限修改失败!");                  
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
