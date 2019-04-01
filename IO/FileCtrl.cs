/*
* @Description: 文档管理
* @Author: ookuro19
* @Date:   2018-07-07 18:50:26
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-07-27 18:51:42
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileCtrl : SingletonMono<FileCtrl>
{
    //加载本地游戏信息
    public LevelGoal[] LoadLevelGoalInfo()
    {
        TextAsset tTxt = Resources.Load<TextAsset>("TextAsset/LevelGoalInfo");
        string tStr = ReadWriteJson.GetStringFromJson(tTxt);
        return JsonHelper.FromJson<LevelGoal>(tStr);
    }

    // public LevelGoal[] LoadLevelGoalInfo()
    // {
    //     path = Path.Combine(Application.persistentDataPath, "LevelGoalInfo.json");
    //     FileInfo m_file = new FileInfo(path);
    //     string tStr;
    //     Debug.Log(path + " m_file.Exists " + m_file.Exists);
    //     if (!m_file.Exists)
    //     {
    //         TextAsset tTxt = Resources.Load<TextAsset>("TextAsset/LevelGoalInfo");
    //         tStr = ReadWriteJson.GetStringFromJson(tTxt);
    //     }
    //     else
    //     {
    //         //这里表示json文件已存在   第二次启动程序的时候会进这里。
    //         //这时候就可以直接访问persistentDataPath的路径  用StreamReader直接读就好了。
    //         tStr = ReadWriteJson.GetStringFromJson(path);
    //     }
    //     return JsonHelper.FromJson<LevelGoal>(tStr);
    // }

    string path;
    public LevelResult[] LoadLevelResultInfo()
    {
        path = Path.Combine(Application.persistentDataPath, "playerData.json");
        FileInfo m_file = new FileInfo(path);
        string tStr;
        Debug.Log(path + " m_file.Exists " + m_file.Exists);
        if (m_file.Exists)
        {
            //这里表示json文件已存在   第二次启动程序的时候会进这里。
            //这时候就可以直接访问persistentDataPath的路径  用StreamReader直接读就好了。
            tStr = ReadWriteJson.GetStringFromJson(path);
            try
            {
                if (JsonHelper.FromJson<LevelResult>(tStr).Length > 0)
                {
                    return JsonHelper.FromJson<LevelResult>(tStr);
                }
            }
            catch (System.Exception e)
            {
                Debug.Log("Error: " + e.Message.ToString());
            }
        }

        TextAsset tTxt = Resources.Load<TextAsset>("TextAsset/LevelResultInfo");
        tStr = ReadWriteJson.GetStringFromJson(tTxt);
        return JsonHelper.FromJson<LevelResult>(tStr);
    }

    /// <summary>
    /// 保存游戏数据
    /// </summary>
    /// <param name="datapath">Datapath.</param>
    public void SavePlayerData()
    {
        path = Path.Combine(Application.persistentDataPath, "playerData.json");
        ReadWriteJson.WirteJson<LevelResult>(path, LevelCtrl.Instance.levelResultArr);
    }
}
