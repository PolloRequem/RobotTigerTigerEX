using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    private int d;
    //private string url;
    //private string postString;
    UnityWebRequest webRequest;
    [SerializeField] TMP_InputField usernameField;
    [SerializeField] TMP_InputField emailField;
    [SerializeField] TMP_InputField passwordField;
    [SerializeField] TMP_InputField ConfirmPasswordField;
    [SerializeField] TextMeshProUGUI erroreText;
    [SerializeField] Button registerButter;

    public void CallRegister()
    {

        

        if (passwordField.text != ConfirmPasswordField.text)
        {
            erroreText.text = "Le password non corrispondono.";
            return;
        }
        StartCoroutine(POST_RegisterUser());
        // url = "http://localhost:8161/WebServerAPI/api/register?" + "email="+emailField.text +"&username=" + usernameField.text + "&password=" + passwordField.text;
        //url = "http://localhost:8161/WebServerAPI/api/hello";// " " + "email=" + emailField.text + "&username=" + usernameField.text + "&password=" + passwordField.text;
        //postString = emailField.text + "," + usernameField.text + "," + passwordField.text;
    }

    private void Update()
    {
        if (usernameField.text.Length >= 3 && emailField.text.Length >= 4 && passwordField.text.Length >= 1 && ConfirmPasswordField.text.Length >= 1)
        {
            registerButter.interactable = true;


        }
        else
        {
            registerButter.interactable = false;
        }

    }
    private IEnumerator POST_RegisterUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("email", emailField.text);
        form.AddField("password", passwordField.text);
        using (webRequest = UnityWebRequest.Post("http://localhost:8161/WebServerAPI/authenticator/registration", form))
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

                   
                    AlaizzaResponseCode(webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    private bool AlaizzaResponseCode(string webResponseText)
    {
        if (webResponseText == "1")
        {
            UtenteRegistrato();
            return true;

        }
        else
        {
            erroreText.text = webResponseText;
            return false;
        }

    }

    private void UtenteRegistrato()
    {
        print(webRequest.downloadHandler.text);
        SceneManager.LoadScene("Registration_Succesfull");
    }


}
