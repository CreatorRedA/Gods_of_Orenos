using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    CardEffect cardEffect;
    GameObject clickedCard;

    List<GameObject> allDeckCards = new List<GameObject>();

    public Text manaDisplay;

    public GameObject deckPanel;
    public GameObject handPanel;
    public GameObject marketPanel;
    

    //card list
    public static List<GameObject> MarketCards;
    public static List<GameObject> DrawDeck;
    public static List<GameObject> DiscardPile;
    public static List<GameObject> Hand;
    public static List<GameObject> NextHand;
    public static List<GameObject> ItemInUse;

    //quest indicator
    public static bool quest1done;
    public static bool quest2done;
    public static bool quest3done;
    public static bool quest4done;
    public static bool quest5done;

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





    public static int mana;

    public static int manaNextTurn;
    public static int numberOfQuestCompleted;
    public int getMana()
    {
        return mana;
    }
    public void showMarketCards()
    {
        marketPanel.SetActive(!marketPanel.active);
            for (int i = 0; i < 5; i++)
            {
                marketPanel.SetActive(!marketPanel.active);

                GameObject j = Instantiate(MarketCards[i]);

                j.transform.SetParent(marketPanel.transform);
        }

    }
    public void drawOneCard()
    {
        Debug.Log("error");
        GameObject cardToDraw = DrawDeck[0];
        DrawDeck.Remove(cardToDraw);
        cardToDraw.SetActive(true);
        cardToDraw.transform.SetParent(handPanel.transform);
    }
    public void gainOneMana()
    {
        mana += 1;
    }
    public void onDeckClick()
    {
        deckPanel.SetActive(!deckPanel.active);
    }
    // Start is called before the first frame update
    void Start()
    {
        MarketCards = new List<GameObject>();
        DrawDeck = new List<GameObject>();
        DiscardPile = new List<GameObject>();
        Hand = new List<GameObject>();
        NextHand = new List<GameObject>();

        allDeckCards.Add(jeweledSerpent);
        allDeckCards.Add(greatDryad);
        allDeckCards.Add(mindParasite);

        foreach(GameObject go in allDeckCards)
        {
            GameObject goInst = Instantiate(go);
            goInst.transform.SetParent(deckPanel.transform);
            goInst = Instantiate(go);
            DrawDeck.Add(goInst);
            goInst.transform.SetParent(deckPanel.transform);
            DrawDeck.Add(goInst);
            goInst = Instantiate(go);
            goInst.transform.SetParent(deckPanel.transform);
            DrawDeck.Add(goInst);
            goInst = Instantiate(go);
            goInst.transform.SetParent(deckPanel.transform);
            DrawDeck.Add(goInst);
            goInst = Instantiate(go);
            goInst.transform.SetParent(deckPanel.transform);
            DrawDeck.Add(goInst);
        }



        cardEffect = GameObject.Find("CardEffect").GetComponent<CardEffect>();

        initializeDrawDeck();
        Debug.Log("Number of cards in deck: " + DrawDeck.Count);

        initializeMarketCard();
        Debug.Log("Number of cards in market: " + MarketCards.Count);

        for (int x = 0; x < 5; x++)
        {
            int cardNumber = Random.Range(0, DrawDeck.Count);

            Hand.Add(Instantiate(DrawDeck[cardNumber], new Vector2(0, 0), Quaternion.identity, 
                GameObject.FindGameObjectWithTag("Hand").transform));
            DrawDeck.RemoveAt(cardNumber);
        }
    }

    // Update is called once per frame
    void Update()
    {
        manaDisplay.text = "Mana: " + mana.ToString();
    }

    void initializeDrawDeck()
    {
        for (int x = 0; x<10; x++)
        {
            DrawDeck.Add(allDeckCards[x%3]);
        }   
    }

    void initializeMarketCard()
    {
        for (int x = 0; x < 3; x++)
        {
            MarketCards.Add(aegisOfOrenos);
            MarketCards.Add(angelicIntervention);
            MarketCards.Add(aromoredMammoth);
            MarketCards.Add(bladeOfAeons);
            MarketCards.Add(chronoLocket);
            MarketCards.Add(comfortingFlame);
            MarketCards.Add(consumePower);
            MarketCards.Add(craft);
            MarketCards.Add(divine);
            MarketCards.Add(empower);
            MarketCards.Add(firewoodSpirt);
            MarketCards.Add(grandPurifier);
            MarketCards.Add(greatDryad);
            MarketCards.Add(hindranceCharm);
            MarketCards.Add(jetBlackFlower);
            MarketCards.Add(jeweledSerpent);
            MarketCards.Add(luckyElf);
            MarketCards.Add(manaLeech);
            MarketCards.Add(manaVial);
            MarketCards.Add(mindParasite);
            MarketCards.Add(search);
            MarketCards.Add(shopKeepsFavor);
            MarketCards.Add(spireOfPower);
            MarketCards.Add(spiritIdol);
            MarketCards.Add(warBeast);
            MarketCards.Add(warp);
            MarketCards.Add(wormhole);
        }
    }

    void DrawToHand(int x)
    {
        for (int y = 0; y < x; y++)
        {
            int cardNumber = Random.Range(0, DrawDeck.Count);
            Hand.Add(DrawDeck[cardNumber]);
            DrawDeck.RemoveAt(cardNumber);
        }
    }

    void DrawNextHand(int x)
    {
        for (int y = 0; y < x; y++)
        {
            int cardNumber = Random.Range(0, DrawDeck.Count);
            NextHand.Add(DrawDeck[cardNumber]);
            DrawDeck.RemoveAt(cardNumber);
        }
    }

}
