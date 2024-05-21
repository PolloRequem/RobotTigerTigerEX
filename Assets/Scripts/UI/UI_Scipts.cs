using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Scipts : MonoBehaviour
{

    private float score;

    [SerializeField] private TextMeshProUGUI palyerText;

    [SerializeField] private TextMeshProUGUI missionText;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI coloreText;
    [SerializeField] private Image colorImage;
    private Color targetColor;

    [SerializeField] private GameObject cuore1;
    [SerializeField] private GameObject cuore2;
    [SerializeField] private GameObject cuore3;
    private float heartCount = 3;


    private void Start()
    {
        score = 0;

        GameEventManager.instance.playerDmged.onPlayerDmged += PlayerDmged_onPlayerDmged;
        GameEventManager.instance.smallMtaken.onSmallMtaken += SmallMtaken_onSmallMtaken;
        GameEventManager.instance.enemyDestroyed.onEnemyDestroyed += EnemyDestroyed_onEnemyDestroyed;
        GameEventManager.instance.coinGain.onCoinGained += CoinGain_onCoinGained;
        missionText.text = PlayerPrefs.GetString("idMissione");
        palyerText.text = PlayerPrefs.GetString("Currentplayer");
        coloreText.text = PlayerPrefs.GetString("coloreMissione");

        if (ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("coloreMissione"), out targetColor))
        {
            colorImage.color = targetColor;
           
        }

    }

    private void CoinGain_onCoinGained()
    {
        score += 100;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            GameEventManager.instance.freezeCam.FreezeCam();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameEventManager.instance.stardDownLevel.StartDownLevel();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameEventManager.instance.startUpLevel.EndLevel();
        }
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
        if (heartCount == 1)
        {
            cuore1.SetActive(false);
            heartCount--;
        }
      
        if (heartCount == 2)
        {
            cuore2.SetActive(false);
            heartCount--;
        }
        if (heartCount == 3)
        {
            cuore3.SetActive(false);
            heartCount--;
        }

    }

    
}
