using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class Record_Player : MonoBehaviour, ISelectHandler
{

    [SerializeField] private TextMeshProUGUI text_id;
    [SerializeField] private TextMeshProUGUI text_userName;
    [SerializeField] private TextMeshProUGUI text_role;
    [SerializeField] private TextMeshProUGUI text_email;

    private PlayerBean thisPlayer;

    public void SetUPRecords(PlayerBean player)
    {
        thisPlayer = player;
        text_id.text = player.id.ToString();
        text_userName.text = player.username;
        text_role.text = player.role;
        text_email.text = player.email;
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        ElencoPlayer.playerSelected = thisPlayer;
       
       
    }
}
