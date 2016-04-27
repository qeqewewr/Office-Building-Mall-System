using System;
namespace com.surfkj.small.goods.Model
{
	/// <summary>
	/// Goods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Goods
	{
		public Goods()
		{}
		#region Model
		private int _id;
		private int _goodtype;
		private string _goodno;
		private string _goodname;
		private string _goodbrand;
		private string _goodmanufacture;
		private string _goodorg;
		private string _goodkg;
		private string _goodnetkg;
		private string _goodcolor;
		private string _goodsize;
		private string _goodspecifications;
		private string _goodmaterial;
		private decimal _goodprice=0M;
		private string _goodmemo;
		private string _goodhot;
		private decimal _goodpromotion=-1M;
		private string _goodrecommand;
		private string _goodboutique;
		private int _goodstock;
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
		public int goodType
		{
			set{ _goodtype=value;}
			get{return _goodtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodNO
		{
			set{ _goodno=value;}
			get{return _goodno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodName
		{
			set{ _goodname=value;}
			get{return _goodname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodBrand
		{
			set{ _goodbrand=value;}
			get{return _goodbrand;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodManufacture
		{
			set{ _goodmanufacture=value;}
			get{return _goodmanufacture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodOrg
		{
			set{ _goodorg=value;}
			get{return _goodorg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodKg
		{
			set{ _goodkg=value;}
			get{return _goodkg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodNetKg
		{
			set{ _goodnetkg=value;}
			get{return _goodnetkg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodColor
		{
			set{ _goodcolor=value;}
			get{return _goodcolor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodSize
		{
			set{ _goodsize=value;}
			get{return _goodsize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodSpecifications
		{
			set{ _goodspecifications=value;}
			get{return _goodspecifications;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodMaterial
		{
			set{ _goodmaterial=value;}
			get{return _goodmaterial;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal goodPrice
		{
			set{ _goodprice=value;}
			get{return _goodprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodMemo
		{
			set{ _goodmemo=value;}
			get{return _goodmemo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodHot
		{
			set{ _goodhot=value;}
			get{return _goodhot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal goodPromotion
		{
			set{ _goodpromotion=value;}
			get{return _goodpromotion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodRecommand
		{
			set{ _goodrecommand=value;}
			get{return _goodrecommand;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodBoutique
		{
			set{ _goodboutique=value;}
			get{return _goodboutique;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int goodStock
		{
			set{ _goodstock=value;}
			get{return _goodstock;}
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

