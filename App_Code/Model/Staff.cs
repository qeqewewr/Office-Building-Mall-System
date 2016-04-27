using System;
namespace com.surfkj.small.Model
{
    /// <summary>
    /// T_Staff:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Staff
    {
        public Staff()
        { }
        #region Model
        private int _id;
        private string _name;
        private DateTime? _birth;
        private string _education;
        private DateTime? _enterdate;
        private DateTime? _leavedate;
        private string _post;
        private string _officetel;
        private string _mobile;
        private string _idnumber;
        private string _homeaddress;
        private string _hometel;
        private string _memo;
        private string _isdeleted = "0";
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? birth
        {
            set { _birth = value; }
            get { return _birth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string education
        {
            set { _education = value; }
            get { return _education; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? enterDate
        {
            set { _enterdate = value; }
            get { return _enterdate; }
        }

        public DateTime? leaveDate
        {
            set { _leavedate = value; }
            get { return _leavedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string post
        {
            set { _post = value; }
            get { return _post; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string officeTel
        {
            set { _officetel = value; }
            get { return _officetel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDNumber
        {
            set { _idnumber = value; }
            get { return _idnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string homeAddress
        {
            set { _homeaddress = value; }
            get { return _homeaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string homeTel
        {
            set { _hometel = value; }
            get { return _hometel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string isDeleted
        {
            set { _isdeleted = value; }
            get { return _isdeleted; }
        }
        #endregion Model

    }
}

