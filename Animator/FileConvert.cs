/*
 * @Description: 转换ge'li
 * @Author: ookuro19 
 * @Date: 2018-07-27 15:47:38 
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-07-27 15:48:28
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;

//文件读取，editor类
public static class FileConvert
{
#region CsvToJson
    [MenuItem("Assets/FileConvert/Csv to Json")]
    static void CsvToJson()
    {
        TextAsset selectCSV = Selection.activeObject as TextAsset;//获取CSV对象
        string rootPath = Path.GetDirectoryName(AssetDatabase.GetAssetPath(selectCSV));//获取路径名称
        List<string[]> tempStrArrList = CreateOrOPenFile(selectCSV);
        List<string> tempStrList = ConverMgs(tempStrArrList, AnsisWarningRule);
        string folderPath = Path.Combine(rootPath, selectCSV.name);  //文本路径  可以自己需要自行更改

        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            AssetDatabase.CreateFolder(rootPath, selectCSV.name);//创建文件夹
            Debug.Log("路径已存在");
        }

        string txtPath = Path.Combine(folderPath, selectCSV.name + ".json");//文本存储路径和名称

        StreamWriter sw = new StreamWriter(txtPath, append: false);      //  生成文件 ,false -> 不添加，直接覆盖

        for (int i = 1; i < tempStrList.Count; i++)
        {
            sw.WriteLine(tempStrList[i]);   // saveString 为你想存储的字符串  将其写入文本中
        }

        sw.Close();   //释放掉

        //刷新一下 ，可以立即被编辑器识别到并使用，否则需要重启一下
        AssetDatabase.Refresh();
    }

    //读入text
    static List<string[]> CreateOrOPenFile(TextAsset tTxt)
    {
        string[] map_row_string = tTxt.text.Trim().Split('\n');
        List<string[]> tempStrArrList = new List<string[]>();
        for (int i = 0; i < map_row_string.Length; i++)
        {
            tempStrArrList.Add(map_row_string[i].Split(';'));
        }
        return tempStrArrList;
    }

    //导入警告内容
    static List<string> ConverMgs(List<string[]> tMapList, Func<string[], string> ansisRule)
    {
        List<string> tempStrList = new List<string>();
        string tStr = "";

        try
        {
            for (int i = 0; i < tMapList.Count; i++)
            {
                tStr = ansisRule(tMapList[i]);
                //tStr += "\n ------------ ";
                Debug.Log(tStr);
                tempStrList.Add(tStr);
                tStr = "";
            }
        }
        catch (Exception x)
        {
            tempStrList = null;
            Debug.LogException(x);
            throw;
        }

        return tempStrList;
        //Debug.Log("WarningModule.g_warningDictiony  "+ WarningModule.g_warningDictiony [warningList[1][1]][warningList[1][2]][0].ToString());
    }

    //警告信息转换规则 WarningMgsCsv.csv\
    static string lastHead = "";
    static string AnsisWarningRule(string[] tStrArr)
    {
        string tStr = string.Empty;
        if (tStrArr[1] != lastHead)
        {
            if (lastHead != "")
            {
                tStr += "}\n";
                tStr += "}\n";
            }
            tStr += "{\n";
            tStr += "\"" + tStrArr[1] + "\":\n";
            tStr += "{\n";
            lastHead = tStrArr[1];
        }

        tStr += "\"" + tStrArr[2] + "\":\n";
        tStr += "[\n";
        tStr += "\"" + tStrArr[3] + "\",\n";
        tStr += "\"" + tStrArr[4] + "\"\n";
        tStr += "],\n";
        Debug.Log(tStr);
        return tStr;
    }
#endregion

}
