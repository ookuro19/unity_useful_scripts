using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 线程交叉访问助手类
/// <summary>
public class ThreadCrossHelper : MonoBehaviour
{

	private static ThreadCrossHelper instance;  
	public static ThreadCrossHelper Instance
	{
		get{return instance;}
	}

	/// <summary>
	/// 延迟项
	/// </summary>
	class DelayedItem
	{
		public Action CurrentAction { get; set; }

		public DateTime Time { get; set; } 

	}

	private List<DelayedItem> delayedActionList= new List<DelayedItem>();

	private void Awake()
	{
		instance = this;
	}

	private void Update()
	{
		CheckDelayedActionList();
	}

	private void CheckDelayedActionList()
	{
		lock (delayedActionList)
		{
			//倒序删除
			for (int i = delayedActionList.Count - 1; i >= 0; i--)
			{
				//如果没有到达执行时间 则跳过
				if (delayedActionList[i].Time > DateTime.Now) continue;
				delayedActionList[i].CurrentAction();
				delayedActionList.RemoveAt(i);
			}
		}
	}

	/// <summary>
	/// 执行需要在主线程调用的方法  由辅助线程调用
	/// </summary>
	/// <param name="action">需要执行的方法</param>
	/// <param name="time">延迟时间</param>
	public void ExecuteOnMainThread(Action action, float time = 0)
	{
		lock (delayedActionList)
		{
			var item = new DelayedItem() { CurrentAction = action, Time = DateTime.Now.AddSeconds(time) };

			delayedActionList.Add(item);
		}
	}
}
