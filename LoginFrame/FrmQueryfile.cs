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
    public partial class FrmQueryfile : Form
    {
        public string Sqlname, typeSqlname,T_Id,T_Name;
        public FrmQueryfile(string Sqlname, string typeSqlname,string T_Id,string T_Name)  //初始化组件
        {
            InitializeComponent();
            this.Sqlname = Sqlname;
            this.typeSqlname = typeSqlname;
            this.T_Id = T_Id;
            this.T_Name = T_Name;
        }
       
        private void Btn_Query_Click(object sender, EventArgs e)  //搜索条件
        {
            string sqlstr = " where 1=1 ";
            if (this.textBox2.Text != "")
            {
                sqlstr += "  and U_Id like '%" + this.textBox2.Text + "%'";
            }
            if (this.txt_bookName.Text != "")
            {
                sqlstr += "  and U_Name like '%" + this.txt_bookName.Text + "%'"; 
            }
            if (this.cb_bookType.SelectedValue.ToString() != "0")
            {
                sqlstr += "  and U_PsdType=" + this.cb_bookType.SelectedValue.ToString(); 
            }
            if (this.textBox1.Text != "")
            {
                sqlstr += "  and U_Note like '%" + this.textBox1.Text + "%'"; 
            }
            HWhere.Text = sqlstr;
            BindData("");
            string rows = this.textBox3.Text;
            DAL.dalBook.Update("U_Row", rows, 2);
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
            DataTable dsLog = DAL.dalCustom .GetFile (NowPage, PageSize, out AllPage, out DataCount, HWhere.Text, Sqlname, typeSqlname);//加载数据
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
        private void FrmQueryfile_Load(object sender, EventArgs e)
        {
            //查询所有的图书类别
            this.cb_bookType.DataSource = DAL.dalCustom.getType("FileType", "F_Id", "F_Name");
            this.cb_bookType.DisplayMember = "F_Name";
            this.cb_bookType.ValueMember = "F_Id";

            this.checkBox1.Checked = DAL.dalBook.getBool(2);
            this.textBox3.Text = DAL.dalBook.getString(2);
            this.HPageSize.Text = DAL.dalBook.getString(2);
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
                FrmEditfile frm = new FrmEditfile("update", Sqlname, typeSqlname,T_Id, T_Name,barcode, this); 
                frm.ShowDialog(); 
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
                    if (DAL.dalCustom .DelFile(barcode, Sqlname))
                        MessageBox.Show("图书删除成功!");
                    else
                        MessageBox.Show("图书删除失败!");

                    BindData("refresh");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                DAL.dalBook.Update("U_Check", "1", 2);
            else
                DAL.dalBook.Update("U_Check", "0", 2);
        }
    }
}
