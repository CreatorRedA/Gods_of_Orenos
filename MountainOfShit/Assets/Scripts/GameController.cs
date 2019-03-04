using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Transform tabletop;
    /*
     * 44-82: Noah
     * 
     * 43-0: Feiyi
     */
    //curse list
    public static bool pauperCurseActive;
    public static bool inaneCurseActive;
    public static bool somnusCurseActive;
    public static bool malumCurseActive;
    public static bool plagaCurseActive;
    public static bool magicianCurseActive;
    
    public static bool pauperCurseWorking;
    public static bool inaneCurseWorking;
    public static bool somnusCurseWorking;
    public static bool malumCurseWorking;
    public static bool plagaCurseWorking;
    public static bool magicianCurseWorking;

    public static bool malumBlocking;
    public int malumCards;
    
    //card list
    public static List<GameObject> MarketCards;
    public List<GameObject> MarketCardsGameObject;
    public static List<GameObject> DrawDeck;
    public static List<GameObject> DiscardPile;
    public static List<GameObject> Hand;
    public static List<GameObject> ItemInUse;

    //mana list
    public List<Image> manaIcons;
    public Text manaCount;

    //destroy item bool
    public bool canDestroyItem;
    //quest indicator
    public bool questGorenaDone;
    public static bool questVorconaDone;
    public static bool questNiruDone;
    public static bool questSentaalDone;
    public static bool questIgejDone;

    bool GorenaRewards;
    bool VorconaRewards;
    bool NiruRewards;
    bool SentaalRewards;
    bool IgejRewards;

    //panels
    public GameObject handPanel;
    public GameObject manaPanel;
    public GameObject marketPanel;
    public GameObject questPanel;
    //scroll panels
    public GameObject deckScrollPanel;
    public GameObject deckScrollPanelContent;

    public GameObject discardScrollPanel;
    public GameObject discardScrollPanelContent;

    //mana image
    public Image manaIcon;

    //turn counter text and count
    public Text turnCounter;
    int turnCount = 0;
    //curse indicator
    public static bool curse1;
    public static bool curse2;
    public static bool curse3;
    public static bool curse4;
    public static bool curse5;
    public static bool curse6;
    //Quest Card Prefabs
    //loading card prefabs
    public GameObject aegisOfOrenos;
    public GameObject angelicIntervention;
    public GameObject comfortingFlame;
    public GameObject divine;
    public GameObject empower;
    public GameObject jetBlackFlower;
    public GameObject luckyElf;
    public GameObject manaVial;
    public GameObject mindParasite;
    public GameObject shopKeepsFavor;
    public GameObject smelt;
    public GameObject spireOfPower;
    public GameObject warBeast;
    public GameObject pyschichHiveQueen;
    public GameObject goodBoy;
    public GameObject druid;
    public GameObject wizard;

    //variables
    public static int mana;
    public static int manaNextTurn;
    public static int numberOfQuestCompleted;
    public static int turns;
    public static int cardDrawed;
    public static int itemPlayed;

    public static int creaturePlayed;
    public static int cardDiscarded;
    public static int cardDrawedThisTurn;
    public static int spellPlayedThisTurn;
    public static int creaturePlayedThisTurn;
    public static int itemPlayedThisTurn;

    public bool turnOver;

    //clicked card indicator
    public static GameObject clickedCard;

    //Able to access mana through method
    public int getMana()
    {
        return mana;
    }
    //initialization
    public void Start()
    {
        tabletop = GameObject.FindGameObjectWithTag("TableTop").transform;
        turnCounter.text = turnCount.ToString();
        manaIcons = new List<Image>();
        MarketCards = new List<GameObject>();
        DrawDeck = new List<GameObject>();
        DiscardPile = new List<GameObject>();
        Hand = new List<GameObject>();
        ItemInUse = new List<GameObject>();
        mana = 0;
        manaNextTurn = 0;
        numberOfQuestCompleted = 0;
        turns = 0;
        cardDrawed = 0;
        initializeDrawDeck();
        initializeMarketCard();
        manaCount.text = mana.ToString();

        GorenaRewards = true;
        VorconaRewards = true;
        NiruRewards = true;
        SentaalRewards = true;
        IgejRewards = true;

        pauperCurseActive = false;
        inaneCurseActive = false;
        somnusCurseActive = false;
        malumCurseActive = false;
        magicianCurseActive = false;

        pauperCurseWorking = false;
        inaneCurseWorking = false;
        somnusCurseWorking = false;
        malumCurseWorking = false;
        magicianCurseWorking = false;

        malumBlocking = false;
        malumCards = 0;
        for (int i = 0; i < 5; i++)
        {
            int RANDOM = Random.Range(0, MarketCards.Count);
            Debug.Log(RANDOM);
            GameObject marketObj = Instantiate(MarketCards[RANDOM]);
            marketObj.transform.SetParent(marketPanel.transform);
            MarketCardsGameObject.Add(marketObj);
        }


    }
    //called ever frame
    void Update()
    {
        if (numberOfQuestCompleted >= 3)
        {
            endTheGame();
        }
        //quest
        Gorena();
        Vorcona();
        Niru();
        Sentaal();
        Igej();
        //curse
        Pauper();
        malum();
    }

    //curse functions
    void Pauper()
    {
        if (pauperCurseActive == true && pauperCurseWorking == false)
        {
            Card card = GameObject.Find("Card").GetComponent<Card>();
            card.changeManaCost(1);
            pauperCurseWorking = true;
        }
    }

    void inane()
    {
        if (inaneCurseActive == true && inaneCurseWorking == false)
        {
            Card card = GameObject.Find("Card").GetComponent<Card>();
            card.discardRandomCards(1);
            inaneCurseWorking = true;
        }
    }

    void somnus()
    {
        if (somnusCurseActive == true && somnusCurseWorking == false)
        {
            mana -= 3;
            somnusCurseWorking = true;
        }
    }

    void malum()
    {
        if (malumCurseActive == true && malumCurseWorking == false)
        {
            malumBlocking = true;
            malumCurseWorking = true;
        }
    }

    //quest functions
    void Gorena()
    {
        if (mana >= 20 && GorenaRewards == true)
        {
            Debug.Log("HI");
            questGorenaDone = true;
            numberOfQuestCompleted += 1;

            for (int x = 0; x < 2; x++)
            {
                int i = Random.Range(0, MarketCards.Count);
                DiscardPile.Add(MarketCards[i]);
                MarketCards[i].transform.SetParent(discardScrollPanel.transform);
                MarketCards.RemoveAt(i);
            }
            GorenaRewards = false;
        }
    }

    void Vorcona()
    {
        if (itemPlayed >= 7 && VorconaRewards == true)
        {
            Card card = GameObject.Find("Card").GetComponent<Card>();
            questVorconaDone = true;
            numberOfQuestCompleted += 1;
            card.changeManaCost(-2);
            VorconaRewards = false;
        }
    }

    void Niru()
    {
        if (cardDrawedThisTurn >= 5 && NiruRewards == true)
        {
            questNiruDone = true;
            numberOfQuestCompleted += 1;
            cardDrawed = 3;
            NiruRewards = false;
        }
    }

    void Sentaal()
    {
        if (creaturePlayed >= 7 && SentaalRewards == true)
        {
            questSentaalDone = true;
            numberOfQuestCompleted += 1;
            addMana(5);
            SentaalRewards = false;
        }
    }

    void Igej()
    {
        if (cardDiscarded >= 7 && IgejRewards == true)
        {
            questIgejDone = true;
            numberOfQuestCompleted += 1;
            for (int x = 0; x < ItemInUse.Count; x++)
            {
                ItemInUse[x].transform.SetParent(discardScrollPanel.transform);
                DiscardPile.Add(ItemInUse[x]);
                ItemInUse.RemoveAt(x);
            }
        }
    }
    public void addMana(int manaAdd)
    {
        mana += manaAdd;
        if (mana >= 20)
        {
            Debug.Log("HI");
            questGorenaDone = true;
        }
        manaCount.text = mana.ToString();
        Image manaObj = Instantiate(manaIcon);
        manaIcons.Add(manaObj);
        for (int i = 0; i < manaAdd; i++)
        {
            manaIcons.Add(manaObj);
            manaObj.transform.SetParent(manaPanel.transform);
        }


    }
    //loose mana and delete picture of mana
    public void looseMana(int manaLoss)
    {
        mana -= manaLoss;
        manaCount.text = mana.ToString();
        Destroy(manaIcons[0]);
        for (int i = 0; i < manaLoss; i++)
        {
            Destroy(manaIcons[i]);
            manaIcons.RemoveAt(i);
        }

    }
    void initializeDrawDeck()
    {
        for (int x = 0; x < 10; x++)
        {
            GameObject wizardObj = Instantiate(wizard);
            if (x < 5) wizardObj.transform.SetParent(handPanel.transform);
            else
            {
                wizardObj.transform.SetParent(deckScrollPanelContent.transform);
                DrawDeck.Add(wizardObj);
            }

        }
    }
    void initializeQuestCard()
    {
    }
    void initializeMarketCard()
    {
        for (int x = 0; x < 3; x++)
        {
            MarketCards.Add(aegisOfOrenos);
            MarketCards.Add(angelicIntervention);
            MarketCards.Add(comfortingFlame);
            //MarketCards.Add(consumePower);
            //MarketCards.Add(craft);
            //MarketCards.Add(divine);
            //MarketCards.Add(empower);
            //MarketCards.Add(firewoodSpirt);
            //MarketCards.Add(grandPurifier);
            //MarketCards.Add(greatDryad);
            //MarketCards.Add(hindranceCharm);
            //MarketCards.Add(jetBlackFlower);
            //MarketCards.Add(jeweledSerpent);
            //MarketCards.Add(luckyElf);
            //MarketCards.Add(manaLeech);
            //MarketCards.Add(manaVial);
            //MarketCards.Add(mindParasite);
            //MarketCards.Add(search);
            MarketCards.Add(shopKeepsFavor);
            //MarketCards.Add(spireOfPower);
            //MarketCards.Add(spiritIdol);
            //MarketCards.Add(warBeast);
            //MarketCards.Add(warp);
            //MarketCards.Add(wormhole);
        }
    }

    public static void endTheGame()
    {
        if (numberOfQuestCompleted >= 3)
        {
            Debug.Log("You Win!");
        }

        else if (turns >= 10 && numberOfQuestCompleted < 3)
        {
            Debug.Log("You Lose");
        }
    }

    public void drawToHand(int i)
    {
        if (malumBlocking == false)
        {
            for (int x = 0; x < i; x++)
            {
                Hand.Add(DrawDeck[0]);
                DrawDeck.RemoveAt(0);
            }

            for (int x = 0; x < Hand.Count; x++)
            {
                GameController.Hand[x].transform.SetParent(handPanel.transform);
                FindObjectOfType<AudioManager>().Play("draw");
                malumCards += 1;

            }
        }
        else if (malumBlocking == true && malumCards <= 5)
        {
            for (int x = 0; x < i; x++)
            {
                Hand.Add(DrawDeck[0]);
                DrawDeck.RemoveAt(0);
            }

            for (int x = 0; x < Hand.Count; x++)
            {
                GameController.Hand[x].transform.SetParent(handPanel.transform);
                FindObjectOfType<AudioManager>().Play("draw");
                malumCards += 1;
            }
        }
        else if (malumBlocking == true && malumCards > 5)
        {
            Debug.Log("You can't draw due to Malum's curse!");
        }
        
    }

    public void deckOnClick()
    {
        deckScrollPanel.SetActive(!deckScrollPanel.activeSelf);
    }
    public void discardOnClick()
    {
        discardScrollPanel.SetActive(!discardScrollPanel.activeSelf);
    }

    public void onTurnEnd()
    {
        cardDrawedThisTurn = 0;
        foreach (GameObject go in Hand)
        {
            go.transform.SetParent(discardScrollPanel.transform);
            DiscardPile.Add(go);
            Hand.Remove(go);
        }
        malumCards = 0;
        drawToHand(5 + cardDrawed);
        mana = manaNextTurn;
        somnus();
        turnOver = true;
        turnCount += 1;
        turnCounter.text = turnCount.ToString();


        if (turnCount >= 8)
        {
            endGame();
        }
        inane();


        canDestroyItem = false;

        if (pauperCurseActive == true)
        {
            pauperCurseActive = false;
            Card card = GameObject.Find("Card").GetComponent<Card>();
            card.changeManaCost(-1);
        }

        inaneCurseActive = false;
        somnusCurseActive = false;
        malumCurseActive = false;
        magicianCurseActive = false;

        pauperCurseWorking = false;
        inaneCurseWorking = false;
        somnusCurseWorking = false;
        malumCurseWorking = false;
        magicianCurseWorking = false;
        malumCards = 0;
    }

    public void destroyItem(GameObject clickedCard)
    {
        if (clickedCard.GetComponent<Card>().cardType == "Item" && clickedCard.transform.parent == tabletop && canDestroyItem)
        {
            int index = ItemInUse.IndexOf(clickedCard);
            DiscardPile.Add(ItemInUse[index]);
            ItemInUse.RemoveAt(index);
            Destroy(clickedCard);
        }
    }

    public void endGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
