using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Informativa_Main : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI informativaText;

    private void Start()
    {
        informativaText.text = "Server =" + PlayerPrefs.GetString("serverDBMS") + ", User = " + PlayerPrefs.GetString("userDBMS") + ", Password =" + PlayerPrefs.GetString("passwordDBMS") +
            ", Charset = " + PlayerPrefs.GetString("charsetDBM") + ", Nome DB = " + PlayerPrefs.GetString("nomeDB") + ", Nome Tabella = " + PlayerPrefs.GetString("nomeTabella") + ".";
    }

    public void CambiaInformativa()
    {
        informativaText.text = "Server =" + PlayerPrefs.GetString("serverDBMS") + " , User = " + PlayerPrefs.GetString("userDBMS") + ", Password =" + PlayerPrefs.GetString("passwordDBMS") +
            ", Charset = " + PlayerPrefs.GetString("charsetDBM") + ", Nome DB = " + PlayerPrefs.GetString("nomeDB") + ", Nome Tabella = " + PlayerPrefs.GetString("nomeTabella") + ".";
    }
}
