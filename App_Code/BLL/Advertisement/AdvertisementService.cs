using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections.Generic;
using com.surfkj.small.Common;
using com.surfkj.small.Model.Advertisement;
namespace com.surfkj.small.BLL.Advertisement
{
    /// <summary>
    /// T_Advertisement
    /// </summary>
    public partial class AdvertisementService
    {
        private readonly com.surfkj.small.DAL.Advertisement.AdvertisementDAL dal = new com.surfkj.small.DAL.Advertisement.AdvertisementDAL();
        public AdvertisementService()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(com.surfkj.small.Model.Advertisement.Advertisement model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(com.surfkj.small.Model.Advertisement.Advertisement model)
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
        public com.surfkj.small.Model.Advertisement.Advertisement GetModel(int ID)
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
        public List<com.surfkj.small.Model.Advertisement.Advertisement> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.Model.Advertisement.Advertisement> GetTopModelList(int Top, string strWhere, string filedOrder)
        {
            DataSet ds = dal.GetList(Top, strWhere, filedOrder);
            return DataTableToList(ds.Tables[0]);
        }


        //获得前几行数据

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<com.surfkj.small.Model.Advertisement.Advertisement> DataTableToList(DataTable dt)
        {
            List<com.surfkj.small.Model.Advertisement.Advertisement> modelList = new List<com.surfkj.small.Model.Advertisement.Advertisement>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                com.surfkj.small.Model.Advertisement.Advertisement model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new com.surfkj.small.Model.Advertisement.Advertisement();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["AdveType"] != null && dt.Rows[n]["AdveType"].ToString() != "")
                    {
                        model.AdveType = int.Parse(dt.Rows[n]["AdveType"].ToString());
                    }
                    if (dt.Rows[n]["ImgUrl"] != null && dt.Rows[n]["ImgUrl"].ToString() != "")
                    {
                        model.ImgUrl = dt.Rows[n]["ImgUrl"].ToString();
                    }
                    if (dt.Rows[n]["Url"] != null && dt.Rows[n]["Url"].ToString() != "")
                    {
                        model.Url = dt.Rows[n]["Url"].ToString();
                    }
                    if (dt.Rows[n]["Imgsize"] != null && dt.Rows[n]["Imgsize"].ToString() != "")
                    {
                        model.Imgsize = float.Parse(dt.Rows[n]["Imgsize"].ToString());
                    }
                    if (dt.Rows[n]["AdveOrder"] != null && dt.Rows[n]["AdveOrder"].ToString() != "")
                    {
                        model.AdveOrder = int.Parse(dt.Rows[n]["AdveOrder"].ToString());
                    }
                    if (dt.Rows[n]["Description"] != null && dt.Rows[n]["Description"].ToString() != "")
                    {
                        model.Description = dt.Rows[n]["Description"].ToString();
                    }
                    if (dt.Rows[n]["UpdateTime"] != null && dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
                    }
                    if (dt.Rows[n]["State"] != null && dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
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