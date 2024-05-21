using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    private GameStates gameState = GameStates.NULLO;



    [SerializeField] private GameObject cameraPos;
    [SerializeField] private float cameraSpeedUP = 1.5f;
    [SerializeField] private float cameraSpeedDown = 1.0f;

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


    }

    private void FreezeCam_onFreezeCam()
    {
        gameState = GameStates.ENDSTAGE;

        print("CameraFreezeTrigger");
    }

    private void StartUpLevel_onStartUpLevel()
    {
        gameState = GameStates.UPGAME;

        print("Inizia Up Level");
    }

    private void StardDownLevel_onStartDownLevel()
    {
        gameState = GameStates.DOWNGAME;

        print("Inizia Down Level");
    }

    void Update()
    {



        if (gameState == GameStates.DOWNGAME)
        {

            CameraVesoIlBasso();

        }

        if (gameState == GameStates.UPGAME)
        {
            CameraVersoLAlto();
        }

        if (gameState == GameStates.ENDSTAGE)
        {

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


    private enum GameStates
    {
        NULLO,
        STARTSTAGE,
        DOWNGAME,
        STAGEFISHED,
        UPGAME,
        ENDSTAGE,
        GAMEOVER
    }

}
