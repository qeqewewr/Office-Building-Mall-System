using System;
using System.Data;
using System.Collections.Generic;
 
using com.surfkj.small.goods.Model;
namespace com.surfkj.small.goods.BLL
{
	/// <summary>
	/// Goods
	/// </summary>
	public partial class GoodsService
	{
        private readonly com.surfkj.small.goods.DAL.GoodsDAL dal = new com.surfkj.small.goods.DAL.GoodsDAL();
        public GoodsService()
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
		public int  Add(com.surfkj.small.goods.Model.Goods model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(com.surfkj.small.goods.Model.Goods model)
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
		public com.surfkj.small.goods.Model.Goods GetModel(int ID)
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
		 public List<com.surfkj.small.goods.Model.Goods> GetList(int Top, string strWhere, string filedOrder)
		{
            		return DataTableToList(dal.GetList(Top, strWhere, filedOrder).Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<com.surfkj.small.goods.Model.Goods> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<com.surfkj.small.goods.Model.Goods> DataTableToList(DataTable dt)
		{
			List<com.surfkj.small.goods.Model.Goods> modelList = new List<com.surfkj.small.goods.Model.Goods>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				com.surfkj.small.goods.Model.Goods model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new com.surfkj.small.goods.Model.Goods();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["goodType"]!=null && dt.Rows[n]["goodType"].ToString()!="")
					{
						model.goodType=int.Parse(dt.Rows[n]["goodType"].ToString());
					}
					if(dt.Rows[n]["goodNO"]!=null && dt.Rows[n]["goodNO"].ToString()!="")
					{
					model.goodNO=dt.Rows[n]["goodNO"].ToString();
					}
					if(dt.Rows[n]["goodName"]!=null && dt.Rows[n]["goodName"].ToString()!="")
					{
					model.goodName=dt.Rows[n]["goodName"].ToString();
					}
					if(dt.Rows[n]["goodBrand"]!=null && dt.Rows[n]["goodBrand"].ToString()!="")
					{
					model.goodBrand=dt.Rows[n]["goodBrand"].ToString();
					}
					if(dt.Rows[n]["goodManufacture"]!=null && dt.Rows[n]["goodManufacture"].ToString()!="")
					{
					model.goodManufacture=dt.Rows[n]["goodManufacture"].ToString();
					}
					if(dt.Rows[n]["goodOrg"]!=null && dt.Rows[n]["goodOrg"].ToString()!="")
					{
					model.goodOrg=dt.Rows[n]["goodOrg"].ToString();
					}
					if(dt.Rows[n]["goodKg"]!=null && dt.Rows[n]["goodKg"].ToString()!="")
					{
					model.goodKg=dt.Rows[n]["goodKg"].ToString();
					}
					if(dt.Rows[n]["goodNetKg"]!=null && dt.Rows[n]["goodNetKg"].ToString()!="")
					{
					model.goodNetKg=dt.Rows[n]["goodNetKg"].ToString();
					}
					if(dt.Rows[n]["goodColor"]!=null && dt.Rows[n]["goodColor"].ToString()!="")
					{
					model.goodColor=dt.Rows[n]["goodColor"].ToString();
					}
					if(dt.Rows[n]["goodSize"]!=null && dt.Rows[n]["goodSize"].ToString()!="")
					{
					model.goodSize=dt.Rows[n]["goodSize"].ToString();
					}
					if(dt.Rows[n]["goodSpecifications"]!=null && dt.Rows[n]["goodSpecifications"].ToString()!="")
					{
					model.goodSpecifications=dt.Rows[n]["goodSpecifications"].ToString();
					}
					if(dt.Rows[n]["goodMaterial"]!=null && dt.Rows[n]["goodMaterial"].ToString()!="")
					{
					model.goodMaterial=dt.Rows[n]["goodMaterial"].ToString();
					}
					if(dt.Rows[n]["goodPrice"]!=null && dt.Rows[n]["goodPrice"].ToString()!="")
					{
						model.goodPrice=decimal.Parse(dt.Rows[n]["goodPrice"].ToString());
					}
					if(dt.Rows[n]["goodMemo"]!=null && dt.Rows[n]["goodMemo"].ToString()!="")
					{
					model.goodMemo=dt.Rows[n]["goodMemo"].ToString();
					}
					if(dt.Rows[n]["goodHot"]!=null && dt.Rows[n]["goodHot"].ToString()!="")
					{
					model.goodHot=dt.Rows[n]["goodHot"].ToString();
					}
					if(dt.Rows[n]["goodPromotion"]!=null && dt.Rows[n]["goodPromotion"].ToString()!="")
					{
						model.goodPromotion=decimal.Parse(dt.Rows[n]["goodPromotion"].ToString());
					}
					if(dt.Rows[n]["goodRecommand"]!=null && dt.Rows[n]["goodRecommand"].ToString()!="")
					{
					model.goodRecommand=dt.Rows[n]["goodRecommand"].ToString();
					}
					if(dt.Rows[n]["goodBoutique"]!=null && dt.Rows[n]["goodBoutique"].ToString()!="")
					{
					model.goodBoutique=dt.Rows[n]["goodBoutique"].ToString();
					}
					if(dt.Rows[n]["goodStock"]!=null && dt.Rows[n]["goodStock"].ToString()!="")
					{
						model.goodStock=int.Parse(dt.Rows[n]["goodStock"].ToString());
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
		//}\\

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

        public int GetInqueryNum(string filed, string str, string filed2, string str2)
        {
            int rows = dal.GetInqueryNum(filed, str, filed2, str2);
            return rows;
        }

        /// <summary>
        /// 自定义分页
        /// </summary>
        public List<com.surfkj.small.goods.Model.Goods> ListPageGoods(int pageno, int pagesize)
        {

            DataSet ds = dal.ListPageGoods(pageno, pagesize);
            return DataTableToList(ds.Tables[0]);
        }

		public List<com.surfkj.small.goods.Model.Goods> ListPageGoods(int pageno, int pagesize, string where)
		{

			DataSet ds = dal.ListLookGoods(pageno, pagesize, where);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// 
        public List<com.surfkj.small.goods.Model.Goods> GetGoodsByName(string name)
        {


            DataSet ds = dal.GetList("Name like '%" + name + "%' order by ID");
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.goods.Model.Goods> ListLookGoods(int pageno, int pagesize, string filed, string name)
        {
            DataSet ds = dal.ListLookGoods(pageno, pagesize, filed, name);
            return DataTableToList(ds.Tables[0]);
        }

        public List<com.surfkj.small.goods.Model.Goods> ListLookGoods(int pageno, int pagesize, string filed, string name,string field2,string value2)
        {
            DataSet ds = dal.ListLookGoods(pageno, pagesize, filed, name, field2, value2);
            return DataTableToList(ds.Tables[0]);
        }

		#endregion  Method
	}
}

