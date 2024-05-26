using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class ElencoPlayer : MonoBehaviour
{
    [SerializeField] private UI_DisplayPlayer uiDiplayer;

    [SerializeField] private GameObject delete_ConfirmTab;

    [SerializeField] private Button  delete_Button;
    [SerializeField] private Button customize_Button;

    private List<PlayerBean> listaPlayerXUI;
    public static PlayerBean playerSelected;

    public void Start()
    {
        delete_ConfirmTab.SetActive(false);
        Call_GET_Player();
        customize_Button.interactable = false;
        delete_Button.interactable = false;

       
    }

    public void Update()
    {

        if (playerSelected == null || playerSelected.role.Equals("admin"))
        {
            customize_Button.interactable = false;
            delete_Button.interactable = false;
        }else
        {
            customize_Button.interactable = true;
            delete_Button.interactable = true;
        }


        
    }

    private void Call_DELETE_Player()
    {
        StartCoroutine(DELETE_Player());
    } 
    private void Call_GET_Player()
    {
        StartCoroutine(GET_Player());
    }


    private IEnumerator GET_Player()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(PlayerPrefsManger.PP_ServerURL() + "/data/players"))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:

                    print((String.Format("Something went wrong  {0}", webRequest.error)));
                    break;
                case UnityWebRequest.Result.Success:

                    List<PlayerBean> playerJson = JsonConvert.DeserializeObject<List<PlayerBean>>(webRequest.downloadHandler.text);
                    listaPlayerXUI = playerJson;
                    uiDiplayer.UpdateVisual(togliThisUser(playerJson));

                    break;
            }
        }
    }

    private IEnumerator DELETE_Player()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Delete(PlayerPrefsManger.PP_ServerURL() + "/data/players/" + playerSelected.id))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:

                    print((String.Format("Something went wrong  {0}", webRequest.error)));
                    break;
                case UnityWebRequest.Result.Success:

                    Call_GET_Player();
                    break;
            }
        }
    }


    public void Button_Delete()
    {
        delete_ConfirmTab.SetActive(true);
    }
    public void Button_ConfirmTab_Cancel()
    {
        delete_ConfirmTab.SetActive(false);
    }
    public void Button_ConfirmTab_Delete()
    {
        Call_DELETE_Player();
        delete_ConfirmTab.SetActive(false);
    }


    public void Button_CustomizePlayer()
    {
        PlayerPrefs.SetString("_Current_CustomizePlayer_username",playerSelected.username);
        PlayerPrefs.Save();
        PlayerPrefsManger.Current_playerBean_Customize = playerSelected;

        SceneManager.LoadScene("Player_Customize");
    }

    private List<PlayerBean> togliThisUser(List<PlayerBean> players)
    {
        List<PlayerBean> dummyList = players;
        foreach (PlayerBean player in players)
        {
            if (player.username.Equals(PlayerPrefs.GetString("Login_Username")))
            {
               dummyList.Remove(player);
            }
        }
        return dummyList;
    }
    //private IEnumerator PUT_ResetPassword_Player()
    //{

    //    using (UnityWebRequest webRequest = UnityWebRequest.Put("PlayerPrefsManger.PP_ServerURL()+"/data/players",))
    //    {
    //        yield return webRequest.SendWebRequest();

    //        switch (webRequest.result)
    //        {
    //            case UnityWebRequest.Result.ConnectionError:
    //            case UnityWebRequest.Result.DataProcessingError:
    //            case UnityWebRequest.Result.ProtocolError:

    //                print((String.Format("Something went wrong  {0}", webRequest.error)));
    //                break;
    //            case UnityWebRequest.Result.Success:

    //                List<PlayerBean> playerJson = JsonConvert.DeserializeObject<List<PlayerBean>>(webRequest.downloadHandler.text);
    //                uiDiplayer.UpdateVisual(playerJson);

    //                break;
    //        }
    //    }
    //}
}
