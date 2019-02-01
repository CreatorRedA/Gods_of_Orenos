using System.Collections;
using System.Collections.Generic;
using System.Linq;

using TwitchLib.Client.Models;
using TwitchLib.Unity;
using UnityEngine;
using UnityEngine.UI;

public class TwitchClient : MonoBehaviour
{

    public static Client client;
    public string channel_name = "god_of_orenos_test";

    public GameObject[] ThreeCubes;
    public GameObject cubeprefabe;
    public Text countDownTimer;
    Vector2 cubePos;
    int[] arrayOfVotes = new int[3];
    float timer;
    float maxTime = 10f;

    int numberOfCube = 3;

    int cubesToChoose = 3;


    void countVote(){
        Debug.Log("finished");
        int indexValue = arrayOfVotes.Max();
        int maxIndex = arrayOfVotes.ToList().IndexOf(indexValue);
        ThreeCubes[maxIndex].GetComponent<Renderer>().material.color = Color.red;
    }


    void vote(string message)
    { 
        if (message.Equals("1"))
        {
            arrayOfVotes[0]++;
            Debug.Log("number of votes for cube 1 " + arrayOfVotes[0]);
        }
        else if (message.Equals("2"))
        {
            arrayOfVotes[1]++;
            Debug.Log("number of votes for cube 2 " + arrayOfVotes[1]);
        }
        else if (message.Equals("3"))
        {
            arrayOfVotes[2]++;
            Debug.Log("number of votes for cube 3 " + arrayOfVotes[2]);
        }
    }
        
        

    
    // Start is called before the first frame update
    private void Start()
    {
        arrayOfVotes[0] = 0;
        arrayOfVotes[1] = 0;
        arrayOfVotes[2] = 0;
        ThreeCubes = new GameObject[cubesToChoose];
        for (int x = 0; x < numberOfCube; x++)
        {
            cubePos = new Vector2(x * 2, 0);
            ThreeCubes[x] = Instantiate(cubeprefabe, cubePos, Quaternion.identity);
        }
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
        vote(e.ChatMessage.Message);
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
        countDownTimer.text = (maxTime - timer).ToString();
        timer += Time.deltaTime;
        test_message();
        if (timer>10 && timer<11)
        {
            countVote();
        }

    }

}
