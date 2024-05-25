using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Records_LeaderBoardPlayers : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text_player;
    [SerializeField] private TextMeshProUGUI text_punteggioToT;


    public void SetUp(string player , int punteggiotot)
    {
        text_player.text = player;
        text_punteggioToT.text = punteggiotot.ToString();
    }
}
