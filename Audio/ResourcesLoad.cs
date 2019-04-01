/*
* @Description: Controller that load audio source from Resources
* @Author: ookuro19
* @Date:   2018-06-21 18:26:19
* @Last Modified by:   ookuro19
* @Last Modified time: 2018-07-18 17:37:45
*/

using UnityEngine;  
using System.Collections;  

// 通过用户传递进来的枚举值, 自动的分析出该枚举值对应的资源在哪个路径下.  
public class ResourcesLoad : SingletonMono<ResourcesLoad>  
{  
	/// <summary>
    /// Loads the audio by enum
    /// </summary>
    /// <returns>The audio.</returns>
    /// <param name="enumName">Enum name.</param>
    public AudioClip LoadAudioClip (object enumName)
    {
        // enumName.GetType().DeclaringType 可以获得enumName所属的类
        // 获取枚举类型的字符串形式   enumName.GetType ().Name;  
        string enumType = enumName.GetType().Name;

        //空的字符串  
        string filePath = "Audio/" + enumType+ "/" + enumName.ToString ();  

        return Resources.Load<AudioClip> (filePath);
    }

    /// <summary>
    /// Loads the audio by enum
    /// </summary>
    /// <returns>The audio.</returns>
    /// <param name="enumName">Enum name.</param>
    public T Load<T> (object enumName) where T : Object  
    {
        // enumName.GetType().DeclaringType 可以获得enumName所属的类
        // 获取枚举类型的字符串形式   enumName.GetType ().Name;  
        string enumType = enumName.GetType().Name;

        //空的字符串  
        string filePath = string.Empty;  

        switch (enumType) {
            case "Activity":
            {  
                filePath = "Audio/Activity/" + enumName.ToString ();  
                break;  
            }
            case "AR":
            {  
                filePath = "Audio/AR/" + enumName.ToString ();  
                break;  
            }
            case "Bgm":
            {  
                filePath = "Audio/Bgm/" + enumName.ToString ();  
                break; 
            }
            case "cash":
            {  
                filePath = "Audio/cash/" + enumName.ToString ();  
                break;  
            }
            case "Dog":
            {  
                filePath = "Audio/Dog/" + enumName.ToString ();  
                break;  
            }
            case "Items":
            {  
                filePath = "Audio/Items/" + enumName.ToString ();  
                break;  
            }
            case "UI":
            {  
                filePath = "Audio/UI/" + enumName.ToString ();  
                break;  
            }

            default:  
            {  
                break;  
            }  
        }
        return Resources.Load<T> (filePath);
    }
}  