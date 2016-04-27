<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        

    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }

    //在接收到一个应用程序请求时触发。对于一个请求来说，它是第一个被触发的事件，请求一般是用户输入的一个页面请求（URL）。
    //void Application_BeginRequest(object sender, EventArgs e)
    //{
    //    //Response.Write("通用注入检查");
    //    bool result = false;
        
    //    if (Request.RequestType.ToUpper() == "POST")
    //    {
    //        result = SQLInjectionHelper.ValidUrlPostData();//Post数据检查
    //    }
    //    else
    //    {
    //        result = SQLInjectionHelper.ValidUrlGetData();//Get数据检查
    //    }
        
    //    if (result)
    //    {
    //       // Response.Write("!!！");   

    //        Response.Write("<script language=javascript>window.location='../Index.aspx';alert('您提交的数据有恶意字符！');" + "</Scr" + "ipt>");
    //      // Response.Write("<script language=javascript>window.location='Default.aspx';<//script>");
    //        Response.End();
    //    }
    //}
       
</script>

