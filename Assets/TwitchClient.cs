using System.Collections;
using System.Collections.Generic;
using TwitchLib.Client.Models;
using TwitchLib.Unity;
using UnityEngine;
using UnityEngine.UI;

public class TwitchClient : MonoBehaviour
{
    public static Client client;
    public string channel_name = "god_of_orenos_test";
    



    // Start is called before the first frame update
    private void Start()
    {
        //ensure this is running in background
        Application.runInBackground = true;

        //set up bot and make it join the channel
        ConnectionCredentials credentials = new ConnectionCredentials("god_of_orenos_bot", Secret.bot_access_token);
        client = new Client();
        client.Initialize(credentials, channel_name);
        client.OnMessageReceived += MymessageReceivedFuntion;

        client.Connect();


    }

    private void MymessageReceivedFuntion(object sender, TwitchLib.Client.Events.OnMessageReceivedArgs e)
    {
        Debug.Log("Message Received!");
        Debug.Log(e.ChatMessage.Username + ": " + e.ChatMessage.Message);
        if (e.ChatMessage.Message == "0")
        {
            Debug.Log("user entered 0");
        }
        else
        {
            Debug.Log("user entered other value");
        }
    }
    
    void test_message()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            client.SendMessage(client.JoinedChannels[0], 
                "This is a message from the bot. " +
                "There is no game to play at this moment. " +
                "God of Orenos is coming soon!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        test_message();
    }

}
