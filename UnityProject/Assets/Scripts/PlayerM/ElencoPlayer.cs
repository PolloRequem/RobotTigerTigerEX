using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class ElencoPlayer : MonoBehaviour
{
    [SerializeField] private UI_DisplayPlayer uiDiplayer;

    [SerializeField] private GameObject delete_ConfirmTab;

    [SerializeField] private Button  delete_Button;
    [SerializeField] private Button customize_Button;
    public static string playerSelected;

    public void Start()
    {
        delete_ConfirmTab.SetActive(false);
        Call_GET_Player();
        customize_Button.interactable = false;
        delete_Button.interactable = false;
    }

    public void Update()
    {

        if (playerSelected != null)
        {
            customize_Button.interactable = true;
            delete_Button.interactable = true;
        }
    }

    private void Call_DELETE_Player()
    {
        StartCoroutine(DELETE_Player());
    } 
    private void Call_GET_Player()
    {
        StartCoroutine(GET_Player());
    }


    private IEnumerator GET_Player()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost:8161/WebServerAPI/data/players"))
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

                    List<PlayerBean> playerJson = JsonConvert.DeserializeObject<List<PlayerBean>>(webRequest.downloadHandler.text);
                   foreach(PlayerBean p in playerJson)
                    {
                        p.toString();
                    }
                    uiDiplayer.UpdateVisual(playerJson);

                    break;
            }
        }
    }

    private IEnumerator DELETE_Player()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Delete("http://localhost:8161/WebServerAPI/data/players/"+playerSelected))
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

                    //List<PlayerBean> playerJson = JsonConvert.DeserializeObject<List<PlayerBean>>(webRequest.downloadHandler.text);
                    //uiDiplayer.UpdateVisual(playerJson);

                    break;
            }
        }
    }


    public void Button_Delete()
    {
        delete_ConfirmTab.SetActive(true);
    }

    public void Button_ConfirmTab_Cancel()
    {
        delete_ConfirmTab.SetActive(false);
    }

    public void Button_ConfirmTab_Delete()
    {
        Call_DELETE_Player();
        delete_ConfirmTab.SetActive(false);
    }
    //private IEnumerator PUT_ResetPassword_Player()
    //{

    //    using (UnityWebRequest webRequest = UnityWebRequest.Put("http://localhost:8161/WebServerAPI/data/players",))
    //    {
    //        yield return webRequest.SendWebRequest();

    //        switch (webRequest.result)
    //        {
    //            case UnityWebRequest.Result.ConnectionError:
    //            case UnityWebRequest.Result.DataProcessingError:
    //            case UnityWebRequest.Result.ProtocolError:

    //                print((String.Format("Something went wrong  {0}", webRequest.error)));
    //                break;
    //            case UnityWebRequest.Result.Success:

    //                List<PlayerBean> playerJson = JsonConvert.DeserializeObject<List<PlayerBean>>(webRequest.downloadHandler.text);
    //                uiDiplayer.UpdateVisual(playerJson);

    //                break;
    //        }
    //    }
    //}
}
