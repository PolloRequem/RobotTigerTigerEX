using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class ElencoPlayer : MonoBehaviour
{
    [SerializeField] private UI_DisplayPlayer uiDiplayer;

    public static string playerSelected;

    public void Start()
    {
        Call_GET_Player();
    }


    [ContextMenu("Get Players")]
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

        using (UnityWebRequest webRequest = UnityWebRequest.Delete("http://localhost:8161/WebServerAPI/data/players"))
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
