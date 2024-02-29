using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class FacebookManager : MonoBehaviour
{
    private string fbLogingState = string.Empty;

    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    Debug.LogError("Couldn't initialize");
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
        {
            FB.ActivateApp();
        }
    }

    private void Update()
    {
        if (FB.IsInitialized)
        {
            if (FB.IsLoggedIn)
            {
                fbLogingState = "Loged in!";
            }
            else
            {
                fbLogingState = "Loged out";
            }
        }
    }

    public static void LoginFacebook()
    {
        var permissions = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(permissions);
    }
    public void LogOut()
    {
        FB.LogOut();
    }


    public void Invite()
    {
        // FB.ShareLink(new System.Uri(""), "");
        FB.AppRequest("Join me on BumpLad", null,null, null, null, null, " ", delegate (IAppRequestResult result)
            {
                Debug.Log(result.RawResult);
            });
    }
    public void FeedFacebook()
    {
        if (FB.IsLoggedIn)
        {
            FB.FeedShare();
        }
    }
    public void FacebookGameRequest()
    {
        FB.AppRequest("Come play with me this awesome game!");
    }
    public string GetLogedState()
    {
        return fbLogingState;
    }
}