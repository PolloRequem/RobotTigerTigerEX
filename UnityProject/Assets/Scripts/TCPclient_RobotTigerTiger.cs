using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using System.IO;


public class TCPclient_RobotTigerTiger : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;

    private void Start()
    {
        GameEventManager.instance.materialPickedUp.onMaterialPickedUp += MaterialPickedUp_onMaterialPickedUp;
    
    }
    private void MaterialPickedUp_onMaterialPickedUp(colori obj)
    {
        print(obj.ToString());
        StreamWriter writer = new StreamWriter(client.GetStream());
        StreamReader reader = new StreamReader(client.GetStream());

        string message = "Hello from C# client";
        writer.WriteLine(message);
        writer.Flush();

        Console.WriteLine("Messaggio inviato: " + message);

        string response = reader.ReadLine();
        Console.WriteLine("Risposta dal server: " + response);

        writer.Close();
        reader.Close();
        client.Close();
    }

}
//    void Start()
//    {
//        GameEventManager.instance.materialPickedUp.onMaterialPickedUp += MaterialPickedUp_onMaterialPickedUp;
//        string serverIP = "127.0.0.1"; // Indirizzo IP del server
//        int port = 50000; // Porta su cui il server è in ascolto

//        try
//        {
//            client = new TcpClient(serverIP, port);
//            stream = client.GetStream();

//            Debug.Log("Client connesso al server.");

//            SendMessageToServer("Ciao, server!");
//        }
//        catch (Exception ex)
//        {
//            Debug.LogError($"Errore durante la connessione al server: {ex}");
//        }
//    }

//    private async void SendMessageToServer(string message)
//    {
//        try
//        {
//            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
//            await stream.WriteAsync(data, 0, data.Length);

//            Debug.Log("Messaggio inviato al server: " + message);

//            Ricevi la risposta dal server
//            byte[] buffer = new byte[1024];
//            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
//            string response = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
//            Debug.Log("Risposta dal server: " + response);
//        }
//        catch (Exception ex)
//        {
//            Debug.LogError($"Errore durante l'invio del messaggio: {ex}");
//        }
//        finally
//        {
//            stream.Close();
//            client.Close();
//        }
//    }
//    private void MaterialPickedUp_onMaterialPickedUp(colori obj)
//    {
//        print(obj.ToString());
//    }
//}



