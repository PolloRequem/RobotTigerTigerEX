using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;


public class Write : MonoBehaviour
{
    private string connectionString;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_command;
    string query;



    public void sendInfo()
    {
        connectDB();

        query = "CREATE TABLE IF NOT EXISTS utenti (id INTEGER PRIMARY KEY, nome TEXT, email TEXT)";

        MS_command = new MySqlCommand(query, MS_Connection);
        MS_command.ExecuteNonQuery();
        MS_Connection.Close();
    }
    public void connectDB()
    {
        connectionString = "Server = localhost ; DataBase = usersdb ; User = root ; Password = ; Charset = utf8;";
        MS_Connection = new MySqlConnection(connectionString);

        MS_Connection.Open();
    }
}
