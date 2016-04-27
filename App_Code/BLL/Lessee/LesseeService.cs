using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using com.surfkj.small.DAL.Lessee;
using com.surfkj.small.Model;

namespace com.surfkj.small.BLL.Lessee
{
    /// <summary>
    /// Lessee
    /// </summary>
    public partial class LesseeService
    {
        LesseeDAL dal = new LesseeDAL();
        public LesseeService()
        { }
        #region  Method

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
        public int Add(com.surfkj.small.Model.Lessee model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(com.surfkj.small.Model.Lessee model)
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
        public com.surfkj.small.Model.Lessee GetModel(int ID)
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
        public List<com.surfkj.small.Model.Lessee> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<com.surfkj.small.Model.Lessee> DataTableToList(DataTable dt)
        {
            List<com.surfkj.small.Model.Lessee> modelList = new List<com.surfkj.small.Model.Lessee>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                com.surfkj.small.Model.Lessee model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new com.surfkj.small.Model.Lessee();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Name"] != null && dt.Rows[n]["Name"].ToString() != "")
                    {
                        model.Name = dt.Rows[n]["Name"].ToString();
                    }
                    if (dt.Rows[n]["Address"] != null && dt.Rows[n]["Address"].ToString() != "")
                    {
                        model.Address = dt.Rows[n]["Address"].ToString();
                    }
                    if (dt.Rows[n]["OperationScope"] != null && dt.Rows[n]["OperationScope"].ToString() != "")
                    {
                        model.OperationScope = dt.Rows[n]["OperationScope"].ToString();
                    }
                    if (dt.Rows[n]["OfficePhone"] != null && dt.Rows[n]["OfficePhone"].ToString() != "")
                    {
                        model.OfficePhone = dt.Rows[n]["OfficePhone"].ToString();
                    }
                    if (dt.Rows[n]["Director"] != null && dt.Rows[n]["Director"].ToString() != "")
                    {
                        model.Director = dt.Rows[n]["Director"].ToString();
                    }
                    if (dt.Rows[n]["DirectorPhone"] != null && dt.Rows[n]["DirectorPhone"].ToString() != "")
                    {
                        model.DirectorPhone = dt.Rows[n]["DirectorPhone"].ToString();
                    }
                    if (dt.Rows[n]["Emergency"] != null && dt.Rows[n]["Emergency"].ToString() != "")
                    {
                        model.Emergency = dt.Rows[n]["Emergency"].ToString();
                    }
                    if (dt.Rows[n]["EmergencyPhone"] != null && dt.Rows[n]["EmergencyPhone"].ToString() != "")
                    {
                        model.EmergencyPhone = dt.Rows[n]["EmergencyPhone"].ToString();
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    if (dt.Rows[n]["Password"] != null && dt.Rows[n]["Password"].ToString() != "")
                    {
                        model.Password = dt.Rows[n]["Password"].ToString();
                    }
                    if (dt.Rows[n]["RoomNum"] != null && dt.Rows[n]["RoomNum"].ToString() != "")
                    {
                        model.RoomNum = dt.Rows[n]["RoomNum"].ToString();
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
                    if (dt.Rows[n]["WarrantMon"] != null && dt.Rows[n]["WarrantMon"].ToString() != "")
                    {
                        model.WarrantMon = float.Parse(dt.Rows[n]["WarrantMon"].ToString());
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
        public List<com.surfkj.small.Model.Lessee> ListPageLessee(int pageno, int pagesize)
        {

            DataSet ds = dal.ListPageLessee(pageno, pagesize);
            return DataTableToList(ds.Tables[0]);
        }


        public List<com.surfkj.small.Model.Lessee> ListLookLessee(int pageno, int pagesize, string filed, string name)
        {
            DataSet ds = dal.ListLookLessee(pageno, pagesize, filed, name);
            return DataTableToList(ds.Tables[0]);
        }
        public com.surfkj.small.Model.Lessee verifyLogin(string cusLoginName, string cusPassword)
        {
            return dal.verifyLogin(cusLoginName, cusPassword);
        }

        #endregion  Method
    }
}