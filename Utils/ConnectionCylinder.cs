using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ConnectionCylinder : MonoBehaviour
{
    // public Transform startTran;
    // public Transform targetTran;
	private float initScale = -1;
	void Awake()
	{
		initScale = transform.localScale.x;
	}


    // Update is called once per frame
    // void Update()
    // {
    //     SetCylinder(startTran.position, targetTran.position);
    // }

    public void SetCylinder(Vector3 startPos, Vector3 endPos)
    {
        transform.position = (startPos + endPos) / 2;

        transform.up = endPos - startPos;
        Vector3 localScale = transform.localScale;
        localScale.z = (endPos - startPos).magnitude;
        transform.localScale = new Vector3(initScale, Vector3.Distance(startPos, endPos) / 2, initScale) ;
    }
}
