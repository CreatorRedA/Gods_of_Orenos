using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TuneVariables : MonoBehaviour
{
    public InputField numberOfQuestCardsOnBoardInput;
    public InputField numberOfMarketCardsOnBoardInput;
    public InputField totalNumberOfQuestCardsInput;
    public InputField totalNumberOfMarketCardsInput;
    public InputField startingDeckSizeInput;
    public InputField numberCardsDrawnInput;
    public InputField voteTimeInput;
    public InputField numberOfCardsChosenInput;
    public InputField numberOfVotesPerViewerInput;

    public static string numberOfQuestCardsOnBoard;
    public static string numberOfMarketCardsOnBoard;
    public static string totalNumberOfQuestCards;
    public static string totalNumberOfMarketCards;
    public static string startingDeckSize;
    public static string numberCardsDrawn;
    public static string voteTime;
    public static string numberOfCardsChosen;
    public static string numberOfVotesPerViewer;

    public GameObject scriptHolder;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(scriptHolder);
    }

    // Update is called once per frame
    void Update()
    {
        numberOfQuestCardsOnBoard = numberOfQuestCardsOnBoardInput.text;

        numberOfMarketCardsOnBoard = numberOfMarketCardsOnBoardInput.text;

        totalNumberOfQuestCards = totalNumberOfQuestCardsInput.text;

        totalNumberOfMarketCards = totalNumberOfMarketCardsInput.text;

        startingDeckSize = startingDeckSizeInput.text;

        numberCardsDrawn = numberCardsDrawnInput.text;

        voteTime = voteTimeInput.text;

        numberOfCardsChosen = numberOfCardsChosenInput.text;

        numberOfVotesPerViewer = numberOfVotesPerViewerInput.text;
    }
}
