using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///pageForm 的摘要说明
/// </summary>
/// 

namespace com.surfkj.small.Common
{
    public class pageForm
    {
        public pageForm()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        //总行数
        private int rowcount;
        public int RowCount
        {
            get { return rowcount; }
            set { rowcount = value; }
        }

        //每个页面的行数
        private int pagesize;
        public int PageSize
        {
            get { return pagesize; }
            set { pagesize = value; }
        }

        //总页数
        private int pagecount;
        public int PageCount
        {
            get { return pagecount; }
            set { pagecount = value; }
        }

        //当前页号
        private int pageno;
        public int PageNo
        {
            get { return pageno; }
            set { pageno = value; }
        }

        //后一页页号
        public int NextPage
        {  
            get {return pageno+1; }
        }

        //前一页页号
        public int PrePage
        {
            get { return pageno-1; }
        }

        public bool behind=false;
        private bool Behind{
            set { behind = value; }
            get{return behind;}
        }

        public bool previous = false;
        private bool Previous
        {
            set { previous = value; }
            get { return previous; }
        }

    }
}