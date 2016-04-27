using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using com.surfkj.small.Common;

namespace com.surfkj.small.DAL.Lessee
{
    /// <summary>
    /// 数据访问类:Lessee
    /// </summary>
    public partial class LesseeDAL
    {
        public LesseeDAL()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Lessee");
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
        public int Add(com.surfkj.small.Model.Lessee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Lessee(");
            strSql.Append("Name,Address,OperationScope,OfficePhone,Director,DirectorPhone,Emergency,EmergencyPhone,Remark,Password,RoomNum,Status,WarrantMon)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Address,@OperationScope,@OfficePhone,@Director,@DirectorPhone,@Emergency,@EmergencyPhone,@Remark,@Password,@RoomNum,@Status,@WarrantMon)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@OperationScope", SqlDbType.NVarChar,50),
					new SqlParameter("@OfficePhone", SqlDbType.VarChar,50),
					new SqlParameter("@Director", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectorPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Emergency", SqlDbType.NVarChar,50),
					new SqlParameter("@EmergencyPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@RoomNum", SqlDbType.NChar,50),
					new SqlParameter("@Status", SqlDbType.Bit,1),
					new SqlParameter("@WarrantMon", SqlDbType.Float,8)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Address;
            parameters[2].Value = model.OperationScope;
            parameters[3].Value = model.OfficePhone;
            parameters[4].Value = model.Director;
            parameters[5].Value = model.DirectorPhone;
            parameters[6].Value = model.Emergency;
            parameters[7].Value = model.EmergencyPhone;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.Password;
            parameters[10].Value = model.RoomNum;
            parameters[11].Value = model.Status;
            parameters[12].Value = model.WarrantMon;

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
        public bool Update(com.surfkj.small.Model.Lessee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Lessee set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Address=@Address,");
            strSql.Append("OperationScope=@OperationScope,");
            strSql.Append("OfficePhone=@OfficePhone,");
            strSql.Append("Director=@Director,");
            strSql.Append("DirectorPhone=@DirectorPhone,");
            strSql.Append("Emergency=@Emergency,");
            strSql.Append("EmergencyPhone=@EmergencyPhone,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Password=@Password,");
            strSql.Append("RoomNum=@RoomNum,");
            strSql.Append("Status=@Status,");
            strSql.Append("WarrantMon=@WarrantMon");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@OperationScope", SqlDbType.NVarChar,50),
					new SqlParameter("@OfficePhone", SqlDbType.VarChar,50),
					new SqlParameter("@Director", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectorPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Emergency", SqlDbType.NVarChar,50),
					new SqlParameter("@EmergencyPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@RoomNum", SqlDbType.NChar,50),
					new SqlParameter("@Status", SqlDbType.Bit,1),
					new SqlParameter("@WarrantMon", SqlDbType.Float,8),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Address;
            parameters[2].Value = model.OperationScope;
            parameters[3].Value = model.OfficePhone;
            parameters[4].Value = model.Director;
            parameters[5].Value = model.DirectorPhone;
            parameters[6].Value = model.Emergency;
            parameters[7].Value = model.EmergencyPhone;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.Password;
            parameters[10].Value = model.RoomNum;
            parameters[11].Value = model.Status;
            parameters[12].Value = model.WarrantMon;
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
            strSql.Append("delete from Lessee ");
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
            strSql.Append("delete from Lessee ");
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
        public com.surfkj.small.Model.Lessee GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Address,OperationScope,OfficePhone,Director,DirectorPhone,Emergency,EmergencyPhone,Remark,Password,RoomNum,Status,WarrantMon from Lessee ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            com.surfkj.small.Model.Lessee model = new com.surfkj.small.Model.Lessee();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OperationScope"] != null && ds.Tables[0].Rows[0]["OperationScope"].ToString() != "")
                {
                    model.OperationScope = ds.Tables[0].Rows[0]["OperationScope"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OfficePhone"] != null && ds.Tables[0].Rows[0]["OfficePhone"].ToString() != "")
                {
                    model.OfficePhone = ds.Tables[0].Rows[0]["OfficePhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Director"] != null && ds.Tables[0].Rows[0]["Director"].ToString() != "")
                {
                    model.Director = ds.Tables[0].Rows[0]["Director"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectorPhone"] != null && ds.Tables[0].Rows[0]["DirectorPhone"].ToString() != "")
                {
                    model.DirectorPhone = ds.Tables[0].Rows[0]["DirectorPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Emergency"] != null && ds.Tables[0].Rows[0]["Emergency"].ToString() != "")
                {
                    model.Emergency = ds.Tables[0].Rows[0]["Emergency"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EmergencyPhone"] != null && ds.Tables[0].Rows[0]["EmergencyPhone"].ToString() != "")
                {
                    model.EmergencyPhone = ds.Tables[0].Rows[0]["EmergencyPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RoomNum"] != null && ds.Tables[0].Rows[0]["RoomNum"].ToString() != "")
                {
                    model.RoomNum = ds.Tables[0].Rows[0]["RoomNum"].ToString();
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
                if (ds.Tables[0].Rows[0]["WarrantMon"] != null && ds.Tables[0].Rows[0]["WarrantMon"].ToString() != "")
                {
                    model.WarrantMon = float.Parse(ds.Tables[0].Rows[0]["WarrantMon"].ToString());
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
            strSql.Append("select ID,Name,Address,OperationScope,OfficePhone,Director,DirectorPhone,Emergency,EmergencyPhone,Remark,Password,RoomNum,Status,WarrantMon ");
            strSql.Append(" FROM Lessee ");
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
            strSql.Append(" ID,Name,Address,OperationScope,OfficePhone,Director,DirectorPhone,Emergency,EmergencyPhone,Remark,Password,RoomNum,Status,WarrantMon ");
            strSql.Append(" FROM Lessee ");
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
            parameters[0].Value = "Lessee";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DBHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        public DataSet ListPageLessee(int pageno, int pagesize)
        {
            int rowcount = this.GetTotalRecordNum();
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from Lessee ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from Lessee )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }



        public DataSet ListLookLessee(int pageno, int pagesize, string filed, string name)
        {
            int rowcount = this.GetInqueryNum(filed, name);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from Lessee where " + filed + " like '%" + name + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from Lessee where " + filed + " like '%" + name + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public int GetTotalRecordNum()
        {
            int rows = DBHelperSQL.countNum("Lessee");
            return rows;
        }

        public int GetInqueryNum(string filed, string str)
        {
            int rows = DBHelperSQL.GetInqueryNum(filed, str, "Lessee");
            return rows;
        }

        public com.surfkj.small.Model.Lessee verifyLogin(string cusLoginName, string cusPassword)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select  top 1 ID,Name,Address,OperationScope,OfficePhone,Director,DirectorPhone,Emergency,EmergencyPhone,Remark,Password,RoomNum,Status,WarrantMon from Lessee ");
            strSql.Append(" where Name=@cusLoginName");
            strSql.Append(" and Password=@cusPassword");
            SqlParameter[] parameters = {
                    new SqlParameter("@cusLoginName", SqlDbType.VarChar,50),
                    new SqlParameter("@cusPassword", SqlDbType.VarChar,50)
};
            parameters[0].Value = cusLoginName;
            parameters[1].Value = cusPassword;

            com.surfkj.small.Model.Lessee model = new com.surfkj.small.Model.Lessee();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OperationScope"] != null && ds.Tables[0].Rows[0]["OperationScope"].ToString() != "")
                {
                    model.OperationScope = ds.Tables[0].Rows[0]["OperationScope"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OfficePhone"] != null && ds.Tables[0].Rows[0]["OfficePhone"].ToString() != "")
                {
                    model.OfficePhone = ds.Tables[0].Rows[0]["OfficePhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Director"] != null && ds.Tables[0].Rows[0]["Director"].ToString() != "")
                {
                    model.Director = ds.Tables[0].Rows[0]["Director"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectorPhone"] != null && ds.Tables[0].Rows[0]["DirectorPhone"].ToString() != "")
                {
                    model.DirectorPhone = ds.Tables[0].Rows[0]["DirectorPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Emergency"] != null && ds.Tables[0].Rows[0]["Emergency"].ToString() != "")
                {
                    model.Emergency = ds.Tables[0].Rows[0]["Emergency"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EmergencyPhone"] != null && ds.Tables[0].Rows[0]["EmergencyPhone"].ToString() != "")
                {
                    model.EmergencyPhone = ds.Tables[0].Rows[0]["EmergencyPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RoomNum"] != null && ds.Tables[0].Rows[0]["RoomNum"].ToString() != "")
                {
                    model.RoomNum = ds.Tables[0].Rows[0]["RoomNum"].ToString();
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
                if (ds.Tables[0].Rows[0]["WarrantMon"] != null && ds.Tables[0].Rows[0]["WarrantMon"].ToString() != "")
                {
                    model.WarrantMon = float.Parse(ds.Tables[0].Rows[0]["WarrantMon"].ToString());
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

