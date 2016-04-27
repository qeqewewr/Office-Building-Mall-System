using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using com.surfkj.small.Common;

namespace com.surfkj.small.DAL.OrderDetailDAL
{
    /// <summary>
    /// 数据访问类:T_OrderDetail
    /// </summary>
    public partial class OrderDetailDAL
    {
        public OrderDetailDAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        /* 		public int GetMaxId()
                {
                return DBHelperSQL.GetMaxID("ID", "T_OrderDetail"); 
                }
         */
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_OrderDetail");
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
        public int Add(com.surfkj.small.Model.OrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_OrderDetail(");
            strSql.Append("OrderID,goodID,goodPrice,goodDiscount,goodQuantity,goodAmount,state,finalAmount)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@goodID,@goodPrice,@goodDiscount,@goodQuantity,@goodAmount,@state,@finalAmount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@goodID", SqlDbType.Int,4),
					new SqlParameter("@goodPrice", SqlDbType.Float,8),
					new SqlParameter("@goodDiscount", SqlDbType.Float,8),
					new SqlParameter("@goodQuantity", SqlDbType.Float,8),
					new SqlParameter("@goodAmount", SqlDbType.Float,8),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@finalAmount", SqlDbType.Float,8)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.goodID;
            parameters[2].Value = model.goodPrice;
            parameters[3].Value = model.goodDiscount;
            parameters[4].Value = model.goodQuantity;
            parameters[5].Value = model.goodAmount;
            parameters[6].Value = model.state;
            parameters[7].Value = model.finalAmount;
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
        public bool Update(com.surfkj.small.Model.OrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_OrderDetail set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("goodID=@goodID,");
            strSql.Append("goodPrice=@goodPrice,");
            strSql.Append("goodDiscount=@goodDiscount,");
            strSql.Append("goodQuantity=@goodQuantity,");
            strSql.Append("goodAmount=@goodAmount,");
            strSql.Append("state=@state,");
            strSql.Append("finalAmount=@finalAmount");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@goodID", SqlDbType.Int,4),
					new SqlParameter("@goodPrice", SqlDbType.Float,8),
					new SqlParameter("@goodDiscount", SqlDbType.Float,8),
					new SqlParameter("@goodQuantity", SqlDbType.Float,8),
					new SqlParameter("@goodAmount", SqlDbType.Float,8),
					new SqlParameter("@state", SqlDbType.Int,4),
                    new SqlParameter("@finalAmount", SqlDbType.Float,8),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.goodID;
            parameters[2].Value = model.goodPrice;
            parameters[3].Value = model.goodDiscount;
            parameters[4].Value = model.goodQuantity;
            parameters[5].Value = model.goodAmount;
            parameters[6].Value = model.state;
            parameters[7].Value = model.finalAmount;
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
            strSql.Append("delete from T_OrderDetail ");
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
            strSql.Append("delete from T_OrderDetail ");
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
        public com.surfkj.small.Model.OrderDetail GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,OrderID,goodID,goodPrice,goodDiscount,goodQuantity,goodAmount,state,finalAmount from T_OrderDetail ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            com.surfkj.small.Model.OrderDetail model = new com.surfkj.small.Model.OrderDetail();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["goodID"] != null && ds.Tables[0].Rows[0]["goodID"].ToString() != "")
                {
                    model.goodID = int.Parse(ds.Tables[0].Rows[0]["goodID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["goodPrice"] != null && ds.Tables[0].Rows[0]["goodPrice"].ToString() != "")
                {
                    model.goodPrice = float.Parse(ds.Tables[0].Rows[0]["goodPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["goodDiscount"] != null && ds.Tables[0].Rows[0]["goodDiscount"].ToString() != "")
                {
                    model.goodDiscount = float.Parse(ds.Tables[0].Rows[0]["goodDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["goodQuantity"] != null && ds.Tables[0].Rows[0]["goodQuantity"].ToString() != "")
                {
                    model.goodQuantity = float.Parse(ds.Tables[0].Rows[0]["goodQuantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["goodAmount"] != null && ds.Tables[0].Rows[0]["goodAmount"].ToString() != "")
                {
                    model.goodAmount = float.Parse(ds.Tables[0].Rows[0]["goodAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state"] != null && ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["finalAmount"] != null && ds.Tables[0].Rows[0]["finalAmount"].ToString() != "")
                {
                    model.finalAmount = float.Parse(ds.Tables[0].Rows[0]["finalAmount"].ToString());
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
            strSql.Append("select ID,OrderID,goodID,goodPrice,goodDiscount,goodQuantity,goodAmount,state,finalAmount ");
            strSql.Append(" FROM T_OrderDetail ");
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
            strSql.Append(" ID,OrderID,goodID,goodPrice,goodDiscount,goodQuantity,goodAmount,state,finalAmount ");
            strSql.Append(" FROM T_OrderDetail ");
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
            parameters[0].Value = "T_OrderDetail";
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

