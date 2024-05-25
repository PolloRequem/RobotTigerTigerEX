using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardPlayer 
{
  
        public string player { get; set; }
        public int punteggioToT { get; set; }
    

    public LeaderBoardPlayer(string player , int punteggio)
    {
        this.player = player;
        punteggioToT = punteggio;
    }


    public string toString()
    {
        return "LeaderboardPlayer {player = " + player + ", punteggioTot = " + punteggioToT + "}";
    }
}
