using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using com.surfkj.small.Common;
namespace com.surfkj.small.DAL.Advertisement
{
    /// <summary>
    /// 数据访问类:T_Advertisement
    /// </summary>
    public partial class AdvertisementDAL
    {
        public AdvertisementDAL()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(com.surfkj.small.Model.Advertisement.Advertisement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Advertisement(");
            strSql.Append("AdveType,ImgUrl,Url,Imgsize,AdveOrder,Description,UpdateTime,State)");
            strSql.Append(" values (");
            strSql.Append("@AdveType,@ImgUrl,@Url,@Imgsize,@AdveOrder,@Description,@UpdateTime,@State)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AdveType", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar),
					new SqlParameter("@Url", SqlDbType.NVarChar),
					new SqlParameter("@Imgsize", SqlDbType.Float,8),
					new SqlParameter("@AdveOrder", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4)};
            parameters[0].Value = model.AdveType;
            parameters[1].Value = model.ImgUrl;
            parameters[2].Value = model.Url;
            parameters[3].Value = model.Imgsize;
            parameters[4].Value = model.AdveOrder;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.UpdateTime;
            parameters[7].Value = model.State;

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
        public bool Update(com.surfkj.small.Model.Advertisement.Advertisement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Advertisement set ");
            strSql.Append("AdveType=@AdveType,");
            strSql.Append("ImgUrl=@ImgUrl,");
            strSql.Append("Url=@Url,");
            strSql.Append("Imgsize=@Imgsize,");
            strSql.Append("AdveOrder=@AdveOrder,");
            strSql.Append("Description=@Description,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("State=@State");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@AdveType", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar),
					new SqlParameter("@Url", SqlDbType.NVarChar),
					new SqlParameter("@Imgsize", SqlDbType.Float,8),
					new SqlParameter("@AdveOrder", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.AdveType;
            parameters[1].Value = model.ImgUrl;
            parameters[2].Value = model.Url;
            parameters[3].Value = model.Imgsize;
            parameters[4].Value = model.AdveOrder;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.UpdateTime;
            parameters[7].Value = model.State;
            parameters[8].Value = model.ID;

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
            strSql.Append("delete from T_Advertisement ");
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
            strSql.Append("delete from T_Advertisement ");
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
        public com.surfkj.small.Model.Advertisement.Advertisement GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,AdveType,ImgUrl,Url,Imgsize,AdveOrder,Description,UpdateTime,State from T_Advertisement ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            com.surfkj.small.Model.Advertisement.Advertisement model = new com.surfkj.small.Model.Advertisement.Advertisement();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AdveType"] != null && ds.Tables[0].Rows[0]["AdveType"].ToString() != "")
                {
                    model.AdveType = int.Parse(ds.Tables[0].Rows[0]["AdveType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ImgUrl"] != null && ds.Tables[0].Rows[0]["ImgUrl"].ToString() != "")
                {
                    model.ImgUrl = ds.Tables[0].Rows[0]["ImgUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Url"] != null && ds.Tables[0].Rows[0]["Url"].ToString() != "")
                {
                    model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Imgsize"] != null && ds.Tables[0].Rows[0]["Imgsize"].ToString() != "")
                {
                    model.Imgsize = float.Parse(ds.Tables[0].Rows[0]["Imgsize"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AdveOrder"] != null && ds.Tables[0].Rows[0]["AdveOrder"].ToString() != "")
                {
                    model.AdveOrder = int.Parse(ds.Tables[0].Rows[0]["AdveOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"] != null && ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
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
            strSql.Append("select ID,AdveType,ImgUrl,Url,Imgsize,AdveOrder,Description,UpdateTime,State ");
            strSql.Append(" FROM T_Advertisement ");
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
            strSql.Append(" ID,AdveType,ImgUrl,Url,Imgsize,AdveOrder,Description,UpdateTime,State ");
            strSql.Append(" FROM T_Advertisement ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder + " desc");
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
            parameters[0].Value = "T_Advertisement";
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

