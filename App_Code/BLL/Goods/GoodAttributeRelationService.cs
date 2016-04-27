using System;
using System.Data;
using System.Collections.Generic;
//using Maticsoft.Common;
using com.surfkj.small.goods.Model;
namespace com.surfkj.small.goods.BLL
{
	/// <summary>
	/// GoodAttributeRelation
	/// </summary>
	public partial class GoodAttributeRelationService
	{
		private readonly com.surfkj.small.goods.DAL.GoodAttributeRelationDAL dal=new com.surfkj.small.goods.DAL.GoodAttributeRelationDAL();
        public GoodAttributeRelationService()
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
		public int  Add(com.surfkj.small.goods.Model.GoodAttributeRelation model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(com.surfkj.small.goods.Model.GoodAttributeRelation model)
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
		public com.surfkj.small.goods.Model.GoodAttributeRelation GetModel(int ID)
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
		public List<com.surfkj.small.goods.Model.GoodAttributeRelation> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<com.surfkj.small.goods.Model.GoodAttributeRelation> DataTableToList(DataTable dt)
		{
			List<com.surfkj.small.goods.Model.GoodAttributeRelation> modelList = new List<com.surfkj.small.goods.Model.GoodAttributeRelation>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				com.surfkj.small.goods.Model.GoodAttributeRelation model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new com.surfkj.small.goods.Model.GoodAttributeRelation();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["goodType"]!=null && dt.Rows[n]["goodType"].ToString()!="")
					{
						model.goodType=int.Parse(dt.Rows[n]["goodType"].ToString());
					}
					if(dt.Rows[n]["goodAttribute"]!=null && dt.Rows[n]["goodAttribute"].ToString()!="")
					{
						model.goodAttribute=int.Parse(dt.Rows[n]["goodAttribute"].ToString());
					}
					if(dt.Rows[n]["additional"]!=null && dt.Rows[n]["additional"].ToString()!="")
					{
						model.additional=int.Parse(dt.Rows[n]["additional"].ToString());
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
        public List<com.surfkj.small.goods.Model.GoodAttributeRelation> ListPageCleaner(int pageno, int pagesize)
        {

            DataSet ds = dal.ListPageAttributeRelation(pageno, pagesize);
            return DataTableToList(ds.Tables[0]);
        }



		#endregion  Method
	}
}

