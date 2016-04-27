using System;
using System.Data;
using System.Collections.Generic;
//using Maticsoft.Common;
using com.surfkj.small.goods.Model;
namespace com.surfkj.small.goods.BLL
{
	/// <summary>
	/// GoodAtrribute
	/// </summary>
	public partial class GoodAtrributeService
	{
		private readonly com.surfkj.small.goods.DAL.GoodAtrributeDAL dal=new com.surfkj.small.goods.DAL.GoodAtrributeDAL();
        public GoodAtrributeService()
		{}
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
		public int  Add(com.surfkj.small.goods.Model.GoodAtrribute model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(com.surfkj.small.goods.Model.GoodAtrribute model)
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
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public com.surfkj.small.goods.Model.GoodAtrribute GetModel(int ID)
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<com.surfkj.small.goods.Model.GoodAtrribute> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<com.surfkj.small.goods.Model.GoodAtrribute> DataTableToList(DataTable dt)
		{
			List<com.surfkj.small.goods.Model.GoodAtrribute> modelList = new List<com.surfkj.small.goods.Model.GoodAtrribute>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				com.surfkj.small.goods.Model.GoodAtrribute model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new com.surfkj.small.goods.Model.GoodAtrribute();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["AttributeName"]!=null && dt.Rows[n]["AttributeName"].ToString()!="")
					{
					model.AttributeName=dt.Rows[n]["AttributeName"].ToString();
					}
					if(dt.Rows[n]["state"]!=null && dt.Rows[n]["state"].ToString()!="")
					{
						model.state=int.Parse(dt.Rows[n]["state"].ToString());
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
        public List<com.surfkj.small.goods.Model.GoodAtrribute> ListPageGoodAttributes(int pageno, int pagesize)
        {

            DataSet ds = dal.ListPageAttribute(pageno, pagesize);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// 
        public List<com.surfkj.small.goods.Model.GoodAtrribute> GetGoodAttributesByName(string name)
        {


            DataSet ds = dal.GetList(" AttributeName like '%" + name + "%' order by ID ");
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.goods.Model.GoodAtrribute> ListLookGoodsAttributes(int pageno, int pagesize, string filed, string name)
        {
            DataSet ds = dal.ListLookGoodAttribute(pageno, pagesize, filed, name);
            return DataTableToList(ds.Tables[0]);
        }

		#endregion  Method
	}
}

