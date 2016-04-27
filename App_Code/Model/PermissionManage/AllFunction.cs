using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.surfkj.small.Model.PermissionManage
{
    /// <summary>
    /// T_AllFunction:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class AllFunction
    {
        public AllFunction()
        { }
        #region Model
        private int _id;
        private int _parentid;
        private string _code;
        private string _fullname;
        private string _navigateurl;
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
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FullName
        {
            set { _fullname = value; }
            get { return _fullname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NavigateUrl
        {
            set { _navigateurl = value; }
            get { return _navigateurl; }
        }
        #endregion Model

    }
}
