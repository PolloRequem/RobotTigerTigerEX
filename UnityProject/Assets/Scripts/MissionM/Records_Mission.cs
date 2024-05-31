using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class Records_Mission : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI text_id;
    [SerializeField] private TextMeshProUGUI text_nome;
    [SerializeField] private TextMeshProUGUI text_robot;
    [SerializeField] private TextMeshProUGUI text_player;

    private string idIndex;

    [SerializeField] private TextMeshProUGUI text_punteggio;
    [SerializeField] private TextMeshProUGUI text_dataInzio;
    [SerializeField] private TextMeshProUGUI text_dataFine;





    public void SetUPRecords(string id, string nome, string robot, string player, string idIndex)
    {
        text_id.text = id;
        text_nome.text = nome;
        text_robot.text = robot;
        text_player.text = player;
        this.idIndex = idIndex;
    }

    public void SetUPALLRecords(string id, string nome, string robot, string player, string punteggio , string dataInizio , string dataFine)
    {
        text_id.text = id;
        text_nome.text = nome;
        text_robot.text = robot;
        text_player.text = player;
        text_punteggio.text = punteggio;
        text_dataInzio.text = dataInizio;
        text_dataFine.text = dataFine;
    }



    public void GOTO_Findigs()
    {
        PlayerPrefs.SetString("Mission_Started_ID", idIndex);
        PlayerPrefs.SetString("Mission_Started_Name", text_nome.text);
        PlayerPrefs.Save();
     
       SceneManager.LoadScene("Mission_ritrovamenti");
    }

    public void GOTO_Game_CompleteMission()
    {
        PlayerPrefs.SetString("IDMission_Started", idIndex);
        PlayerPrefs.SetString("Mission_Comleted_Name", text_nome.text);
        PlayerPrefs.SetString("Mission_Comleted_Player_NotCurrent", text_player.text);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game_CompleteMission");
    }
}
