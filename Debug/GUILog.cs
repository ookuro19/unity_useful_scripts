/*
 * @Description: screen loger
 * @Author: ookuro19 
 * @Date: 2018-12-19 15:19:51 
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-12-19 15:21:38
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class GUILog : MonoBehaviour
{
    public static StringBuilder sb = new StringBuilder();

    public void OnGUI()
    {
        GUIStyle bb = new GUIStyle();
        bb.normal.background = null;
        bb.normal.textColor = new Color(1, 0, 0);
        bb.fontSize = 80;
        GUI.Label(new Rect(0, 0, 200, 200), sb.ToString(), bb);
    }
}
