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
    public Text voteResult;
    Vector2 cubePos;
    int[] arrayOfVotes = new int[3];
    float timer;
    float maxTime = 10f;
    List<string> votedUser = new List<string>();

    bool countNow;
    bool noVote;

    int numberOfCube = 3;

    int cubesToChoose = 3;


    void countVote(){
        Debug.Log("Finished");
        int indexValue = arrayOfVotes.Max();
        int maxIndex = arrayOfVotes.ToList().IndexOf(indexValue);

        //ensure at least one vote is accepted, if no one vote, show it somewhere
        if (noVote != true)
        {
            ThreeCubes[maxIndex].GetComponent<Renderer>().material.color = Color.red;
            voteResult.text = "Cube No." + (maxIndex + 1) + " is selected!";
        }
        else
        {
            voteResult.text = "No vote received!";
        }
        
        countNow = false;
    }

    private void MymessageReceivedFuntion(object sender, TwitchLib.Client.Events.OnMessageReceivedArgs e)
    {   
        if (!votedUser.Contains(e.ChatMessage.Username))//check if this audience have voted already
        {
            if (e.ChatMessage.Message.Equals("1"))//check whether the coming message is a vote
            {
                arrayOfVotes[0]++;//plus one to vote count for this cube
                noVote = false;//tell the script now we have at least one vote
                votedUser.Add(e.ChatMessage.Username);//add this audience to the list of voted user
                Debug.Log(e.ChatMessage.Username + "just voted for cube 1." + " Number of votes for cube 1: " + arrayOfVotes[0]);
            }
            else if (e.ChatMessage.Message.Equals("2"))
            {
                arrayOfVotes[1]++;
                noVote = false;
                votedUser.Add(e.ChatMessage.Username);
                Debug.Log(e.ChatMessage.Username + "just voted for cube 2." + " Number of votes for cube 1: " + arrayOfVotes[1]);
            }
            else if (e.ChatMessage.Message.Equals("3"))
            {
                arrayOfVotes[2]++;
                noVote = false;
                votedUser.Add(e.ChatMessage.Username);
                Debug.Log(e.ChatMessage.Username + "just voted for cube 3." + " Number of votes for cube 1: " + arrayOfVotes[2]);
            }  
        }
        else
        {
            Debug.Log(e.ChatMessage.Username + " is trying to vote again!");
        }

    }

    void vote(string message, string userName)
    {
        
        
        
    }
        
        

    
    // Start is called before the first frame update
    private void Start()
    {
        List<string> votedUser = new List<string>();
        votedUser.Add("0");

        arrayOfVotes[0] = 0;
        arrayOfVotes[1] = 0;
        arrayOfVotes[2] = 0;

        countNow = true;
        noVote = true;

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

    void countDown ()
    {
        if (timer < 10)
        {
            countDownTimer.text = (maxTime - timer).ToString();
            timer += Time.deltaTime;
        }
        else
        {
            countDownTimer.text = "Countdown finished!".ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        countDown();
        test_message();
        if (timer > 10 && countNow == true)
        {
            countVote();
        }

    }

}
