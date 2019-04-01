/*
* @Description: 一些可以复用的函数
* @Author: ookuro19
* @Date:   2018-07-05 16:34:25
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-12-03 17:12:10
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public static class CommonFunction
{

    #region 计算时间戳差值
    //与提供的时间戳对比，获得相应倒计时	
    public static float GetRemainTime(string timeStamp)
    {
        DateTime dateTimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        TimeSpan nowTS = DateTime.UtcNow - dateTimeStart;
        long lTime;

        if (timeStamp.Length.Equals(10))
        {
            lTime = long.Parse(timeStamp + "0000000");//判断是10位
        }
        else
        {
            lTime = long.Parse(timeStamp + "0000");//13位
        }

        TimeSpan severTimeSpan = new TimeSpan(lTime);
        TimeSpan tSpan = severTimeSpan.Subtract(nowTS);
        //Debug.Log("当前时间的时间戳:  " + nowTS.TotalSeconds.ToString() + "  给定的获得的时间戳  " + severTimeSpan.TotalSeconds.ToString() + " tSpan: " + tSpan.TotalSeconds.ToString());

        return (float)tSpan.TotalSeconds;
    }

    //与提供的时间戳对比，获得相应倒计时timespan
    public static TimeSpan GetRemainTimeSpan(string timeStamp)
    {
        DateTime dateTimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        TimeSpan nowTS = DateTime.UtcNow - dateTimeStart;
        long lTime;

        if (timeStamp.Length.Equals(10))
        {
            lTime = long.Parse(timeStamp + "0000000");//判断是10位
        }
        else
        {
            lTime = long.Parse(timeStamp + "0000");//13位
        }

        TimeSpan severTimeSpan = new TimeSpan(lTime);
        TimeSpan tSpan = severTimeSpan.Subtract(nowTS);
        //Debug.Log("当前时间的时间戳:  " + nowTS.TotalSeconds.ToString() + "  给定的获得的时间戳  " + severTimeSpan.TotalSeconds.ToString() + " tSpan: " + tSpan.TotalSeconds.ToString());

        return tSpan;
    }

    //与提供的时间戳对比，获得经过的时间	
    public static TimeSpan GetPassedTime(string timeStamp)
    {
        DateTime dateTimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        TimeSpan nowTS = DateTime.UtcNow - dateTimeStart;
        long lTime;

        if (timeStamp.Length.Equals(10))
        {
            lTime = long.Parse(timeStamp + "0000000");//判断是10位
        }
        else
        {
            lTime = long.Parse(timeStamp + "0000");//13位
        }

        TimeSpan severTimeSpan = new TimeSpan(lTime);
        TimeSpan tSpan = nowTS.Subtract(severTimeSpan);

        //Debug.Log("当前时间的时间戳:  " + nowTS.TotalSeconds.ToString() + "  给定的获得的时间戳  " + severTimeSpan.TotalSeconds.ToString() + " tSpan: " + tSpan.TotalSeconds.ToString());

        return tSpan;
    }

    public static String GetTodayNum()
    {
        DateTime today = DateTime.Today;
        return string.Format("{0:00}{1:00}{2:00}", today.Year % 100, today.Month, today.Day);
    }

    /// <summary>
    /// 获得当前时刻1天后的时间戳(10位)
    /// </summary>
    /// <returns>The tomorrow time span.</returns>
    /// <param name="bflag">bflag为真时获取10位时间戳,为假时获取13位时间戳..</param>
    public static string GetTomorrowTimeSpan(bool bflag)
    {
        DateTime dateTimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        TimeSpan nowTS = DateTime.UtcNow - dateTimeStart;

        string ret = string.Empty;
        if (bflag)
        {
            ret = Convert.ToInt64(nowTS.TotalSeconds).ToString(); //获得10位时间戳，精确到秒
        }
        else
        {
            ret = Convert.ToInt64(nowTS.TotalMilliseconds).ToString(); //获得13位时间戳，精确到毫秒
        }

        return ret;
    }
    #endregion

    #region 转换为字符串
    public static string ListToStr<T>(List<T> tList)
    {
        string tStr = string.Empty;
        int tCount = tList.Count;

        for (int i = 0; i < tCount; i++)
        {
            tStr += tList[i];
            if (i != tCount - 1)
            {
                tStr += "  ";
            }
        }

        return tStr;
    }
    #endregion

    //分数改变时效果
    public static IEnumerator ScoreChange(Text m_Test, int startScore, int endScore)
    {
        Debug.Log("minScore:" + startScore + " maxScore: " + endScore);
        int offset = (int)Mathf.Ceil((endScore - startScore) / 10);
        offset = Mathf.Clamp(offset, 1, 100);
        for (int i = startScore; i <= endScore; i += offset)
        {
            m_Test.transform.DOScale(1.2f, GameConstant.digitChangeDuration);
            yield return GameConstant.WFS_DigitChangeWaitTime;
            // VoiceCtrl.Instance.PlaySound(AudioType.UI.ScoreChange);
            m_Test.text = i.ToString();
        }
        m_Test.text = endScore.ToString();
        m_Test.transform.DOScale(1f, GameConstant.digitChangeDuration);
        // VoiceCtrl.Instance.StopUISound();
        yield return null;
    }

    #region Android
    public static string GetAndroidBrand()
    {
        string android_brand = "Huawei";//HONOR
        try
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaObject brand = new AndroidJavaClass("android.os.Build");
            android_brand = brand.GetStatic<string>("BRAND");
#endif
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }

        return android_brand;
    }

    #endregion
}