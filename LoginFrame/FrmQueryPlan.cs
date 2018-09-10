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
    public partial class FrmQueryPlan : Form
    {
        public string Sqlname, yearmonth;
        public FrmQueryPlan(string Sqlname, string yearmonth)  //初始化组件
        {
            InitializeComponent();
            this.Sqlname = Sqlname;
            this.yearmonth = yearmonth;
        }
       
        private void Btn_Query_Click(object sender, EventArgs e)  //搜索条件
        {
            string sqlstr = " where 1=1 ";
            if (this.comboBox2 .Text != "")
            {
                sqlstr += "  and U_Month = " + this.comboBox2.Items; 
            }
            if (this.comboBox1.SelectedValue.ToString() != "0")
            {
                sqlstr += "  and U_ClerkType=" + this.comboBox1.SelectedValue.ToString(); 
            }          
            HWhere.Text = sqlstr;
            BindData("");
            string rows = this.textBox3.Text;
            DAL.dalBook.Update("U_Row", rows, 4);
        }

        public void BindData(string strClass)
        {
            string Number = this.textBox3.Text;
            int number;
            if (int.TryParse(Number, out number))
            {
                if (number < 40 && number > 10)
                {
                    this.HPageSize.Text = Number;
                }
            }
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Text);//每页显示行数
            switch (strClass) //下一页
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Text) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Text) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Text);
                    break;
                case "refresh":
                    NowPage = Convert.ToInt32(HNowPage.Text);
                    break;
                default:
                    break;
            }
            DataTable dsLog = DAL.dalCustom.GetPlan(NowPage, PageSize, out AllPage, out DataCount, HWhere.Text, Sqlname);//加载数据
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            this.dataGridView_Book.DataSource = dsLog.DefaultView; 
            PageMes.Text = string.Format("[每页{0}条 第{1}页／共{2}页   共{3}条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Text = Convert.ToString(NowPage++);//?++
            HAllPage.Text = AllPage.ToString();

            if (dsLog.Rows.Count > 0)
            {
                this.Btn_Update.Enabled = true;
                this.Btn_Del.Enabled = true;
            }
            else
            {
                this.Btn_Update.Enabled = false;
                this.Btn_Del.Enabled = false;
            }
        }

        /*开始加载窗体后*/
        private void FrmQueryPlan_Load(object sender, EventArgs e)
        {
            if (yearmonth == "year")
            {
                this.label3.Visible = false;
                this.comboBox2.Visible = false;
            }
            if (Sqlname == "U_AllPlan")
            {
                this.label2.Visible = false;
                this.comboBox1.Visible = false;
                if (yearmonth == "year")
                    this.Text = "公司年度计划查询";
                else
                    this.Text = "公司月度计划查询";
            }
            if (Sqlname == "U_DepPlan")
            {
                if (yearmonth == "year")
                    this.Text = "部门年度计划查询";
                else
                    this.Text = "部门月度计划查询";
            }
            if (Sqlname == "U_PerPlan")
            {
                if (yearmonth == "year")
                    this.Text = "个人年度计划查询";
                else
                    this.Text = "个人月度计划查询";
            }

            this.checkBox1.Checked = DAL.dalBook.getBool(4);
            this.textBox3.Text = DAL.dalBook.getString(4);
            this.HPageSize.Text = DAL.dalBook.getString(4);
            if (checkBox1.Checked)
                BindData("");
        }
        private void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }

        private void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }

        private void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }

        private void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.BaseCollection)(dataGridView_Book.SelectedRows)).Count != 1)
            {
                MessageBox.Show("请选择一条数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                String barcode = this.dataGridView_Book.CurrentRow.Cells[0].Value.ToString();
                switch (Sqlname)
                {
                    case "U_AllPlan":
                        FrmPlan frm1 = new FrmPlan("update", yearmonth, barcode);
                        frm1.ShowDialog();
                        break;
                    case "U_DepPlan":
                        FrmDepPlan frm2 = new FrmDepPlan("update", yearmonth, barcode);
                        frm2.ShowDialog();
                        break;
                    case "U_PerPlan":
                        FrmPerPlan frm3 = new FrmPerPlan("update", yearmonth, barcode);
                        frm3.ShowDialog();
                        break;
                }
            }
        }
        private void Btn_Del_Click(object sender, EventArgs e)
        { 
            if (((System.Windows.Forms.BaseCollection)(dataGridView_Book.SelectedRows)).Count != 1)
            {
                MessageBox.Show("请选择一条数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {  
                if ( MessageBox.Show("确定删除吗?", "删除提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    String barcode = this.dataGridView_Book.CurrentRow.Cells[0].Value.ToString();
                    string str = "delect from " + Sqlname + " where U_Id=" + barcode;
                    if ((DAL.DBHelp.ExecuteNonQuery(str, null)) > 0)
                        MessageBox.Show("删除成功!");
                    else
                        MessageBox.Show("删除失败!");

                    BindData("refresh");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPlan frm = new FrmPlan(null, null, null);
            frm.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                DAL.dalBook.Update("U_Check", "1", 4);
            else
                DAL.dalBook.Update("U_Check", "0", 4);
        }
       
    }
}
