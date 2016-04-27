using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

/// <summary>
///UserBLL 的摘要说明
/// </summary>
public class UserBLL
{
	public UserBLL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//

	}

    public bool Exists(int id) {
        UserDAL dal = new UserDAL();
        return dal.Exists(id);
    }
    public int Add(com.surfkj.small.Model.LoginUser model) {
        UserDAL dal = new UserDAL();
        return dal.Add(model);
    }

    public bool Update(com.surfkj.small.Model.LoginUser model)
    {
        UserDAL dal = new UserDAL();
        return dal.Update(model);

    }

    public bool Delete(int id) {
        UserDAL dal = new UserDAL();
        return dal.Delete(id);
    }

    public bool DeleteList(string idlist) {
        UserDAL dal = new UserDAL();
        return dal.DeleteList(idlist);
    
    }

    public com.surfkj.small.Model.LoginUser GetModel(int id)
    {
        UserDAL dal = new UserDAL();
        return dal.GetModel(id);
    }

    public DataSet GetList(string strWhere)
    {
        UserDAL dal = new UserDAL();
        return dal.GetList(strWhere);
    }

    public DataSet GetList(int Top, string strWhere, string filedOrder)
    {
        UserDAL dal = new UserDAL();
        return dal.GetList(Top, strWhere, filedOrder);
    }
    public com.surfkj.small.Model.LoginUser verifyLogin(string loginName, string loginPwd)
    {
        UserDAL dal = new UserDAL();
        return dal.verifyLogin(loginName, loginPwd);
    }




}