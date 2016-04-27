using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Data;
using System.Collections.Generic;
using com.surfkj.small.Common;
using com.surfkj.small.Model.AdvAttachment;
namespace com.surfkj.small.BLL.AdvAttachment
{
    /// <summary>
    /// T_AdvAttachment
    /// </summary>
    public partial class AdvAttachmentService
    {
        private readonly com.surfkj.small.DAL.AdvAttachment.AdvAttachmentDAL dal = new com.surfkj.small.DAL.AdvAttachment.AdvAttachmentDAL();
        public AdvAttachmentService()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(com.surfkj.small.Model.AdvAttachment.AdvAttachment model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(com.surfkj.small.Model.AdvAttachment.AdvAttachment model)
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
        public com.surfkj.small.Model.AdvAttachment.AdvAttachment GetModel(int ID)
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
        public List<com.surfkj.small.Model.AdvAttachment.AdvAttachment> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<com.surfkj.small.Model.AdvAttachment.AdvAttachment> DataTableToList(DataTable dt)
        {
            List<com.surfkj.small.Model.AdvAttachment.AdvAttachment> modelList = new List<com.surfkj.small.Model.AdvAttachment.AdvAttachment>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                com.surfkj.small.Model.AdvAttachment.AdvAttachment model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new com.surfkj.small.Model.AdvAttachment.AdvAttachment();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["attachType"] != null && dt.Rows[n]["attachType"].ToString() != "")
                    {
                        model.attachType = int.Parse(dt.Rows[n]["attachType"].ToString());
                    }
                    if (dt.Rows[n]["attachUrl"] != null && dt.Rows[n]["attachUrl"].ToString() != "")
                    {
                        model.attachUrl = dt.Rows[n]["attachUrl"].ToString();
                    }
                    if (dt.Rows[n]["attachName"] != null && dt.Rows[n]["attachName"].ToString() != "")
                    {
                        model.attachName = dt.Rows[n]["attachName"].ToString();
                    }
                    if (dt.Rows[n]["advID"] != null && dt.Rows[n]["advID"].ToString() != "")
                    {
                        model.advID = int.Parse(dt.Rows[n]["advID"].ToString());
                    }
                    if (dt.Rows[n]["addDate"] != null && dt.Rows[n]["addDate"].ToString() != "")
                    {
                        model.addDate = DateTime.Parse(dt.Rows[n]["addDate"].ToString());
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