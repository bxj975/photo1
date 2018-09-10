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
    public partial class FrmWork : Form
    {
        public FrmWork(string state, string CustomName, String U_Id)
        {
            InitializeComponent();
            this.state = state;
            this.CustomName = CustomName;
            this.U_Id = U_Id;
        }
        string Note, CustomName, state, Sqlname, typeSqlname, U_Id;
        int Mode, Rate, Attention, Clerk;
        DateTime Login, Remind;
        decimal Amount;
        private Book book = new Book();
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            BindData();
            string SqlStr = "update U_work set U_ModeType=" + Mode + ",U_Note='" + Note + "',U_RateType=" + Rate + ",U_ClerkType=" + Clerk + ",U_AttentionType=" + Attention + ",U_RemindTime=" + Remind + ", U_LoginTime=" + Login + ",U_Amount=" + Amount + "  where U_Id=" + U_Id;
            if (DAL.DBHelp.ExecuteNonQuery(SqlStr) > 0)
                MessageBox.Show("更新成功!");
            else
                MessageBox.Show("更新失败!");
            this.Close();
        }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            BindData();
            string SqlStr ="insert into U_work(U_ModeType,U_Note,U_RateType,U_ClerkType,U_AttentionType,U_Custom,U_RemindTime,U_LoginTime,U_Amount)  values(" + Mode + ",'" + Note + "'," + Rate + "," + Clerk + "," + Attention + "," + int.Parse(CustomName) + "," + Remind + "," + Login + "," + Amount + ")";
            if (DAL.DBHelp.ExecuteNonQuery(SqlStr) > 0)
                MessageBox.Show("添加成功!");
            else
                MessageBox.Show("添加失败!");
            this.Close();
        }

        private void BindData()
        {
            Mode = Int32.Parse(this.comboBox1.SelectedValue.ToString()); //名称
            Rate = Int32.Parse(this.comboBox2.SelectedValue.ToString());
            Attention = Int32.Parse(this.comboBox3.SelectedValue.ToString());
            Clerk = LoginRoler.U_Id;
            Note = txt_publish.Text;
            Login = this.dtp_publishDate.Value;
            Remind = this.dateTimePicker1.Value;
            Amount = Decimal.Parse(this.textBox9.Text);
        }

        private void FrmWork_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = DAL.dalCustom.getType("ModeType", "M_Id", "M_Name");
            this.comboBox1.DisplayMember = "M_Name";
            this.comboBox1.ValueMember = "M_Id";

            this.comboBox2.DataSource = DAL.dalCustom.getType("RateType", "R_Id", "R_Name");
            this.comboBox2.DisplayMember = "R_Name";
            this.comboBox2.ValueMember = "R_Id";

            this.comboBox3.DataSource = DAL.dalCustom.getType("AttentionType", "Att_Id", "Att_Name");
            this.comboBox3.DisplayMember = "Att_Name";
            this.comboBox3.ValueMember = "Att_Id";

            this.comboBox4.DataSource = DAL.dalCustom.getType("U_UserInfo", "U_Id", "U_Name");
            this.comboBox4.DisplayMember = "U_Name";
            this.comboBox4.ValueMember = "U_Id";

            if (state == "Add")
            {
                this.Btn_Update.Visible = false;
                this.button3.Visible = false;
                DataTable Dt = DAL.dalCustom.getCustom(CustomName);
                this.textBox8.Text = Dt.Rows[0]["U_Name"].ToString();
                this.textBox7.Text = Dt.Rows[0]["U_Address"].ToString();
                this.textBox6.Text = Dt.Rows[0]["U_Email"].ToString();
                this.textBox5.Text = Dt.Rows[0]["U_QQ"].ToString();
                this.textBox4.Text = Dt.Rows[0]["U_Weixin"].ToString();
                this.textBox3.Text = Dt.Rows[0]["U_RelName"].ToString();
                this.textBox2.Text = Dt.Rows[0]["U_MoveTele"].ToString();
                this.textBox1.Text = Dt.Rows[0]["U_Telephone"].ToString();
                this.comboBox4.SelectedValue = LoginRoler.U_Id;
            }
            else
            {
                this.button1.Visible = false;
                this.Btn_Update.Visible = false;
                string SqlStr = "select * from U_work  where U_Id=" + U_Id;
                DataTable dt = DAL.DBHelp.DataTable(SqlStr);
                this.comboBox1.SelectedValue = dt.Rows[0]["U_ModeType"].ToString(); //名称
                this.comboBox2.SelectedValue = dt.Rows[0]["U_RateType"].ToString();
                this.comboBox3.SelectedValue = dt.Rows[0]["U_AttentionType"].ToString();
                this.comboBox4.SelectedValue = dt.Rows[0]["U_ClerkType"].ToString();
                this.txt_publish.Text = dt.Rows[0]["U_Note"].ToString();
                this.dtp_publishDate.Value = (DateTime)dt.Rows[0]["U_LoginTime"];
                this.dateTimePicker1.Value = (DateTime)dt.Rows[0]["U_RemindTime"];
                this.textBox9.Text = dt.Rows[0]["U_Amount"].ToString();

                DataTable Dt = DAL.dalCustom.getCustom(dt.Rows[0]["U_Custom"].ToString());
                this.textBox8.Text = Dt.Rows[0]["U_Name"].ToString();
                this.textBox7.Text = Dt.Rows[0]["U_Address"].ToString();
                this.textBox6.Text = Dt.Rows[0]["U_Email"].ToString();
                this.textBox5.Text = Dt.Rows[0]["U_QQ"].ToString();
                this.textBox4.Text = Dt.Rows[0]["U_Weixin"].ToString();
                this.textBox3.Text = Dt.Rows[0]["U_RelName"].ToString();
                this.textBox2.Text = Dt.Rows[0]["U_MoveTele"].ToString();
                this.textBox1.Text = Dt.Rows[0]["U_Telephone"].ToString();

                this.comboBox1.Enabled = false;
                this.comboBox2.Enabled = false;
                this.comboBox3.Enabled = false;
                this.comboBox4.Enabled = false;
                this.txt_publish.Enabled = false;
                this.dtp_publishDate.Enabled = false;
                this.dateTimePicker1.Enabled = false;
                this.textBox9.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Btn_Update.Visible = true ;
            this.button3.Visible = false;

            this.comboBox1.Enabled = true;
            this.comboBox2.Enabled = true;
            this.comboBox3.Enabled = true;
            this.comboBox4.Enabled = true;
            this.txt_publish.Enabled = true;
            this.dtp_publishDate.Enabled = true;
            this.dateTimePicker1.Enabled = true;
            this.textBox9.Enabled = true;
        }
    }
}
