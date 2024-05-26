using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefsManger.PP_ServerURL() == null)
        {
            PlayerPrefs.SetString("ServerURL", PlayerPrefsManger.defaultServerURL);
        }
    }

}
