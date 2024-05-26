using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using TMPro;

public class Mangaer_Player_CustomizePlayer : MonoBehaviour
{
    [Header("PlayerInfo")]
    [SerializeField] private TextMeshProUGUI text_player_username;
    [SerializeField] private TextMeshProUGUI text_player_role;

    [Header("ChangePanel")]
    [SerializeField] private GameObject GO_changeUser;
    [SerializeField] private GameObject GO_changeRole;
    [SerializeField] private GameObject GO_changePassword;

    [Header("Input")]
    [SerializeField] private TMP_Dropdown roleSeletc;
    [SerializeField] private TMP_InputField userInputField;
    [SerializeField] private TMP_InputField passwordInputField;

    [Header("Bottoni")]
    [SerializeField] private GameObject button_ChangeUser;
    [SerializeField] private GameObject button_ChangeRole;
    [SerializeField] private Button button_ResetPassword;

    [Header("Errori")]
    [SerializeField] private TextMeshProUGUI errorMessage;

    private PlayerBean newPlayer;

    private bool isChangeRuoloPressed;
   
    private void Start()
    {
     
        text_player_role.text = PlayerPrefsManger.Current_playerBean_Customize.role;
        text_player_username.text = PlayerPrefsManger.Current_playerBean_Customize.username;
        
        newPlayer = PlayerPrefsManger.Current_playerBean_Customize;

        button_ResetPassword.interactable = false;

       
    }




    public void cambiaNome()
    {
        newPlayer.username = userInputField.text;


       
    }

    public void cambiaRuolo()
    {
        newPlayer.role = roleSeletc.options[roleSeletc.value].text;

    }

    public void Button_ChangeUser()
    {
        button_ChangeUser.SetActive(false);
        GO_changeUser.SetActive(true);
      
    }

    public void Button_ChangeRole()
    {
        button_ChangeRole.SetActive(false);
        GO_changeRole.SetActive(true);
       
    }


    public void Button_ChangePassword()
    {
        GO_changePassword.SetActive(true);

    }



    public void Call_PUT_ChangePlayer()
    {
        StartCoroutine(PUT_ChangePlayer());
    }
    private IEnumerator PUT_ChangePlayer()
    {
     
        using (UnityWebRequest webRequest = UnityWebRequest.Put(PlayerPrefsManger.PP_ServerURL() + "/data/players", JsonConvert.SerializeObject(newPlayer)))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:

                    print((String.Format("Something went wrong  {0}", webRequest.error)));
                    break;
                case UnityWebRequest.Result.Success:

                    analizzaRisposta(webRequest.downloadHandler.text);


                    break;
            }
        }
    }

    private void analizzaRisposta(string riposta)
    {
        if(riposta == "1")
        {
            SceneManager.LoadScene("Hub_Players");
        }
        else if(riposta== "2")
        {
            errorMessage.text = "User Name already exist";
        }
        else
        {
            errorMessage.text = riposta;
        }
    }

    
}
