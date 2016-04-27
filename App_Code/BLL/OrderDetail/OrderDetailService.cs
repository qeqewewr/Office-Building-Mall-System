using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using com.surfkj.small.DAL.OrderDetailDAL;
using com.surfkj.small.Model;
namespace com.surfkj.small.BLL.OrderDetail
{
    /// <summary>
    /// T_OrderDetail
    /// </summary>
    public partial class OrderDetailService
    {
        OrderDetailDAL dal = new OrderDetailDAL();
        public OrderDetailService()
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
        public int Add(com.surfkj.small.Model.OrderDetail model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(com.surfkj.small.Model.OrderDetail model)
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
        public com.surfkj.small.Model.OrderDetail GetModel(int ID)
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
        public List<com.surfkj.small.Model.OrderDetail> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<com.surfkj.small.Model.OrderDetail> DataTableToList(DataTable dt)
        {
            List<com.surfkj.small.Model.OrderDetail> modelList = new List<com.surfkj.small.Model.OrderDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                com.surfkj.small.Model.OrderDetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new com.surfkj.small.Model.OrderDetail();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    if (dt.Rows[n]["goodID"] != null && dt.Rows[n]["goodID"].ToString() != "")
                    {
                        model.goodID = int.Parse(dt.Rows[n]["goodID"].ToString());
                    }
                    if (dt.Rows[n]["goodPrice"] != null && dt.Rows[n]["goodPrice"].ToString() != "")
                    {
                        model.goodPrice = float.Parse(dt.Rows[n]["goodPrice"].ToString());
                    }
                    if (dt.Rows[n]["goodDiscount"] != null && dt.Rows[n]["goodDiscount"].ToString() != "")
                    {
                        model.goodDiscount = float.Parse(dt.Rows[n]["goodDiscount"].ToString());
                    }
                    if (dt.Rows[n]["goodQuantity"] != null && dt.Rows[n]["goodQuantity"].ToString() != "")
                    {
                        model.goodQuantity = float.Parse(dt.Rows[n]["goodQuantity"].ToString());
                    }
                    if (dt.Rows[n]["goodAmount"] != null && dt.Rows[n]["goodAmount"].ToString() != "")
                    {
                        model.goodAmount = float.Parse(dt.Rows[n]["goodAmount"].ToString());
                    }
                    if (dt.Rows[n]["state"] != null && dt.Rows[n]["state"].ToString() != "")
                    {
                        model.state = int.Parse(dt.Rows[n]["state"].ToString());
                    }
                    if (dt.Rows[n]["finalAmount"] != null && dt.Rows[n]["finalAmount"].ToString() != "")
                    {
                        model.finalAmount = float.Parse(dt.Rows[n]["finalAmount"].ToString());
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

