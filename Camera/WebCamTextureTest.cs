/*
 * @Description:自调整尺寸视窗
 * @Author: ookuro19 
 * @Date: 2018-10-29 19:56:29 
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-10-29 20:33:19
 */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WebCamTextureTest : MonoBehaviour
{
    [Range(0.1f, 10f)]
    public float ScaleFactor = 2f;
    public RawImage rawImage;

    private WebCamTexture webCamTexture;
    private RectTransform previewTran;
    private bool m_isSizeSet = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CallWebCam());
        previewTran = rawImage.rectTransform;
    }

    IEnumerator CallWebCam()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {

            webCamTexture = new WebCamTexture();

            WebCamDevice[] devices = WebCamTexture.devices;

            webCamTexture.deviceName = devices[0].name;

            rawImage.texture = webCamTexture;
            webCamTexture.Play();

            Debug.Log(string.Format("Start tTex.width: {0}, tTex.height: {1}", webCamTexture.width, webCamTexture.height));
            if (!m_isSizeSet)
            {
                SetPreviewSize((float)webCamTexture.width / (float)webCamTexture.height);
            }
            Debug.Log(string.Format("Start tTex.width: {0}, tTex.height: {1}", webCamTexture.width, webCamTexture.height));

        }
    }
    
    void SetPreviewSize(float tScale)
    {
        Debug.Log("tScale: " + tScale);
        previewTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / ScaleFactor);
        previewTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, tScale * Screen.height / ScaleFactor);
    }
}