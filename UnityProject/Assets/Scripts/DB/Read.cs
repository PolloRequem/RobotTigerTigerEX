using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Read : MonoBehaviour
{
    private string connectionString;
    string query;
    private MySqlCommand MS_Command;
    private MySqlConnection MS_Connection;
    private MySqlDataReader MS_Reader;


    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private TextMeshProUGUI[] texts1;
    [SerializeField] private TextMeshProUGUI errorText;

    [SerializeField] private GameObject[] completeButtons;
    private string[] ids;
    private string[] coloriMissioni;



    public void Awake()
    {
        ids = new string[7];
        coloriMissioni = new string[7];
        PlayerPrefs.SetString("serverDBMS", "localhost");
        PlayerPrefs.SetString("nomeDB", "robotmissions");
        PlayerPrefs.SetString("userDBMS", "root");
        PlayerPrefs.SetString("passwordDBMS", "");
        PlayerPrefs.SetString("charsetDBMS", "utf8");
        PlayerPrefs.SetString("nomeTabella", "missioni");
        PlayerPrefs.Save();
    }



    //public IEnumerator Start()
    //{

    //    //WWW request = new WWW("http://localhost/phpmyadmin/webtest.php");

    //    //yield return request;


    //    //print(request.text);
    //    //string[] rows = request.text.Split("\n");

    //    //for (int i = 0; i <= rows.Length - 1; i++)
    //    //{
            
    //    //    texts[i].text = rows[i];



    //    //}
    //}
    public void CallViewInfo()
    {
        
       // viewInfo();
        print("entrato");
    }
    //private  IEnumerator viewInfo()
    //{


    //    //WWWForm form = new WWWForm();
    //    //form.AddField("server", PlayerPrefs.GetString("serverDBMS"));
    //    //form.AddField("userDBMS", PlayerPrefs.GetString("userDBMS"));
    //    //form.AddField("passwordDBMS", PlayerPrefs.GetString("passwordDBMS"));
    //    //form.AddField("nomeDB", PlayerPrefs.GetString("nomeDB"));
    //    //form.AddField("nomeTabella", PlayerPrefs.GetString("nomeTabella"));



    //    print("a");
    //        WWW request = new WWW("http://localhost/phpmyadmin/webtest.php");
    //    print("inviata");
    //        yield return request;

    //    print("request:" + request);

    //        string[] rows = request.text.Split("\n");
    //    print(rows);
    //        for(int i = 0;  i > rows.Length ; i++)
    //    {
    //        string[] colonne = rows[i].Split("|");
    //        print(colonne);
    //        texts1[i].text += colonne[0];
    //        texts1[i].text += colonne[1];
    //        texts1[i].text += colonne[2];
    //        texts1[i].text += colonne[3];
    //    }
        
        //try
        //{
        //    query = "SELECT * FROM " + PlayerPrefs.GetString("nomeTabella");
        //    connectionString = "Server = " + PlayerPrefs.GetString("serverDBMS") + "; DataBase = " + PlayerPrefs.GetString("nomeDB") + " ; User = " + PlayerPrefs.GetString("userDBMS") + " ; Password = " + PlayerPrefs.GetString("passwordDBMS") + " ; Charset = " + PlayerPrefs.GetString("charsetDBM") + ";";

        //    MS_Connection = new MySqlConnection(connectionString);
        //    MS_Connection.Open();

        //    MS_Command = new MySqlCommand(query, MS_Connection);
        //    MS_Reader = MS_Command.ExecuteReader();
        //}
        //catch (MySqlException e)
        //{
        //    errorText.text = e.Message;
        //}
        //    for (int i = 0; MS_Reader.Read(); i++)
        //{

        //    //texts[i].text = MS_Reader[0] + "                    " + MS_Reader[1] + "                                  " + MS_Reader[2] + "                                            " + vediSeIsNull(MS_Reader[3].ToString());
        //    string column1 = MS_Reader[0].ToString().PadRight(20); 
        //    string column2 = MS_Reader[1].ToString().PadRight(40);
        //    string column3 = MS_Reader[2].ToString().PadRight(40);
        //    if (!controllaBool(MS_Reader[2].ToString()))
        //    {
        //        completeButtons[i].SetActive(true);
        //    }
        //    string column4 = vediSeIsNull(MS_Reader[3].ToString()).PadRight(50); 

        //    texts[i].text = column1 + column2 + column3 + column4;
        //    ids[i] = MS_Reader[0].ToString();
        //    coloriMissioni[i] = MS_Reader[1].ToString();

        //}

    }

    

