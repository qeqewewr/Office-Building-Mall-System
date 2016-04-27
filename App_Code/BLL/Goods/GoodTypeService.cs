using System;
using System.Data;
using System.Collections.Generic;
//using Maticsoft.Common;
using com.surfkj.small.goods.Model;
namespace com.surfkj.small.goods.BLL
{
	/// <summary>
	/// GoodType
	/// </summary>
	public partial class GoodTypeService
	{
        private readonly com.surfkj.small.goods.DAL.GoodTypeDAL dal = new com.surfkj.small.goods.DAL.GoodTypeDAL();
        public GoodTypeService()
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
		public int  Add(com.surfkj.small.goods.Model.GoodType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(com.surfkj.small.goods.Model.GoodType model)
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
		public com.surfkj.small.goods.Model.GoodType GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		 

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<com.surfkj.small.goods.Model.GoodType> GetList(string strWhere)
		{
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
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
		public List<com.surfkj.small.goods.Model.GoodType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<com.surfkj.small.goods.Model.GoodType> DataTableToList(DataTable dt)
		{
			List<com.surfkj.small.goods.Model.GoodType> modelList = new List<com.surfkj.small.goods.Model.GoodType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				com.surfkj.small.goods.Model.GoodType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new com.surfkj.small.goods.Model.GoodType();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["typeName"]!=null && dt.Rows[n]["typeName"].ToString()!="")
					{
					model.typeName=dt.Rows[n]["typeName"].ToString();
					}
					if(dt.Rows[n]["parent"]!=null && dt.Rows[n]["parent"].ToString()!="")
					{
						model.parent=int.Parse(dt.Rows[n]["parent"].ToString());
					}
					if(dt.Rows[n]["Tlevel"]!=null && dt.Rows[n]["Tlevel"].ToString()!="")
					{
					model.Tlevel=dt.Rows[n]["Tlevel"].ToString();
					}
					if(dt.Rows[n]["memo"]!=null && dt.Rows[n]["memo"].ToString()!="")
					{
					model.memo=dt.Rows[n]["memo"].ToString();
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
        public List<com.surfkj.small.goods.Model.GoodType> GetAllList()
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
        public List<com.surfkj.small.goods.Model.GoodType> ListPageGoodType(int pageno, int pagesize)
        {

            DataSet ds = dal.ListPageGoodType(pageno, pagesize);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// 
        public List<com.surfkj.small.goods.Model.GoodType> GetGoodTypeByName(string name)
        {


            DataSet ds = dal.GetList("Name like '%" + name + "%' order by ID");
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.goods.Model.GoodType> ListLookGoodType(int pageno, int pagesize, string filed, string name)
        {
            DataSet ds = dal.ListLookGoodType(pageno, pagesize, filed, name);
            return DataTableToList(ds.Tables[0]);
        }

		#endregion  Method
	}
}

