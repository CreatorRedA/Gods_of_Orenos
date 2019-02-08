using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    CardEffect cardEffect;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
