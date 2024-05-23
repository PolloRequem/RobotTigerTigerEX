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



    public void SetUPRecords(int id, string Username, string role, string email)
    {
        text_id.text = id.ToString();
        text_userName.text = Username;
        text_role.text = role;
        text_email.text = email;
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        ElencoPlayer.playerSelected = text_id.text;
        print(ElencoPlayer.playerSelected);
    }
}
