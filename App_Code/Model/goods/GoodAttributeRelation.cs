using System;
namespace com.surfkj.small.goods.Model
{
	/// <summary>
	/// GoodAttributeRelation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GoodAttributeRelation
	{
		public GoodAttributeRelation()
		{}
		#region Model
		private int _id;
		private int _goodtype;
		private int _goodattribute;
		private int? _additional=0;
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
		public int goodType
		{
			set{ _goodtype=value;}
			get{return _goodtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int goodAttribute
		{
			set{ _goodattribute=value;}
			get{return _goodattribute;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? additional
		{
			set{ _additional=value;}
			get{return _additional;}
		}
		#endregion Model

	}
}

