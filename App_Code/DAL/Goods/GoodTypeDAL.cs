using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using com.surfkj.small.Common;
namespace com.surfkj.small.goods.DAL
{
	/// <summary>
	/// 数据访问类:GoodType
	/// </summary>
	public partial class GoodTypeDAL
	{
        public GoodTypeDAL()
		{}
		#region  Method

		 

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_GoodType");
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
		public int Add(com.surfkj.small.goods.Model.GoodType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_GoodType(");
			strSql.Append("typeName,parent,Tlevel,memo,additional)");
			strSql.Append(" values (");
			strSql.Append("@typeName,@parent,@Tlevel,@memo,@additional)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@typeName", SqlDbType.VarChar),
					new SqlParameter("@parent", SqlDbType.Int,4),
					new SqlParameter("@Tlevel", SqlDbType.VarChar),
					new SqlParameter("@memo", SqlDbType.VarChar),
					new SqlParameter("@additional", SqlDbType.Int,4)};
			parameters[0].Value = model.typeName;
			parameters[1].Value = model.parent;
			parameters[2].Value = model.Tlevel;
			parameters[3].Value = model.memo;
			parameters[4].Value = model.additional;

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
		public bool Update(com.surfkj.small.goods.Model.GoodType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_GoodType set ");
			strSql.Append("typeName=@typeName,");
			strSql.Append("parent=@parent,");
			strSql.Append("Tlevel=@Tlevel,");
			strSql.Append("memo=@memo,");
			strSql.Append("additional=@additional");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@typeName", SqlDbType.VarChar),
					new SqlParameter("@parent", SqlDbType.Int,4),
					new SqlParameter("@Tlevel", SqlDbType.VarChar),
					new SqlParameter("@memo", SqlDbType.VarChar),
					new SqlParameter("@additional", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.typeName;
			parameters[1].Value = model.parent;
			parameters[2].Value = model.Tlevel;
			parameters[3].Value = model.memo;
			parameters[4].Value = model.additional;
			parameters[5].Value = model.ID;

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
			strSql.Append("delete from T_GoodType ");
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
			strSql.Append("delete from T_GoodType ");
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
		public com.surfkj.small.goods.Model.GoodType GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,typeName,parent,Tlevel,memo,additional from T_GoodType ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			com.surfkj.small.goods.Model.GoodType model=new com.surfkj.small.goods.Model.GoodType();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["typeName"]!=null && ds.Tables[0].Rows[0]["typeName"].ToString()!="")
				{
					model.typeName=ds.Tables[0].Rows[0]["typeName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["parent"]!=null && ds.Tables[0].Rows[0]["parent"].ToString()!="")
				{
					model.parent=int.Parse(ds.Tables[0].Rows[0]["parent"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Tlevel"]!=null && ds.Tables[0].Rows[0]["Tlevel"].ToString()!="")
				{
					model.Tlevel=ds.Tables[0].Rows[0]["Tlevel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["memo"]!=null && ds.Tables[0].Rows[0]["memo"].ToString()!="")
				{
					model.memo=ds.Tables[0].Rows[0]["memo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["additional"]!=null && ds.Tables[0].Rows[0]["additional"].ToString()!="")
				{
					model.additional=int.Parse(ds.Tables[0].Rows[0]["additional"].ToString());
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
			strSql.Append("select ID,typeName,parent,Tlevel,memo,additional ");
			strSql.Append(" FROM T_GoodType ");
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
			strSql.Append(" ID,typeName,parent,Tlevel,memo,additional ");
			strSql.Append(" FROM T_GoodType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_GoodType";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

         public DataSet ListPageGoodType(int pageno, int pagesize)
        {
            int rowcount = this.GetTotalRecordNum();
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_GoodType ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_GoodType )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public DataSet ListLookGoodType(int pageno, int pagesize, string filed, string name) 
        {
            int rowcount = this.GetInqueryNum(filed, name);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_GoodType where " + filed + " like '%" + name + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_GoodType where " + filed + " like '%" + name + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public int GetTotalRecordNum()
        {
            int rows = DBHelperSQL.countNum("T_GoodType");
            return rows;
        }

        public int GetInqueryNum(string filed, string str) 
        {
            int rows = DBHelperSQL.GetInqueryNum(filed, str, "T_GoodType");
            return rows;
        }
        #endregion  Method
    }



}

