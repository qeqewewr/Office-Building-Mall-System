using System;
using System.Data;
using System.Text;
using System.Data.SqlClient; 
using com.surfkj.small.Common;
using com.surfkj.small.user.Model;//Please add references
namespace com.surfkj.small.user.DAL
{
    /// <summary>
    /// 数据访问类:Customer
    /// </summary>
    public partial class CustomerDAO
    {
        public CustomerDAO()
        { }
        #region  Method
 

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Customer");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            return DBHelperSQL.Exists(strSql.ToString(), parameters);
        }


        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int Add(com.surfkj.small.user.Model.Customer model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into T_Customer(");
        //    strSql.Append("cusName,cusLoginName,cusPassword,cusRegTime,cusLevel,cusPoint,cusEmail,cusUnit,cusTel,cusAddr,cusMemo,state,cusMoney)");
        //    strSql.Append(" values (");
        //    strSql.Append("@cusName,@cusLoginName,@cusPassword,@cusRegTime,@cusLevel,@cusPoint,@cusEmail,@cusUnit,@cusTel,@cusAddr,@cusMemo,@state,@cusMoney)");
        //    strSql.Append(";select @@IDENTITY");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@cusName", SqlDbType.VarChar,50),
        //            new SqlParameter("@cusLoginName", SqlDbType.VarChar,50),
        //            new SqlParameter("@cusPassword", SqlDbType.VarChar,50),
        //            new SqlParameter("@cusRegTime", SqlDbType.DateTime),
        //            new SqlParameter("@cusLevel", SqlDbType.VarChar,10),
        //            new SqlParameter("@cusPoint", SqlDbType.Int,4),
        //            new SqlParameter("@cusEmail", SqlDbType.VarChar,50),
        //            new SqlParameter("@cusUnit", SqlDbType.VarChar,50),
        //            new SqlParameter("@cusTel", SqlDbType.VarChar,50),
        //            new SqlParameter("@cusAddr", SqlDbType.VarChar,255),
        //            new SqlParameter("@cusMemo", SqlDbType.NVarChar,1000),
        //            new SqlParameter("@state", SqlDbType.Int,4)};
        //           // new SqlParameter("@cusMoney", SqlDbType.Float,8)};
        //    parameters[0].Value = model.cusName;
        //    parameters[1].Value = model.cusLoginName;
        //    parameters[2].Value = model.cusPassword;
        //    parameters[3].Value = model.cusRegTime;
        //    parameters[4].Value = model.cusLevel;
        //    parameters[5].Value = model.cusPoint;
        //    parameters[6].Value = model.cusEmail;
        //    parameters[7].Value = model.cusUnit;
        //    parameters[8].Value = model.cusTel;
        //    parameters[9].Value = model.cusAddr;
        //    parameters[10].Value = model.cusMemo;
        //    parameters[11].Value = model.state;
        //   // parameters[12].Value = model.cusMoney;
            

        //    object obj = DBHelperSQL.GetSingle(strSql.ToString(), parameters);
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(com.surfkj.small.user.Model.Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Customer(");
            strSql.Append("cusName,cusLoginName,cusPassword,cusRegTime,cusLevel,cusPoint,cusEmail,cusUnit,cusTel,cusAddr,cusMemo,state,cusMoney)");
            strSql.Append(" values (");
            strSql.Append("@cusName,@cusLoginName,@cusPassword,@cusRegTime,@cusLevel,@cusPoint,@cusEmail,@cusUnit,@cusTel,@cusAddr,@cusMemo,@state,@cusMoney)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@cusName", SqlDbType.VarChar,50),
					new SqlParameter("@cusLoginName", SqlDbType.VarChar,50),
					new SqlParameter("@cusPassword", SqlDbType.VarChar,50),
					new SqlParameter("@cusRegTime", SqlDbType.DateTime),
					new SqlParameter("@cusLevel", SqlDbType.VarChar,10),
					new SqlParameter("@cusPoint", SqlDbType.Int,4),
					new SqlParameter("@cusEmail", SqlDbType.VarChar,50),
					new SqlParameter("@cusUnit", SqlDbType.VarChar,50),
					new SqlParameter("@cusTel", SqlDbType.VarChar,50),
					new SqlParameter("@cusAddr", SqlDbType.VarChar,255),
					new SqlParameter("@cusMemo", SqlDbType.NVarChar,1000),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@cusMoney", SqlDbType.Float,8)};
            parameters[0].Value = model.cusName;
            parameters[1].Value = model.cusLoginName;
            parameters[2].Value = model.cusPassword;
            parameters[3].Value = model.cusRegTime;
            parameters[4].Value = model.cusLevel;
            parameters[5].Value = model.cusPoint;
            parameters[6].Value = model.cusEmail;
            parameters[7].Value = model.cusUnit;
            parameters[8].Value = model.cusTel;
            parameters[9].Value = model.cusAddr;
            parameters[10].Value = model.cusMemo;
            parameters[11].Value = model.state;
            parameters[12].Value = model.cusMoney;

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
        public bool Update(com.surfkj.small.user.Model.Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Customer set ");
            strSql.Append("cusName=@cusName,");
            strSql.Append("cusLoginName=@cusLoginName,"); 
            strSql.Append("cusPassword=@cusPassword,");
            strSql.Append("cusRegTime=@cusRegTime,");
            strSql.Append("cusLevel=@cusLevel,");
            strSql.Append("cusPoint=@cusPoint,");
            strSql.Append("cusEmail=@cusEmail,");
            strSql.Append("cusUnit=@cusUnit,");
            strSql.Append("cusTel=@cusTel,");
            strSql.Append("cusAddr=@cusAddr,");
            strSql.Append("cusMemo=@cusMemo,");
            strSql.Append("state=@state,");
            strSql.Append("cusMoney=@cusMoney");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@cusName", SqlDbType.VarChar,50),
                    new SqlParameter("@cusLoginName", SqlDbType.VarChar,50),
					new SqlParameter("@cusPassword", SqlDbType.VarChar,50),
					new SqlParameter("@cusRegTime", SqlDbType.DateTime),
					new SqlParameter("@cusLevel", SqlDbType.VarChar,10),
					new SqlParameter("@cusPoint", SqlDbType.Int,4),
					new SqlParameter("@cusEmail", SqlDbType.VarChar,50),
					new SqlParameter("@cusUnit", SqlDbType.VarChar,50),
					new SqlParameter("@cusTel", SqlDbType.VarChar,50),
					new SqlParameter("@cusAddr", SqlDbType.VarChar,255),
					new SqlParameter("@cusMemo", SqlDbType.NVarChar,1000),
					new SqlParameter("@state", SqlDbType.Int,4),
                    new SqlParameter("@cusMoney", SqlDbType.Float,8),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.cusName;
            parameters[1].Value = model.cusLoginName;
            parameters[2].Value = model.cusPassword;
            parameters[3].Value = model.cusRegTime;
            parameters[4].Value = model.cusLevel;
            parameters[5].Value = model.cusPoint;
            parameters[6].Value = model.cusEmail;
            parameters[7].Value = model.cusUnit;
            parameters[8].Value = model.cusTel;
            parameters[9].Value = model.cusAddr;
            parameters[10].Value = model.cusMemo;
            parameters[11].Value = model.state;
            parameters[12].Value = model.cusMoney;
            parameters[13].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Customer ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Customer ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public com.surfkj.small.user.Model.Customer GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,cusName,cusLoginName,cusPassword,cusRegTime,cusLevel,cusPoint,cusEmail,cusUnit,cusTel,cusAddr,cusMemo,state,cusMoney from T_Customer ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            com.surfkj.small.user.Model.Customer model = new com.surfkj.small.user.Model.Customer();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cusName"] != null && ds.Tables[0].Rows[0]["cusName"].ToString() != "")
                {
                    model.cusName = ds.Tables[0].Rows[0]["cusName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusLoginName"] != null && ds.Tables[0].Rows[0]["cusLoginName"].ToString() != "")
                {
                    model.cusLoginName = ds.Tables[0].Rows[0]["cusLoginName"].ToString();
                } 
                if (ds.Tables[0].Rows[0]["cusPassword"] != null && ds.Tables[0].Rows[0]["cusPassword"].ToString() != "")
                {
                    model.cusPassword = ds.Tables[0].Rows[0]["cusPassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusRegTime"] != null && ds.Tables[0].Rows[0]["cusRegTime"].ToString() != "")
                {
                    model.cusRegTime = DateTime.Parse(ds.Tables[0].Rows[0]["cusRegTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cusLevel"] != null && ds.Tables[0].Rows[0]["cusLevel"].ToString() != "")
                {
                    model.cusLevel = ds.Tables[0].Rows[0]["cusLevel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusPoint"] != null && ds.Tables[0].Rows[0]["cusPoint"].ToString() != "")
                {
                    model.cusPoint = int.Parse(ds.Tables[0].Rows[0]["cusPoint"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cusEmail"] != null && ds.Tables[0].Rows[0]["cusEmail"].ToString() != "")
                {
                    model.cusEmail = ds.Tables[0].Rows[0]["cusEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusUnit"] != null && ds.Tables[0].Rows[0]["cusUnit"].ToString() != "")
                {
                    model.cusUnit = ds.Tables[0].Rows[0]["cusUnit"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusTel"] != null && ds.Tables[0].Rows[0]["cusTel"].ToString() != "")
                {
                    model.cusTel = ds.Tables[0].Rows[0]["cusTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusAddr"] != null && ds.Tables[0].Rows[0]["cusAddr"].ToString() != "")
                {
                    model.cusAddr = ds.Tables[0].Rows[0]["cusAddr"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusMemo"] != null && ds.Tables[0].Rows[0]["cusMemo"].ToString() != "")
                {
                    model.cusMemo = ds.Tables[0].Rows[0]["cusMemo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["state"] != null && ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cusMoney"] != null && ds.Tables[0].Rows[0]["cusMoney"].ToString() != "")
                {
                    model.cusMoney = float.Parse(ds.Tables[0].Rows[0]["cusMoney"].ToString());
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
            strSql.Append("select ID,cusName,cusLoginName,cusPassword,cusRegTime,cusLevel,cusPoint,cusEmail,cusUnit,cusTel,cusAddr,cusMemo,state,cusMoney ");
            strSql.Append(" FROM T_Customer ");
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
            strSql.Append(" ID,cusName,cusLoginName,cusPassword,cusRegTime,cusLevel,cusPoint,cusEmail,cusUnit,cusTel,cusAddr,cusMemo,state,cusMoney ");
            strSql.Append(" FROM T_Customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelperSQL.Query(strSql.ToString());
        }

        public DataSet ListPageCustomer(int pageno, int pagesize)
        {
            int rowcount = this.GetTotalRecordNum();
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Customer ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Customer )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }



        public DataSet ListLookCustomer(int pageno, int pagesize, string filed, string name)
        {
            int rowcount = this.GetInqueryNum(filed, name);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Customer where " + filed + " like '%" + name + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Customer where " + filed + " like '%" + name + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public int GetTotalRecordNum()
        {
            int rows = DBHelperSQL.countNum("T_Customer");
            return rows;
        }

        public int GetInqueryNum(string filed, string str)
        {
            int rows = DBHelperSQL.GetInqueryNum(filed, str, "T_Customer");
            return rows;
        }

        public Customer verifyLogin(string cusLoginName, string cusPassword)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select  top 1 ID,cusName,cusLoginName,cusPassword,cusRegTime,cusLevel,cusPoint,cusEmail,cusUnit,cusTel,cusAddr,cusMemo,state,cusMoney  from T_Customer ");
            strSql.Append(" where cusLoginName=@cusLoginName");
            strSql.Append(" and cusPassword=@cusPassword");

            SqlParameter[] parameters = {
					new SqlParameter("@cusLoginName", SqlDbType.VarChar,50),
                    new SqlParameter("@cusPassword", SqlDbType.VarChar,50)
        };
            parameters[0].Value = cusLoginName;
            parameters[1].Value = cusPassword;

            Customer model = new Customer();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cusName"] != null && ds.Tables[0].Rows[0]["cusName"].ToString() != "")
                {
                    model.cusName = ds.Tables[0].Rows[0]["cusName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusLoginName"] != null && ds.Tables[0].Rows[0]["cusLoginName"].ToString() != "")
                {
                    model.cusLoginName = ds.Tables[0].Rows[0]["cusLoginName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusPassword"] != null && ds.Tables[0].Rows[0]["cusPassword"].ToString() != "")
                {
                    model.cusPassword = ds.Tables[0].Rows[0]["cusPassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusRegTime"] != null && ds.Tables[0].Rows[0]["cusRegTime"].ToString() != "")
                {
                    model.cusRegTime = DateTime.Parse(ds.Tables[0].Rows[0]["cusRegTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cusLevel"] != null && ds.Tables[0].Rows[0]["cusLevel"].ToString() != "")
                {
                    model.cusLevel = ds.Tables[0].Rows[0]["cusLevel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusPoint"] != null && ds.Tables[0].Rows[0]["cusPoint"].ToString() != "")
                {
                    model.cusPoint = int.Parse(ds.Tables[0].Rows[0]["cusPoint"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cusEmail"] != null && ds.Tables[0].Rows[0]["cusEmail"].ToString() != "")
                {
                    model.cusEmail = ds.Tables[0].Rows[0]["cusEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusUnit"] != null && ds.Tables[0].Rows[0]["cusUnit"].ToString() != "")
                {
                    model.cusUnit = ds.Tables[0].Rows[0]["cusUnit"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusTel"] != null && ds.Tables[0].Rows[0]["cusTel"].ToString() != "")
                {
                    model.cusTel = ds.Tables[0].Rows[0]["cusTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusAddr"] != null && ds.Tables[0].Rows[0]["cusAddr"].ToString() != "")
                {
                    model.cusAddr = ds.Tables[0].Rows[0]["cusAddr"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cusMemo"] != null && ds.Tables[0].Rows[0]["cusMemo"].ToString() != "")
                {
                    model.cusMemo = ds.Tables[0].Rows[0]["cusMemo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["state"] != null && ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cusMoney"] != null && ds.Tables[0].Rows[0]["cusMoney"].ToString() != "")
                {
                    model.cusMoney = float.Parse(ds.Tables[0].Rows[0]["cusMoney"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }





        #endregion  Method
    }
}

