using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RiquadriRobotManager : MonoBehaviour
{
    public Image[] riquadri;
    public Image[] robotBodyes;
    public TextMeshProUGUI nomiRobot;
    


    private bool isUnRiquadroSelezionato;
    private int lastSelectedIndex;
   

    private void Start()
    {
        isUnRiquadroSelezionato = false;
      //lastSelectedIndex = riquadri.Length + 1;
    }
    public void selectRiquadro(int index)
    {
        
        riquadri[index].color = Color.yellow;

        if (!isUnRiquadroSelezionato)
        {
            print("Entra nel primo if");
            isUnRiquadroSelezionato = true;
            return;
        }
        else
        {
            print("Entra nel primo else");
            riquadri[lastSelectedIndex].color = Color.white;
            lastSelectedIndex = index;
           
        }

        print(lastSelectedIndex);

    }

    private void GET_DataRobots()
    {

    }
}
