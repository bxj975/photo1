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
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace LoginFrame
{
    public partial class FrmSummarize : Form
    {
        public FrmSummarize(string state, string barcode)
        {
            InitializeComponent();
            this.state = state;
            this.barcode = barcode;

           // this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage); 
        }
        string Note;
        int A,B,C,D,E,F,G,H,I,J,Clerk;
        DateTime Login;
        public String barcode, state;
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            BindData();
            string SqlStr = "update U_Report set U_A=" + A + ",U_B=" + B + ",U_C=" + C + ",U_D=" + D + ", U_E=" + E + ",U_F=" + F + ",U_G=" + G + ",U_H=" + H + ",U_I=" + I + ",U_J=" + J + ",U_Note='" + Note + "', U_LoginTime=" + Login + "  where U_Id=" + barcode;
            if (DAL.DBHelp.ExecuteNonQuery(SqlStr)>0)
                MessageBox.Show("更新成功!");
            else
                MessageBox.Show("更新失败!");
            this.Close(); 
        }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
           int One= OneBind();
           if (One == 0)
           {
               BindData();
               string SqlStr = "insert into U_Report(U_A,U_B,U_C,U_D,U_E,U_F,U_G,U_H,U_I,U_J,U_Note,U_LoginTime,U_ClerkType,U_Check)  values(" + A + "," + B + "," + C + "," + D + "," + E + "," + F + "," + G + "," + H + "," + I + "," + J + ",'" + Note + "'," + Login + "," + LoginRoler.U_Id + ",0)";
               if (DAL.DBHelp.ExecuteNonQuery(SqlStr) > 0)
                   MessageBox.Show("添加成功!");
               else
                   MessageBox.Show("添加失败!");
               this.Close();
           }
            else 
                   MessageBox.Show("已做日报，不能重复!");

        }

        private void BindData()
        {
            Clerk = int.Parse(this.comboBox1.SelectedValue.ToString());
            Note = this.txt_publish.Text; ;
            Login = this.dtp_publishDate.Value;
            A = int.Parse(this.textBox11.Text);
            B = int.Parse(this.textBox12.Text);
            C = int.Parse(this.textBox13.Text);
            D = int.Parse(this.textBox14.Text);
            E = int.Parse(this.textBox15.Text);
            F = int.Parse(this.textBox16.Text);
            G = int.Parse(this.textBox17.Text);
            H = int.Parse(this.textBox18.Text);
            I = int.Parse(this.textBox19.Text);
            J = int.Parse(this.textBox20.Text);
        }

        private int OneBind()
        {
            Clerk = int.Parse (this.comboBox1.SelectedValue.ToString());
            Login = this.dtp_publishDate.Value;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from U_Report");
            strSql.Append(" where ");
            strSql.Append(" U_ClerkType = @Clerk and U_LoginTime= @Login");
            SqlParameter[] parameters = {
					new SqlParameter("@Clerk", SqlDbType.Int ),
                    new SqlParameter("@Login", SqlDbType.DateTime )
            };
            parameters[0].Value = Clerk;
            parameters[1].Value = Login;

           return  Convert.ToInt32(DAL.DBHelp.ExecuteScalar(strSql.ToString(), parameters));
        }
        private void FrmSummarize_Load(object sender, EventArgs e)
        {          
            this.comboBox1.DataSource = DAL.dalCustom.getType("U_UserInfo", "U_Id", "U_Name");
            this.comboBox1.DisplayMember = "U_Name";
            this.comboBox1.ValueMember = "U_Id";
            
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
                string sql = "select * from U_Report where U_Id=" + barcode ;
                DataTable Dt = DAL.DBHelp.DataTable(sql);
                this.txt_publish.Text = Dt.Rows[0]["U_Note"].ToString(); ;
                this.dtp_publishDate.Value = (DateTime)Dt.Rows[0]["U_LoginTime"];
                this.comboBox1.SelectedValue = Dt.Rows[0]["U_ClerkType"].ToString();
                this.textBox11.Text = Dt.Rows[0]["U_A"].ToString();
                this.textBox12.Text = Dt.Rows[0]["U_B"].ToString();
                this.textBox13.Text = Dt.Rows[0]["U_C"].ToString();
                this.textBox14.Text = Dt.Rows[0]["U_D"].ToString();
                this.textBox15.Text = Dt.Rows[0]["U_E"].ToString();
                this.textBox16.Text = Dt.Rows[0]["U_F"].ToString();
                this.textBox17.Text = Dt.Rows[0]["U_G"].ToString();
                this.textBox18.Text = Dt.Rows[0]["U_H"].ToString();
                this.textBox19.Text = Dt.Rows[0]["U_I"].ToString();
                this.textBox20.Text = Dt.Rows[0]["U_J"].ToString();
                
                this.button1.Visible = false;
                this.Btn_Update.Visible = false;
                this.button3.Visible = false;

            }
            else 
            {
                this.Btn_Update.Visible = false;
                this.button4.Visible = false;
                this.comboBox1.SelectedValue = LoginRoler.U_Id;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login = this.dtp_publishDate.Value;
            string sql = "select count(U_A),count(U_B),count(U_C),count(U_D),count(U_E),count(U_F),count(U_G),count(U_H),count(U_I),count(U_J) from U_Report where (CONVERT(varchar(100), U_LoginTime, 23)=CONVERT(varchar(100)," + Login + ", 23)";
            DataTable Dt = DAL.DBHelp.DataTable(sql);
            this.textBox11.Text = Dt.Rows[0][1].ToString();
            this.textBox12.Text = Dt.Rows[0][2].ToString();
            this.textBox13.Text = Dt.Rows[0][3].ToString();
            this.textBox14.Text = Dt.Rows[0][4].ToString();
            this.textBox15.Text = Dt.Rows[0][5].ToString();
            this.textBox16.Text = Dt.Rows[0][6].ToString();
            this.textBox17.Text = Dt.Rows[0][7].ToString();
            this.textBox18.Text = Dt.Rows[0][8].ToString();
            this.textBox19.Text = Dt.Rows[0][9].ToString();
            this.textBox20.Text = Dt.Rows[0][10].ToString();
            this.button1.Visible = false;
            this.Btn_Update.Visible = false;
            this.button3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button3.Visible = true ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string SqlStr = "update U_Report set U_Check=" + LoginRoler.U_Id + "  where U_Id=" + barcode;
            if (DAL.DBHelp.ExecuteNonQuery(SqlStr) > 0)
                MessageBox.Show("审核成功!");
            else
                MessageBox.Show("审核失败!");
            this.Close(); 
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font titleFont = new Font("宋体", 19, FontStyle.Bold);//标题字体           

            Font fntTxt = new Font("宋体", 19, FontStyle.Regular);//正文文字           

            Brush brush = new SolidBrush(Color.Black);//画刷           

            Pen pen = new Pen(Color.Black);           //线条颜色           

            Point po = new Point(20, 20);

            string str = this.GetPrintSW().ToString(); 
            
            try
            {
                e.Graphics.DrawString(str, titleFont, brush, po);   //DrawString方式进行打印。                      
            }

            catch (Exception ex)
            {

                MessageBox.Show(this, "打印出错！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw ex;
            }

        }

        ///GetPrintSw方法用来构造打印文本，内部StringBuilder.AppendLine在Drawstring时单独占有一行。

        public StringBuilder GetPrintSW()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" 工作日报 \n");

            sb.AppendLine("-----------------------------------------");

            sb.AppendLine("日期:" + DateTime.Now.ToShortDateString());

            sb.AppendLine("-----------------------------------------");
            sb.AppendLine("员工:" + comboBox1.Text + "");
            sb.AppendLine("客户新增:" + textBox19.Text + "");
            sb.AppendLine("客户成交:" + textBox10.Text + "");
            sb.AppendLine("回款金额:" + textBox22.Text + "");
            sb.AppendLine("员工:" + comboBox1.Text + "");
            sb.AppendLine("员工:" + comboBox1.Text + "");
            sb.AppendLine("员工:" + comboBox1.Text + "");
            sb.AppendLine("员工:" + comboBox1.Text + "");
            sb.AppendLine("-----------------------------------------");

            return sb;

        }



        //在打印页面创建PrintDocument对象

        PrintDocument pd = new PrintDocument();

        //如果需要打印预览，可以声明打印预览变量，预览这一部分，这里不再介绍，博客园里相应代码多到没边，可以自行查询。

        //打印按钮事件：

        //private void btnPrint_Click(object sender, EventArgs e)
        //{

           // pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage); //打印页面需指定相应的PrintDocument_PrintPrintPage事件委托     

           // CommonUtils.Printer.Print(pd);

       // }

        private void button6_Click(object sender, EventArgs e)
        {
            //显示预览对话
            this.printPreviewDialog1.ShowDialog();

        }
        private void button7_Click(object sender, EventArgs e)
        {
            //显示预览对话
            //Print.Form1 frm = new Print.Form1();
            //frm.ShowDialog();
            
        }
    }
}
