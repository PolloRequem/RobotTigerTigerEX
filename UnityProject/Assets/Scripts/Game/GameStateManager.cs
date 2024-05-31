using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    private GameStates gameState = GameStates.NULLO;
    public static GameDifficulty current_gameDifficulty = GameDifficulty.NORMAL;

    [Header("Camera")]
    [SerializeField] private GameObject cameraPos;
    [SerializeField] private float cameraSpeedUP;
    [SerializeField] private float cameraSpeedDown;

    [Header("GO")]
    [SerializeField] private GameObject bandiere;

    [Header("Menu")]
    [SerializeField] private GameObject completeMenu;
    [SerializeField] private GameObject deadMenu;
    [SerializeField] private GameObject difficultyMenu;

    [Header("Menu")]
    [SerializeField] private UI_Scipts uiManger;

    private bool completamentoAttivato = false;
    private bool morteAttivata = false;
    public void Awake()
    {
        //
        //instance = new GameStateManager();
    }

    public void Start()
    {
        switch (current_gameDifficulty)
        {
            case GameDifficulty.EASY:

                cameraSpeedUP = 2.5f;
                cameraSpeedDown = 2f;
                break;

            case GameDifficulty.NORMAL:

                cameraSpeedUP = 3.4f;
                cameraSpeedDown = 3f;
                break;

            case GameDifficulty.HARD:

                cameraSpeedUP = 4.5f;
                cameraSpeedDown = 6f;
                break;

            default:
                //metti le impostazioni normali
                cameraSpeedUP = 4f;
                cameraSpeedDown = 3.5f;
                break;
        }


        GameEventManager.instance.stardDownLevel.onStartDownLevel += StardDownLevel_onStartDownLevel;
        GameEventManager.instance.startUpLevel.onStartUpLevel += StartUpLevel_onStartUpLevel;
        GameEventManager.instance.freezeCam.onFreezeCam += FreezeCam_onFreezeCam;
        gameState = GameStates.STARTSTAGE;

        GameEventManager.instance.playerDead.onPlayerDead += PlayerDead_onPlayerDead;
        GameEventManager.instance.endLevel.onEndLevel += EndLevel_onEndLevel;


    }

    private void EndLevel_onEndLevel()
    {
        gameState = GameStates.ENDSTAGE;
    }

    private void PlayerDead_onPlayerDead()
    {
        gameState = GameStates.GAMEOVER;
    }

    private void FreezeCam_onFreezeCam()
    {
        gameState = GameStates.FEEZE;

    }

    private void StartUpLevel_onStartUpLevel()
    {
        gameState = GameStates.UPGAME;
        bandiere.SetActive(true);

    }

    private void StardDownLevel_onStartDownLevel()
    {
        gameState = GameStates.DOWNGAME;

    }

    void Update()
    {



        switch (gameState)
        {
            case GameStates.DOWNGAME:
                CameraVesoIlBasso();
                break;

            case GameStates.UPGAME:
                CameraVersoLAlto();
                break;

            case GameStates.ENDSTAGE:

                if (!completamentoAttivato)
                {
                    completeMenu.SetActive(true);
                    Time.timeScale = 0f;
                    completamentoAttivato = true;


                }
                break;

            case GameStates.FEEZE:
                break;

            case GameStates.GAMEOVER:

                if (!morteAttivata)
                {
                    deadMenu.SetActive(true);
                    Time.timeScale = 0f;
                    morteAttivata = true;


                }

                break;

            default:
                gameState = GameStates.NULLO;
                break;
        }



    }


    public void CameraVesoIlBasso()
    {
        Vector3 newPos = cameraPos.transform.position - cameraPos.transform.up * cameraSpeedDown * Time.deltaTime;
        cameraPos.transform.position = newPos;
    }

    private void CameraVersoLAlto()
    {
        Vector3 newPos = cameraPos.transform.position + cameraPos.transform.up * cameraSpeedUP * Time.deltaTime;
        cameraPos.transform.position = newPos;
    }


    public void Button_CompleteAndExit()
    {
        PlayerPrefsManger.Current_Score = uiManger.getPunteggio();
        SetReloadScene("Sim_Complete");
    }
    public void Button_Restart()
    {
        SetReloadScene(SceneManager.GetActiveScene().name);
    }
    public void Button_Exit()
    {
        
        SetReloadScene("Hub_CompleteMission");
    }
    public void Button_ChangeDifficulty()
    {
        difficultyMenu.SetActive(true);
        deadMenu.SetActive(false);
    }


    public void Button_ChangeDifficulty_TOEasy()
    {
        current_gameDifficulty = GameDifficulty.EASY;
        SetReloadScene(SceneManager.GetActiveScene().name);
    }
    public void Button_ChangeDifficulty_TONormal()
    {
        current_gameDifficulty = GameDifficulty.NORMAL;
        SetReloadScene(SceneManager.GetActiveScene().name);
    }
    public void Button_ChangeDifficulty_TOHard()
    {
        current_gameDifficulty = GameDifficulty.HARD;
        SetReloadScene(SceneManager.GetActiveScene().name);


    }

    private void SetReloadScene(string sceneName)
    {
        gameState = GameStates.NULLO;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }



}
