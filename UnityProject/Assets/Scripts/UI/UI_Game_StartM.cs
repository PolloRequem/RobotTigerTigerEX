using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI_Game_StartM : MonoBehaviour
{
    public static int coloreSelezionatoID;

    [SerializeField] private PlayerMov playerMov;
    [SerializeField] private PlayerHook playerHoock;

    [SerializeField] private TextMeshProUGUI missionName;
    [SerializeField] private TextMeshProUGUI colorText;
    [SerializeField] private Image colorImage;

    [SerializeField] private GameObject confirmTab;

    private bool isUnColoreScelto = false;

    private void Start()
    {

        if (PlayerPrefs.GetString("_Start_MissionName")!=null)
        {
            missionName.text = PlayerPrefs.GetString("_Start_MissionName");

        }
        GameEventManager.instance.materialPickedUp.onMaterialPickedUp += MaterialPickedUp_onMaterialPickedUp;
        GameEventManager.instance.endSimulationSM.onEndSimulationSM += EndSimulationSM_onEndSimulationSM;

    }

    private void EndSimulationSM_onEndSimulationSM()
    {
        if (isUnColoreScelto)
        {
            playerHoock.enabled = false;
            playerMov.enabled = false;
            confirmTab.SetActive(true);
        }
       
    }

    private void MaterialPickedUp_onMaterialPickedUp(Colori_Enum obj)
    {
        colorText.text = obj.ToString();
        colorImage.color = ColorMangaer.StringToColor(obj.ToString());

        isUnColoreScelto = true;

        coloreSelezionatoID = ColorMangaer.Color_EnumTOIDMaterial(obj.ToString());
        print(coloreSelezionatoID);
    }


    public void cancellButton()
    {
        confirmTab.SetActive(false);
        playerHoock.enabled = true;
        playerMov.enabled = true;
    }

   
}