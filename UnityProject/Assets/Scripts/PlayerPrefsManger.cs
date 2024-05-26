using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public   class PlayerPrefsManger : MonoBehaviour
{
   public static string PP_LoginUsername()
    {
        return PlayerPrefs.GetString("Login_UserName");
    }

    public static string PP_LoginRole()
    {
        return PlayerPrefs.GetString("Login_Role");
    }


    public static string PP_Current_Player_CustomizePlayer_UserName()
    {
        return PlayerPrefs.GetString("_Current_CustomizePlayer_username");
    }

    public static string PP_ServerURL()
    {
        return PlayerPrefs.GetString("ServerURL");
    }

    public static PlayerBean Current_playerBean_Customize;

    public static string defaultServerURL = "http://localhost:8170/WebServerAPIv9.1";
}
