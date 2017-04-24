using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myBLOG
{
    public partial class BlogIndex : System.Web.UI.Page
    {
        SqlConnection ST_myConn;
        public string ST_bgcolor;
        public string ST_tcolor;
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化页面
            string ST_dns = ConfigurationSettings.AppSettings["conStr"];
            //最新推荐文章
            string ST_cmd_sql = "select top 10 * from news where ST_n_iscmd=1 order by n_date desc";
            SqlConnection ST_myConn = new SqlConnection(ST_dns);

            //定义并初始化命令对象
            SqlDataAdapter ST_classCmd = new SqlDataAdapter("select n_classid, classname from class", ST_myConn);
            SqlDataAdapter ST_cmd_Cmd = new SqlDataAdapter(ST_cmd_sql, ST_myConn);

            //创建一个dataset数据集
            DataSet ST_classds = new DataSet();
            ST_classCmd.Fill(ST_classds, "类别列表");
            DataSet ST_cmdds = new DataSet();
            ST_cmd_Cmd.Fill(ST_cmdds, "推荐文章");
            ClassList.DataSource = new DataView(ST_classds.Tables[0]);

            //绑定文章类型列表
            ClassList.DataBind();
            cmdList.DataSource = new DataView(ST_cmdds.Tables[0]);
            cmdList.DataBind();

            //绑定最新博客列表
            NewsList_Bind();
            if (Request.Cookies["colors"] != null)
            {
                string ST_test = Request.Cookies["colors"].Value;
                string[] ST_colorList = ST_test.Split(new char[] { ',' });
                ST_bgcolor = ST_colorList[0];
                ST_tcolor = ST_colorList[1];
            }
            else
            {
                ST_bgcolor = "#FFDE94";
                ST_tcolor = "#EFE3CE";
            }
            Page.DataBind();
        }

        public void NewsList_Bind()
        {
            string ST_sql;
            if (Request.QueryString["n_classID"] == null)
            {
                //定义一个查询文章信息的SQL
                ST_sql = "select * from news order by n_date desc";
            }
            else
            {
                if (IsSafe(Request.QueryString["n_classID"], 2) == true)
                {
                    //查找最新博客列表
                    ST_sql = "select * from ST_news where n_classID=" + Request.QueryString["n_classID"] + "order by n_date desc";
                }
                else
                {
                    ST_sql = "";
                    Response.Write("非法参数");
                    Response.End();
                }
            }

            //定义并初始化数据适配器
            SqlDataAdapter ST_myCmd = new SqlDataAdapter(ST_sql, ST_myConn);

            //创建一个dataset数据集
            DataSet ST_ds = new DataSet();
            //填充数据
            ST_myCmd.Fill(ST_ds, "文章列表");
            NewsList.DataSource = new DataView(ST_ds.Tables[0]);
            NewsList.DataBind();
        }

        public bool IsSafe(string str, int prama)
        {
            if (prama == 1)
            {
                if (Regex.IsMatch(str, "[0-9]"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (str.IndexOf("and") > 0 || str.IndexOf("'") > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}