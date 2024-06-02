using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;



using UnityEngine.SceneManagement;
using Newtonsoft.Json;


public class UI_Sim_Start : MonoBehaviour
{




    private bool isMissionRegistrationOK;
    Robot[] robots;

    [Header("Mission Data")]
    [SerializeField] private TMP_InputField missionID;
    [SerializeField] private TMP_InputField missionName;
    [SerializeField] private TextMeshProUGUI user;
    [SerializeField] private TextMeshProUGUI date;

    [Header("Erroror Message ")]
    [SerializeField] private TextMeshProUGUI error_missionName;
    [SerializeField] private TextMeshProUGUI error_missionID;
    [SerializeField] private TextMeshProUGUI error_robot;
    [SerializeField] private TextMeshProUGUI error_default;

    [Header("Buttons")]
    [SerializeField] private Button startButton;

    [Header("Scripts")]
    [SerializeField] UI_Riquadri ui_Riquadri;
    void Start()
    {

        Call_GET_DATAobots();
        date.text = System.DateTime.Today.ToShortDateString();
        user.text = PlayerPrefs.GetString("Login_UserName");
        autoMissionID();
        isMissionRegistrationOK = false;

    }




    public void Call_GET_Misison()
    {
        StartCoroutine(GET_Missions());
    }
    public void Call_GET_DATAobots()
    {
        StartCoroutine(GET_DataRobots());
    }
    public void Call_POST_AddMission()
    {
        StartCoroutine(POST_AddMission(missionID.text, missionName.text, UI_Riquadri.robotSelected , PlayerPrefs.GetString("Login_UserName")));
    }



    private IEnumerator GET_Missions()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(PlayerPrefsManger.PP_ServerURL()+"/data/missions"))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    //Debug.LogError
                    print((String.Format("Something went wrong  {0}", webRequest.error)));
                    break;
                case UnityWebRequest.Result.Success:

                    Mission[] missions = JsonConvert.DeserializeObject<Mission[]>(webRequest.downloadHandler.text);

                    foreach(Mission m in missions)
                    {
                        print(m.toString());
                    }


                    break;
            }
        }
    }
    private IEnumerator GET_DataRobots()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(PlayerPrefsManger.PP_ServerURL() + "/data/robots"))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    //Debug.LogError
                    print((String.Format("Something went wrong  {0}", webRequest.error)));
                    break;
                case UnityWebRequest.Result.Success:
                    robots = JsonConvert.DeserializeObject<Robot[]>(webRequest.downloadHandler.text);
                    ui_Riquadri.UpdateVisual(robots);

                    break;
            }
        }
    }
    private IEnumerator POST_AddMission(string M_ID, string M_Name ,string robotName , string currentPlayer)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", M_ID);
        form.AddField("nome", M_Name);
        form.AddField("robot", robotName);
        form.AddField("player", currentPlayer);
        using (UnityWebRequest webRequest = UnityWebRequest.Post(PlayerPrefsManger.PP_ServerURL()+"/data/missions", form))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(String.Format("Something went wrong  {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:


                   isMissionRegistrationOK = AnalizzaRisposta(webRequest.downloadHandler.text);
                    print(isMissionRegistrationOK);
                    break;
            }
        }
    }



    //private void jsonIntoSerialiArray(string json)
    //{

    //    json = json.Trim('[', ']');
    //    string[] stringArraySeriali = json.Split(',');

    //    foreach (string seriali in stringArraySeriali)
    //    {

    //        elencoSeriali.Add(seriali);

    //    }


    //}
    private int getIDRandoNumber()
    {
        System.Random rand = new System.Random();
        return rand.Next(100000000, 999999999);



    }
    public void autoMissionID()
    {
        missionID.text = getIDRandoNumber().ToString();
    }
    private bool AnalizzaRisposta(string webRequestTEXT)
    {
        print(webRequestTEXT);
        switch (webRequestTEXT)
        {
            case "1":

                PlayerPrefs.SetString("Mission_Started_ID", missionID.text);
                PlayerPrefs.SetString("Mission_Started_Name", missionName.text);


                PlayerPrefs.Save();
                //  SceneManager.LoadScene("Game_StartMission");
                SceneManager.LoadScene("Mission_ritrovamenti");
                return true;

         

            default:
                error_default.text = webRequestTEXT;
                return false;
        }

    }


    public void StartButton()
    {
        if (isMissionIDEnter() && isMissionNameEnter() && isRobotSelected())
        {
            Call_POST_AddMission();
            if (isMissionRegistrationOK)
            {
            
                
            }
            
        }
    }
    private bool isMissionIDEnter()
    {
        if (missionID.text.Length < 9)
        {
            error_missionID.text = "*The ID must have 9 digits*";
            return false;
        }
        else
        {
            error_missionID.text = "";
            return true;
        }
    }
    //private bool isOtherSerialLikeThis()
    //{
    //    foreach (string i in elencoSeriali)
    //    {
    //        if ( missionID.text== i && isMissionIDEnter())
    //        {
    //            print("ad");
    //            error_missionID.text = "*This ID already exist ";
    //            return false;
    //        }

    //    }
    //    return true;
    //}
    private bool isMissionNameEnter()
    {
        if (missionName.text.Length < 1)
        {
            error_missionName.text = "*Enter the name of the mission*";
            return false;
        }
        else
        {
            error_missionName.text = "";
            return true;
        }
    }
    private bool isRobotSelected()
    {
        if (UI_Riquadri.robotSelected == null)
        {
            error_robot.text = "*Select a robot*";
            return false;
        }
        else
        {
            error_robot.text = "";
            return true;
        }
    }


   
}
