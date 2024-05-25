using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class Test_Test1GameManager : MonoBehaviour
{


    [Header("URL")]
    [SerializeField] TMP_InputField urlGET;
    [SerializeField] TMP_InputField urlPOST;

    [Header("Form")]
    [SerializeField] TMP_InputField form1;
    [SerializeField] TMP_InputField form2;

    [Header("Risposta")]
    [SerializeField] TextMeshProUGUI risposta;



    public void Call_GET_REQUEST()
    {
        StartCoroutine(GET_REQUEST());
    }

    public void Call_POST_REQUEST()
    {
        StartCoroutine(POST_REQUEST());
    }

    private IEnumerator POST_REQUEST()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", form1.text);
        form.AddField("password", form2.text);
        using (UnityWebRequest webRequest = UnityWebRequest.Post(urlPOST.text, form))
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

                    risposta.text = webRequest.downloadHandler.text;
                    break;
            }
        }
    }
    private IEnumerator GET_REQUEST()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(urlGET.text))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:

                    print((String.Format("Something went wrong  {0}", webRequest.error)));
                    break;
                case UnityWebRequest.Result.Success:

                    risposta.text = webRequest.downloadHandler.text;

                    break;
            }
        }
    }

}
