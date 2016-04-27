using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace com.surfkj.small.Model.AdvAttachment
{
    /// <summary>
    /// T_AdvAttachment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class AdvAttachment
    {
        public AdvAttachment()
        { }
        #region Model
        private int _id;
        private int _attachtype;
        private string _attachurl;
        private string _attachname;
        private int _advid;
        private DateTime _adddate;
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
        public int attachType
        {
            set { _attachtype = value; }
            get { return _attachtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attachUrl
        {
            set { _attachurl = value; }
            get { return _attachurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attachName
        {
            set { _attachname = value; }
            get { return _attachname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int advID
        {
            set { _advid = value; }
            get { return _advid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime addDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        #endregion Model

    }
}