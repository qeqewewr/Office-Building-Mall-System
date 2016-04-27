using System;
using System.Collections.Generic;
using System.Web;
using com.surfkj.small.Common;
using System.Text;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///UserDAL 的摘要说明
/// </summary>
public class UserDAL
{
	public UserDAL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from T_loginUser");
        strSql.Append(" where id=@id");
        SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
        parameters[0].Value = id;

        return DBHelperSQL.Exists(strSql.ToString(), parameters);
    }


    /// <summary>
    /// 增加一条数据
    /// </summary>
    public int Add(com.surfkj.small.Model.LoginUser model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into T_loginUser(");
        strSql.Append("staff,loginName,loginPwd,loginCount,loginTime,loginIP,sessionID)");
        strSql.Append(" values (");
        strSql.Append("@staff,@loginName,@loginPwd,@loginCount,@loginTime,@loginIP,@sessionID)");
        strSql.Append(";select @@IDENTITY");
        SqlParameter[] parameters = {
					new SqlParameter("@staff", SqlDbType.Int,4),
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@loginPwd", SqlDbType.VarChar,255),
					new SqlParameter("@loginCount", SqlDbType.Int,4),
					new SqlParameter("@loginTime", SqlDbType.DateTime),
					new SqlParameter("@loginIP", SqlDbType.VarChar,50),
					new SqlParameter("@sessionID", SqlDbType.VarChar,255)};
        parameters[0].Value = model.staff;
        parameters[1].Value = model.loginName;
        parameters[2].Value = model.loginPwd;
        parameters[3].Value = model.loginCount;
        parameters[4].Value = model.loginTime;
        parameters[5].Value = model.loginIP;
        parameters[6].Value = model.sessionID;

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
    public bool Update(com.surfkj.small.Model.LoginUser model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update T_loginUser set ");
        strSql.Append("staff=@staff,");
        strSql.Append("loginName=@loginName,");
        strSql.Append("loginPwd=@loginPwd,");
        strSql.Append("loginCount=@loginCount,");
        strSql.Append("loginTime=@loginTime,");
        strSql.Append("loginIP=@loginIP,");
        strSql.Append("sessionID=@sessionID");
        strSql.Append(" where id=@id");
        SqlParameter[] parameters = {
					new SqlParameter("@staff", SqlDbType.Int,4),
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@loginPwd", SqlDbType.VarChar,255),
					new SqlParameter("@loginCount", SqlDbType.Int,4),
					new SqlParameter("@loginTime", SqlDbType.DateTime),
					new SqlParameter("@loginIP", SqlDbType.VarChar,50),
					new SqlParameter("@sessionID", SqlDbType.VarChar,255),
					new SqlParameter("@id", SqlDbType.Int,4)};
        parameters[0].Value = model.staff;
        parameters[1].Value = model.loginName;
        parameters[2].Value = model.loginPwd;
        parameters[3].Value = model.loginCount;
        parameters[4].Value = model.loginTime;
        parameters[5].Value = model.loginIP;
        parameters[6].Value = model.sessionID;
        parameters[7].Value = model.id;

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
        strSql.Append("delete from T_loginUser ");
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
        strSql.Append("delete from T_loginUser ");
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
    public com.surfkj.small.Model.LoginUser GetModel(int id)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select  top 1 id,staff,loginName,loginPwd,loginCount,loginTime,loginIP,sessionID from T_loginUser ");
        strSql.Append(" where id=@id");
        SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
        };
        parameters[0].Value = id;

        com.surfkj.small.Model.LoginUser model = new com.surfkj.small.Model.LoginUser();
        DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
            {
                model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["staff"] != null && ds.Tables[0].Rows[0]["staff"].ToString() != "")
            {
                model.staff = int.Parse(ds.Tables[0].Rows[0]["staff"].ToString());
            }
            if (ds.Tables[0].Rows[0]["loginName"] != null && ds.Tables[0].Rows[0]["loginName"].ToString() != "")
            {
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
            }
            if (ds.Tables[0].Rows[0]["loginPwd"] != null && ds.Tables[0].Rows[0]["loginPwd"].ToString() != "")
            {
                model.loginPwd = ds.Tables[0].Rows[0]["loginPwd"].ToString();
            }
            if (ds.Tables[0].Rows[0]["loginCount"] != null && ds.Tables[0].Rows[0]["loginCount"].ToString() != "")
            {
                model.loginCount = int.Parse(ds.Tables[0].Rows[0]["loginCount"].ToString());
            }
            if (ds.Tables[0].Rows[0]["loginTime"] != null && ds.Tables[0].Rows[0]["loginTime"].ToString() != "")
            {
                model.loginTime = DateTime.Parse(ds.Tables[0].Rows[0]["loginTime"].ToString());
            }
            if (ds.Tables[0].Rows[0]["loginIP"] != null && ds.Tables[0].Rows[0]["loginIP"].ToString() != "")
            {
                model.loginIP = ds.Tables[0].Rows[0]["loginIP"].ToString();
            }
            if (ds.Tables[0].Rows[0]["sessionID"] != null && ds.Tables[0].Rows[0]["sessionID"].ToString() != "")
            {
                model.sessionID = ds.Tables[0].Rows[0]["sessionID"].ToString();
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
        strSql.Append("select id,staff,loginName,loginPwd,loginCount,loginTime,loginIP,sessionID ");
        strSql.Append(" FROM T_loginUser ");
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
        strSql.Append(" id,staff,loginName,loginPwd,loginCount,loginTime,loginIP,sessionID ");
        strSql.Append(" FROM T_loginUser ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        strSql.Append(" order by " + filedOrder);
        return DBHelperSQL.Query(strSql.ToString());
    }

    public  com.surfkj.small.Model.LoginUser verifyLogin(string loginName, string loginPwd) {
        StringBuilder strSql = new StringBuilder();

        strSql.Append("select  top 1 id,staff,loginName,loginPwd,loginCount,loginTime,loginIP,sessionID from T_loginUser ");
        strSql.Append(" where loginName=@loginName");
        strSql.Append(" and loginPwd=@loginPwd");

        SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
                    new SqlParameter("loginPwd", SqlDbType.VarChar,50)
        };
        parameters[0].Value = loginName;
        parameters[1].Value = loginPwd;

        com.surfkj.small.Model.LoginUser model = new com.surfkj.small.Model.LoginUser();
        DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
            {
                model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["staff"] != null && ds.Tables[0].Rows[0]["staff"].ToString() != "")
            {
                model.staff = int.Parse(ds.Tables[0].Rows[0]["staff"].ToString());
            }
            if (ds.Tables[0].Rows[0]["loginName"] != null && ds.Tables[0].Rows[0]["loginName"].ToString() != "")
            {
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
            }
            if (ds.Tables[0].Rows[0]["loginPwd"] != null && ds.Tables[0].Rows[0]["loginPwd"].ToString() != "")
            {
                model.loginPwd = ds.Tables[0].Rows[0]["loginPwd"].ToString();
            }
            if (ds.Tables[0].Rows[0]["loginCount"] != null && ds.Tables[0].Rows[0]["loginCount"].ToString() != "")
            {
                model.loginCount = int.Parse(ds.Tables[0].Rows[0]["loginCount"].ToString());
            }
            if (ds.Tables[0].Rows[0]["loginTime"] != null && ds.Tables[0].Rows[0]["loginTime"].ToString() != "")
            {
                model.loginTime = DateTime.Parse(ds.Tables[0].Rows[0]["loginTime"].ToString());
            }
            if (ds.Tables[0].Rows[0]["loginIP"] != null && ds.Tables[0].Rows[0]["loginIP"].ToString() != "")
            {
                model.loginIP = ds.Tables[0].Rows[0]["loginIP"].ToString();
            }
            if (ds.Tables[0].Rows[0]["sessionID"] != null && ds.Tables[0].Rows[0]["sessionID"].ToString() != "")
            {
                model.sessionID = ds.Tables[0].Rows[0]["sessionID"].ToString();
            }
            return model;
        }
        else
        {
            return null;
        }
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
        parameters[0].Value = "T_loginUser";
        parameters[1].Value = "id";
        parameters[2].Value = PageSize;
        parameters[3].Value = PageIndex;
        parameters[4].Value = 0;
        parameters[5].Value = 0;
        parameters[6].Value = strWhere;	
        return DBHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
    }*/









}