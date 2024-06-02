using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class ElencoMission : MonoBehaviour
{

    [SerializeField] private UI_DiplayMIsisons uiDiplayer;



    public void Start()
    {
        Call_GET_Missions();
    }

    [ContextMenu("Get Missioni")]
    private void Call_GET_Missions()
    {
        StartCoroutine(GET_Missions());
    }

    private IEnumerator GET_Missions()
    {
        
        using (UnityWebRequest webRequest = UnityWebRequest.Get(PlayerPrefsManger.PP_ServerURL() + "/data/missions"))
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

                    List<Mission> missionsJson = JsonConvert.DeserializeObject<List<Mission>>(webRequest.downloadHandler.text);

                    if (RoleManger.isPlayerAdmin())
                    {
                        uiDiplayer.UpdateVisual(TogliCompletati(missionsJson));
                    }
                    else
                    {
                        uiDiplayer.UpdateVisual(TogliCompletatiEthisUser(missionsJson));
                    }
                   

                    break;
            }
        }
    }

    private List<Mission> TogliCompletatiEthisUser(List<Mission> jsonMissions)
    {
        List<Mission> missionDummyList = new List<Mission>();

        foreach (Mission mission in jsonMissions)
        {
            if (mission.dataFine == null && mission.player == PlayerPrefs.GetString("Login_UserName"))
            {
                missionDummyList.Add(mission);
            }
        }

        return missionDummyList;
    }




    private List<Mission> TogliCompletati(List<Mission> jsonMissions)
    {
        List<Mission> missionDummyList = new List<Mission>();

        foreach (Mission mission in jsonMissions)
        {
            if (mission.dataFine == null)
            {
                missionDummyList.Add(mission);
            }
        }

        return missionDummyList;
    }
}
