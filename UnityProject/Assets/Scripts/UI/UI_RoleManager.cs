using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class UI_RoleManager : MonoBehaviour
{
    [SerializeField] private Button playersHub_Button;
    void Start()
    {

        print(PlayerPrefs.GetString("Login_Role"));
        if (PlayerPrefs.GetString("Login_Role") != "admin")
        {
            playersHub_Button.interactable = false;
        }
    }
}
