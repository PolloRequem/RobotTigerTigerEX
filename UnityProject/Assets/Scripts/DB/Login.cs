using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
public class Login : MonoBehaviour
{
    UnityWebRequest webRequest;
    [SerializeField] TMP_InputField usernameField;
    [SerializeField] TMP_InputField passwordField;
    [SerializeField] TextMeshProUGUI erroreText;

    public void CallLogin()
    {
       
        StartCoroutine(POST_UserLogin());
     
    }

    
    private IEnumerator POST_UserLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("password", passwordField.text);
        using (webRequest = UnityWebRequest.Post(PlayerPrefsManger.PP_ServerURL() + "/authenticator/login", form))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(String.Format("Something went wrong  {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:

                    TrovaUtente(webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    private IEnumerator GET_UserLogged()
    {
       
        using (webRequest = UnityWebRequest.Get(PlayerPrefsManger.PP_ServerURL() + "/data/players/"+ usernameField.text))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(String.Format("Something went wrong  {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:

                   PlayerBean playerLoggato = JsonConvert.DeserializeObject<PlayerBean>(webRequest.downloadHandler.text);
                    PlayerPrefsManger.Current_playerLogged = playerLoggato;

                    if (PlayerPrefsManger.Current_playerLogged.role.Equals("admin"))
                    {
                        AdminLoggato();
                    }
                    else
                    {
                        UtenteLoggato();
                    }

                    break;
            }
        }
    }



    private bool TrovaUtente(string webRequestTEXT)
    {
        switch (webRequestTEXT)
        {
            case "1":
                StartCoroutine(GET_UserLogged());
                return true;

            default:
                erroreText.text = webRequestTEXT;
                return false;
        }

    }

    private void UtenteLoggato()
    {
        
        PlayerPrefs.SetString("Login_Loggato", "true");
        PlayerPrefs.SetString("Login_UserName", usernameField.text);
        PlayerPrefs.SetString("Login_Role", "user");
        PlayerPrefs.Save();
        SceneManager.LoadScene("_MainScene");

    }

    private void AdminLoggato()
    {

        PlayerPrefs.SetString("Login_Loggato", "true");
        PlayerPrefs.SetString("Login_UserName", usernameField.text);
        PlayerPrefs.SetString("Login_Role", "admin");
        PlayerPrefs.Save();
        SceneManager.LoadScene("_MainScene");
    }


}
