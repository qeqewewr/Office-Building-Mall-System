using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.BLL;
using com.surfkj.small.Model;

public partial class User_Register : System.Web.UI.Page
{
    private AgreementsService service;
    public Agreements loginAgreement;
    protected void Page_Load(object sender, EventArgs e)
    {
        service = new AgreementsService();
        loginAgreement = service.GetModel(1);
    }
}