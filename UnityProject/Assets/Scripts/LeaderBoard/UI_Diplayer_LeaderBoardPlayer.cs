using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Diplayer_LeaderBoardPlayer : MonoBehaviour
{
    [SerializeField] private Transform frameTemplate;

    private void Awake()
    {
        frameTemplate.gameObject.SetActive(false);
    }

    public void UpdateVisual(List<PlayerBean> players)
    {
        foreach (Transform child in transform)
        {
            if (child == frameTemplate) continue;
            Destroy(child.gameObject);
        }



        foreach (PlayerBean p in players)
        {
            Transform frameTranform = Instantiate(frameTemplate, transform);
            frameTranform.gameObject.SetActive(true);
            frameTranform.GetComponent<Records_LeaderBoardPlayers>().SetUp(p.username, p.totalPoints);

        }

    }

    #region metodo utilizzato in versione precedente a 0.7
    //public void UpdateVisual(List<LeaderBoardPlayer> players)
    //{
    //    foreach (Transform child in transform)
    //    {
    //        if (child == frameTemplate) continue;
    //        Destroy(child.gameObject);
    //    }



    //    foreach (LeaderBoardPlayer p in players)
    //    {
    //        Transform frameTranform = Instantiate(frameTemplate, transform);
    //        frameTranform.gameObject.SetActive(true);
    //        frameTranform.GetComponent<Records_LeaderBoardPlayers>().SetUp(p.player, p.punteggioToT);

    //    }

    //}
    #endregion
}