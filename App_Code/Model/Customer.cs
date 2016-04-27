using System;
namespace com.surfkj.small.user.Model
{
	/// <summary>
	/// Customer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Customer
	{
		public Customer()
		{}
		#region Model
		private int _id;
		private string _cusname;
        private string _cusLoginName;
		private string _cuspassword;
		private DateTime _cusregtime;
		private string _cuslevel;
		private int _cuspoint=0;
		private string _cusemail;
		private string _cusunit;
		private string _custel;
		private string _cusaddr;
		private string _cusmemo;
		private int _state=0;
        private float _cusmoney;
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
		public string cusName
		{
			set{ _cusname=value;}
			get{return _cusname;}
		}

        public string cusLoginName 
        {
            set { _cusLoginName = value; }
            get { return _cusLoginName; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string cusPassword
		{
			set{ _cuspassword=value;}
			get{return _cuspassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime cusRegTime
		{
			set{ _cusregtime=value;}
			get{return _cusregtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cusLevel
		{
			set{ _cuslevel=value;}
			get{return _cuslevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int cusPoint
		{
			set{ _cuspoint=value;}
			get{return _cuspoint;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cusEmail
		{
			set{ _cusemail=value;}
			get{return _cusemail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cusUnit
		{
			set{ _cusunit=value;}
			get{return _cusunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cusTel
		{
			set{ _custel=value;}
			get{return _custel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cusAddr
		{
			set{ _cusaddr=value;}
			get{return _cusaddr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cusMemo
		{
			set{ _cusmemo=value;}
			get{return _cusmemo;}
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
        public float cusMoney
        {
            set { _cusmoney = value; }
            get { return _cusmoney; }
        }
		#endregion Model

	}
}

