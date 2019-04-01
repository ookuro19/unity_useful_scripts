/*
 * @Description: 本地化
 * @Author: ookuro19 
 * @Date: 2018-08-16 15:27:15 
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-08-16 15:28:07
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimpleLocalizationText : MonoBehaviour
{
    private Text txt;
    public string ch = "";
    public string en = "";

    void Awake()
    {
        txt = gameObject.GetComponent<Text>();
    }

    public void OnEnable()
    {
        if (CurrentGameInfo.g_LanguageType == ELanguageType.Chinese)
        {
            txt.text = System.Text.RegularExpressions.Regex.Unescape(ch);
        }
        else
        {
            txt.text = System.Text.RegularExpressions.Regex.Unescape(en);
        }
    }
}
