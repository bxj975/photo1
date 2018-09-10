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
    public partial class FrmPerPlan : Form
    {
        public FrmPerPlan(string state, string yearmonth, string barcode)
        {
            InitializeComponent();
            this.state = state;
            this.yearmonth = yearmonth;
        }
        int A, B, C, D, E, F, G, H, I, J, ClerkType, Mon, Type;
        public String state, yearmonth, barcode;
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            BindData();
            string SqlStr = "update U_PerPlan set U_A=" + A + ",U_B='" + B + "',U_C=" + C + ",U_D=" + D + ",U_E=" + E + ", U_F=" + F + ",, U_G=" + G + ", U_H=" + H + ", U_I=" + I + ", U_J=" + J + "  where U_Id=" + barcode;
            if (DAL.DBHelp.ExecuteNonQuery(SqlStr) > 0)
                MessageBox.Show("更新成功!");
            else
                MessageBox.Show("更新失败!");
            this.Close();
        }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            BindData();
            if (yearmonth == "year")
            {
                Type = 9;
                Mon = 0;
            }
            else
            {
                Type = 1;
                Mon = (int)this.comboBox2.SelectedItem;
            }
            string SqlStr = "insert into U_PerPlan(U_A,U_B,U_C,U_D,U_E,U_F,U_G,U_H,U_I,U_J,U_Type,U_Month,U_ClerkType,U_LoginTime)  values(" + A + ",'" + B + "'," + C + "," + D + "," + E + "," + F + "," + G + "," + H + "," + I + "," + J + "," + Type + "," + Mon + "," + ClerkType + ",getdate())";
            if (DAL.DBHelp.ExecuteNonQuery(SqlStr) > 0)
                MessageBox.Show("设定成功!");
            else
                MessageBox.Show("设定失败!");
            this.Close();
        }

        private void BindData()
        {
            A = int.Parse(this.textBox11.Text.ToString());
            B = int.Parse(this.textBox12.Text.ToString());
            C = int.Parse(this.textBox13.Text.ToString());
            D = int.Parse(this.textBox14.Text.ToString());
            E = int.Parse(this.textBox15.Text.ToString());
            F = int.Parse(this.textBox16.Text.ToString());
            G = int.Parse(this.textBox17.Text.ToString());
            H = int.Parse(this.textBox18.Text.ToString());
            I = int.Parse(this.textBox19.Text.ToString());
            J = int.Parse(this.textBox20.Text.ToString());
            ClerkType=(int)this.comboBox1.SelectedValue ;
        }

        private void FrmPerPlan_Load(object sender, EventArgs e)
        {
            string sqlStr1 = "select * from ModeType";
            DataTable MTable = DAL.DBHelp.DataTable(sqlStr1);
            string[] Mode = new string[MTable.Rows.Count];
            for (int i = 0; i < MTable.Rows.Count; i++)
            {
                Mode[i] = MTable.Rows[i][1].ToString();
            }
            if (MTable.Rows.Count > 0)
                this.textBox1.Text = Mode[0];
            if (MTable.Rows.Count > 1)
                this.textBox2.Text = Mode[1];
            if (MTable.Rows.Count > 2)
                this.textBox3.Text = Mode[2];
            if (MTable.Rows.Count > 3)
                this.textBox4.Text = Mode[3];
            if (MTable.Rows.Count > 4)
                this.textBox5.Text = Mode[4];
            if (MTable.Rows.Count > 5)
                this.textBox6.Text = Mode[5];
            if (MTable.Rows.Count > 6)
                this.textBox7.Text = Mode[6];
            if (MTable.Rows.Count > 7)
                this.textBox8.Text = Mode[7];

            if (state == "update")
            {
                string str = "select * from U_PerPlan where U_Id=" + barcode;
                DataTable Dt = DAL.DBHelp.DataTable(str);
                this.textBox20.Text = Dt.Rows[0]["U_J"].ToString();
                this.textBox19.Text = Dt.Rows[0]["U_I"].ToString();
                this.textBox18.Text = Dt.Rows[0]["U_H"].ToString();
                this.textBox17.Text = Dt.Rows[0]["U_G"].ToString();
                this.textBox16.Text = Dt.Rows[0]["U_F"].ToString();
                this.textBox15.Text = Dt.Rows[0]["U_E"].ToString();
                this.textBox14.Text = Dt.Rows[0]["U_D"].ToString();
                this.textBox13.Text = Dt.Rows[0]["U_C"].ToString();
                this.textBox12.Text = Dt.Rows[0]["U_B"].ToString();
                this.textBox11.Text = Dt.Rows[0]["U_A"].ToString();
                this.button1.Visible = false;
                this.comboBox2.Enabled = false;
                this.comboBox1.Enabled = false;
                this.comboBox1.SelectedValue = Dt.Rows[0]["U_ClerkType"].ToString();
                if (yearmonth != "year")
                    this.comboBox2.SelectedValue = Dt.Rows[0]["U_Month"].ToString();

            }
            else
            {
                this.Btn_Update.Visible = false;
                this.button1.Visible = false;
            }
            if (yearmonth == "year")
            {
                this.label2.Visible = false;
                this.comboBox2.Visible = false;
                this.Text = "个人年度计划";
            }
            else
                this.Text = "个人月度计划";

            this.comboBox2.DataSource = DAL.dalCustom.getType("U_UserInfo", "U_Id", "U_Name");
            this.comboBox2.DisplayMember = "U_Name";
            this.comboBox2.ValueMember = "U_Id";

        }

    }
}
