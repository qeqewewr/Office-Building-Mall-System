using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using com.surfkj.small.Common;
using com.surfkj.small.Model.PermissionManage;
using com.surfkj.small.DAL.PermissionManage;
namespace com.surfkj.small.BLL.PermissionManage
{
    /// <summary>
    /// T_AllFunction
    /// </summary>
    public partial class AllFunctionService
    {
        AllFunctionDAL dal = new AllFunctionDAL();
        public AllFunctionService()
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
        public int Add(com.surfkj.small.Model.PermissionManage.AllFunction model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(com.surfkj.small.Model.PermissionManage.AllFunction model)
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
        public com.surfkj.small.Model.PermissionManage.AllFunction GetModel(int ID)
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
        public List<com.surfkj.small.Model.PermissionManage.AllFunction> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<com.surfkj.small.Model.PermissionManage.AllFunction> DataTableToList(DataTable dt)
        {
            List<com.surfkj.small.Model.PermissionManage.AllFunction> modelList = new List<com.surfkj.small.Model.PermissionManage.AllFunction>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                com.surfkj.small.Model.PermissionManage.AllFunction model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new com.surfkj.small.Model.PermissionManage.AllFunction();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["ParentID"] != null && dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = int.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    if (dt.Rows[n]["Code"] != null && dt.Rows[n]["Code"].ToString() != "")
                    {
                        model.Code = dt.Rows[n]["Code"].ToString();
                    }
                    if (dt.Rows[n]["FullName"] != null && dt.Rows[n]["FullName"].ToString() != "")
                    {
                        model.FullName = dt.Rows[n]["FullName"].ToString();
                    }
                    if (dt.Rows[n]["NavigateUrl"] != null && dt.Rows[n]["NavigateUrl"].ToString() != "")
                    {
                        model.NavigateUrl = dt.Rows[n]["NavigateUrl"].ToString();
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

        #endregion  Method
    }
}
