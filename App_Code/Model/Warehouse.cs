using System;

namespace com.surfkj.small.Model
{
	/// <summary>
	/// Warehouse:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Warehouse
	{
		public Warehouse()
		{
            
        }
		#region Model
		private int _id;
		private string _name;
		private string _address;
		private string _telephone;
		private int? _contact;
		private DateTime? _addtime;
		private int? _adder;
		private string _isdeleted= "0";
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
           
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string isDeleted
		{
			set{ _isdeleted=value;}
			get{return _isdeleted;}
		}

        /// <summary>
		/// 
		/// </summary>
		public int? adder
		{
            set { _adder = value; }
            get { return _adder; }
		}

		#endregion Model

	}
}

