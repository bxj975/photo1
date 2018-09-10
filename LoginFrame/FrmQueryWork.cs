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
    public partial class FrmQueryWork : Form
    {
        public FrmQueryWork()  //初始化组件
        {
            InitializeComponent();
        }
        public String barcode;
        private void dtp_publishDate_ValueChanged(object sender, EventArgs e)  //选择日期
        {
            this.txt_publishDate.Text = this.dtp_publishDate.Value.ToShortDateString();
        } 
        private void txt_publishDate_DoubleClick(object sender, EventArgs e)  //双击日期框 清空
        {
            this.txt_publishDate.Text = "";
        }

        private void Btn_Query_Click(object sender, EventArgs e)  //搜索条件
        {
            string Position=LoginRoler.U_Position;
            string sqlstr = " where 1=1 ";
           
            if (this.comboBox2.SelectedValue.ToString() != "0")
            {
                sqlstr += "  and U_ClerkType=" + this.comboBox2.SelectedValue.ToString();
            }
            if (this.txt_publishDate.Text != "")
            {
                sqlstr += "  and convert(char(11),U_LoginTime,20) ='" + this.txt_publishDate.Text + "'"; 
            }
            if (Position != "") 
            {
                switch (Position)
                {
                    case "总经理":
                        break;
                    case "部门经理":
                        sqlstr += "  and U_ClerkType in (select U_Id from U_UserInfo where U_department=" + LoginRoler.U_DpaType;
                        break;
                    default:
                        sqlstr += "  and U_ClerkType =" + LoginRoler.U_Id;
                        break;
                }
            }
            else 
            {
                sqlstr += "  and U_ClerkType =9999";
            }
            if (this.checkBox1.Checked)
            {
                sqlstr += "  and U_Check=0";
            }
           
            HWhere.Text = sqlstr;
            BindData("");
            string rows = this.textBox3.Text;
            DAL.dalBook.Update("U_Row", rows, 7);
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
            DataTable dsLog = DAL.dalCustom .Getwork (NowPage, PageSize, out AllPage, out DataCount, HWhere.Text);
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

        /*开始加载窗体后*/
        private void FrmQueryWork_Load(object sender, EventArgs e)
        {
            this.comboBox2.DataSource = DAL.dalCustom.getType("U_UserInfo", "U_Id", "U_Name");
            this.comboBox2.DisplayMember = "U_Name";
            this.comboBox2.ValueMember = "U_Id";

            this.checkBox1.Checked = DAL.dalBook.getBool(7);
            this.textBox3.Text = DAL.dalBook.getString(7);
            this.HPageSize.Text = DAL.dalBook.getString(7);
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
                FrmWork frm = new FrmWork("update",null,barcode);
                frm.ShowDialog();
            }
        }

        private void Btn_Del_Click(object sender, EventArgs e)
        {
            删除ToolStripMenuItem_Click(sender, e);
        }

        private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            barcode = "";                                                  //多行选择
            for (int i = 0; i < dataGridView_Book.SelectedRows.Count; i++)
            {
                if (i != dataGridView_Book.SelectedRows.Count - 1)
                    barcode += dataGridView_Book.Rows[i].Cells[0].Value.ToString() + ",";
                else
                    barcode += dataGridView_Book.Rows[i].Cells[0].Value.ToString();
            }
          
            string sql = "";
            //string[] ids = barcode.Split(',');
            //for (int i = 0; i < ids.Length; i++)
            //{
           //     if (i != ids.Length - 1)
           //         sql += ids[i] + ",";
           //     else
            //        sql += ids[i];
           // }
            sql = "update U_Work set U_Check=" + LoginRoler.U_Id + "  where U_Id in (" + barcode + ")";
            //return ((DAL.DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
            if ((DAL.DBHelp.ExecuteNonQuery(sql, null)) > 0)
                        MessageBox.Show("审核成功!");
            else
                        MessageBox.Show("审核失败!");
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            barcode = "";                                                  //多行选择
            for (int i = 0; i < dataGridView_Book.SelectedRows.Count; i++)
            {
                if (i != dataGridView_Book.SelectedRows.Count - 1)
                    barcode += dataGridView_Book.Rows[i].Cells[0].Value.ToString() + ",";
                else
                    barcode += dataGridView_Book.Rows[i].Cells[0].Value.ToString();
            }
          
            string sql = "";
            string[] ids = barcode.Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                if (i != ids.Length - 1)
                    sql += ids[i] + ",";
                else
                    sql += ids[i];
            }
            sql = "delete U_Work  where U_Id in (" + sql + ")";
            //return ((DAL.DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
            if ((DAL.DBHelp.ExecuteNonQuery(sql, null)) > 0)
                        MessageBox.Show("删除成功!");
            else
                        MessageBox.Show("删除失败!");
            BindData("refresh");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FrmUserName frm=new FrmUserName ("U_Custom");
             frm.ShowDialog();
        
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                DAL.dalBook.Update("U_Check", "1", 7);
            else
                DAL.dalBook.Update("U_Check", "0", 7);
        }

    }
}
