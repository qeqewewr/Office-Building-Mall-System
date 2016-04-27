using System;
using System.Data;
using System.Collections.Generic;


using com.surfkj.small.Model;
using com.surfkj.small.DAL;


/// <summary>
///StaffService 的摘要说明
/// </summary>
public class StaffService
{
	public StaffService()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

 
      
 
      
        #region  Method 
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StaffDAL dal = new StaffDAL(); 
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(com.surfkj.small.Model.Staff model)
        {
            StaffDAL dal = new StaffDAL(); 
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(com.surfkj.small.Model.Staff model)
        {
            StaffDAL dal = new StaffDAL(); 
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StaffDAL dal = new StaffDAL(); 
            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StaffDAL dal = new StaffDAL(); 
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public com.surfkj.small.Model.Staff GetModel(int id)
        {
            StaffDAL dal = new StaffDAL(); 
            return dal.GetModel(id);
        }
     
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StaffDAL dal = new StaffDAL(); 
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StaffDAL dal = new StaffDAL(); 
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<com.surfkj.small.Model.Staff> GetModelList(string strWhere)
        {
            StaffDAL dal = new StaffDAL(); 
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<com.surfkj.small.Model.Staff> DataTableToList(DataTable dt)
        {
            List<com.surfkj.small.Model.Staff> modelList = new List<com.surfkj.small.Model.Staff>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                com.surfkj.small.Model.Staff model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new com.surfkj.small.Model.Staff();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["name"] != null && dt.Rows[n]["name"].ToString() != "")
                    {
                        model.name = dt.Rows[n]["name"].ToString();
                    }
                    if (dt.Rows[n]["birth"] != null && dt.Rows[n]["birth"].ToString() != "")
                    {
                        model.birth = DateTime.Parse(dt.Rows[n]["birth"].ToString());
                    }
                    if (dt.Rows[n]["education"] != null && dt.Rows[n]["education"].ToString() != "")
                    {
                        model.education = dt.Rows[n]["education"].ToString();
                    }
                    if (dt.Rows[n]["enterDate"] != null && dt.Rows[n]["enterDate"].ToString() != "")
                    {
                        model.enterDate = DateTime.Parse(dt.Rows[n]["enterDate"].ToString());
                    }
                    if (dt.Rows[n]["post"] != null && dt.Rows[n]["post"].ToString() != "")
                    {
                        model.post = dt.Rows[n]["post"].ToString();
                    }
                    if (dt.Rows[n]["officeTel"] != null && dt.Rows[n]["officeTel"].ToString() != "")
                    {
                        model.officeTel = dt.Rows[n]["officeTel"].ToString();
                    }
                    if (dt.Rows[n]["mobile"] != null && dt.Rows[n]["mobile"].ToString() != "")
                    {
                        model.mobile = dt.Rows[n]["mobile"].ToString();
                    }
                    if (dt.Rows[n]["IDNumber"] != null && dt.Rows[n]["IDNumber"].ToString() != "")
                    {
                        model.IDNumber = dt.Rows[n]["IDNumber"].ToString();
                    }
                    if (dt.Rows[n]["homeAddress"] != null && dt.Rows[n]["homeAddress"].ToString() != "")
                    {
                        model.homeAddress = dt.Rows[n]["homeAddress"].ToString();
                    }
                    if (dt.Rows[n]["homeTel"] != null && dt.Rows[n]["homeTel"].ToString() != "")
                    {
                        model.homeTel = dt.Rows[n]["homeTel"].ToString();
                    }
                    if (dt.Rows[n]["memo"] != null && dt.Rows[n]["memo"].ToString() != "")
                    {
                        model.memo = dt.Rows[n]["memo"].ToString();
                    }
                    if (dt.Rows[n]["isDeleted"] != null && dt.Rows[n]["isDeleted"].ToString() != "")
                    {
                        model.isDeleted = dt.Rows[n]["isDeleted"].ToString();
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