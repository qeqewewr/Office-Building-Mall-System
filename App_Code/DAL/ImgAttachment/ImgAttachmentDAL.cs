using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using com.surfkj.small.Model;
using com.surfkj.small.Common;
namespace com.surfkj.small.DAL
{
    /// <summary>
    /// 数据访问类:T_ImgAttachment
    /// </summary>
    public partial class ImgAttachmentDAL
    {
        public ImgAttachmentDAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        /* public int GetMaxId()
        {
        return DBHelperSQL.GetMaxID("ID", "T_ImgAttachment"); 
        } */

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_ImgAttachment");
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
        public int Add(com.surfkj.small.Model.ImgAttachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_ImgAttachment(");
            strSql.Append("attachType,attachUrl,attachName,moduleID,addDate)");
            strSql.Append(" values (");
            strSql.Append("@attachType,@attachUrl,@attachName,@moduleID,@addDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@attachType", SqlDbType.Int,4),
					new SqlParameter("@attachUrl", SqlDbType.VarChar),
					new SqlParameter("@attachName", SqlDbType.VarChar),
					new SqlParameter("@moduleID", SqlDbType.VarChar),
					new SqlParameter("@addDate", SqlDbType.DateTime)};
            parameters[0].Value = model.attachType;
            parameters[1].Value = model.attachUrl;
            parameters[2].Value = model.attachName;
            parameters[3].Value = model.moduleID;
            parameters[4].Value = model.addDate;

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
        public bool Update(com.surfkj.small.Model.ImgAttachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_ImgAttachment set ");
            strSql.Append("attachType=@attachType,");
            strSql.Append("attachUrl=@attachUrl,");
            strSql.Append("attachName=@attachName,");
            strSql.Append("moduleID=@moduleID,");
            strSql.Append("addDate=@addDate");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@attachType", SqlDbType.Int,4),
					new SqlParameter("@attachUrl", SqlDbType.VarChar),
					new SqlParameter("@attachName", SqlDbType.VarChar),
					new SqlParameter("@moduleID", SqlDbType.VarChar),
					new SqlParameter("@addDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.attachType;
            parameters[1].Value = model.attachUrl;
            parameters[2].Value = model.attachName;
            parameters[3].Value = model.moduleID;
            parameters[4].Value = model.addDate;
            parameters[5].Value = model.ID;

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
            strSql.Append("delete from T_ImgAttachment ");
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
            strSql.Append("delete from T_ImgAttachment ");
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
        public com.surfkj.small.Model.ImgAttachment GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,attachType,attachUrl,attachName,moduleID,addDate from T_ImgAttachment ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            com.surfkj.small.Model.ImgAttachment model = new com.surfkj.small.Model.ImgAttachment();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["attachType"] != null && ds.Tables[0].Rows[0]["attachType"].ToString() != "")
                {
                    model.attachType = int.Parse(ds.Tables[0].Rows[0]["attachType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["attachUrl"] != null && ds.Tables[0].Rows[0]["attachUrl"].ToString() != "")
                {
                    model.attachUrl = ds.Tables[0].Rows[0]["attachUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["attachName"] != null && ds.Tables[0].Rows[0]["attachName"].ToString() != "")
                {
                    model.attachName = ds.Tables[0].Rows[0]["attachName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["moduleID"] != null && ds.Tables[0].Rows[0]["moduleID"].ToString() != "")
                {
                    model.moduleID = ds.Tables[0].Rows[0]["moduleID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["addDate"] != null && ds.Tables[0].Rows[0]["addDate"].ToString() != "")
                {
                    model.addDate = DateTime.Parse(ds.Tables[0].Rows[0]["addDate"].ToString());
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
            strSql.Append("select ID,attachType,attachUrl,attachName,moduleID,addDate ");
            strSql.Append(" FROM T_ImgAttachment ");
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
            strSql.Append(" ID,attachType,attachUrl,attachName,moduleID,addDate ");
            strSql.Append(" FROM T_ImgAttachment ");
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
            parameters[0].Value = "T_ImgAttachment";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DBHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}

