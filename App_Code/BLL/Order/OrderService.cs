using System;
using System.Data;
using System.Collections.Generic; 
using com.surfkj.small.order.Model;
namespace com.surfkj.small.order.BLL
{
    /// <summary>
    /// Order
    /// </summary>
    public partial class OrderService
    {
        private readonly com.surfkj.small.order.DAL.OrderDAL dal = new com.surfkj.small.order.DAL.OrderDAL();
        public OrderService()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(com.surfkj.small.order.Model.Order model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(com.surfkj.small.order.Model.Order model)
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
        public com.surfkj.small.order.Model.Order GetModel(int ID)
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
        public List<com.surfkj.small.order.Model.Order> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<com.surfkj.small.order.Model.Order> DataTableToList(DataTable dt)
        {
            List<com.surfkj.small.order.Model.Order> modelList = new List<com.surfkj.small.order.Model.Order>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                com.surfkj.small.order.Model.Order model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new com.surfkj.small.order.Model.Order();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["customer"] != null && dt.Rows[n]["customer"].ToString() != "")
                    {
                        model.customer = int.Parse(dt.Rows[n]["customer"].ToString());
                    }
                    if (dt.Rows[n]["customerType"] != null && dt.Rows[n]["customerType"].ToString() != "")
                    {
                        model.customerType = dt.Rows[n]["customerType"].ToString();
                    }
                    if (dt.Rows[n]["payTime"] != null && dt.Rows[n]["payTime"].ToString() != "")
                    {
                        model.payTime = DateTime.Parse(dt.Rows[n]["payTime"].ToString());
                    }
                    if (dt.Rows[n]["Receiver"] != null && dt.Rows[n]["Receiver"].ToString() != "")
                    {
                        model.Receiver = dt.Rows[n]["Receiver"].ToString();
                    }
                    if (dt.Rows[n]["Tel"] != null && dt.Rows[n]["Tel"].ToString() != "")
                    {
                        model.Tel = dt.Rows[n]["Tel"].ToString();
                    }
                    if (dt.Rows[n]["addr"] != null && dt.Rows[n]["addr"].ToString() != "")
                    {
                        model.addr = dt.Rows[n]["addr"].ToString();
                    }
                    if (dt.Rows[n]["zip"] != null && dt.Rows[n]["zip"].ToString() != "")
                    {
                        model.zip = dt.Rows[n]["zip"].ToString();
                    }
                    if (dt.Rows[n]["Memo"] != null && dt.Rows[n]["Memo"].ToString() != "")
                    {
                        model.Memo = dt.Rows[n]["Memo"].ToString();
                    }
                    if (dt.Rows[n]["state"] != null && dt.Rows[n]["state"].ToString() != "")
                    {
                        model.state = int.Parse(dt.Rows[n]["state"].ToString());
                    }
                    if (dt.Rows[n]["orderNO"] != null && dt.Rows[n]["orderNO"].ToString() != "")
                    {
                        model.orderNO = dt.Rows[n]["orderNO"].ToString();
                    }
                    if (dt.Rows[n]["orderStatus"] != null && dt.Rows[n]["orderStatus"].ToString() != "")
                    {
                        model.orderStatus = dt.Rows[n]["orderStatus"].ToString();
                    }
                    if (dt.Rows[n]["payType"] != null && dt.Rows[n]["payType"].ToString() != "")
                    {
                        model.payType = int.Parse(dt.Rows[n]["payType"].ToString());
                    }
                    if (dt.Rows[n]["message"] != null && dt.Rows[n]["message"].ToString() != "")
                    {
                        model.message = dt.Rows[n]["message"].ToString();
                    }
                    if (dt.Rows[n]["reply"] != null && dt.Rows[n]["reply"].ToString() != "")
                    {
                        model.reply = dt.Rows[n]["reply"].ToString();
                    }
                    if (dt.Rows[n]["deliveryInfo"] != null && dt.Rows[n]["deliveryInfo"].ToString() != "")
                    {
                        model.deliveryInfo = dt.Rows[n]["deliveryInfo"].ToString();
                    }
                    if (dt.Rows[n]["signer"] != null && dt.Rows[n]["signer"].ToString() != "")
                    {
                        model.signer = dt.Rows[n]["signer"].ToString();
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


        public int GetOrderInqueryNum(string receiver, string num, string status)
        {
            int rows = dal.GetOrderInqueryNum(receiver, num, status);
            return rows;
        }

        /// <summary>
        /// 自定义分页
        /// </summary>
        public List<com.surfkj.small.order.Model.Order> ListPageOrder(int pageno, int pagesize)
        {

            DataSet ds = dal.ListPageOrder(pageno, pagesize);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// 
        public List<com.surfkj.small.order.Model.Order> GetOrderByNO(string orderNO)
        {


            DataSet ds = dal.GetList(" orderNO like '%" + orderNO + "%' order by ID");
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.order.Model.Order> GetOrderInquery(string receiver, string num, string status)
        {
            DataSet ds = dal.GetList("Receiver like '%" + receiver + "%' and orderStatus like '%" + status + "%' and orderNO like '%" + num + "%'");
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.order.Model.Order> GetOrderInquery2(string num, string status)
        {
            DataSet ds = dal.GetList("orderStatus like '%" + status + "%' and orderNO like '%" + num + "%'");
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.order.Model.Order> GetOrderInquery3(string receiver, string num)
        {
            DataSet ds = dal.GetList("Receiver like '%" + receiver + "%' and orderNO like '%" + num + "%'");
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.order.Model.Order> GetOrderInquery4(string receiver, string status)
        {
            DataSet ds = dal.GetList("Receiver like '%" + receiver + "%' and orderStatus like '%" + status + "%'");
            return DataTableToList(ds.Tables[0]);
        }
        public List<com.surfkj.small.order.Model.Order> GetOrderInquery5(string status)
        {
            DataSet ds = dal.GetList("orderStatus like '%" + status + "%'");
            return DataTableToList(ds.Tables[0]);
        }
        public List<com.surfkj.small.order.Model.Order> GetOrderInquery6(string receiver)
        {
            DataSet ds = dal.GetList("Receiver like '%" + receiver + "%'");
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.order.Model.Order> ListLookOrder(int pageno, int pagesize, string filed, string name)
        {
            DataSet ds = dal.ListLookOrder(pageno, pagesize, filed, name);
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.order.Model.Order> ListLookOrder2(int pageno, int pagesize, string receiver, string num, string status)
        {
            DataSet ds = dal.ListLookOrder2(pageno, pagesize, receiver, num, status);
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.order.Model.Order> ListLookOrder3(int pageno, int pagesize, int row , string num, string status)
        {
            DataSet ds = dal.ListLookOrder3(pageno, pagesize, row, num, status);
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.order.Model.Order> ListLookOrder4(int pageno, int pagesize, int row, string receiver, string num)
        {
            DataSet ds = dal.ListLookOrder4(pageno, pagesize,  row, receiver, num);
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.order.Model.Order> ListLookOrder5(int pageno, int pagesize, int row, string receiver, string scope)
        {
            DataSet ds = dal.ListLookOrder5(pageno, pagesize, row, receiver, scope);
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.order.Model.Order> ListLookOrder6(int pageno, int pagesize, int row, string scope)
        {
            DataSet ds = dal.ListLookOrder6(pageno, pagesize, row, scope);
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.order.Model.Order> ListLookOrder7(int pageno, int pagesize, int row, string receiver)
        {
            DataSet ds = dal.ListLookOrder7(pageno, pagesize, row, receiver);
            return DataTableToList(ds.Tables[0]);
        }

        #endregion  Method
    }
}

