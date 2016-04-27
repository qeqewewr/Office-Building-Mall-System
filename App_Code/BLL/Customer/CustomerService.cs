using System;
using System.Data;
using System.Collections.Generic; 
using com.surfkj.small.user.Model;


namespace com.surfkj.small.user.BLL
{
    /// <summary>
    /// Customer
    /// </summary>
    public partial class CustomerService
    {
        private readonly com.surfkj.small.user.DAL.CustomerDAO dal = new com.surfkj.small.user.DAL.CustomerDAO();
        public CustomerService()
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
        public int Add(com.surfkj.small.user.Model.Customer model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(com.surfkj.small.user.Model.Customer model)
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
        public com.surfkj.small.user.Model.Customer GetModel(int ID)
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
        public List<com.surfkj.small.user.Model.Customer> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<com.surfkj.small.user.Model.Customer> DataTableToList(DataTable dt)
        {
            List<com.surfkj.small.user.Model.Customer> modelList = new List<com.surfkj.small.user.Model.Customer>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                com.surfkj.small.user.Model.Customer model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new com.surfkj.small.user.Model.Customer();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["cusLoginName"] != null && dt.Rows[n]["cusLoginName"].ToString() != "")
                    {
                        model.cusLoginName = dt.Rows[n]["cusLoginName"].ToString();
                    }
                    if (dt.Rows[n]["cusName"] != null && dt.Rows[n]["cusName"].ToString() != "")
                    {
                        model.cusName = dt.Rows[n]["cusName"].ToString();
                    }
                    if (dt.Rows[n]["cusPassword"] != null && dt.Rows[n]["cusPassword"].ToString() != "")
                    {
                        model.cusPassword = dt.Rows[n]["cusPassword"].ToString();
                    }
                    if (dt.Rows[n]["cusRegTime"] != null && dt.Rows[n]["cusRegTime"].ToString() != "")
                    {
                        model.cusRegTime = DateTime.Parse(dt.Rows[n]["cusRegTime"].ToString());
                    }
                    if (dt.Rows[n]["cusLevel"] != null && dt.Rows[n]["cusLevel"].ToString() != "")
                    {
                        model.cusLevel = dt.Rows[n]["cusLevel"].ToString();
                    }
                    if (dt.Rows[n]["cusPoint"] != null && dt.Rows[n]["cusPoint"].ToString() != "")
                    {
                        model.cusPoint = int.Parse(dt.Rows[n]["cusPoint"].ToString());
                    }
                    if (dt.Rows[n]["cusEmail"] != null && dt.Rows[n]["cusEmail"].ToString() != "")
                    {
                        model.cusEmail = dt.Rows[n]["cusEmail"].ToString();
                    }
                    if (dt.Rows[n]["cusUnit"] != null && dt.Rows[n]["cusUnit"].ToString() != "")
                    {
                        model.cusUnit = dt.Rows[n]["cusUnit"].ToString();
                    }
                    if (dt.Rows[n]["cusTel"] != null && dt.Rows[n]["cusTel"].ToString() != "")
                    {
                        model.cusTel = dt.Rows[n]["cusTel"].ToString();
                    }
                    if (dt.Rows[n]["cusAddr"] != null && dt.Rows[n]["cusAddr"].ToString() != "")
                    {
                        model.cusAddr = dt.Rows[n]["cusAddr"].ToString();
                    }
                    if (dt.Rows[n]["cusMemo"] != null && dt.Rows[n]["cusMemo"].ToString() != "")
                    {
                        model.cusMemo = dt.Rows[n]["cusMemo"].ToString();
                    }
                    if (dt.Rows[n]["state"] != null && dt.Rows[n]["state"].ToString() != "")
                    {
                        model.state = int.Parse(dt.Rows[n]["state"].ToString());
                    }
                    if (dt.Rows[n]["cusMoney"] != null && dt.Rows[n]["cusMoney"].ToString() != "")
                    {
                        model.cusMoney = float.Parse(dt.Rows[n]["cusMoney"].ToString());
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

        public Customer verifyLogin(string cusLoginName, string cusPassword) {
            return dal.verifyLogin(cusLoginName, cusPassword);
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
        public List<com.surfkj.small.user.Model.Customer> ListPageCustomer(int pageno, int pagesize)
        {

            DataSet ds = dal.ListPageCustomer(pageno, pagesize);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// 
        //public List<com.surfkj.small.user.Model.Customer> GetCustomerByNO(string orderNO)
        //{


        //    DataSet ds = dal.GetList(" orderNO like '%" + orderNO + "%' order by ID");
        //    return DataTableToList(ds.Tables[0]);
        //}

        public List<com.surfkj.small.user.Model.Customer> ListLookCustomer(int pageno, int pagesize, string filed, string name)
        {
            DataSet ds = dal.ListLookCustomer(pageno, pagesize, filed, name);
            return DataTableToList(ds.Tables[0]);
        }

        #endregion  Method
    }
}

