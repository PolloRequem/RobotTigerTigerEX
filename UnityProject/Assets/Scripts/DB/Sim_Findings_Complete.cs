using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class Sim_Findings_Complete : MonoBehaviour
{


    
    [ContextMenu("Get Missioni")]
    public void Call_POST_RegistraFinding()
    {
        StartCoroutine(POST_RegistraFinding());
    }

    private IEnumerator POST_RegistraFinding()
    {
        WWWForm form = new WWWForm();
        form.AddField("missione", PlayerPrefsManger.PP_Mission_Started_ID());            
        form.AddField("materiale", UI_Game_StartM.coloreSelezionatoID);
        form.AddField("data", UnityDateTOSQLDate(System.DateTime.Today.ToShortDateString()));
        form.AddField("parziali", getIDRandoNumber());
        using (UnityWebRequest webRequest = UnityWebRequest.Post(PlayerPrefsManger.PP_ServerURL() + "/data/ritrovamenti", form))
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


                    print(webRequest.downloadHandler.text);
                    GOTO_Sim_Finding_Complete();
                    break;
            }
        }
    }

    private int getIDRandoNumber()
    {
        System.Random rand = new System.Random();
        return rand.Next(1, 9999);
    }


    private void GOTO_Sim_Finding_ConnectionError()
    {
        SceneManager.LoadScene("Mission_Sim_Finding_ConnectionError");
    }

    private void GOTO_Sim_Finding_Complete()
    {
        SceneManager.LoadScene("Mission_ritrovamenti");
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
