/*
* @Description: 读取CSV，参考链接 https://www.jianshu.com/p/ffda934b5e15
* @Author: ookuro19
* @Date:   2018-07-07 19:04:49
* @Last Modified by:   ookuro19
* @Last Modified time: 2018-07-07 19:56:23
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadWriteCsv : SingletonCSharp<ReadWriteCsv> {

	public List<string[]> m_ArrayData = new List<string[]>();

	public List<string[]> LoadFile(string path)
	{
		m_ArrayData.Clear ();
		StreamReader sr = null;
		try
		{
			sr = File.OpenText(path);
		}
		catch {
			return null;
		}

		string line;
		while((line = sr.ReadLine()) != null)
		{
            m_ArrayData.Add(line.Split(';'));
		}
		//关闭
		sr.Close ();
		//销毁
		sr.Dispose ();

		return m_ArrayData;
	}

	public void WriteFile(string dataPath,string data)
	{
		if (File.Exists (dataPath)) {
			File.Delete (dataPath);
		}
		//File.Create (dataPath);
		FileStream fs = new FileStream(dataPath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
		StreamWriter sw = new StreamWriter (fs, System.Text.Encoding.UTF8);
		sw.WriteLine (data);
		sw.Close ();
		sw.Dispose ();

		Debug.Log ("save succeed ... ");
	}
}
