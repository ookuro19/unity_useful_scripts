/*
 * @Description:JsonData数据转换
 * @Author: ookuro19 
 * @Date: 2018-07-28 11:16:12 
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-07-28 19:34:58
 * @Reference: https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonHelper
{

#region json array 相关操作
	//如果要支持List和Array，建议写一个包装类，将其包含再里边。并且泛型中加入[Serializable]标签
	//没有包含[Serializable]的类，不可被包含在序列化类内
	//可参考https://blog.csdn.net/oyji1992/article/details/74505230
	[System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }

	public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    //Generate a JSON representation of the public fields of an object
    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }
#endregion
}
