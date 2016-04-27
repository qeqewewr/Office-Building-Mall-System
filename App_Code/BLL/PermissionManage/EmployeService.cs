using System;
using System.Data;
using System.Collections.Generic;
using com.surfkj.small.Model;
using com.surfkj.small.DAL.PermissionManage;
using com.surfkj.small.Common;
namespace com.surfkj.small.BLL.PermissionManage
{
    /// <summary>
    /// Employe
    /// </summary>
    public partial class EmployeService
    {
        EmployeDAL dal = new EmployeDAL();
        public EmployeService()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        //public int GetMaxId()
        //{
        //    return dal.GetMaxId();
        //}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(com.surfkj.small.Model.PermissionManage.Employe model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(com.surfkj.small.Model.PermissionManage.Employe model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public com.surfkj.small.Model.PermissionManage.Employe GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<com.surfkj.small.Model.PermissionManage.Employe> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<com.surfkj.small.Model.PermissionManage.Employe> DataTableToList(DataTable dt)
        {
            List<com.surfkj.small.Model.PermissionManage.Employe> modelList = new List<com.surfkj.small.Model.PermissionManage.Employe>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                com.surfkj.small.Model.PermissionManage.Employe model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new com.surfkj.small.Model.PermissionManage.Employe();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["EmployeID"] != null && dt.Rows[n]["EmployeID"].ToString() != "")
                    {
                        model.EmployeID = dt.Rows[n]["EmployeID"].ToString();
                    }
                    if (dt.Rows[n]["Name"] != null && dt.Rows[n]["Name"].ToString() != "")
                    {
                        model.Name = dt.Rows[n]["Name"].ToString();
                    }
                    if (dt.Rows[n]["IDNumber"] != null && dt.Rows[n]["IDNumber"].ToString() != "")
                    {
                        model.IDNumber = dt.Rows[n]["IDNumber"].ToString();
                    }
                    if (dt.Rows[n]["Sex"] != null && dt.Rows[n]["Sex"].ToString() != "")
                    {
                        model.Sex = dt.Rows[n]["Sex"].ToString();
                    }
                    if (dt.Rows[n]["Nation"] != null && dt.Rows[n]["Nation"].ToString() != "")
                    {
                        model.Nation = dt.Rows[n]["Nation"].ToString();
                    }
                    if (dt.Rows[n]["Birth"] != null && dt.Rows[n]["Birth"].ToString() != "")
                    {
                        model.Birth = DateTime.Parse(dt.Rows[n]["Birth"].ToString());
                    }
                    if (dt.Rows[n]["Politics"] != null && dt.Rows[n]["Politics"].ToString() != "")
                    {
                        model.Politics = dt.Rows[n]["Politics"].ToString();
                    }
                    if (dt.Rows[n]["Education"] != null && dt.Rows[n]["Education"].ToString() != "")
                    {
                        model.Education = dt.Rows[n]["Education"].ToString();
                    }
                    if (dt.Rows[n]["Department"] != null && dt.Rows[n]["Department"].ToString() != "")
                    {
                        model.Department = dt.Rows[n]["Department"].ToString();
                    }
                    if (dt.Rows[n]["OfficeTel"] != null && dt.Rows[n]["OfficeTel"].ToString() != "")
                    {
                        model.OfficeTel = dt.Rows[n]["OfficeTel"].ToString();
                    }
                    if (dt.Rows[n]["HomeTel"] != null && dt.Rows[n]["HomeTel"].ToString() != "")
                    {
                        model.HomeTel = dt.Rows[n]["HomeTel"].ToString();
                    }
                    if (dt.Rows[n]["Mobile"] != null && dt.Rows[n]["Mobile"].ToString() != "")
                    {
                        model.Mobile = dt.Rows[n]["Mobile"].ToString();
                    }
                    if (dt.Rows[n]["HomeAddress"] != null && dt.Rows[n]["HomeAddress"].ToString() != "")
                    {
                        model.HomeAddress = dt.Rows[n]["HomeAddress"].ToString();
                    }
                    if (dt.Rows[n]["Email"] != null && dt.Rows[n]["Email"].ToString() != "")
                    {
                        model.Email = dt.Rows[n]["Email"].ToString();
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Status"].ToString() == "1") || (dt.Rows[n]["Status"].ToString().ToLower() == "true"))
                        {
                            model.Status = true;
                        }
                        else
                        {
                            model.Status = false;
                        }
                    }
                    if (dt.Rows[n]["EnterDate"] != null && dt.Rows[n]["EnterDate"].ToString() != "")
                    {
                        model.EnterDate = DateTime.Parse(dt.Rows[n]["EnterDate"].ToString());
                    }
                    if (dt.Rows[n]["LeaveDate"] != null && dt.Rows[n]["LeaveDate"].ToString() != "")
                    {
                        model.LeaveDate = DateTime.Parse(dt.Rows[n]["LeaveDate"].ToString());
                    }
                    if (dt.Rows[n]["Password"] != null && dt.Rows[n]["Password"].ToString() != "")
                    {
                        model.Password = dt.Rows[n]["Password"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        public int GetTotalRecordNum()
        {
            int rows = dal.GetTotalRecordNum();
            return rows;
        }
        public int GetInqueryNum(string filed, string str)
        {
            int rows = dal.GetInqueryNum(filed, str);
            return rows;
        }
        /// <summary>
        /// 自定义分页
        /// </summary>
        public List<com.surfkj.small.Model.PermissionManage.Employe> ListPageEmploye(int pageno, int pagesize)
        {

            DataSet ds = dal.ListPageEmploye(pageno, pagesize);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// 
        public List<com.surfkj.small.Model.PermissionManage.Employe> GetEmployeByName(string name)
        {


            DataSet ds = dal.GetList("Name like '%" + name + "%' order by ID");
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.Model.PermissionManage.Employe> ListLookEmploye(int pageno, int pagesize, string filed, string name)
        {
            DataSet ds = dal.ListLookEmploye(pageno, pagesize, filed, name);
            return DataTableToList(ds.Tables[0]);
        }

        public com.surfkj.small.Model.PermissionManage.Employe verifyLogin(string loginName, string loginPwd)
        {
            return dal.verifyLogin(loginName, loginPwd);
        }

        #endregion  Method
    }
}

