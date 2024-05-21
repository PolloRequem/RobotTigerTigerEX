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


    public void SetUPRecords(string id, string nome, string robot, string player, string idIndex)
    {
        text_id.text = id;
        text_nome.text = nome;
        text_robot.text = robot;
        text_player.text = player;
        this.idIndex = idIndex;
    }


    public void GOTO_Findigs()
    {
        PlayerPrefs.SetString("ID_ritrovamenti", idIndex);
        PlayerPrefs.Save();
     
       SceneManager.LoadScene("Mission_ritrovamenti");
    }
}
