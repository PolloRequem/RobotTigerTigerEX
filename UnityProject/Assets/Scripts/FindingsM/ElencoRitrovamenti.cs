using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class ElencoRitrovamenti : MonoBehaviour
{
    [SerializeField] private UI_DispalyFindings uiDiplayer;
    [SerializeField] private TextMeshProUGUI missioneNameTitle;


    public void Start()
    {
        Call_GET_Ritrovamenti();
        missioneNameTitle.text = PlayerPrefsManger.PP_Mission_Started_Name();


    }

    [ContextMenu("Get Missioni")]
    private void Call_GET_Ritrovamenti()
    {
        StartCoroutine(GET_Ritrovamenti());
    }

    private IEnumerator GET_Ritrovamenti()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(PlayerPrefsManger.PP_ServerURL() + "/data/ritrovamenti"))
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

                    List<Ritrovamenti> ritrovamentiJson = JsonConvert.DeserializeObject<List<Ritrovamenti>>(webRequest.downloadHandler.text);
                    uiDiplayer.UpdateVisual(RitrovamentiBYID(ritrovamentiJson));
                    break;
            }
        }
    }

    private List<Ritrovamenti> RitrovamentiBYID(List<Ritrovamenti> ritrovamentiJson)
    {
        List<Ritrovamenti> ritrovamentiDummyList = new List<Ritrovamenti>();

        foreach (Ritrovamenti ritrovamento in ritrovamentiJson)
        {
            if (ritrovamento.missione == PlayerPrefs.GetString("IDMission_Started"))
            {
                ritrovamentiDummyList.Add(ritrovamento);
            }
        }

        return ritrovamentiDummyList;
    }

}
