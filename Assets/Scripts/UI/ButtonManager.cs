using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
   
    public void QUIT()
    {
        Application.Quit();
        print("Application is Quitting");
    }
    public void GOTO_Authentication_Login()
    {
        SceneManager.LoadScene("Scene_Login");
    }

    public void GOTO_Authentication_Register()
    {
        SceneManager.LoadScene("Scene_Register");
    }

    public void GOTO_Authentation_Main()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GOTO_Info()
    {
        SceneManager.LoadScene("Scene_Info");
    }

    public void GOTO_Hub_Players()
    {
        SceneManager.LoadScene("Hub_Players");
    }

    public void GOTO_Hub_Missions()
    {
        SceneManager.LoadScene("Hub_Missions");
    }
    public void GOTO_Hub_Simulation()
    {
        SceneManager.LoadScene("Hub_Simulation");
    }
    public void GOTO_MainScene()
    {
        SceneManager.LoadScene("_MainScene");
    }

    public void GOTO_Sim_Start()
    {
        SceneManager.LoadScene("Simulation");
    }

    

}
