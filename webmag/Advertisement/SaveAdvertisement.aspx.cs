using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.Model.Advertisement;
using com.surfkj.small.BLL.Advertisement;

public partial class webmag_Advertisement_SaveAdvertisement : System.Web.UI.Page
{
    private AdvertisementService service;
    private Advertisement advertisement;
    private string id;
    private string url;
    private string imgUrl;
    private string description;
    private string adveOrder;
    private bool flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        service = new AdvertisementService();
        advertisement = new Advertisement();
        id = Request["id"];
        url = Request["Url"];
        imgUrl = Request["ImgUrl"];
        description = Request["Description"];
        adveOrder = Request["adveOrder"];
        flag = false;
        advertisement = service.GetModel(int.Parse(id));
        advertisement.Url = url;
        advertisement.ImgUrl = imgUrl;
        advertisement.Description = description;
        advertisement.AdveOrder = int.Parse(adveOrder);
        advertisement.State = 1;//启用标志
        advertisement.UpdateTime = DateTime.Now;

        flag = service.Update(advertisement);


    }
}