using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    CardEffect cardEffect;
    GameObject clickedCard;

    //card list
    public static List<GameObject> MarketCards;
    public static List<GameObject> DrawDeck;
    public static List<GameObject> DiscardPile;
    public static List<GameObject> Hand;
    public static List<GameObject> NextHand;

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

    // Start is called before the first frame update
    void Start()
    {

        MarketCards = new List<GameObject>();
        DrawDeck = new List<GameObject>();
        DiscardPile = new List<GameObject>();
        Hand = new List<GameObject>();
        NextHand = new List<GameObject>();

        cardEffect = GameObject.Find("CardEffect").GetComponent<CardEffect>();

        initializeDrawDeck();
        Debug.Log("Number of cards in deck: " + DrawDeck.Count);

        initializeMarketCard();
        Debug.Log("Number of cards in market: " + MarketCards.Count);

        for (int x = 0; x < 5; x++)
        {
            int cardNumber = Random.Range(0, DrawDeck.Count);
            Instantiate(DrawDeck[cardNumber], new Vector2(0, 0), Quaternion.identity,
                GameObject.FindGameObjectWithTag("Hand").transform);
            DrawDeck.RemoveAt(cardNumber);
        }
        Debug.Log("Number of cards in deck: " + DrawDeck.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initializeDrawDeck()
    {
        for (int x = 0; x<10; x++)
        {
            DrawDeck.Add(wizard);
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
