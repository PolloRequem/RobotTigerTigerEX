using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        form.AddField("missone", PlayerPrefs.GetString("IDMission_Started"));
        form.AddField("materiale", UI_Game_StartM.coloreSelezionatoID);
        form.AddField("data", System.DateTime.Today.ToShortDateString());
        form.AddField("parziali", getIDRandoNumber());
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost:8161/WebServerAPI/data/ritrovamenti", form))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(String.Format("Something went wrong  {0}", webRequest.error));
                    GOTO_Sim_Finding_ConnectionError();
                    break;
                case UnityWebRequest.Result.Success:
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
        SceneManager.LoadScene("Sim_Finding_ConnectionError");
    }

    private void GOTO_Sim_Finding_Complete()
    {
        SceneManager.LoadScene("Sim_Finding_Complete");
    }
}
