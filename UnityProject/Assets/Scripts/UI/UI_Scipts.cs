using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Scipts : MonoBehaviour
{

    private int score;

    [SerializeField] private TextMeshProUGUI palyerText;

    [SerializeField] private TextMeshProUGUI missionText;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI modeText;

    [SerializeField] private TextMeshProUGUI coloreText;
    [SerializeField] private Image colorImage;
 //   private Color targetColor;

    [SerializeField] private GameObject cuore1;
    [SerializeField] private GameObject cuore2;
    [SerializeField] private GameObject cuore3;
   // private float heartCount = 3;


    private void Start()
    {
        score = ScoreOnStart();
        scoreText.text = score.ToString();
        GameEventManager.instance.playerDmged.onPlayerDmged += PlayerDmged_onPlayerDmged;
        GameEventManager.instance.smallMtaken.onSmallMtaken += SmallMtaken_onSmallMtaken;
        GameEventManager.instance.enemyDestroyed.onEnemyDestroyed += EnemyDestroyed_onEnemyDestroyed;
        GameEventManager.instance.coinGain.onCoinGained += CoinGain_onCoinGained;
    
        missionText.text = PlayerPrefsManger.PP_Mission_Copleted_Name();
        palyerText.text = PlayerPrefsManger.PP_Mission_Copleted_Player();
        modeText.text = GameStateManager.current_gameDifficulty.ToString();
      

    }



    private int ScoreOnStart()
    {
        switch (GameStateManager.current_gameDifficulty)
        {
            case GameDifficulty.EASY:
                return -500;
           
            case GameDifficulty.NORMAL:
                return 0;
                
            case GameDifficulty.HARD:
                return 500;
             
            default:
                return -999;


        }
    }


    private void CoinGain_onCoinGained()
    {
        score += 100;
        scoreText.text = score.ToString();
    }

 
    private void OnDisable()
    {
        GameEventManager.instance.playerDmged.onPlayerDmged -= PlayerDmged_onPlayerDmged;
        GameEventManager.instance.smallMtaken.onSmallMtaken -= SmallMtaken_onSmallMtaken;
        GameEventManager.instance.enemyDestroyed.onEnemyDestroyed -= EnemyDestroyed_onEnemyDestroyed;
        GameEventManager.instance.coinGain.onCoinGained -= CoinGain_onCoinGained;
    }
    private void EnemyDestroyed_onEnemyDestroyed()
    {
        score += 100;
        scoreText.text = score.ToString();
    }
    private void SmallMtaken_onSmallMtaken()
    {
        score += 500;
        scoreText.text = score.ToString();
    }
    private void PlayerDmged_onPlayerDmged()
    {
        score -= 250;
        scoreText.text = score.ToString();

        #region non implementato nel gioco finale
        //if (heartCount == 1)
        //{
        //    cuore1.SetActive(false);
        //    heartCount--;
        //}

        //if (heartCount == 2)
        //{
        //    cuore2.SetActive(false);
        //    heartCount--;
        //}
        //if (heartCount == 3)
        //{
        //    cuore3.SetActive(false);
        //    heartCount--;
        //}
        #endregion

    }

    public  int getPunteggio()
    {
        return score;
    }
}
