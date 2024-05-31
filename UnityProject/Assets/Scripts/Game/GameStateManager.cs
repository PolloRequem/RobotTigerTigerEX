using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    private GameStates gameState = GameStates.NULLO;



    [SerializeField] private GameObject cameraPos;
    [SerializeField] private float cameraSpeedUP = 1.5f;
    [SerializeField] private float cameraSpeedDown = 1.0f;


    [SerializeField] private GameObject deadMenu;
    [SerializeField] private GameObject difficultyMenu;

    public void Awake()
    {
        //
        //instance = new GameStateManager();
    }

    public void Start()
    {
        GameEventManager.instance.stardDownLevel.onStartDownLevel += StardDownLevel_onStartDownLevel;
        GameEventManager.instance.startUpLevel.onStartUpLevel += StartUpLevel_onStartUpLevel;
        GameEventManager.instance.freezeCam.onFreezeCam += FreezeCam_onFreezeCam;
        gameState = GameStates.STARTSTAGE;

        GameEventManager.instance.playerDead.onPlayerDead += PlayerDead_onPlayerDead;


    }

    private void PlayerDead_onPlayerDead()
    {
        gameState = GameStates.GAMEOVER;
    }

    private void FreezeCam_onFreezeCam()
    {
        gameState = GameStates.ENDSTAGE;

    }

    private void StartUpLevel_onStartUpLevel()
    {
        gameState = GameStates.UPGAME;

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
              
                break;

            case GameStates.FEEZE:
                break;

            case GameStates.GAMEOVER:

                deadMenu.SetActive(true);
                Time.timeScale = 0f;

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




    public void Button_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Button_ChangeDifficulty()
    {
        difficultyMenu.SetActive(true);
        deadMenu.SetActive(false);
    }

    public void Button_Exit()
    {
        SceneManager.LoadScene("Hub_CompleteMission");
    }






    private enum GameStates
    {
        NULLO,
        FEEZE,
        STARTSTAGE,
        DOWNGAME,
        STAGEFISHED,
        UPGAME,
        ENDSTAGE,
        GAMEOVER
    }

}
