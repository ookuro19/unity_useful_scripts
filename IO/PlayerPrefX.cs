/*
* @Description: 使用Unity自带持久化存储数组
* @Author: ookuro19
* @Date:   2018-07-07 18:27:38
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-07-28 19:35:24
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefX
{
    public static int[] GetIntArray(string str)
    {
        int[] tmp = new int[PlayerPrefs.GetInt(str)];
        for (int i = 0; i < PlayerPrefs.GetInt(str); i++)
            tmp[i] = PlayerPrefs.GetInt(str + "__" + i);
        return tmp;
    }
    public static void SetIntArray(string str, int[] nums)
    {
        PlayerPrefs.SetInt(str, nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            PlayerPrefs.SetInt(str + "__" + i, nums[i]);
        }
    }
}