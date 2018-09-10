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
    public partial class FrmQueryWord : Form
    {
        public FrmQueryWord()  //初始化组件
        {
            InitializeComponent();
        }

        private void Btn_Query_Click(object sender, EventArgs e)  //搜索条件
        {
            string sqlstr = " where 1=1 ";
            if (this.textBox1.Text != "")
            {
                sqlstr += "  and U_Note like '%" + this.textBox1.Text + "%'";
            }
            if (this.textBox2.Text != "")
            {
                sqlstr += "  and U_Pronounce like '%" + this.textBox2.Text + "%'";
            }
            if (this.txt_bookName.Text != "")
            {
                sqlstr += "  and U_Chinese like '%" + this.txt_bookName.Text + "%'"; 
            }
            if (this.txt_barcode.Text != "")
            {
                sqlstr += "  and U_Word like '%" + this.txt_barcode.Text + "%'"; 
            }
            HWhere.Text = sqlstr;
            BindData("");
            string rows = this.textBox3.Text;
            DAL.dalBook.Update("U_Row", rows, 6);
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
            int PageSize = Convert.ToInt32(HPageSize.Text);
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
            DataTable dsLog = DAL.dalCustom .GetWord (NowPage, PageSize, out AllPage, out DataCount, HWhere.Text);
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
            HNowPage.Text = Convert.ToString(NowPage++);
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
                FrmEditword frmEditword = new FrmEditword("update", barcode, this); 
                frmEditword.ShowDialog(); 
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
                    if (DAL.dalCustom .DelWrod (barcode))
                        MessageBox.Show("删除成功!");
                    else
                        MessageBox.Show("删除失败!");

                    BindData("refresh");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                DAL.dalBook.Update("U_Check", "1", 6);
            else
                DAL.dalBook.Update("U_Check", "0", 6);
        }

        private void FrmQueryWord_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = DAL.dalBook.getBool(6);
            this.textBox3.Text = DAL.dalBook.getString(6);
            this.HPageSize.Text = DAL.dalBook.getString(6);
            if (checkBox1.Checked)
                BindData("");
        }
    }
}
