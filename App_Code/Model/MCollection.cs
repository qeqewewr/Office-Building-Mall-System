using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
///MCollection 的摘要说明
/// </summary>
public class MCollection:CollectionBase
{
	public MCollection()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public void Add(Object item) {
        InnerList.Add(item);
    }

    public void Remove(object item) {
        InnerList.Remove(item);
    }

    public int Count() {
        return InnerList.Count;
    }

    public void Clear() {
        InnerList.Clear();
    }
}