using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.surfkj.small.Model
{
    /// <summary>
    /// T_ImgAttachment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ImgAttachment
    {
        public ImgAttachment()
        { }
        #region Model
        private int _id;
        private int _attachtype;
        private string _attachurl;
        private string _attachname;
        private string _moduleid;
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
        public string moduleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
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
