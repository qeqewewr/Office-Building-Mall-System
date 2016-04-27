using System;
namespace com.surfkj.small.goods.Model
{
	/// <summary>
	/// GoodType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GoodType
	{
		public GoodType()
		{}
		#region Model
		private int _id;
		private string _typename;
		private int _parent;
		private string _tlevel;
		private string _memo;
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
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int parent
		{
			set{ _parent=value;}
			get{return _parent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tlevel
		{
			set{ _tlevel=value;}
			get{return _tlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string memo
		{
			set{ _memo=value;}
			get{return _memo;}
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

