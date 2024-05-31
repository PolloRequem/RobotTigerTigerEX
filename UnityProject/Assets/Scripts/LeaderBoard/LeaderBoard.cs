using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.Linq;
public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private UI_Diplayer_LeaderBoardPlayer Display_leaderBoardPlayer;

    private int leaderBoardMAXplayer = 5;
    private void Start()
    {
        Call_GET_Player();
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
                    Display_leaderBoardPlayer.UpdateVisual(sortAndSet(playerJson));

                    break;
            }
        }
    }
    private List<PlayerBean> sortAndSet(List<PlayerBean> leaderBoards)
    {

        List<PlayerBean> leaderBoardSorted = new List<PlayerBean>();




        return leaderBoards.OrderByDescending(players => players.totalPoints).Take(leaderBoardMAXplayer).ToList();
    }

    #region metodo utilizzato nelle versione precendeti a 0.7
    //private IEnumerator GET_Mission()
    //{

    //    using (UnityWebRequest webRequest = UnityWebRequest.Get(PlayerPrefsManger.PP_ServerURL() + "/data/missions"))
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

    //                List<Mission> playerJson = JsonConvert.DeserializeObject<List<Mission>>(webRequest.downloadHandler.text);
    //                Display_leaderBoardPlayer.UpdateVisual(sortAndSet(GetLeaderBoard(playerJson)));


    //                break;
    //        }
    //    }
    //}

    //private List<LeaderBoardPlayer> GetLeaderBoard(List<Mission> missions)
    //{
    //    var leaderBoard = new Dictionary<string, LeaderBoardPlayer>();

    //    foreach (var mission in missions)
    //    {
    //        if (mission.dataFine != null)
    //        {
    //            if (leaderBoard.ContainsKey(mission.player))
    //            {
    //                leaderBoard[mission.player].punteggioToT += mission.punteggio;
    //            }
    //            else
    //            {
    //                leaderBoard[mission.player] = new LeaderBoardPlayer(mission.player, mission.punteggio);
    //            }
    //        }
    //    }

    //    return leaderBoard.Values.ToList();
    //}
    //private List<LeaderBoardPlayer> sortAndSet(List<LeaderBoardPlayer> leaderBoards)
    //{

    //    List<LeaderBoardPlayer> leaderBoardSorted = new List<LeaderBoardPlayer>();




    //    return leaderBoards.OrderByDescending(lbp => lbp.punteggioToT).Take(leaderBoardMAXplayer).ToList();
    //}

    #endregion
}
