using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class MissionCopleteDBConnector : MonoBehaviour
{
 //   private string connectionString;
 //   private MySqlConnection MS_Connection;
 //   private MySqlCommand MS_command;
 //   string query;
 ////   private float scorePoints = 0;


    //public void  Start()
    //{
    //    GameEventManager.instance.endLevel.onEndLevel += EndLevel_onEndLevel;
    //    GameEventManager.instance.smallMtaken.onSmallMtaken += SmallMtaken_onSmallMtaken;
    //}
    //private void SmallMtaken_onSmallMtaken()
    //{
    //    scorePoints++;
    //}
    //private void EndLevel_onEndLevel()
    //{
    //    connectDB();
       
    //    query = "UPDATE missioni SET completata = TRUE, punti ="+scorePoints+" WHERE id = "+PlayerPrefs.GetString("idMissione");
    //    print(query);
    //    MS_command = new MySqlCommand(query, MS_Connection);
    //    MS_command.ExecuteNonQuery();
    //    MS_Connection.Close();
    //}




    //public void connectDB()
    //{
    //    connectionString = "Server = localhost ; DataBase = robotmissions ; User = root ; Password = ; Charset = utf8;";
    //    MS_Connection = new MySqlConnection(connectionString);

    //    MS_Connection.Open();
    //}
}
