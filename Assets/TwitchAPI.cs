using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchLib.Unity;
using TwitchLib.Api.Models.Undocumented.Chatters;

public class TwitchAPI : MonoBehaviour
{
    public Api api;


    void Start()
    {
        Application.runInBackground = true;
        api = new Api();
        api.Settings.AccessToken = Secret.bot_access_token;
        api.Settings.ClientId = Secret.client_id;
    }

    private void GetChatterListCallback(List<ChatterFormatted> listOfChatters)
    {
        Debug.Log("List of" + listOfChatters.Count + "viwers:");
        foreach(var ChatterObject in listOfChatters)
        {
            Debug.Log(ChatterObject.Username);
        }
    }
    void num2Invoke(Client client)
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            api.Invoke(api.Undocumented.GetChattersAsync(client.JoinedChannels[0].Channel), GetChatterListCallback);
        }
    }


    void Update()
    {
        num2Invoke(TwitchClient.client);
    }
}
