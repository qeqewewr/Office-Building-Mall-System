using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using com.surfkj.small.Common;
//using Maticsoft.DBUtility;//Please add references
namespace com.surfkj.small.goods.DAL
{
	/// <summary>
	/// 数据访问类:Goods
	/// </summary>
	public partial class GoodsDAL
	{
        public GoodsDAL()
		{}
		#region  Method

		 

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Goods");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(com.surfkj.small.goods.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Goods(");
			strSql.Append("goodType,goodNO,goodName,goodBrand,goodManufacture,goodOrg,goodKg,goodNetKg,goodColor,goodSize,goodSpecifications,goodMaterial,goodPrice,goodMemo,goodHot,goodPromotion,goodRecommand,goodBoutique,goodStock,state)");
			strSql.Append(" values (");
			strSql.Append("@goodType,@goodNO,@goodName,@goodBrand,@goodManufacture,@goodOrg,@goodKg,@goodNetKg,@goodColor,@goodSize,@goodSpecifications,@goodMaterial,@goodPrice,@goodMemo,@goodHot,@goodPromotion,@goodRecommand,@goodBoutique,@goodStock,@state)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@goodType", SqlDbType.Int,4),
					new SqlParameter("@goodNO", SqlDbType.VarChar,50),
					new SqlParameter("@goodName", SqlDbType.NVarChar),
					new SqlParameter("@goodBrand", SqlDbType.VarChar,50),
					new SqlParameter("@goodManufacture", SqlDbType.VarChar,50),
					new SqlParameter("@goodOrg", SqlDbType.VarChar,255),
					new SqlParameter("@goodKg", SqlDbType.VarChar,50),
					new SqlParameter("@goodNetKg", SqlDbType.VarChar,50),
					new SqlParameter("@goodColor", SqlDbType.VarChar,50),
					new SqlParameter("@goodSize", SqlDbType.VarChar,50),
					new SqlParameter("@goodSpecifications", SqlDbType.VarChar,50),
					new SqlParameter("@goodMaterial", SqlDbType.VarChar,50),
					new SqlParameter("@goodPrice", SqlDbType.Float,8),
					new SqlParameter("@goodMemo", SqlDbType.NVarChar),
					new SqlParameter("@goodHot", SqlDbType.VarChar,10),
					new SqlParameter("@goodPromotion", SqlDbType.Float,8),
					new SqlParameter("@goodRecommand", SqlDbType.VarChar,10),
					new SqlParameter("@goodBoutique", SqlDbType.VarChar,10),
					new SqlParameter("@goodStock", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4)};
			parameters[0].Value = model.goodType;
			parameters[1].Value = model.goodNO;
			parameters[2].Value = model.goodName;
			parameters[3].Value = model.goodBrand;
			parameters[4].Value = model.goodManufacture;
			parameters[5].Value = model.goodOrg;
			parameters[6].Value = model.goodKg;
			parameters[7].Value = model.goodNetKg;
			parameters[8].Value = model.goodColor;
			parameters[9].Value = model.goodSize;
			parameters[10].Value = model.goodSpecifications;
			parameters[11].Value = model.goodMaterial;
			parameters[12].Value = model.goodPrice;
			parameters[13].Value = model.goodMemo;
			parameters[14].Value = model.goodHot;
			parameters[15].Value = model.goodPromotion;
			parameters[16].Value = model.goodRecommand;
			parameters[17].Value = model.goodBoutique;
			parameters[18].Value = model.goodStock;
			parameters[19].Value = model.state;

			object obj = DBHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(com.surfkj.small.goods.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Goods set ");
			strSql.Append("goodType=@goodType,");
			strSql.Append("goodNO=@goodNO,");
			strSql.Append("goodName=@goodName,");
			strSql.Append("goodBrand=@goodBrand,");
			strSql.Append("goodManufacture=@goodManufacture,");
			strSql.Append("goodOrg=@goodOrg,");
			strSql.Append("goodKg=@goodKg,");
			strSql.Append("goodNetKg=@goodNetKg,");
			strSql.Append("goodColor=@goodColor,");
			strSql.Append("goodSize=@goodSize,");
			strSql.Append("goodSpecifications=@goodSpecifications,");
			strSql.Append("goodMaterial=@goodMaterial,");
			strSql.Append("goodPrice=@goodPrice,");
			strSql.Append("goodMemo=@goodMemo,");
			strSql.Append("goodHot=@goodHot,");
			strSql.Append("goodPromotion=@goodPromotion,");
			strSql.Append("goodRecommand=@goodRecommand,");
			strSql.Append("goodBoutique=@goodBoutique,");
			strSql.Append("goodStock=@goodStock,");
			strSql.Append("state=@state");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@goodType", SqlDbType.Int,4),
					new SqlParameter("@goodNO", SqlDbType.VarChar,50),
					new SqlParameter("@goodName", SqlDbType.NVarChar),
					new SqlParameter("@goodBrand", SqlDbType.VarChar,50),
					new SqlParameter("@goodManufacture", SqlDbType.VarChar,50),
					new SqlParameter("@goodOrg", SqlDbType.VarChar,255),
					new SqlParameter("@goodKg", SqlDbType.VarChar,50),
					new SqlParameter("@goodNetKg", SqlDbType.VarChar,50),
					new SqlParameter("@goodColor", SqlDbType.VarChar,50),
					new SqlParameter("@goodSize", SqlDbType.VarChar,50),
					new SqlParameter("@goodSpecifications", SqlDbType.VarChar,50),
					new SqlParameter("@goodMaterial", SqlDbType.VarChar,50),
					new SqlParameter("@goodPrice", SqlDbType.Float,8),
					new SqlParameter("@goodMemo", SqlDbType.NVarChar),
					new SqlParameter("@goodHot", SqlDbType.VarChar,10),
					new SqlParameter("@goodPromotion", SqlDbType.Float,8),
					new SqlParameter("@goodRecommand", SqlDbType.VarChar,10),
					new SqlParameter("@goodBoutique", SqlDbType.VarChar,10),
					new SqlParameter("@goodStock", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.goodType;
			parameters[1].Value = model.goodNO;
			parameters[2].Value = model.goodName;
			parameters[3].Value = model.goodBrand;
			parameters[4].Value = model.goodManufacture;
			parameters[5].Value = model.goodOrg;
			parameters[6].Value = model.goodKg;
			parameters[7].Value = model.goodNetKg;
			parameters[8].Value = model.goodColor;
			parameters[9].Value = model.goodSize;
			parameters[10].Value = model.goodSpecifications;
			parameters[11].Value = model.goodMaterial;
			parameters[12].Value = model.goodPrice;
			parameters[13].Value = model.goodMemo;
			parameters[14].Value = model.goodHot;
			parameters[15].Value = model.goodPromotion;
			parameters[16].Value = model.goodRecommand;
			parameters[17].Value = model.goodBoutique;
			parameters[18].Value = model.goodStock;
			parameters[19].Value = model.state;
			parameters[20].Value = model.ID;

			int rows=DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Goods ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			int rows=DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Goods ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DBHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public com.surfkj.small.goods.Model.Goods GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,goodType,goodNO,goodName,goodBrand,goodManufacture,goodOrg,goodKg,goodNetKg,goodColor,goodSize,goodSpecifications,goodMaterial,goodPrice,goodMemo,goodHot,goodPromotion,goodRecommand,goodBoutique,goodStock,state from T_Goods ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			com.surfkj.small.goods.Model.Goods model=new com.surfkj.small.goods.Model.Goods();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["goodType"]!=null && ds.Tables[0].Rows[0]["goodType"].ToString()!="")
				{
					model.goodType=int.Parse(ds.Tables[0].Rows[0]["goodType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["goodNO"]!=null && ds.Tables[0].Rows[0]["goodNO"].ToString()!="")
				{
					model.goodNO=ds.Tables[0].Rows[0]["goodNO"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodName"]!=null && ds.Tables[0].Rows[0]["goodName"].ToString()!="")
				{
					model.goodName=ds.Tables[0].Rows[0]["goodName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodBrand"]!=null && ds.Tables[0].Rows[0]["goodBrand"].ToString()!="")
				{
					model.goodBrand=ds.Tables[0].Rows[0]["goodBrand"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodManufacture"]!=null && ds.Tables[0].Rows[0]["goodManufacture"].ToString()!="")
				{
					model.goodManufacture=ds.Tables[0].Rows[0]["goodManufacture"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodOrg"]!=null && ds.Tables[0].Rows[0]["goodOrg"].ToString()!="")
				{
					model.goodOrg=ds.Tables[0].Rows[0]["goodOrg"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodKg"]!=null && ds.Tables[0].Rows[0]["goodKg"].ToString()!="")
				{
					model.goodKg=ds.Tables[0].Rows[0]["goodKg"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodNetKg"]!=null && ds.Tables[0].Rows[0]["goodNetKg"].ToString()!="")
				{
					model.goodNetKg=ds.Tables[0].Rows[0]["goodNetKg"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodColor"]!=null && ds.Tables[0].Rows[0]["goodColor"].ToString()!="")
				{
					model.goodColor=ds.Tables[0].Rows[0]["goodColor"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodSize"]!=null && ds.Tables[0].Rows[0]["goodSize"].ToString()!="")
				{
					model.goodSize=ds.Tables[0].Rows[0]["goodSize"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodSpecifications"]!=null && ds.Tables[0].Rows[0]["goodSpecifications"].ToString()!="")
				{
					model.goodSpecifications=ds.Tables[0].Rows[0]["goodSpecifications"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodMaterial"]!=null && ds.Tables[0].Rows[0]["goodMaterial"].ToString()!="")
				{
					model.goodMaterial=ds.Tables[0].Rows[0]["goodMaterial"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodPrice"]!=null && ds.Tables[0].Rows[0]["goodPrice"].ToString()!="")
				{
					model.goodPrice=decimal.Parse(ds.Tables[0].Rows[0]["goodPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["goodMemo"]!=null && ds.Tables[0].Rows[0]["goodMemo"].ToString()!="")
				{
					model.goodMemo=ds.Tables[0].Rows[0]["goodMemo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodHot"]!=null && ds.Tables[0].Rows[0]["goodHot"].ToString()!="")
				{
					model.goodHot=ds.Tables[0].Rows[0]["goodHot"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodPromotion"]!=null && ds.Tables[0].Rows[0]["goodPromotion"].ToString()!="")
				{
					model.goodPromotion=decimal.Parse(ds.Tables[0].Rows[0]["goodPromotion"].ToString());
				}
				if(ds.Tables[0].Rows[0]["goodRecommand"]!=null && ds.Tables[0].Rows[0]["goodRecommand"].ToString()!="")
				{
					model.goodRecommand=ds.Tables[0].Rows[0]["goodRecommand"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodBoutique"]!=null && ds.Tables[0].Rows[0]["goodBoutique"].ToString()!="")
				{
					model.goodBoutique=ds.Tables[0].Rows[0]["goodBoutique"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodStock"]!=null && ds.Tables[0].Rows[0]["goodStock"].ToString()!="")
				{
					model.goodStock=int.Parse(ds.Tables[0].Rows[0]["goodStock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["state"]!=null && ds.Tables[0].Rows[0]["state"].ToString()!="")
				{
					model.state=int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,goodType,goodNO,goodName,goodBrand,goodManufacture,goodOrg,goodKg,goodNetKg,goodColor,goodSize,goodSpecifications,goodMaterial,goodPrice,goodMemo,goodHot,goodPromotion,goodRecommand,goodBoutique,goodStock,state ");
			strSql.Append(" FROM T_Goods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,goodType,goodNO,goodName,goodBrand,goodManufacture,goodOrg,goodKg,goodNetKg,goodColor,goodSize,goodSpecifications,goodMaterial,goodPrice,goodMemo,goodHot,goodPromotion,goodRecommand,goodBoutique,goodStock,state ");
			strSql.Append(" FROM T_Goods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelperSQL.Query(strSql.ToString());
		}

        public DataSet ListPageGoods(int pageno, int pagesize)
        {
            int rowcount = this.GetTotalRecordNum();
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Goods ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Goods )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

		public DataSet ListLookGoods(int pageno, int pagesize, string where)
		{
			int rowcount = DBHelperSQL.countNum("T_Goods", where);
			String sql;
			if (pageno * pagesize > rowcount)
				sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Goods where " + where + " ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
			else
				sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Goods where " + where + " )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

			return DBHelperSQL.Query(sql);
		}        

        public DataSet ListLookGoods(int pageno, int pagesize, string filed, string name)
        {
            int rowcount = this.GetInqueryNum(filed, name);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Goods where " + filed + " like '%" + name + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Goods where " + filed + " like '%" + name + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public DataSet ListLookGoods(int pageno, int pagesize, string filed1, string value1, string field2, string value2)
        {
            int rowcount = this.GetInqueryNum(filed1, value1,field2,value2);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Goods where " + filed1 + " =" + value1 + " and "+ field2 + " like '%"+ value2 +"%' ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Goods where " + filed1 + " =" + value1 + " and " + field2 + " like '%" + value2 + "%' )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public int GetTotalRecordNum()
        {
            int rows = DBHelperSQL.countNum("T_Goods");
            return rows;
        }

        public int GetInqueryNum(string filed, string str)
        {
            int rows = DBHelperSQL.GetInqueryNum(filed, str, "T_Goods");
            return rows;
        }

        public int GetInqueryNum(string filed, string str,string field2,string str2)
        {
            int rows = DBHelperSQL.GetInqueryNum(filed, str,field2,str2,"T_Goods");
            return rows;
        }

		#endregion  Method
	}
}

