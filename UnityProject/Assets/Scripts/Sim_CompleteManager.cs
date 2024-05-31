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
    [SerializeField] private TextMeshProUGUI nomePlayer1;
    [SerializeField] private TextMeshProUGUI nomePlayer2;

    [SerializeField] private TextMeshProUGUI puntiOttenuti;
    [SerializeField] private TextMeshProUGUI puntiTotali;
    [SerializeField] private TextMeshProUGUI missioniCompletate;

    [SerializeField] private TextMeshProUGUI error_message;



   


    private void Start()
    {
        nomeMissioneTitolo.text = PlayerPrefsManger.PP_Mission_Copleted_Name();
        nomePlayer1.text = PlayerPrefsManger.PP_Mission_Copleted_Player();
        nomePlayer2.text = PlayerPrefsManger.PP_Mission_Copleted_Player();
        StartCoroutine(IncrementNumbers(puntiOttenuti,1f ,0f ,PlayerPrefsManger.Current_Score));
        StartCoroutine(IncrementNumbers(puntiTotali , 1f , 1.2f ,PlayerPrefsManger.Current_playerLogged.totalPoints+ PlayerPrefsManger.Current_Score));
        StartCoroutine(IncrementNumbers(missioniCompletate , .5f, 2.2f, PlayerPrefsManger.Current_playerLogged.missionsCompleted + 1));

        StartCoroutine(PUT_ModifyPlayer());
        StartCoroutine(PUT_ModifyMission());
    }

    private IEnumerator IncrementNumbers(TextMeshProUGUI textToChange, float duration, float wiatforSeconds,  int targetPoints)
    {


        yield return new WaitForSeconds(wiatforSeconds);

        int currentPoints = 0;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            currentPoints = Mathf.FloorToInt(Mathf.Lerp(0, targetPoints, elapsedTime / duration));
           textToChange.text = currentPoints.ToString();
            yield return null;
        }

        textToChange.text = targetPoints.ToString();
    }




    private IEnumerator PUT_ModifyPlayer()
    {

     
        PlayerPrefsManger.Current_playerLogged.totalPoints += PlayerPrefsManger.Current_Score;
        PlayerPrefsManger.Current_playerLogged.missionsCompleted += 1;

        using (UnityWebRequest webRequest = UnityWebRequest.Put(PlayerPrefsManger.PP_ServerURL() + "/data/players/addPoints", JsonConvert.SerializeObject(PlayerPrefsManger.Current_playerLogged)))
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

                    if (webRequest.downloadHandler.text != "1")
                    {
                        error_message.text = "Something went worong";
                    }
                    break;
            }
        }
    }

    private IEnumerator PUT_ModifyMission()
    {
        PlayerPrefsManger.Current_Mission_Complete = new Mission();
        PlayerPrefsManger.Current_Mission_Complete.id = PlayerPrefsManger.PP_Mission_Completed_Id();
        PlayerPrefsManger.Current_Mission_Complete.punteggio = PlayerPrefsManger.Current_Score;
        PlayerPrefsManger.Current_Mission_Complete.dataFine = UnityDateTOSQLDate(System.DateTime.Today.ToShortDateString());

        //non ho voglia di sistemarlo


        using (UnityWebRequest webRequest = UnityWebRequest.Put(PlayerPrefsManger.PP_ServerURL() + "/data/missions", JsonConvert.SerializeObject(PlayerPrefsManger.Current_Mission_Complete)))
        {

            webRequest.SetRequestHeader("Content-Type", "application/json");
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    error_message.text = webRequest.error;
                    Debug.LogError(String.Format("Something went wrong  {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:

                    if (webRequest.downloadHandler.text != "1")
                    {
                        error_message.text = "Something went worong";
                    }
                    break;
            }
        }
    }

    private string UnityDateTOSQLDate(string inputDate)
    {
        string[] dateParts = inputDate.Split('/');


        string day = dateParts[0];

        string month = dateParts[1];

        string year = dateParts[2];



        return $"{year}-{month}-{day}";

    }

}


