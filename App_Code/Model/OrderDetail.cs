using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.surfkj.small.Model
{
    /// <summary>
    /// T_OrderDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OrderDetail
    {
        public OrderDetail()
        { }
        #region Model
        private int _id;
        private int _orderid;
        private int _goodid;
        private float _goodprice;
        private float _gooddiscount;
        private float _goodquantity;
        private float _goodamount;
        private int _state = 0;
        private float _finalamount;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int goodID
        {
            set { _goodid = value; }
            get { return _goodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float goodPrice
        {
            set { _goodprice = value; }
            get { return _goodprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float goodDiscount
        {
            set { _gooddiscount = value; }
            get { return _gooddiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float goodQuantity
        {
            set { _goodquantity = value; }
            get { return _goodquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float goodAmount
        {
            set { _goodamount = value; }
            get { return _goodamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int state
        {
            set { _state = value; }
            get { return _state; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float finalAmount
        {
            set { _finalamount = value; }
            get { return _finalamount; }
        }
        #endregion Model

    }
}