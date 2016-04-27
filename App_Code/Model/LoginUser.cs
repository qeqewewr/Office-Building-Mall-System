
using System;
namespace com.surfkj.small.Model
{
	/// <summary>
	/// T_loginUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LoginUser
	{
		public LoginUser()
		{}
		#region Model
		private int _id;
		private int? _staff;
		private string _loginname;
		private string _loginpwd;
		private int? _logincount=0;
		private DateTime? _logintime;
		private string _loginip;
		private string _sessionid;
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
		public int? staff
		{
			set{ _staff=value;}
			get{return _staff;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string loginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string loginPwd
		{
			set{ _loginpwd=value;}
			get{return _loginpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? loginCount
		{
			set{ _logincount=value;}
			get{return _logincount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? loginTime
		{
			set{ _logintime=value;}
			get{return _logintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string loginIP
		{
			set{ _loginip=value;}
			get{return _loginip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sessionID
		{
			set{ _sessionid=value;}
			get{return _sessionid;}
		}
		#endregion Model

	}
}

