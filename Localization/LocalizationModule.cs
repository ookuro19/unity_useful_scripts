/*
 * @Description: 多语言模块
 * @Author: ookuro19 
 * @Date: 2018-12-13 18:09:02 
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-12-13 18:40:15
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocalizationModule : SingletonMono<LocalizationModule>
{
    // public ELanguageType _currentLangType;
    private static Dictionary<string, string> dic = new Dictionary<string, string>();

    void Awake()
    {
        LoadLocalizationData();
    }

    /// <summary>  
    /// 读取配置文件，将文件信息保存到字典里  
    /// </summary>  
    public void LoadLocalizationData()
    {
        TextAsset ta = Resources.Load<TextAsset>("TextAsset/GameLang");
        string text = ta.text;
        int typeNum = (int)CurrentGameInfo.g_LanguageType + 1;
        string[] lines = text.Split('\n');
        foreach (string line in lines)
        {
            if (line == null)
            {
                continue;
            }
            string[] keyAndValue = line.Split(';');
            if (keyAndValue.Length > 2)
            {
                dic.Add(keyAndValue[0], keyAndValue[typeNum]);
                // Debug.Log(string.Format("keyAndValue[{0}], keyAndValue[typeNum]: {1}", keyAndValue[0], keyAndValue[typeNum]));
            }
        }
    }

    /// <summary>  
    /// 获取value  
    /// </summary>  
    /// <param name="key"></param>  
    /// <returns></returns>  
    public static string GetValue(string key)
    {
        if (dic.ContainsKey(key) == false)
        {
            return null;
        }
        string value = null;
        dic.TryGetValue(key, out value);
        return value;
    }
}