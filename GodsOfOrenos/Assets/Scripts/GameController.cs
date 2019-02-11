using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    CardEffect cardEffect;
    GameObject clickedCard;
    public GameObject HandPanel;


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

        DrawDeck.AddRange(MarketCards);

        DrawNextHand(5);

        DrawToHand(5);




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


    void DrawNextHand(int x)
    {
        for (int y = 0; y < x; y++)
        {
            int cardNumber = Random.Range(0, DrawDeck.Count);
            NextHand.Add(DrawDeck[cardNumber]);
            DrawDeck.RemoveAt(cardNumber);
        }
        Debug.Log("cards in next hand: " + NextHand.Count);
    }


    void DrawToHand(int x)
    {
        for (int y = 0; y < x; y++)
        {
            Hand.Add(NextHand[y]);  
        }
        Debug.Log("cards in hand: " + Hand.Count);

        for (int y = 0; y < x; y++)
        {
            NextHand.RemoveAt(0);
        }
        Debug.Log("cards in next hand: " + NextHand.Count);

        if (NextHand.Count < 5)
        {
            int diff = 5 - NextHand.Count;
            for (int y = 0; y < diff; y++)
            {
                int cardNumber = Random.Range(0, DrawDeck.Count);
                NextHand.Add(DrawDeck[cardNumber]);
                DrawDeck.RemoveAt(cardNumber);
            }
        }
    }


    public static void DrawCard()
    {
        for (int x = 0; x < Hand.Count; x++)
        {
            Instantiate(Hand[x], new Vector2(0, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Hand").transform);
        }
        Debug.Log("cards in hand: " + Hand.Count);
    }

    public static void Discard()
    {
        GameController gameController;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        int size = Hand.Count;
        for (int x = 0; x < size; x++)
        {
            DiscardPile.Add(Hand[x]);
            Destroy(gameController.HandPanel.transform.GetChild(x).gameObject);
        }
        Hand.Clear();
        Debug.Log("cards in hand: " + Hand.Count);
    }
}
