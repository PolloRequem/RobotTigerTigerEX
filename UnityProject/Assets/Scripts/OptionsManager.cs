using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OptionsManager : MonoBehaviour
{

    [SerializeField] private TMP_InputField serverURL;
    [SerializeField] private GameObject imageChek_ChangeServerUrl;



    public void ChangeURL()
    {
        PlayerPrefs.SetString("ServerURL", serverURL.text);
        imageChek_ChangeServerUrl.SetActive(true);
    }


    public void Default()
    {
        PlayerPrefs.SetString("ServerURL", PlayerPrefsManger.defaultServerURL);
        serverURL.text = PlayerPrefsManger.defaultServerURL;
        imageChek_ChangeServerUrl.SetActive(true);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
