using System;
namespace com.surfkj.small.goods.Model
{
	/// <summary>
	/// GoodExtendedAttributes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GoodExtendedAttributes
	{
		public GoodExtendedAttributes()
		{}
		#region Model
		private int _id;
		private string _attributename;
		private int _goodid;
		private int _additional=0;
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
		public string attributeName
		{
			set{ _attributename=value;}
			get{return _attributename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int goodID
		{
			set{ _goodid=value;}
			get{return _goodid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int additional
		{
			set{ _additional=value;}
			get{return _additional;}
		}
		#endregion Model

	}
}

