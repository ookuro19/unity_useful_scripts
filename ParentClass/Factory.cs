/*
 * @Description: 工厂类
 * @Author: ookuro19 
 * @Date: 2018-08-04 17:42:51 
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-08-04 17:56:22
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : SingletonMono<Factory>
{

    public GameObject tPrefab;
    List<GameObject> freeObjList = new List<GameObject>();
    List<GameObject> usedObjList = new List<GameObject>();


    #region 初始化
    void Awake()
    {
        InitFactory();
    }

    //工厂初始化
    protected virtual void InitFactory()
    {

    }
    #endregion


    #region Produce
    //产生物体后的行为
    protected virtual void OnAfterProduce(GameObject obj)
    {
        obj.SetActive(true);
    }

    public GameObject Produce()
    {
        GameObject obj;
        if (freeObjList.Count > 0)
        {
            obj = freeObjList[0];
            freeObjList.RemoveAt(0);
        }
        else
        {
            obj = GameObject.Instantiate(tPrefab);
        }

        usedObjList.Add(obj);

        OnAfterProduce(obj);
        return obj;
    }
    #endregion

    #region Recycle
    //回收之前的行为
    protected virtual void OnBeforeRecycle(GameObject obj)
    {
        obj.SetActive(false);
    }

    //回收
    public void Recycle(GameObject obj)
    {
        OnBeforeRecycle(obj);
        if (usedObjList.Contains(obj))
        {
            usedObjList.Remove(obj);
            freeObjList.Add(obj);
        }
    }
    #endregion

    #region Clear
    public void ClearFactory()
    {
        if (usedObjList.Count > 0)
        {
            for (int i = 0; i < usedObjList.Count; i++)
            {
                usedObjList[i].SetActive(false);
                if (usedObjList[i].transform.parent != null)
                {
                    usedObjList[i].transform.parent.DetachChildren();
                }
                freeObjList.Add(usedObjList[i]);
            }
            usedObjList.Clear();
        }
    }

    // public void ClearFactory()
    // { 
    // 	if (freeObjList.Count > 0) {
    // 		for (int i = 0; i < freeObjList.Count; i++) {
    // 			Destroy (freeObjList [i]);
    // 		}
    // 	}
    // 	freeObjList.Clear ();

    // 	if (usedObjList.Count > 0) {
    // 		for (int i = 0; i < usedObjList.Count; i++) {
    // 			Destroy (usedObjList [i]);
    // 		}
    // 	}
    // 	usedObjList.Clear ();
    // }
    #endregion

}
