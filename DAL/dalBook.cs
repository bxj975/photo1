using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    /*图书业务逻辑层实现*/
    public class dalBook
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加图书实现*/
        public static bool AddBook(Model.Book book)
        {
            string sql = "insert into U_Custom(U_Name,U_RelName,U_Email,U_QQ,U_MoveTele,U_Telephone,U_WeiXin,U_PsdType,U_AreaType,U_ClerkType,U_Address,U_Position,U_Note,U_Image,U_LoginTime) values(@U_Name,@U_RelName,@U_Email,@U_QQ,@U_MoveTele,@U_Telephone,@U_WeiXin,@U_PsdType,@U_AreaType,@U_ClerkType,@U_Address,@U_Position,@U_Note,@U_Image,@U_LoginTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@U_Name",SqlDbType.VarChar),
             new SqlParameter("@U_RelName",SqlDbType.VarChar,50),
             new SqlParameter("@U_Email",SqlDbType.VarChar,50),
             new SqlParameter("@U_QQ",SqlDbType.VarChar,50),
             new SqlParameter("@U_MoveTele",SqlDbType.VarChar,50),
             new SqlParameter("@U_Telephone",SqlDbType.VarChar,50),
             new SqlParameter("@U_WeiXin",SqlDbType.VarChar,50),  
             new SqlParameter("@U_PsdType",SqlDbType.Int),
             new SqlParameter("@U_AreaType",SqlDbType.Int),
             new SqlParameter("@U_ClerkType",SqlDbType.Int),
             new SqlParameter("@U_Address",SqlDbType.VarChar,50),
             new SqlParameter("@U_Position",SqlDbType.VarChar,50),
             new SqlParameter("@U_Note",SqlDbType.NVarChar,200),
             new SqlParameter("@U_Image",SqlDbType.Image),
             new SqlParameter("@U_LoginTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = book.bookName; 
            parm[1].Value = book.Name; 
            parm[2].Value = book.email; 
            parm[3].Value = book.qq; 
            parm[4].Value = book.move; 
            parm[5].Value = book.tele; 
            parm[6].Value = book.weixin; 
            parm[7].Value = book.bookType; 
            parm[8].Value = book.area; 
            parm[9].Value = book.clerk; 
            parm[10].Value = book.address; 
            parm[11].Value = book.www; 
            parm[12].Value = book.note; 
            parm[13].Value = book.bookPhoto; 
            parm[14].Value = book.publishDate;
            foreach (SqlParameter p in parm)   //没有对传入的数据作空值的处理
            {
                if (p.Value  == null)
                {
                    p.Value = DBNull.Value;
                }
            }
            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }
       
        /*根据barcode获取某条图书记录*/
        public static Model.Book getSomeBook(string barcode)
        {
            /*构建查询sql*/
            string sql = "select * from U_Custom where U_id=" + barcode;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            Model.Book book = new Model.Book();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                book.barcode = Convert.ToInt32(DataRead["U_Id"]);
                book.bookName = DataRead["U_Name"].ToString();
                book.Name = DataRead["U_RelName"].ToString();
                book.email = DataRead["U_Email"].ToString();
                book.qq = DataRead["U_QQ"].ToString();
                book.move = DataRead["U_MoveTele"].ToString();
                book.tele = DataRead["U_Telephone"].ToString();
                book.weixin = DataRead["U_Weixin"].ToString();
                book.bookType = Convert.ToInt32(DataRead["U_PsdType"]);
                book.area = Convert.ToInt32(DataRead["U_areaType"]);
                book.clerk = Convert.ToInt32(DataRead["U_ClerkType"]);
                book.address = DataRead["U_Address"].ToString();
                book.www = DataRead["U_Position"].ToString();
                book.note = DataRead["U_Note"].ToString();
                book.bookPhoto = (byte[])DataRead["U_Image"];
                book.publishDate = Convert.ToDateTime(DataRead["U_LoginTime"].ToString());
            }
            DataRead.Close();
            return book;
        }       

        /*更新图书实现*/
        public static bool EditBook(Model.Book book)
        {
            string sql = "update U_Custom set U_Name=@U_Name,U_RelName=@U_RelName,U_Email=@U_Email,U_QQ=@U_QQ,U_MoveTele=@U_MoveTele,U_Telephone=@U_Telephone,U_WeiXin=@U_WeiXin,U_PsdType=@U_PsdType,U_AreaType=@U_AreaType,U_ClerkType=@U_ClerkType,U_Address=@U_Address,U_Position=@U_Position,U_Note=@U_Note,U_Image=@U_Image,U_LoginTime=@U_LoginTime where U_Id=@U_Id";
                        
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@U_Id",SqlDbType.Int),
             new SqlParameter("@U_Name",SqlDbType.VarChar),
             new SqlParameter("@U_RelName",SqlDbType.VarChar),
             new SqlParameter("@U_Email",SqlDbType.VarChar),
             new SqlParameter("@U_QQ",SqlDbType.VarChar),
             new SqlParameter("@U_MoveTele",SqlDbType.VarChar),
             new SqlParameter("@U_Telephone",SqlDbType.VarChar),
             new SqlParameter("@U_WeiXin",SqlDbType.VarChar),  
             new SqlParameter("@U_PsdType",SqlDbType.Int),
             new SqlParameter("@U_AreaType",SqlDbType.Int),
             new SqlParameter("@U_ClerkType",SqlDbType.Int),
             new SqlParameter("@U_Address",SqlDbType.VarChar),
             new SqlParameter("@U_Position",SqlDbType.VarChar),
             new SqlParameter("@U_Note",SqlDbType.VarChar),
             new SqlParameter("@U_Image",SqlDbType.Image),
             new SqlParameter("@U_LoginTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = book.barcode; 
            parm[1].Value = book.bookName; 
            parm[2].Value = book.Name; 
            parm[3].Value = book.email; 
            parm[4].Value = book.qq; 
            parm[5].Value = book.move; 
            parm[6].Value = book.tele; 
            parm[7].Value = book.weixin; 
            parm[8].Value = book.bookType; 
            parm[9].Value = book.area; 
            parm[10].Value = book.clerk; 
            parm[11].Value = book.address; 
            parm[12].Value = book.www; 
            parm[13].Value = book.note; 
            parm[14].Value = book.bookPhoto; 
            parm[15].Value = book.publishDate; 
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }
     
        /*删除图书*/
        public static bool DelBook(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                if (i != ids.Length - 1)
                    sql += "'" + ids[i] + "',";
                else
                    sql += "'" + ids[i] + "'";
            }
            sql = "delete from U_Custom where U_Id in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }      
        
        /*查询图书*/
        public static System.Data.DataTable GetBook(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select U_Custom.*,CustomType.C_Name from U_Custom,CustomType where  U_Custom.U_PsdType=CustomType.C_Id ";
                string strShow = "U_Id as 编码,U_Name as 客户名称,U_RelName as 联系人,U_Email as 邮箱,U_QQ as QQ,U_MoveTele as 手机,U_Telephone as 电话,U_WeiXin as 微信,C_Name as 类型,convert(char(11),U_LoginTime,20) as 时间";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "U_Id", strShow, strSql, strWhere, " U_Id asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   
        public static DataSet getAllBook()
        {
            try
            {
                string strSql = "select * from Book";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string getString(int UserID)//返回一个类型名称
        {
            string cmdText = "select U_Row from  U_Row  where U_Id=" + UserID;
            SqlConnection conn = DBHelp.GetConnection;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            string TypeName = (string)cmd.ExecuteScalar();
            return TypeName;
        }

        public static bool getBool(int UserID)//返回一个类型名称
        {
            string cmdText = "select U_Check from  U_Row  where U_Id=" + UserID;
            SqlConnection conn = DBHelp.GetConnection;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            bool TypeName = (bool)cmd.ExecuteScalar();
            return TypeName;
        }

        public static int Update(string T_Name, string New, int UserID)
        {
            string sql = "update U_Row set " + T_Name + "=" + New + " where U_Id=" + UserID;
            SqlConnection conn = DBHelp.GetConnection;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int num = cmd.ExecuteNonQuery();
            return num;
        }

        public static bool IsIntNum(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[-]?[1-9]{1}\d*$|^[0]{1}$");
            bool ismatch = reg1.IsMatch(str);
            //if (!ismatch)
            //Show("您输入的数字不是整数！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return ismatch;
        }

    }
}
