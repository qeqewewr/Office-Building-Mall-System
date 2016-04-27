using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
namespace com.surfkj.small.Model
{
    /// <summary>
    /// Lessee:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Lessee
    {
        public Lessee()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _address;
        private string _operationscope;
        private string _officephone;
        private string _director;
        private string _directorphone;
        private string _emergency;
        private string _emergencyphone;
        private string _remark;
        private string _password = "8C312DD0F61E2AC639ED513C";
        private string _roomnum;
        private bool _status;
        private float _warrantmon;
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OperationScope
        {
            set { _operationscope = value; }
            get { return _operationscope; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OfficePhone
        {
            set { _officephone = value; }
            get { return _officephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Director
        {
            set { _director = value; }
            get { return _director; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DirectorPhone
        {
            set { _directorphone = value; }
            get { return _directorphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Emergency
        {
            set { _emergency = value; }
            get { return _emergency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmergencyPhone
        {
            set { _emergencyphone = value; }
            get { return _emergencyphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoomNum
        {
            set { _roomnum = value; }
            get { return _roomnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float WarrantMon
        {
            set { _warrantmon = value; }
            get { return _warrantmon; }
        }
        #endregion Model

    }
}

