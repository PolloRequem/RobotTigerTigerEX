using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class Riquadri_Body : MonoBehaviour, ISelectHandler
{

    private Selectable selectable;

    [SerializeField] private TextMeshProUGUI seriale;
    [SerializeField] private TextMeshProUGUI nome;
    [SerializeField] private Image coloreImage;

    private void OnEnable()
    {
    
    }

    public void SetRiquadro(Robot robot)
    {
        this.seriale.text = robot.serial;
        this.nome.text = robot.nome;
       
      //  coloreImage.color = _colori.StringToColor(colore);
    }

    private void Update()
    {


    }

    public void OnSelect(BaseEventData eventData)
    {
        UI_Riquadri.robotSelected = nome.text;
        //PlayerPrefs.SetString("_KeyRobot", nome.text);
        PlayerPrefs.Save();

    }



}
