using System;
using System.Collections.Generic;
using System.Web;

namespace com.surfkj.small.Model.Advertisement
{
    /// <summary>
    /// T_Advertisement:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Advertisement
    {
        public Advertisement()
        { }
        #region Model
        private int _id;
        private int _advetype;
        private string _imgurl;
        private string _url;
        private float _imgsize;
        private int _adveorder;
        private string _description;
        private DateTime _updatetime;
        private int _state = 0;
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
        public int AdveType
        {
            set { _advetype = value; }
            get { return _advetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float Imgsize
        {
            set { _imgsize = value; }
            get { return _imgsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AdveOrder
        {
            set { _adveorder = value; }
            get { return _adveorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        #endregion Model

    }
}