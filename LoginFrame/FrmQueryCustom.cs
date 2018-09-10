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
    public partial class FrmQueryCustom : Form
    {
        DataTable dsLog;
        public FrmQueryCustom()  //初始化组件
        {
            InitializeComponent();
        }
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
            string Position = LoginRoler.U_Position;
            string sqlstr = " where 1=1 ";
            if (this.textBox1.Text != "")
            {
                sqlstr += "  and U_Id like '%" + this.textBox1.Text + "%'";
            }
            if (this.txt_bookName.Text != "")
            {
                sqlstr += "  and U_Name like '%" + this.txt_bookName.Text + "%'";
            }
            if (this.cb_bookType.SelectedValue.ToString() != "0")
            {
                sqlstr += "  and U_PsdType=" + this.cb_bookType.SelectedValue.ToString();
            }
            if (this.comboBox1.SelectedValue.ToString() != "0")
            {
                sqlstr += "  and U_areaType=" + this.comboBox1.SelectedValue.ToString();
            }
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
            HWhere.Text = sqlstr;
            BindData("");

            string rows = this.textBox2.Text;
            DAL.dalBook.Update("U_Row", rows, 1);
        }
       
        public void BindData(string strClass)
        {
            string Number = this.textBox2.Text;
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
            dsLog = BLL.bllBook.GetBook(NowPage, PageSize, out AllPage, out DataCount, HWhere.Text);
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
        private void FrmQueryBook_Load(object sender, EventArgs e)
        {
            this.comboBox2.DataSource = DAL.dalCustom.getType("U_UserInfo", "U_Id", "U_Name");
            this.comboBox2.DisplayMember = "U_Name";
            this.comboBox2.ValueMember = "U_Id";

            this.cb_bookType.DataSource = DAL.dalCustom.getType("CustomType","C_Id","C_Name");
            this.cb_bookType.DisplayMember = "C_Name";
            this.cb_bookType.ValueMember = "C_Id";

            this.comboBox1.DataSource = DAL.dalCustom.getType("areatype", "A_Id", "A_Name");
            this.comboBox1.DisplayMember = "A_Name";
            this.comboBox1.ValueMember = "A_Id";

            this.checkBox1.Checked = DAL.dalBook.getBool(1);
            this.textBox2.Text = DAL.dalBook.getString(1);
            this.HPageSize.Text = DAL.dalBook.getString(1);
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
                FrmAddCustom frmAddBook = new FrmAddCustom("update", barcode, this);
                frmAddBook.ShowDialog();
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
                if (MessageBox.Show("删除吗?", "删除提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    String barcode = this.dataGridView_Book.CurrentRow.Cells[0].Value.ToString();
                    if (BLL.bllBook.DelBook(barcode))
                        MessageBox.Show("删除成功!");
                    else
                        MessageBox.Show("删除失败!");

                    BindData("refresh");
                }
            }
        }

        private void 联系客户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.BaseCollection)(dataGridView_Book.SelectedRows)).Count != 1)
            {
                MessageBox.Show("请选择一条数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                String barcode = this.dataGridView_Book.CurrentRow.Cells[0].Value.ToString();
                FrmWork frm = new FrmWork("Add", barcode, null);
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            联系客户ToolStripMenuItem_Click(sender, e);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmAddCustom frm = new FrmAddCustom(null, null, null);
            frm.ShowDialog();
            /*string path="c:/ee.xls";    //测试
            DAL.ExcelIO excel=new DAL.ExcelIO() ;
            DataTable dsLog = excel.ImportExcel(path);
            this.dataGridView_Book.DataSource = dsLog.DefaultView;*/
        }

        private void QQ已发送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string barcode = "";                                                  //多行选择
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
                {
                    sql = "insert into U_Work(U_Custom,U_ModeType,U_LoginTime) Values(" + ids[i] + ",4,GETDATE()";
                    DAL.DBHelp.ExecuteNonQuery(sql, null);
                }
                else
                {
                    sql = "insert into U_Work(U_Custom,U_ModeType,U_LoginTime) Values(" + ids[i] + ",4,GETDATE()";
                    if ((DAL.DBHelp.ExecuteNonQuery(sql, null)) > 0)
                        MessageBox.Show("操作成功!");
                    else
                        MessageBox.Show("操作失败!");
                }
            }
            //return ((DAL.DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }

        private void email已发送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string barcode = "";                                                  //多行选择
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
                {
                    sql = "insert into U_Work(U_Custom,U_ModeType,U_ClerkType,U_LoginTime) Values(" + ids[i] + ",4," + LoginRoler.U_Id + ",GETDATE()";
                    DAL.DBHelp.ExecuteNonQuery(sql, null);
                }
                else
                {
                    sql = "insert into U_Work(U_Custom,U_ModeType,U_ClerkType,U_LoginTime) Values(" + ids[i] + ",4," + LoginRoler.U_Id + ",GETDATE()";
                    if ((DAL.DBHelp.ExecuteNonQuery(sql, null)) > 0)
                        MessageBox.Show("操作成功!");
                    else
                        MessageBox.Show("操作失败!");
                }
            }
        }


        private void 微信已发送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string barcode = "";                                                  //多行选择
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
                {
                    sql = "insert into U_Work(U_Custom,U_ModeType,U_ClerkType,U_LoginTime) Values(" + ids[i] + ",4," + LoginRoler.U_Id + ",GETDATE()";
                    DAL.DBHelp.ExecuteNonQuery(sql, null);
                }
                else
                {
                    sql = "insert into U_Work(U_Custom,U_ModeType,U_ClerkType,U_LoginTime) Values(" + ids[i] + ",4," + LoginRoler.U_Id + ",GETDATE()";
                    if ((DAL.DBHelp.ExecuteNonQuery(sql, null)) > 0)
                        MessageBox.Show("操作成功!");
                    else
                        MessageBox.Show("操作失败!");
                }
            }
        }

        private void 派单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string barcode = "";                                                  //多行选择
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
                {
                    sql = "insert into U_Work(U_Custom,U_ModeType,U_ClerkType,U_LoginTime) Values(" + ids[i] + ",4," + LoginRoler.U_Id + ",GETDATE()";
                    DAL.DBHelp.ExecuteNonQuery(sql, null);
                }
                else
                {
                    sql = "insert into U_Work(U_Custom,U_ModeType,U_ClerkType,U_LoginTime) Values(" + ids[i] + ",4," + LoginRoler.U_Id + ",GETDATE()";
                    if ((DAL.DBHelp.ExecuteNonQuery(sql, null)) > 0)
                        MessageBox.Show("操作成功!");
                    else
                        MessageBox.Show("操作失败!");
                }
            }
        }

        private void 参加活动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string barcode = "";                                                  //多行选择
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
                {
                    sql = "insert into U_Work(U_Custom,U_ModeType,U_ClerkType,U_LoginTime) Values(" + ids[i] + ",4," + LoginRoler.U_Id + ",GETDATE()";
                    DAL.DBHelp.ExecuteNonQuery(sql, null);
                }
                else
                {
                    sql = "insert into U_Work(U_Custom,U_ModeType,U_ClerkType,U_LoginTime) Values(" + ids[i] + ",4," + LoginRoler.U_Id + ",GETDATE()";
                    if ((DAL.DBHelp.ExecuteNonQuery(sql, null)) > 0)
                        MessageBox.Show("操作成功!");
                    else
                        MessageBox.Show("操作失败!");
                }
            }
        }

        private void dataGridView_Book_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Btn_Update_Click(sender, e);
        }

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDataInOut frm = new FrmDataInOut();
            frm.ShowDialog();
        }

        private void 导出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DAL.ExcelIO ee = new DAL.ExcelIO();
            ee.ExportExcel("客户导出数据", dsLog, "c:/客户导出数据.xls");
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font tabelTextFont = new Font("宋体", 10);
            if (dataGridView_Book.DataBindings != null)
            {
                int[] columnsWidth = new int[dataGridView_Book.Columns.Count];//得到所有列的个数
                int[] columnsLeft = new int[dataGridView_Book.Columns.Count]; //
                for (int c = 0; c < columnsWidth.Length; c++)//得到列标题的宽度
                {
                    columnsWidth[c] = (int)e.Graphics.MeasureString(dataGridView_Book.Columns[c].HeaderText, tabelTextFont).Width;//测量表头内容宽度
                }
                for (int rowIndex = 0; rowIndex < dataGridView_Book.Rows.Count; rowIndex++)//rowindex当前行
                {
                    for (int columnIndex = 0; columnIndex < dataGridView_Book.Columns.Count; columnIndex++)//当前列
                    {
                        int w = (int)e.Graphics.MeasureString(dataGridView_Book.Columns[columnIndex].Name, tabelTextFont).Width; 
                        columnsWidth[columnIndex] = w > columnsWidth[columnIndex] ? w : columnsWidth[columnIndex];//算出最宽值
                    }
                }
                int rowHidth = 20;
                int tableLeft = 60;
                int tableTop = 70;
                columnsLeft[0] = tableLeft;
                for (int i = 1; i <= columnsWidth.Length - 1; i++)
                {
                    columnsLeft[i] = columnsLeft[i - 1] + columnsWidth[i - 1] + 15;
                }
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;//居中打印
                e.Graphics.DrawString("欢迎交流!", new Font("宋体", 15), Brushes.Black, new Point(e.PageBounds.Width / 2, 20), sf);//打印标题
                for (int c = 0; c < columnsWidth.Length; c++)//打印表中的列名
                {
                    e.Graphics.DrawString(dataGridView_Book.Columns[c].HeaderText, new Font("宋体", 10, FontStyle.Bold), Brushes.Black, new Point(columnsLeft[c], tableTop)); 
                    e.Graphics.DrawLine(Pens.Black, new Point(columnsLeft[c] - 5, tableTop - 5), new Point(columnsLeft[c] - 5, tableTop + (dataGridView_Book.Rows.Count + 1) * rowHidth));
                }
                e.Graphics.DrawLine(Pens.Black, new Point(columnsLeft[dataGridView_Book.Columns.Count - 1] + columnsWidth[dataGridView_Book.Columns.Count - 1], tableTop - 5), new Point(columnsLeft[dataGridView_Book.Columns.Count - 1] + columnsWidth[dataGridView_Book.Columns.Count - 1], tableTop + (dataGridView_Book.Rows.Count + 1) * rowHidth));//画最后面的线
                e.Graphics.DrawLine(Pens.Black, new Point(columnsLeft[0] - 5, tableTop - 5), new Point(columnsLeft[dataGridView_Book.Columns.Count - 1] + columnsWidth[dataGridView_Book.Columns.Count - 1], tableTop - 5)); 
                for (int rowIndex = 0; rowIndex < dataGridView_Book.Rows.Count; rowIndex++)//打印表中的内容
                {
                    for (int columnIndex = 0; columnIndex < dataGridView_Book.Columns.Count; columnIndex++)
                    {
                        e.Graphics.DrawString(dataGridView_Book.Rows[rowIndex].Cells[columnIndex].Value.ToString(), tabelTextFont, Brushes.Black, new Point(columnsLeft[columnIndex], tableTop + rowHidth * (rowIndex + 1)));
                    }
                    e.Graphics.DrawLine(Pens.Black, new Point(columnsLeft[0] - 5, tableTop + (rowIndex + 1) * rowHidth - 5), new Point(columnsLeft[dataGridView_Book.Columns.Count - 1] + columnsWidth[dataGridView_Book.Columns.Count - 1], tableTop + (rowIndex + 1) * rowHidth - 5));//循环画行
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                DAL.dalBook.Update("U_Check", "1", 1);
            else
                DAL.dalBook.Update("U_Check", "0", 1);
        }

    }
 }
