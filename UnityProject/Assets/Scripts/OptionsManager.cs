using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OptionsManager : MonoBehaviour
{

    [SerializeField] private TMP_InputField serverURL;



    public void ChangeURL()
    {
        PlayerPrefs.SetString("ServerURL", serverURL.text);
    }


    public void Default()
    {
        PlayerPrefs.SetString("ServerURL", PlayerPrefsManger.defaultServerURL);
    }
}
