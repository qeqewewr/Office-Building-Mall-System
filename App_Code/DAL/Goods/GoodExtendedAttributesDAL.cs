using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using com.surfkj.small.Common;
//using Maticsoft.DBUtility;//Please add references
namespace com.surfkj.small.goods.DAL
{
	/// <summary>
	/// 数据访问类:GoodExtendedAttributes
	/// </summary>
	public partial class GoodExtendedAttributesDAL
	{
        public GoodExtendedAttributesDAL()
		{}
		#region  Method

        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //return DBHelperSQL.GetMaxID("ID", "T_GoodExtendedAttributes"); 
        //}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_GoodExtendedAttributes");
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
		public int Add(com.surfkj.small.goods.Model.GoodExtendedAttributes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_GoodExtendedAttributes(");
			strSql.Append("attributeName,goodID,additional)");
			strSql.Append(" values (");
			strSql.Append("@attributeName,@goodID,@additional)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@attributeName", SqlDbType.VarChar),
					new SqlParameter("@goodID", SqlDbType.Int,4),
					new SqlParameter("@additional", SqlDbType.Int,4)};
			parameters[0].Value = model.attributeName;
			parameters[1].Value = model.goodID;
			parameters[2].Value = model.additional;

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
		public bool Update(com.surfkj.small.goods.Model.GoodExtendedAttributes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_GoodExtendedAttributes set ");
			strSql.Append("attributeName=@attributeName,");
			strSql.Append("goodID=@goodID,");
			strSql.Append("additional=@additional");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@attributeName", SqlDbType.VarChar),
					new SqlParameter("@goodID", SqlDbType.Int,4),
					new SqlParameter("@additional", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.attributeName;
			parameters[1].Value = model.goodID;
			parameters[2].Value = model.additional;
			parameters[3].Value = model.ID;

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
			strSql.Append("delete from T_GoodExtendedAttributes ");
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
			strSql.Append("delete from T_GoodExtendedAttributes ");
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
		public com.surfkj.small.goods.Model.GoodExtendedAttributes GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,attributeName,goodID,additional from T_GoodExtendedAttributes ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			com.surfkj.small.goods.Model.GoodExtendedAttributes model=new com.surfkj.small.goods.Model.GoodExtendedAttributes();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["attributeName"]!=null && ds.Tables[0].Rows[0]["attributeName"].ToString()!="")
				{
					model.attributeName=ds.Tables[0].Rows[0]["attributeName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["goodID"]!=null && ds.Tables[0].Rows[0]["goodID"].ToString()!="")
				{
					model.goodID=int.Parse(ds.Tables[0].Rows[0]["goodID"].ToString());
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
			strSql.Append("select ID,attributeName,goodID,additional ");
			strSql.Append(" FROM T_GoodExtendedAttributes ");
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
			strSql.Append(" ID,attributeName,goodID,additional ");
			strSql.Append(" FROM T_GoodExtendedAttributes ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelperSQL.Query(strSql.ToString());
		}

        public DataSet ListPageExtendedAttributes(int pageno, int pagesize)
        {
            int rowcount = this.GetTotalRecordNum();
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_GoodAttributeRelation ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_GoodAttributeRelation )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public DataSet ListLookAttributeRelation(int pageno, int pagesize, string filed, string name)
        {
            int rowcount = this.GetInqueryNum(filed, name);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_GoodAttributeRelation where " + filed + " like '%" + name + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_GoodAttributeRelation where " + filed + " like '%" + name + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public int GetTotalRecordNum()
        {
            int rows = DBHelperSQL.countNum("T_GoodAttributeRelation");
            return rows;
        }

        public int GetInqueryNum(string filed, string str)
        {
            int rows = DBHelperSQL.GetInqueryNum(filed, str, "T_GoodAttributeRelation");
            return rows;
        }


		#endregion  Method
	}
}

