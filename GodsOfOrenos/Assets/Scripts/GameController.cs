using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    CardEffect cardEffect;
    AllCard allCard;
    GameObject clickedCard;

    public static List<GameObject> MarketCards;
    public static List<GameObject> DrawDeck;
    public static List<GameObject> DiscardPile;
    public static List<GameObject> Hand;
    public static List<GameObject> NextHand;

    public static bool quest1done;
    public static bool quest2done;
    public static bool quest3done;
    public static bool quest4done;
    public static bool quest5done;






    public static int mana;
    public static int manaNextTurn;
    public static int numberOfQuestCompleted;

    // Start is called before the first frame update
    void Start()
    {
        cardEffect = GameObject.Find("CardEffect").GetComponent<CardEffect>();
        allCard = GameObject.Find("AllCard").GetComponent<AllCard>();
        initializeDrawDeck();
        Debug.Log(DrawDeck.Count);
        initializeMarketCard();
        Debug.Log(MarketCards.Count);
        MarketCards = new List<GameObject>();
        DrawDeck = new List<GameObject>();
        DiscardPile = new List<GameObject>();
        Hand = new List<GameObject>();
        NextHand = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initializeDrawDeck()
    {
        for (int x = 0; x<10; x++)
        {
            DrawDeck.Add(allCard.wizard);
        }   
    }
    void initializeMarketCard()
    {
        for (int x = 0; x < 3; x++)
        {
            MarketCards.Add(allCard.aegisOfOrenos);
            MarketCards.Add(allCard.angelicIntervention);
            MarketCards.Add(allCard.aromoredMammoth);
            MarketCards.Add(allCard.bladeOfAeons);
            MarketCards.Add(allCard.chronoLocket);
            MarketCards.Add(allCard.comfortingFlame);
            MarketCards.Add(allCard.consumePower);
            MarketCards.Add(allCard.craft);
            MarketCards.Add(allCard.divine);
            MarketCards.Add(allCard.empower);
            MarketCards.Add(allCard.firewoodSpirt);
            MarketCards.Add(allCard.grandPurifier);
            MarketCards.Add(allCard.greatDryad);
            MarketCards.Add(allCard.hindranceCharm);
            MarketCards.Add(allCard.jetBlackFlower);
            MarketCards.Add(allCard.jeweledSerpent);
            MarketCards.Add(allCard.luckyElf);
            MarketCards.Add(allCard.manaLeech);
            MarketCards.Add(allCard.manaVial);
            MarketCards.Add(allCard.mindParasite);
            MarketCards.Add(allCard.search);
            MarketCards.Add(allCard.shopKeepsFavor);
            MarketCards.Add(allCard.spireOfPower);
            MarketCards.Add(allCard.spiritIdol);
            MarketCards.Add(allCard.warBeast);
            MarketCards.Add(allCard.warp);
            MarketCards.Add(allCard.wormhole);
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
