using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    private string url;
    UnityWebRequest webRequest;
    [SerializeField] TMP_InputField usernameField;
    [SerializeField] TMP_InputField passwordField;
    [SerializeField] TextMeshProUGUI erroreText;

    public void CallLogin()
    {
       
        StartCoroutine(POST_UserLogin());
        url = "http://localhost:8161/WebServerAPI/api/hello?username="+usernameField.text+"&password="+passwordField.text;
    }

    
    private IEnumerator POST_UserLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("password", passwordField.text);
        using (webRequest = UnityWebRequest.Post("http://localhost:8161/WebServerAPI/authenticator/login", form))
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


    private bool TrovaUtente(string webRequestTEXT)
    {
        switch (webRequestTEXT)
        {
            case "1":
                UtenteLoggato();
                return true;
                
            case "2":
                print("admin");
                AdminLoggato();
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
