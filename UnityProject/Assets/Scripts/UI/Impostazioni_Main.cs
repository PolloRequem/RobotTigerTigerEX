using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Impostazioni_Main : MonoBehaviour
{
    [SerializeField]private GameObject impostazioniGO;

    [SerializeField] private TMP_InputField server_InputField;
    [SerializeField] private TMP_InputField user_InputField;
    [SerializeField] private TMP_InputField password_InputField;
    [SerializeField] private TMP_InputField charSet_InputField;
    [SerializeField] private TMP_InputField nomeDB_InputField;
    [SerializeField] private TMP_InputField nomeTabella_InputField;


    public void Start()
    {
        Disattiva();
    }

    public void Attiva()
    {
        impostazioniGO.SetActive(true);
    }

    public void Disattiva()
    {
        impostazioniGO.SetActive(false);
    }

    public void SubmitInput()
    {
        PlayerPrefs.SetString("serverDBMS", server_InputField.text);
        PlayerPrefs.SetString("userDBMS", user_InputField.text);
        PlayerPrefs.SetString("passwordDBMS", password_InputField.text);
        PlayerPrefs.SetString("charsetDBMS", charSet_InputField.text);
        PlayerPrefs.SetString("nomeDB", nomeDB_InputField.text);
        PlayerPrefs.SetString("nomeTabella", nomeTabella_InputField.text);
        PlayerPrefs.Save();
        print(PlayerPrefs.GetString("nomeDB"));
    }
}
