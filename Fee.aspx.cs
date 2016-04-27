using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using com.surfkj.small.user.Model;
using com.surfkj.small.Model;

public partial class Fee : System.Web.UI.Page
{
    public Customer customer;
    public Lessee lee;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["customer"] != null)
        //{

        //    if (Session["lee"] != null)
        //    {
        //        Session["lee"] = null;
        //    }
        //    customer = (Customer)Session["customer"];
        //    Response.Write(customer.cusPassword);
        //}
        //else if (Session["lee"] != null)
        //{
        //    if (Session["customer"] != null)
        //    {
        //        Session["customer"] = null;
        //    }
        //    lee = (Lessee)Session["lee"];
        //    customerLevel = "注册用户";
        //    Response.Write(lee.Password);
        //}
        //else
        //{
        //    Response.Write("<script language='javascript'>alert('对不起，请登录系统！');window.location.href='User/login.aspx';</script>");
        //}
     
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EMISDatabase2ConnectionString"].ConnectionString);
        //SqlConnection conn = new SqlConnection("server=.\\SQLExpress;uid=CEMIS;password=CEMIS;database=EMISDatabase2;");
        SqlDataAdapter adapterScene = new SqlDataAdapter("SELECT ID, Lessee AS 承租人,Fee AS 费用, FeeType AS 费用类型 ,DeadLine AS 限交日期 FROM Fee WHERE Lessee=@lessee ", (SqlConnection)conn);
        DbParameter par = adapterScene.SelectCommand.CreateParameter();        
        par.DbType = DbType.String;
        par.ParameterName = "@lessee";
        par.Value = "浙江工业大学";
        adapterScene.SelectCommand.Parameters.Add(par);
        SqlCommandBuilder builder = new SqlCommandBuilder(adapterScene);
        DataTable table = new DataTable();        
        adapterScene.Fill(table);  
        GridView1.DataSource = table;
        GridView1.DataBind();
        GridView1.HeaderStyle.Width = 100;
       
        

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}