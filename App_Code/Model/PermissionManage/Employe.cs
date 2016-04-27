using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.surfkj.small.Model.PermissionManage
{
    /// <summary>
    /// Employe:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Employe
    {
        public Employe()
        { }
        #region Model
        private int _id;
        private string _employeid;
        private string _name;
        private string _idnumber;
        private string _sex;
        private string _nation;
        private DateTime? _birth;
        private string _politics;
        private string _education;
        private string _department;
        private string _officetel;
        private string _hometel;
        private string _mobile;
        private string _homeaddress;
        private string _email;
        private bool _status;
        private DateTime? _enterdate;
        private DateTime? _leavedate;
        private string _password;
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
        public string EmployeID
        {
            set { _employeid = value; }
            get { return _employeid; }
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
        public string IDNumber
        {
            set { _idnumber = value; }
            get { return _idnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Nation
        {
            set { _nation = value; }
            get { return _nation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Birth
        {
            set { _birth = value; }
            get { return _birth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Politics
        {
            set { _politics = value; }
            get { return _politics; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Education
        {
            set { _education = value; }
            get { return _education; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OfficeTel
        {
            set { _officetel = value; }
            get { return _officetel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HomeTel
        {
            set { _hometel = value; }
            get { return _hometel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HomeAddress
        {
            set { _homeaddress = value; }
            get { return _homeaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
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
        public DateTime? EnterDate
        {
            set { _enterdate = value; }
            get { return _enterdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LeaveDate
        {
            set { _leavedate = value; }
            get { return _leavedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        #endregion Model

    }
}