using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_OtherButtoons : MonoBehaviour
{
   public void GOTOMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
