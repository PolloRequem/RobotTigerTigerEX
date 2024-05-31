using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using TMPro;


public class Sim_CompleteManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nomeMissioneTitolo;
    [SerializeField] private TextMeshProUGUI nomePlayer;

    [SerializeField] private TextMeshProUGUI puntiOttenuti;
    [SerializeField] private TextMeshProUGUI puntiTotali;



    public float duration = 2.0f;



 
    private void Start()
    {
        nomeMissioneTitolo.text = PlayerPrefsManger.PP_Mission_Copleted_Name();
        nomePlayer.text = PlayerPrefsManger.PP_Mission_Copleted_Player();
        StartCoroutine(IncrementPoints(10000));


    }

    private IEnumerator IncrementPoints(int targetPoints)
    {
        int currentPoints = 0;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            currentPoints = Mathf.FloorToInt(Mathf.Lerp(0, targetPoints, elapsedTime / duration));
            puntiOttenuti.text = currentPoints.ToString();
            yield return null;
        }

        puntiOttenuti.text = targetPoints.ToString();
    }



    private IEnumerator PUT_ModifyPlayer()
    {

     
        PlayerPrefsManger.Current_playerLogged.totalPoints += PlayerPrefsManger.Current_Score;
        PlayerPrefsManger.Current_playerLogged.missionsCompleted += 1;

        using (UnityWebRequest webRequest = UnityWebRequest.Put(PlayerPrefsManger.PP_ServerURL() + "/players/addPoints", JsonConvert.SerializeObject(PlayerPrefsManger.Current_playerLogged)))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(String.Format("Something went wrong  {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:

                    print(webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}


