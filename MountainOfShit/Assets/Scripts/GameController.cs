using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //card list
    public static List<GameObject> MarketCards;
    public static List<GameObject> DrawDeck;
    public static List<GameObject> DiscardPile;
    public static List<GameObject> Hand;
    public static List<GameObject> ItemInUse;

    //mana list
    public List<Image> manaIcons;

    //quest indicator
    public static bool quest1done;
    public static bool quest2done;
    public static bool quest3done;
    public static bool quest4done;
    public static bool quest5done;

    //panels
    public GameObject handPanel;
    public GameObject manaPanel;
    public GameObject marketPanel;

    //mana image
    public Image manaIcon;

    //curse indicator
    public static bool curse1;
    public static bool curse2;
    public static bool curse3;
    public static bool curse4;
    public static bool curse5;
    public static bool curse6;

    //loading card prefabs
    public GameObject aegisOfOrenos;
    public GameObject angelicIntervention;
    public GameObject aromoredMammoth;
    public GameObject bladeOfAeons;
    public GameObject chronoLocket;
    public GameObject comfortingFlame;
    public GameObject consumePower;
    public GameObject craft;
    public GameObject divine;
    public GameObject empower;
    public GameObject firewoodSpirt;
    public GameObject grandPurifier;
    public GameObject greatDryad;
    public GameObject hindranceCharm;
    public GameObject jetBlackFlower;
    public GameObject jeweledSerpent;
    public GameObject luckyElf;
    public GameObject manaLeech;
    public GameObject manaVial;
    public GameObject mindParasite;
    public GameObject search;
    public GameObject shopKeepsFavor;
    public GameObject spireOfPower;
    public GameObject spiritIdol;
    public GameObject warBeast;
    public GameObject warp;
    public GameObject wizard;
    public GameObject wormhole;

    //variables
    public static int mana;
    public static int manaNextTurn;
    public static int numberOfQuestCompleted;
    public static int turns;
    public static int cardDrawed;

    public static int spellPlayedThisTurn;
    public static int creaturePlayedThisTurn;
    public static int itemPlayedThisTurn;


    //Able to access mana through method
    public int getMana()
    {
        return mana;
    }
    //initialization
    public void Start()
    {
        manaIcons = new List<Image>();
        MarketCards = new List<GameObject>();
        DrawDeck = new List<GameObject>();
        DiscardPile = new List<GameObject>();
        Hand = new List<GameObject>();
        ItemInUse = new List<GameObject>();
        for(int x = 0; x < 5; x++)
        {
            GameObject wizardObj = Instantiate(wizard);
            wizardObj.transform.SetParent(handPanel.transform);
        }
        mana = 0;
        manaNextTurn = 0;
        numberOfQuestCompleted = 0;
        turns = 0;
        cardDrawed = 5;

        initializeMarketCard();
        for(int i = 0; i < 5; i++)
        {
            int RANDOM = Random.Range(0, MarketCards.Count);
            GameObject marketObj = Instantiate(MarketCards[RANDOM]);
            marketObj.transform.SetParent(marketPanel.transform);
        }

    }
    //called ever frame
    void Update()
    {
        if (numberOfQuestCompleted >= 3)
        {
            endTheGame();
        }
    }

    public void addMana(int manaAdd)
    {
        mana += manaAdd;
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
            DrawDeck.Add(wizard);
        }
    }

    void initializeMarketCard()
    {
        for (int x = 0; x < 3; x++)
        {
            MarketCards.Add(aegisOfOrenos);
            //MarketCards.Add(angelicIntervention);
            //MarketCards.Add(aromoredMammoth);
            //MarketCards.Add(bladeOfAeons);
            //MarketCards.Add(chronoLocket);
            //MarketCards.Add(comfortingFlame);
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
            //MarketCards.Add(shopKeepsFavor);
            //MarketCards.Add(spireOfPower);
            //MarketCards.Add(spiritIdol);
            //MarketCards.Add(warBeast);
            //MarketCards.Add(warp);
            //MarketCards.Add(wormhole);
        }
    }

    public static void endTheGame()
    {
        if (numberOfQuestCompleted >=3)
        {
            Debug.Log("You Win!");
        }

        else if( turns >= 10 && numberOfQuestCompleted < 3)
        {
            Debug.Log("You Lose");
        }
    }

    public void drawToHand(int i)
    {
        for (int x = 0; x < i; x++)
        {
            Hand.Add(DrawDeck[0]);
            DrawDeck.RemoveAt(0);
        }

        for (int x = 0; x < Hand.Count; x++)
        {
            Instantiate(Hand[x], new Vector2(0, 0), Quaternion.identity,
                GameObject.FindGameObjectWithTag("Hand").transform);
        }
    }

    //public void buyCard (GameObject clickedCard)
    //{
    //    int cost = clickedCard.GetComponent<CardScript>().manaCost;
    //    int CardIndex = MarketCards.IndexOf(clickedCard);
    //    if (mana >= cost)
    //    {
    //        mana -= cost;
    //        DrawDeck.Add(MarketCards[CardIndex]);
    //        MarketCards.RemoveAt(CardIndex);
    //    }
    //    else
    //    {
    //        Debug.Log("No engough mana");
    //    }

    //}
}
