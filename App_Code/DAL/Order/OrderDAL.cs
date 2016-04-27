using System;
using System.Data;
using System.Text;
using System.Data.SqlClient; 
using com.surfkj.small.Common;//Please add references
namespace com.surfkj.small.order.DAL
{
    /// <summary>
    /// 数据访问类:Order
    /// </summary>
    public partial class OrderDAL
    {
        public OrderDAL()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(com.surfkj.small.order.Model.Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Order(");
            strSql.Append("customer,customerType,payTime,Receiver,Tel,addr,zip,Memo,state,orderNO,orderStatus,payType,message,reply,deliveryInfo,signer)");
            strSql.Append(" values (");
            strSql.Append("@customer,@customerType,@payTime,@Receiver,@Tel,@addr,@zip,@Memo,@state,@orderNO,@orderStatus,@payType,@message,@reply,@deliveryInfo,@signer)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@customer", SqlDbType.Int,4),
					new SqlParameter("@customerType", SqlDbType.VarChar,10),
					new SqlParameter("@payTime", SqlDbType.DateTime),
					new SqlParameter("@Receiver", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@addr", SqlDbType.VarChar,255),
					new SqlParameter("@zip", SqlDbType.VarChar,10),
					new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@orderNO", SqlDbType.VarChar,50),
					new SqlParameter("@orderStatus", SqlDbType.VarChar),
					new SqlParameter("@payType", SqlDbType.Int,4),
					new SqlParameter("@message", SqlDbType.NVarChar),
					new SqlParameter("@reply", SqlDbType.NVarChar),
					new SqlParameter("@deliveryInfo", SqlDbType.NVarChar),
					new SqlParameter("@signer", SqlDbType.VarChar,50)};
            parameters[0].Value = model.customer;
            parameters[1].Value = model.customerType;
            parameters[2].Value = model.payTime;
            parameters[3].Value = model.Receiver;
            parameters[4].Value = model.Tel;
            parameters[5].Value = model.addr;
            parameters[6].Value = model.zip;
            parameters[7].Value = model.Memo;
            parameters[8].Value = model.state;
            parameters[9].Value = model.orderNO;
            parameters[10].Value = model.orderStatus;
            parameters[11].Value = model.payType;
            parameters[12].Value = model.message;
            parameters[13].Value = model.reply;
            parameters[14].Value = model.deliveryInfo;
            parameters[15].Value = model.signer;

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
        public bool Update(com.surfkj.small.order.Model.Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Order set ");
            strSql.Append("customer=@customer,");
            strSql.Append("customerType=@customerType,");
            strSql.Append("payTime=@payTime,");
            strSql.Append("Receiver=@Receiver,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("addr=@addr,");
            strSql.Append("zip=@zip,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("state=@state,");
            strSql.Append("orderNO=@orderNO,");
            strSql.Append("orderStatus=@orderStatus,");
            strSql.Append("payType=@payType,");
            strSql.Append("message=@message,");
            strSql.Append("reply=@reply,");
            strSql.Append("deliveryInfo=@deliveryInfo,");
            strSql.Append("signer=@signer");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@customer", SqlDbType.Int,4),
					new SqlParameter("@customerType", SqlDbType.VarChar,10),
					new SqlParameter("@payTime", SqlDbType.DateTime),
					new SqlParameter("@Receiver", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@addr", SqlDbType.VarChar,255),
					new SqlParameter("@zip", SqlDbType.VarChar,10),
					new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@orderNO", SqlDbType.VarChar,50),
					new SqlParameter("@orderStatus", SqlDbType.VarChar),
					new SqlParameter("@payType", SqlDbType.Int,4),
					new SqlParameter("@message", SqlDbType.NVarChar),
					new SqlParameter("@reply", SqlDbType.NVarChar),
					new SqlParameter("@deliveryInfo", SqlDbType.NVarChar),
					new SqlParameter("@signer", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.customer;
            parameters[1].Value = model.customerType;
            parameters[2].Value = model.payTime;
            parameters[3].Value = model.Receiver;
            parameters[4].Value = model.Tel;
            parameters[5].Value = model.addr;
            parameters[6].Value = model.zip;
            parameters[7].Value = model.Memo;
            parameters[8].Value = model.state;
            parameters[9].Value = model.orderNO;
            parameters[10].Value = model.orderStatus;
            parameters[11].Value = model.payType;
            parameters[12].Value = model.message;
            parameters[13].Value = model.reply;
            parameters[14].Value = model.deliveryInfo;
            parameters[15].Value = model.signer;
            parameters[16].Value = model.ID;

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
            strSql.Append("delete from T_Order ");
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
            strSql.Append("delete from T_Order ");
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
        public com.surfkj.small.order.Model.Order GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,customer,customerType,payTime,Receiver,Tel,addr,zip,Memo,state,orderNO,orderStatus,payType,message,reply,deliveryInfo,signer from T_Order ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            com.surfkj.small.order.Model.Order model = new com.surfkj.small.order.Model.Order();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["customer"] != null && ds.Tables[0].Rows[0]["customer"].ToString() != "")
                {
                    model.customer = int.Parse(ds.Tables[0].Rows[0]["customer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["customerType"] != null && ds.Tables[0].Rows[0]["customerType"].ToString() != "")
                {
                    model.customerType = ds.Tables[0].Rows[0]["customerType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["payTime"] != null && ds.Tables[0].Rows[0]["payTime"].ToString() != "")
                {
                    model.payTime = DateTime.Parse(ds.Tables[0].Rows[0]["payTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Receiver"] != null && ds.Tables[0].Rows[0]["Receiver"].ToString() != "")
                {
                    model.Receiver = ds.Tables[0].Rows[0]["Receiver"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tel"] != null && ds.Tables[0].Rows[0]["Tel"].ToString() != "")
                {
                    model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["addr"] != null && ds.Tables[0].Rows[0]["addr"].ToString() != "")
                {
                    model.addr = ds.Tables[0].Rows[0]["addr"].ToString();
                }
                if (ds.Tables[0].Rows[0]["zip"] != null && ds.Tables[0].Rows[0]["zip"].ToString() != "")
                {
                    model.zip = ds.Tables[0].Rows[0]["zip"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Memo"] != null && ds.Tables[0].Rows[0]["Memo"].ToString() != "")
                {
                    model.Memo = ds.Tables[0].Rows[0]["Memo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["state"] != null && ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderNO"] != null && ds.Tables[0].Rows[0]["orderNO"].ToString() != "")
                {
                    model.orderNO = ds.Tables[0].Rows[0]["orderNO"].ToString();
                }
                if (ds.Tables[0].Rows[0]["orderStatus"] != null && ds.Tables[0].Rows[0]["orderStatus"].ToString() != "")
                {
                    model.orderStatus = ds.Tables[0].Rows[0]["orderStatus"].ToString();
                }
                if (ds.Tables[0].Rows[0]["payType"] != null && ds.Tables[0].Rows[0]["payType"].ToString() != "")
                {
                    model.payType = int.Parse(ds.Tables[0].Rows[0]["payType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["message"] != null && ds.Tables[0].Rows[0]["message"].ToString() != "")
                {
                    model.message = ds.Tables[0].Rows[0]["message"].ToString();
                }
                if (ds.Tables[0].Rows[0]["reply"] != null && ds.Tables[0].Rows[0]["reply"].ToString() != "")
                {
                    model.reply = ds.Tables[0].Rows[0]["reply"].ToString();
                }
                if (ds.Tables[0].Rows[0]["deliveryInfo"] != null && ds.Tables[0].Rows[0]["deliveryInfo"].ToString() != "")
                {
                    model.deliveryInfo = ds.Tables[0].Rows[0]["deliveryInfo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["signer"] != null && ds.Tables[0].Rows[0]["signer"].ToString() != "")
                {
                    model.signer = ds.Tables[0].Rows[0]["signer"].ToString();
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
            strSql.Append("select ID,customer,customerType,payTime,Receiver,Tel,addr,zip,Memo,state,orderNO,orderStatus,payType,message,reply,deliveryInfo,signer ");
            strSql.Append(" FROM T_Order ");
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
            strSql.Append(" ID,customer,customerType,payTime,Receiver,Tel,addr,zip,Memo,state,orderNO,orderStatus,payType,message,reply,deliveryInfo,signer");
            strSql.Append(" FROM T_Order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelperSQL.Query(strSql.ToString());
        }

        public DataSet ListPageOrder(int pageno, int pagesize)
        {
            int rowcount = this.GetTotalRecordNum();
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Order) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Order)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public DataSet ListLookOrder(int pageno, int pagesize, string filed, string name)
        {
            int rowcount = this.GetInqueryNum(filed, name);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Order where " + filed + " like '%" + name + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Order where " + filed + " like '%" + name + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public DataSet ListLookOrder2(int pageno, int pagesize, string receiver, string num, string status)
        {
            int rowcount = this.GetOrderInqueryNum(receiver, num, status);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Order where Receiver like '%" + receiver + "%' and orderStatus like '%" + status + "%' and orderNO like '%" + num + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Order where Receiver like '%" + receiver + "%' and orderStatus like '%" + status + "%' and orderNO like '%" + num + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public DataSet ListLookOrder3(int pageno, int pagesize, int rowcount, string num, string status)
        {
           // int rowcount = this.GetOrderInqueryNum(num, status);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Order where orderStatus like '%" + status + "%' and orderNO like '%" + num + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Order where orderStatus like '%" + status + "%' and orderNO like '%" + num + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public DataSet ListLookOrder4(int pageno, int pagesize, int rowcount, string receiver, string num)
        {
            // int rowcount = this.GetOrderInqueryNum(num, status);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Order where Receiver like '%" + receiver + "%' and orderNO like '%" + num + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Order where Receiver like '%" + receiver + "%' and orderNO like '%" + num + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public DataSet ListLookOrder5(int pageno, int pagesize, int rowcount, string receiver, string scope)
        {
            // int rowcount = this.GetOrderInqueryNum(num, status);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Order where Receiver like '%" + receiver + "%' and orderStatus like '%" + scope + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Order where Receiver like '%" + receiver + "%' and orderStatus like '%" + scope + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public DataSet ListLookOrder6(int pageno, int pagesize, int rowcount, string scope)
        {
            // int rowcount = this.GetOrderInqueryNum(num, status);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Order where orderStatus like '%" + scope + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Order where orderStatus like '%" + scope + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public DataSet ListLookOrder7(int pageno, int pagesize, int rowcount, string receiver)
        {
            // int rowcount = this.GetOrderInqueryNum(num, status);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Order where Receiver like '%" + receiver + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Order where Receiver like '%" + receiver + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public int GetTotalRecordNum()
        {
            int rows = DBHelperSQL.countNum("T_Order");
            return rows;
        }

        public int GetInqueryNum(string filed, string str)
        {
            int rows = DBHelperSQL.GetInqueryNum(filed, str, "T_Order");
            return rows;
        }

        public int GetOrderInqueryNum(string receiver, string num, string status)
        {
            int rows = DBHelperSQL.GetOrderInqueryNum(receiver, num, status, "T_Order");
            return rows;
        }

        #endregion  Method
    }
}

