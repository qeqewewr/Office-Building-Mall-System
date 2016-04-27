using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using com.surfkj.small.Common;
namespace com.surfkj.small.DAL.PermissionManage
{
    /// <summary>
    /// 数据访问类:Employe
    /// </summary>
    public partial class EmployeDAL
    {
        public EmployeDAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        //public int GetMaxId()
        //{
        //    return DBHelperSQL.GetMaxID("ID", "Employe");
        //}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Employe");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            return DBHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(com.surfkj.small.Model.PermissionManage.Employe model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Employe(");
            strSql.Append("EmployeID,Name,IDNumber,Sex,Nation,Birth,Politics,Education,Department,OfficeTel,HomeTel,Mobile,HomeAddress,Email,Status,EnterDate,LeaveDate,Password)");
            strSql.Append(" values (");
            strSql.Append("@EmployeID,@Name,@IDNumber,@Sex,@Nation,@Birth,@Politics,@Education,@Department,@OfficeTel,@HomeTel,@Mobile,@HomeAddress,@Email,@Status,@EnterDate,@LeaveDate,@Password)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeID", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@IDNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.NChar,1),
					new SqlParameter("@Nation", SqlDbType.NChar,10),
					new SqlParameter("@Birth", SqlDbType.DateTime,3),
					new SqlParameter("@Politics", SqlDbType.NChar,20),
					new SqlParameter("@Education", SqlDbType.VarChar,50),
					new SqlParameter("@Department", SqlDbType.NVarChar,50),
					new SqlParameter("@OfficeTel", SqlDbType.VarChar,50),
					new SqlParameter("@HomeTel", SqlDbType.NChar,20),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@HomeAddress", SqlDbType.VarChar,255),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.Bit,1),
					new SqlParameter("@EnterDate", SqlDbType.DateTime,3),
					new SqlParameter("@LeaveDate", SqlDbType.DateTime,3),
					new SqlParameter("@Password", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.EmployeID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.IDNumber;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Nation;
            parameters[5].Value = model.Birth;
            parameters[6].Value = model.Politics;
            parameters[7].Value = model.Education;
            parameters[8].Value = model.Department;
            parameters[9].Value = model.OfficeTel;
            parameters[10].Value = model.HomeTel;
            parameters[11].Value = model.Mobile;
            parameters[12].Value = model.HomeAddress;
            parameters[13].Value = model.Email;
            parameters[14].Value = model.Status;
            parameters[15].Value = model.EnterDate;
            parameters[16].Value = model.LeaveDate;
            parameters[17].Value = model.Password;

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
        public bool Update(com.surfkj.small.Model.PermissionManage.Employe model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Employe set ");
            strSql.Append("EmployeID=@EmployeID,");
            strSql.Append("Name=@Name,");
            strSql.Append("IDNumber=@IDNumber,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Nation=@Nation,");
            strSql.Append("Birth=@Birth,");
            strSql.Append("Politics=@Politics,");
            strSql.Append("Education=@Education,");
            strSql.Append("Department=@Department,");
            strSql.Append("OfficeTel=@OfficeTel,");
            strSql.Append("HomeTel=@HomeTel,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("HomeAddress=@HomeAddress,");
            strSql.Append("Email=@Email,");
            strSql.Append("Status=@Status,");
            strSql.Append("EnterDate=@EnterDate,");
            strSql.Append("LeaveDate=@LeaveDate,");
            strSql.Append("Password=@Password");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeID", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@IDNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.NChar,1),
					new SqlParameter("@Nation", SqlDbType.NChar,10),
					new SqlParameter("@Birth", SqlDbType.DateTime,3),
					new SqlParameter("@Politics", SqlDbType.NChar,20),
					new SqlParameter("@Education", SqlDbType.VarChar,50),
					new SqlParameter("@Department", SqlDbType.NVarChar,50),
					new SqlParameter("@OfficeTel", SqlDbType.VarChar,50),
					new SqlParameter("@HomeTel", SqlDbType.NChar,20),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@HomeAddress", SqlDbType.VarChar,255),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.Bit,1),
					new SqlParameter("@EnterDate", SqlDbType.DateTime,3),
					new SqlParameter("@LeaveDate", SqlDbType.DateTime,3),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.EmployeID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.IDNumber;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Nation;
            parameters[5].Value = model.Birth;
            parameters[6].Value = model.Politics;
            parameters[7].Value = model.Education;
            parameters[8].Value = model.Department;
            parameters[9].Value = model.OfficeTel;
            parameters[10].Value = model.HomeTel;
            parameters[11].Value = model.Mobile;
            parameters[12].Value = model.HomeAddress;
            parameters[13].Value = model.Email;
            parameters[14].Value = model.Status;
            parameters[15].Value = model.EnterDate;
            parameters[16].Value = model.LeaveDate;
            parameters[17].Value = model.Password;
            parameters[18].Value = model.ID;

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
            strSql.Append("delete from Employe ");
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
            strSql.Append("delete from Employe ");
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
        public com.surfkj.small.Model.PermissionManage.Employe GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,EmployeID,Name,IDNumber,Sex,Nation,Birth,Politics,Education,Department,OfficeTel,HomeTel,Mobile,HomeAddress,Email,Status,EnterDate,LeaveDate,Password from Employe ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            com.surfkj.small.Model.PermissionManage.Employe model = new com.surfkj.small.Model.PermissionManage.Employe();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EmployeID"] != null && ds.Tables[0].Rows[0]["EmployeID"].ToString() != "")
                {
                    model.EmployeID = ds.Tables[0].Rows[0]["EmployeID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IDNumber"] != null && ds.Tables[0].Rows[0]["IDNumber"].ToString() != "")
                {
                    model.IDNumber = ds.Tables[0].Rows[0]["IDNumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Nation"] != null && ds.Tables[0].Rows[0]["Nation"].ToString() != "")
                {
                    model.Nation = ds.Tables[0].Rows[0]["Nation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Birth"] != null && ds.Tables[0].Rows[0]["Birth"].ToString() != "")
                {
                    model.Birth = DateTime.Parse(ds.Tables[0].Rows[0]["Birth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Politics"] != null && ds.Tables[0].Rows[0]["Politics"].ToString() != "")
                {
                    model.Politics = ds.Tables[0].Rows[0]["Politics"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Education"] != null && ds.Tables[0].Rows[0]["Education"].ToString() != "")
                {
                    model.Education = ds.Tables[0].Rows[0]["Education"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Department"] != null && ds.Tables[0].Rows[0]["Department"].ToString() != "")
                {
                    model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OfficeTel"] != null && ds.Tables[0].Rows[0]["OfficeTel"].ToString() != "")
                {
                    model.OfficeTel = ds.Tables[0].Rows[0]["OfficeTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HomeTel"] != null && ds.Tables[0].Rows[0]["HomeTel"].ToString() != "")
                {
                    model.HomeTel = ds.Tables[0].Rows[0]["HomeTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Mobile"] != null && ds.Tables[0].Rows[0]["Mobile"].ToString() != "")
                {
                    model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HomeAddress"] != null && ds.Tables[0].Rows[0]["HomeAddress"].ToString() != "")
                {
                    model.HomeAddress = ds.Tables[0].Rows[0]["HomeAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Status"].ToString() == "1") || (ds.Tables[0].Rows[0]["Status"].ToString().ToLower() == "true"))
                    {
                        model.Status = true;
                    }
                    else
                    {
                        model.Status = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["EnterDate"] != null && ds.Tables[0].Rows[0]["EnterDate"].ToString() != "")
                {
                    model.EnterDate = DateTime.Parse(ds.Tables[0].Rows[0]["EnterDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LeaveDate"] != null && ds.Tables[0].Rows[0]["LeaveDate"].ToString() != "")
                {
                    model.LeaveDate = DateTime.Parse(ds.Tables[0].Rows[0]["LeaveDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
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
            strSql.Append("select ID,EmployeID,Name,IDNumber,Sex,Nation,Birth,Politics,Education,Department,OfficeTel,HomeTel,Mobile,HomeAddress,Email,Status,EnterDate,LeaveDate,Password ");
            strSql.Append(" FROM Employe ");
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
            strSql.Append(" ID,EmployeID,Name,IDNumber,Sex,Nation,Birth,Politics,Education,Department,OfficeTel,HomeTel,Mobile,HomeAddress,Email,Status,EnterDate,LeaveDate,Password ");
            strSql.Append(" FROM Employe ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelperSQL.Query(strSql.ToString());
        }
        public DataSet ListPageEmploye(int pageno, int pagesize)
        {
            int rowcount = this.GetTotalRecordNum();
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from Employe) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from Employe)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public DataSet ListLookEmploye(int pageno, int pagesize, string filed, string name) 
        {
            int rowcount = this.GetInqueryNum(filed, name);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from Employe where " + filed + " like '%" + name + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from Employe where " + filed + " like '%" + name + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public int GetTotalRecordNum()
        {
            int rows = DBHelperSQL.countNum("Employe");
            return rows;
        }

        public int GetInqueryNum(string filed, string str) 
        {
            int rows = DBHelperSQL.GetInqueryNum(filed, str, "Employe");
            return rows;
        }

        public com.surfkj.small.Model.PermissionManage.Employe verifyLogin(string EmployeID, string Password)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select  top 1 ID,EmployeID,Name,IDNumber,Sex,Nation,Birth,Politics,Education,Department,OfficeTel,HomeTel,Mobile,HomeAddress,Email,Status,EnterDate,LeaveDate,Password from Employe ");
            strSql.Append(" where EmployeID=@EmployeID");
            strSql.Append(" and Password=@Password");

            SqlParameter[] parameters = {
					new SqlParameter("@EmployeID", SqlDbType.VarChar,50),
                    new SqlParameter("@Password", SqlDbType.VarChar,50)
        };
            parameters[0].Value = EmployeID;
            parameters[1].Value = Password;

            com.surfkj.small.Model.PermissionManage.Employe model = new com.surfkj.small.Model.PermissionManage.Employe();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EmployeID"] != null && ds.Tables[0].Rows[0]["EmployeID"].ToString() != "")
                {
                    model.EmployeID = ds.Tables[0].Rows[0]["EmployeID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IDNumber"] != null && ds.Tables[0].Rows[0]["IDNumber"].ToString() != "")
                {
                    model.IDNumber = ds.Tables[0].Rows[0]["IDNumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Nation"] != null && ds.Tables[0].Rows[0]["Nation"].ToString() != "")
                {
                    model.Nation = ds.Tables[0].Rows[0]["Nation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Birth"] != null && ds.Tables[0].Rows[0]["Birth"].ToString() != "")
                {
                    model.Birth = DateTime.Parse(ds.Tables[0].Rows[0]["Birth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Politics"] != null && ds.Tables[0].Rows[0]["Politics"].ToString() != "")
                {
                    model.Politics = ds.Tables[0].Rows[0]["Politics"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Education"] != null && ds.Tables[0].Rows[0]["Education"].ToString() != "")
                {
                    model.Education = ds.Tables[0].Rows[0]["Education"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Department"] != null && ds.Tables[0].Rows[0]["Department"].ToString() != "")
                {
                    model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OfficeTel"] != null && ds.Tables[0].Rows[0]["OfficeTel"].ToString() != "")
                {
                    model.OfficeTel = ds.Tables[0].Rows[0]["OfficeTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HomeTel"] != null && ds.Tables[0].Rows[0]["HomeTel"].ToString() != "")
                {
                    model.HomeTel = ds.Tables[0].Rows[0]["HomeTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Mobile"] != null && ds.Tables[0].Rows[0]["Mobile"].ToString() != "")
                {
                    model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HomeAddress"] != null && ds.Tables[0].Rows[0]["HomeAddress"].ToString() != "")
                {
                    model.HomeAddress = ds.Tables[0].Rows[0]["HomeAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Status"].ToString() == "1") || (ds.Tables[0].Rows[0]["Status"].ToString().ToLower() == "true"))
                    {
                        model.Status = true;
                    }
                    else
                    {
                        model.Status = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["EnterDate"] != null && ds.Tables[0].Rows[0]["EnterDate"].ToString() != "")
                {
                    model.EnterDate = DateTime.Parse(ds.Tables[0].Rows[0]["EnterDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LeaveDate"] != null && ds.Tables[0].Rows[0]["LeaveDate"].ToString() != "")
                {
                    model.LeaveDate = DateTime.Parse(ds.Tables[0].Rows[0]["LeaveDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
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

