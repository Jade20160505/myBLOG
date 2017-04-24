using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//引用数据库命名空间
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data;

namespace myBLOG.App_Start
{
    public class Sqldata
    {
        private SqlConnection sqlcon; //声明一个连接
        private SqlCommand sqlcom; //声明一个command
        private SqlDataAdapter sqladp;

        #region
        /// <summary>
        /// 构造函数，初始化连接数据库
        /// </summary>
        public Sqldata()
        {
            sqlcon = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        }
        #endregion//构造连接函数

        #region //绑定用户页面中的gridView控件
        public bool BindData(GridView dl, string sqlCom)
        {
            dl.DataSource = this.ExceDS(sqlCom);
            try
            {
                dl.DataBind();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlcon.Close();
            }
        }
        #endregion

        #region //返回dataset类型数据

        public DataSet ExceDS(string sqlCom)
        {
            try
            {
                sqlcon.Open();
                sqlcom = new SqlCommand(sqlCom, sqlcon);
                sqladp = new SqlDataAdapter()
                {
                    SelectCommand = sqlcom
                };//定义并初始化适配器 
                DataSet ds = new DataSet();
                sqladp.Fill(ds);//返回一个数据集
                return ds;
            }
            finally
            {
                sqlcon.Close();
            }
        }
        #endregion


        #region //执行SQL语句方法
        public bool ExceSQL(string sqlCom)
        {
            SqlCommand sqlcom = new SqlCommand(sqlCom, sqlcon);
            try
            {
                //判断数据库是否连接
                if (sqlcon.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                //执行语句
                sqlcom.ExecuteNonQuery();
                return true;
            }
            catch
            {
                //语句失败
                return false;
            }
            finally
            {
                sqlcon.Close();
            }
        }
        #endregion
    }
}