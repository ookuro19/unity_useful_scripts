/*
 * @Description: 本地化unit
 * @Author: ookuro19 
 * @Date: 2018-08-16 15:27:15 
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-12-13 18:28:08
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocalizationText : MonoBehaviour
{
    public string key = "";
    public int[] _fontSizeArr;
    public Font[] _fontArr;

    private bool m_isTextSet = false;

    void Start()
    {
        if (!m_isTextSet)
        {
            GetComponent<Text>().text = System.Text.RegularExpressions.Regex.Unescape(LocalizationModule.GetValue(key));
        }

        if (_fontSizeArr.Length > 0)
        {
            GetComponent<Text>().resizeTextMaxSize = _fontSizeArr[(int)CurrentGameInfo.g_LanguageType];
        }
        // Debug.Log("LocalizationText " + key + " : " + GetComponent<Text>().text);
        if (_fontArr.Length > 0)
        {
            GetComponent<Text>().font = _fontArr[(int)CurrentGameInfo.g_LanguageType];
        }
    }

    public void SetText(string tStr)
    {
        m_isTextSet = true;
        GetComponent<Text>().text = System.Text.RegularExpressions.Regex.Unescape(tStr);
    }

    public string GetText()
    {
        return GetComponent<Text>().text;
    }
}
