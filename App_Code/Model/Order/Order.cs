using System;
namespace com.surfkj.small.order.Model
{
	/// <summary>
	/// Order:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Order
	{
		public Order()
		{}
		#region Model
		private int _id;
		private int _customer;
        private string _customerType;
		private DateTime _paytime;
		private string _receiver;
		private string _tel;
		private string _addr;
		private string _zip;
		private string _memo;
		private int _state=0;
		private string _orderno;
        private string _orderStatus;
        private int _paytype;
        private string _message;
        private string _reply;
        private string _deliveryinfo;
        private string _signer;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int customer
		{
			set{ _customer=value;}
			get{return _customer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime payTime
		{
			set{ _paytime=value;}
			get{return _paytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Receiver
		{
			set{ _receiver=value;}
			get{return _receiver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string addr
		{
			set{ _addr=value;}
			get{return _addr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zip
		{
			set{ _zip=value;}
			get{return _zip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Memo
		{
			set{ _memo=value;}
			get{return _memo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string orderNO
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
        public string customerType
		{ 
            set { _customerType = value; }
            get { return _customerType; }
		}

        public string orderStatus 
		{
            set { _orderStatus = value; }
            get { return _orderStatus; }
		}

        /// <summary>
        /// 
        /// </summary>
        public int payType
        {
            set { _paytype = value; }
            get { return _paytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string message
        {
            set { _message = value; }
            get { return _message; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string reply
        {
            set { _reply = value; }
            get { return _reply; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string deliveryInfo
        {
            set { _deliveryinfo = value; }
            get { return _deliveryinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string signer
        {
            set { _signer = value; }
            get { return _signer; }
        }
        
        
		#endregion Model

	}
}

