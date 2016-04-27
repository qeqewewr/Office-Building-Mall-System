using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.surfkj.small.Model.PermissionManage
{
    /// <summary>
    /// T_Permission:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Permission
    {
        public Permission()
        { }
        #region Model
        private int _id;
        private int _staffid;
        private int _functionid;
        private string _Description;
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
        public int StaffID
        {
            set { _staffid = value; }
            get { return _staffid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FunctionID
        {
            set { _functionid = value; }
            get { return _functionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }
        #endregion Model

    }
}