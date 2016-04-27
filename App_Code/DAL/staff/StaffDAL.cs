using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using com.surfkj.small.Common;

/// <summary>
///StaffDAL 的摘要说明
/// </summary>

namespace com.surfkj.small.DAL 
{
    public class StaffDAL
    {
        public StaffDAL()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        #region 公用方法
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Staff");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
        };
            parameters[0].Value = id;

            return DBHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// 增加一条数据
        /// </summary>
        public int Add(com.surfkj.small.Model.Staff model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Staff(");
            strSql.Append("name,birth,education,enterDate,leaveDate,post,officeTel,mobile,IDNumber,homeAddress,homeTel,memo,isDeleted)");
            strSql.Append(" values (");
            strSql.Append("@name,@birth,@education,@enterDate,@leaveDate,@post,@officeTel,@mobile,@IDNumber,@homeAddress,@homeTel,@memo,@isDeleted)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@birth", SqlDbType.Date,3),
					new SqlParameter("@education", SqlDbType.VarChar,50),
					new SqlParameter("@enterDate", SqlDbType.Date,3),
                    new SqlParameter("@leaveDate", SqlDbType.Date,3),
					new SqlParameter("@post", SqlDbType.VarChar,50),
					new SqlParameter("@officeTel", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
					new SqlParameter("@IDNumber", SqlDbType.VarChar,50),
					new SqlParameter("@homeAddress", SqlDbType.VarChar,255),
					new SqlParameter("@homeTel", SqlDbType.NChar,10),
					new SqlParameter("@memo", SqlDbType.NText),
					new SqlParameter("@isDeleted", SqlDbType.VarChar,50)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.birth;
            parameters[2].Value = model.education;
            parameters[3].Value = model.enterDate;
            parameters[4].Value = model.enterDate;
            parameters[5].Value = model.post;
            parameters[6].Value = model.officeTel;
            parameters[7].Value = model.mobile;
            parameters[8].Value = model.IDNumber;
            parameters[9].Value = model.homeAddress;
            parameters[10].Value = model.homeTel;
            parameters[11].Value = model.memo;
            parameters[12].Value = model.isDeleted;

            object obj = DBHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(com.surfkj.small.Model.Staff model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Staff set ");
            strSql.Append("name=@name,");
            strSql.Append("birth=@birth,");
            strSql.Append("education=@education,");
            strSql.Append("enterDate=@enterDate,");
            strSql.Append("leaveDate=@leaveDate,");
            strSql.Append("post=@post,");
            strSql.Append("officeTel=@officeTel,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("IDNumber=@IDNumber,");
            strSql.Append("homeAddress=@homeAddress,");
            strSql.Append("homeTel=@homeTel,");
            strSql.Append("memo=@memo,");
            strSql.Append("isDeleted=@isDeleted");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@birth", SqlDbType.Date,3),
					new SqlParameter("@education", SqlDbType.VarChar,50),
					new SqlParameter("@enterDate", SqlDbType.Date,3),
					new SqlParameter("@post", SqlDbType.VarChar,50),
					new SqlParameter("@officeTel", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
					new SqlParameter("@IDNumber", SqlDbType.VarChar,50),
					new SqlParameter("@homeAddress", SqlDbType.VarChar,255),
					new SqlParameter("@homeTel", SqlDbType.NChar,10),
					new SqlParameter("@memo", SqlDbType.NText),
					new SqlParameter("@isDeleted", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@leaveDate", SqlDbType.Date,3)                     
                                        };
            parameters[0].Value = model.name;
            parameters[1].Value = model.birth;
            parameters[2].Value = model.education;
            parameters[3].Value = model.enterDate;
            parameters[4].Value = model.post;
            parameters[5].Value = model.officeTel;
            parameters[6].Value = model.mobile;
            parameters[7].Value = model.IDNumber;
            parameters[8].Value = model.homeAddress;
            parameters[9].Value = model.homeTel;
            parameters[10].Value = model.memo;
            parameters[11].Value = model.isDeleted;
            parameters[12].Value = model.id;
            parameters[13].Value = model.leaveDate;
            int rows = DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Staff ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            int rows = DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Staff ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DBHelperSQL.ExecuteSql(strSql.ToString());
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
        public com.surfkj.small.Model.Staff GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,birth,education,enterDate,leaveDate,post,officeTel,mobile,IDNumber,homeAddress,homeTel,memo,isDeleted from T_Staff ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            com.surfkj.small.Model.Staff model = new com.surfkj.small.Model.Staff();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["name"] != null && ds.Tables[0].Rows[0]["name"].ToString() != "")
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["birth"] != null && ds.Tables[0].Rows[0]["birth"].ToString() != "")
                {
                    model.birth = DateTime.Parse(ds.Tables[0].Rows[0]["birth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["education"] != null && ds.Tables[0].Rows[0]["education"].ToString() != "")
                {
                    model.education = ds.Tables[0].Rows[0]["education"].ToString();
                }
                if (ds.Tables[0].Rows[0]["enterDate"] != null && ds.Tables[0].Rows[0]["enterDate"].ToString() != "")
                {
                    model.enterDate = DateTime.Parse(ds.Tables[0].Rows[0]["enterDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["leaveDate"] != null && ds.Tables[0].Rows[0]["leaveDate"].ToString() != "")
                {
                    model.leaveDate = DateTime.Parse(ds.Tables[0].Rows[0]["leaveDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["post"] != null && ds.Tables[0].Rows[0]["post"].ToString() != "")
                {
                    model.post = ds.Tables[0].Rows[0]["post"].ToString();
                }
                if (ds.Tables[0].Rows[0]["officeTel"] != null && ds.Tables[0].Rows[0]["officeTel"].ToString() != "")
                {
                    model.officeTel = ds.Tables[0].Rows[0]["officeTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["mobile"] != null && ds.Tables[0].Rows[0]["mobile"].ToString() != "")
                {
                    model.mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IDNumber"] != null && ds.Tables[0].Rows[0]["IDNumber"].ToString() != "")
                {
                    model.IDNumber = ds.Tables[0].Rows[0]["IDNumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["homeAddress"] != null && ds.Tables[0].Rows[0]["homeAddress"].ToString() != "")
                {
                    model.homeAddress = ds.Tables[0].Rows[0]["homeAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["homeTel"] != null && ds.Tables[0].Rows[0]["homeTel"].ToString() != "")
                {
                    model.homeTel = ds.Tables[0].Rows[0]["homeTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["memo"] != null && ds.Tables[0].Rows[0]["memo"].ToString() != "")
                {
                    model.memo = ds.Tables[0].Rows[0]["memo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isDeleted"] != null && ds.Tables[0].Rows[0]["isDeleted"].ToString() != "")
                {
                    model.isDeleted = ds.Tables[0].Rows[0]["isDeleted"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,birth,education,enterDate,leaveDate,post,officeTel,mobile,IDNumber,homeAddress,homeTel,memo,isDeleted ");
            strSql.Append(" FROM T_Staff ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,name,birth,education,enterDate,leaveDate,post,officeTel,mobile,IDNumber,homeAddress,homeTel,memo,isDeleted ");
            strSql.Append(" FROM T_Staff ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "T_Staff";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}