/*
* @Description: 点击按钮时发生的效果
* @Author: ookuro19
* @Date:   2018-06-21 15:15:22
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-07-30 20:03:38
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ClickButtonBehavior : MonoBehaviour, IPointerClickHandler {
	
	public bool m_IsScaleChangeAwailable = true;
	public bool m_IsVoiceAvailable = true;

	//Init local scale of button
	private Vector3 m_InitLocalScale = Vector3.one;
	//About Button Click
	private static float buttonClickDuration = 0.1f;

	void Awake()
	{
		m_InitLocalScale = gameObject.GetComponent<RectTransform>().localScale;
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (m_IsScaleChangeAwailable) 
		{
			gameObject.transform.DOScale (m_InitLocalScale * 0.9f, buttonClickDuration).OnComplete (delegate {  
				gameObject.transform.DOScale (m_InitLocalScale, buttonClickDuration);
				});
		}
		if (m_IsVoiceAvailable) 
		{
			VoiceCtrl.Instance.PlaySound (AudioType.UI.Click);
		}
	}
}
