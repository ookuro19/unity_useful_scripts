using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
// using cn.sharesdk.unity3d;

public class ShareCtrl : SingletonMono<ShareCtrl>
{
    //点击分享按钮调用的方法
    public void ShareInfo()
    {
        ScreenCapture.CaptureScreenshot("screenshot.png");
        string destination = Path.Combine(Application.persistentDataPath, "screenshot.png");

        if (!Application.isEditor)
        {
            using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    //调用静态方法
                    jo.Call("ShareImg", destination);
                }
            }
        }
    }

    #region sharesdk方式
    // private ShareSDK shareSdk;
    // //显示回调信息的文本框
    // void Start()
    // {
    //     shareSdk = GetComponent<ShareSDK>();
    //     //分享回调事件 绑定
    //     shareSdk.shareHandler += ShareResultHandle;
    //     // //授权回调事件
    //     // shareSdk.authHandler += AuthResultHandle;
    //     // //用户信息事件
    //     // shareSdk.showUserHandler += GetUserInfoResultHandle;
    // }


    //点击分享按钮调用的方法，
    // public void ShareInfo()
    // {
    //     ShareContent content = new ShareContent();
    //     content.SetText("this is a test string.");
    //     ScreenCapture.CaptureScreenshot("screen.png");

    //     content.SetImagePath(Application.persistentDataPath + "/screen.png");
    //     content.SetTitle("哈视奇科技");
    //     // content.SetUrl("http://www.hashvr.com");
    //     content.SetShareType(ContentType.Image);

    //     #region 复杂但可行版本
    //     // ShareContent content = new ShareContent();
    //     // //(Android only) 隐藏九宫格里面不需要用到的平台（仅仅是不显示平台）
    //     // //(Android only) 也可以把jar包删除或者把Enabl属性e改成false（对应平台的全部功能将用不了）
    //     // content.SetText("this is a test string.");
    //     // content.SetImageUrl("http://ww3.sinaimg.cn/mw690/be159dedgw1evgxdt9h3fj218g0xctod.jpg");
    //     // content.SetTitle("test title");
    //     // //(Android only) 针对Android绕过审核的多图分享，传图片String数组 
    //     // string[] imageArray = { "/sdcard/test.jpg", "http://f1.webshare.mob.com/dimgs/1c950a7b02087bf41bc56f07f7d3572c11dfcf36.jpg", "/sdcard/test.jpg" };
    //     // content.SetImageArray(imageArray);
    //     // content.SetTitleUrl("http://www.mob.com");
    //     // content.SetSite("Mob-ShareSDK");
    //     // content.SetSiteUrl("http://www.mob.com");
    //     // content.SetComment("test description");
    //     // content.SetUrl("http://www.mob.com");
    //     // content.SetShareType(ContentType.Image);
    //     #endregion

    //     //弹出分享菜单选择列表
    //     shareSdk.ShowPlatformList(null, content, 100, 100);

    //     //指定平台分享
    //     //shareSdk.ShowShareContentEditor (PlatformType.QQ,content);

    // }
    #endregion
}