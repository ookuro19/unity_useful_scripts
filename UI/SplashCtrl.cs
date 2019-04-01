using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashCtrl : SingletonMono<SplashCtrl>
{
    public CanvasGroup _logoCanvasGroup;

    // Use this for initialization
    void Start()
    {
        _logoCanvasGroup.alpha = 1;
        StartCoroutine(SwitchToLoadingScene());
    }

    IEnumerator SwitchToLoadingScene()
    {
		yield return GameConstant.WFS_OneSeconds;

        for (float i = 1; i > 0; i -= 0.01f)
        {
            _logoCanvasGroup.alpha = i;
            yield return null;
        }

        SceneManager.LoadSceneAsync("LoadingScene");
    }

}
