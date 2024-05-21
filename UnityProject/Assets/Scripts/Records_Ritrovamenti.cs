using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Records_Ritrovamenti : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text_idMissione;
    [SerializeField] private TextMeshProUGUI text_materiale;
    [SerializeField] private TextMeshProUGUI text_data;
    [SerializeField] private TextMeshProUGUI text_parziali;

   


    public void SetUPRecords(string id, string materiale, string data, double parziali)
    {
        text_idMissione.text = id;
        text_materiale.text = materiale;
        text_data.text =data;
        text_parziali.text = parziali.ToString();
     
    }

}
