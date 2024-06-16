using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using TMPro;

public class ProfileManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI input_id;
    [SerializeField] TextMeshProUGUI input_username;
    [SerializeField] TextMeshProUGUI input_email;
    [SerializeField] TextMeshProUGUI input_role;

    [SerializeField] TextMeshProUGUI input_totalPoints;
    [SerializeField] TextMeshProUGUI input_MissionsCompleted;

    private void Start()
    {
        StartCoroutine(GET_Player());
    }

    private IEnumerator GET_Player()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(PlayerPrefsManger.PP_ServerURL() + "/data/players/"+ PlayerPrefsManger.Current_playerLogged.username))
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

                    PlayerBean playerJson = JsonConvert.DeserializeObject<PlayerBean>(webRequest.downloadHandler.text);
                    SetPlayerProfile(playerJson);
                    break;
            }
        }
    }


    private void SetPlayerProfile(PlayerBean player)
    {
        input_id.text = player.id.ToString();
        input_username.text = player.username;
        input_email.text = player.email;
        input_role.text = player.role;
        input_totalPoints.text = player.totalPoints.ToString();
        input_MissionsCompleted.text = player.missionsCompleted.ToString();

    }
}
