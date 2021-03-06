﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL;
using Model;

namespace LoginFrame
{
    //public delegate void GetState(string name);//委托
    public partial class Frm个人信息 : Form
    {
        public Frm个人信息( )
        {
            InitializeComponent();
        }
        public byte[] byte_Image = null;//添加   
        public byte[] byte_Image2 = null;//查看
        public int id;
        public string Pagetype = "";//操作类型
        //public event GetState getName;


        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)//上传图片
        {
            try
            {
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                openFileDialog1.Filter = "图片（*.jpg;*.bmp;*.gif,*.png）|*.jpg;*.bmp;*.gif;*.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.txt_pic.Text = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(txt_pic.Text);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader bw = new BinaryReader(fs);
                    byte_Image = bw.ReadBytes((int)fs.Length);
                }
            }
            catch
            {
                MessageBox.Show("请选择正确的图片格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm个人信息_Load(object sender, EventArgs e)
        {
            
            
            string ButtonShow = System.Configuration.ConfigurationManager.AppSettings["ButtonShow"].ToString();//是否显示密保按钮(0:隐藏 1:显示)
            if (ButtonShow == "0")
            {
                this.checkBox1.Visible = false;
            }
            if (Pagetype == "Update")
            {
                this.button4.Visible = true;
            }

            this.comboBox1.DataSource = DAL.dalCustom.getType("DepartmentType", "D_Id", "D_Name");
            this.comboBox1.DisplayMember = "D_Name";
            this.comboBox1.ValueMember = "D_Id";

            U_NativePlace.Items.Add("总经理");
            U_NativePlace.Items.Add("部门经理");
            U_NativePlace.Items.Add("职员");           
            
            this.GetUserInfo();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Frm找回密码 frm = new Frm找回密码();
                frm.Message("false");
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// 传递参数
        /// </summary>
        /// <param name="sid">主键</param>
        /// <param name="type">添加 | 修改</param>
        public void Message(int sid, string type)
        {
            this.id = sid;//编号
            this.Pagetype = type;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MU_UserInfo user = new MU_UserInfo();
            Common com = new Common();
            if (byte_Image == null) //显示用户生活照
            {
                if (byte_Image2 == null)
                {
                    user.U_Image = null;
                }
                else
                {
                    user.U_Image = byte_Image2;
                }
            }
            else
            {
                user.U_Image = byte_Image;
            }
            user.U_Name = U_Name.Text;//用户名

            user.U_RelName = U_RelName.Text;//用户真实姓名

            user.U_Sex = false;

            if (this.radio_women.Checked == true)//男
            {
                user.U_Sex = true;
            }
            user.U_Birthday = this.U_Birthday.Value;//出生日期

            if (U_IdCard.Text != "")
            {
                if (com.RegexcardID(U_IdCard.Text))
                {
                    user.U_IdCard = U_IdCard.Text;//身份证号
                }
                else
                {
                    MessageBox.Show("身份证号格式输入错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                user.U_IdCard = "";
            }
            user.U_NativePlace = U_Position.Text;//民族

            user.U_Address = U_Address.Text;//家庭住址
 
            if (U_Telephone.Text != "")
            {
                if (com.RegexPhone(U_Telephone.Text))
                {
                    user.U_Telephone = U_Telephone.Text;//电话号码
                }
                else
                {
                    MessageBox.Show("电话号码格式输入错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                user.U_Telephone = "";
            }

            if (U_Email.Text != "")
            {
                if (com.RegexEmail(U_Email.Text))
                {
                    user.U_Email = U_Email.Text;//邮箱号码
                }
                else
                {
                    MessageBox.Show("邮箱号码格式输入错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                user.U_Email = "";
            }
            user.U_PostalId = U_PostalId.Text;//邮编号码
            user.U_QQ = textBox1.Text; //QQ
            user.U_Id = id;
            bool flag = new BU_UserInfo().Update(user);
            if (flag)
            {
                //if (LoginRoler.U_ROlesType == 2)
                //{
                    //getName("随便传的值");
                //}
                MessageBox.Show("修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.button4.Visible = true ;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        public void GetUserInfo()
        {
            BU_UserInfo bll = new BU_UserInfo();
            MU_UserInfo user = bll.GetModel(id);
            U_Name.Text = user.U_Name;//用户名
            U_Name.ReadOnly = true;
            U_RelName.Text = user.U_RelName;//用户真实姓名
            if (user.U_Sex == true)//女
            {
                this.radio_women.Checked = true;
            }
            this.U_Birthday.Value = user.U_Birthday;//出生日期
            U_IdCard.Text = user.U_IdCard;//身份证号
            U_Position.Text = user.U_NativePlace;//籍贯
            U_NativePlace.Text = user.U_Position;//籍贯
            U_Address.Text = user.U_Address;//家庭住址
            U_Telephone.Text = user.U_Telephone;//电话号码
            U_Email.Text = user.U_Email;//邮箱号码
            U_PostalId.Text = user.U_DepType.ToString();//user.U_PostalId;//邮编号码
            textBox1.Text = user.U_QQ;    //QQ
            this.comboBox1.SelectedValue = user.U_DepType.ToString();
            //显示用户生活照
            if (user.U_Image != null)
            {
                byte_Image2 = (byte[])(user.U_Image);
                MemoryStream ms = new MemoryStream(byte_Image2);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            U_RelName.ReadOnly =false;
            this.radion_man.Enabled =true;          
            this.radio_women.Enabled =true;
            this.U_Birthday.Enabled =true ;
            U_IdCard.ReadOnly =false;
            U_Address.ReadOnly =false;
            U_Telephone.ReadOnly =false;
            U_Email.ReadOnly =false;
            U_PostalId.ReadOnly =false;
            U_Position.ReadOnly = false;
            textBox1.ReadOnly =false;    
            this.button1.Visible = true;
            this.button3.Enabled  = true;
            this.button4.Visible = false;
        }
    }
}
