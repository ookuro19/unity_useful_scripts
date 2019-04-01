/*
* @Description: 读写Json文件
* @Author: ookuro19
* @Date:   2018-07-07 18:27:38
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-07-28 19:35:24
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ReadWriteJson
{
    #region 读取Json
    static string ReadJson(string datapath)
    {
        if (!File.Exists(datapath))
        {
            Debug.LogWarning("加载文件不存在,路径:" + datapath);
            return null;
        }

        try
        {
            StreamReader sr = new StreamReader(datapath);
            string tStr = sr.ReadToEnd();
            if (sr != null)
            {
                sr.Close();
            }
            return tStr;
        }
        catch(System.Exception e)
        {
            Debug.Log("Error: " + e.Message);
            return null;
        }

    }

    static string ReadJson(TextAsset tTxt)
    {
        // Debug.Log(tTxt.text);
        return tTxt.text;
        // string[] map_row_string = tTxt.text.Trim().Split('\n');
        // List<string[]> tempStrArrList = new List<string[]>();
        // for (int i = 0; i < map_row_string.Length; i++)
        // {
        //     tempStrArrList.Add(map_row_string[i].Split(';'));
        // }
        // return tempStrArrList;
    }


    //获取string
    public static string GetStringFromJson(string datapath)
    {
        return ReadJson(datapath);
    }

    public static string GetStringFromJson(TextAsset tTxt)
    {
        return ReadJson(tTxt);
    }

    //获取对应的类
    public static T GetClassFromJson<T>(string datapath)
    {
        string jsonString = ReadJson(datapath);
        return JsonUtility.FromJson<T>(jsonString);
    }
    #endregion

    #region 写入json
    //直接传入字符串
    public static void WirteJson(string datapath, string tContent)
    {
        //以FileStream操作
        // FileStream file = new FileStream(datapath, FileMode.Create);//这里的FileMode.create是创建这个文件,如果文件名存在则覆盖重新创建
        // byte[] bts = System.Text.Encoding.UTF8.GetBytes(tContent);//存储时时二进制,所以这里需要把我们的字符串转成二进制
        // file.Write(bts, 0, bts.Length);
        // file.Close();

        //以StreamWriter操作
        StreamWriter sw = new StreamWriter(datapath, append: false); //  生成文件 ,false -> 不添加，直接覆盖
        sw.Write(tContent);   // saveString 为你想存储的字符串  将其写入文本中
        sw.Close();
    }
    //直接传入类
    public static void WirteJson<T>(string datapath, T tClass)
    {
        string tContent = JsonUtility.ToJson(tClass, true);
        Debug.Log(tContent);

        //以FileStream操作
        // FileStream file = new FileStream(datapath, FileMode.Create);//这里的FileMode.create是创建这个文件,如果文件名存在则覆盖重新创建
        // byte[] bts = System.Text.Encoding.UTF8.GetBytes(tContent);//存储时时二进制,所以这里需要把我们的字符串转成二进制
        // file.Write(bts, 0, bts.Length);
        // file.Close();

        //以StreamWriter操作
        StreamWriter sw = new StreamWriter(datapath, append: false); //  生成文件 ,false -> 不添加，直接覆盖
        sw.Write(tContent);   // saveString 为你想存储的字符串  将其写入文本中
        sw.Close();
    }

    public static void WirteJson<T>(string datapath, T[] tArray)
    {
        string tContent = JsonHelper.ToJson(tArray, true);
        Debug.Log(tContent);

        //以StreamWriter操作
        StreamWriter sw = new StreamWriter(datapath, append: false); //  生成文件 ,false -> 不添加，直接覆盖
        sw.Write(tContent);   // saveString 为你想存储的字符串  将其写入文本中
        sw.Close();
    }
    #endregion
}
