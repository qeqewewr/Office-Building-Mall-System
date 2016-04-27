using System;
namespace com.surfkj.small.goods.Model
{
	/// <summary>
	/// GoodAtrribute:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GoodAtrribute
	{
		public GoodAtrribute()
		{}
		#region Model
		private int _id;
		private string _attributename;
		private int _state=0;
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
		public string AttributeName
		{
			set{ _attributename=value;}
			get{return _attributename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

