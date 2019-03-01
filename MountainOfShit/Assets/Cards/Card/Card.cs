using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    /*
     * Parent Class for all cards to inherit from
     */

    public bool playOnceOnly = false;
    public bool alreadyPurchased = false;

    public GameController gameController;

    public GameObject clickedCard;

    public int totalMana;

    public Transform hand;
    private Transform tableTop;
    private Transform market;
    public Transform discard;
    public Text cardTypeUI;

    public string cardTitle;
    public string cardType;

    public string manaCostString;
    public string manaAddString;

    public int manaCost;
    public int manaAdd;

    public bool isItem = false;

    public void Start()
    {
        this.GetComponent<Draggable>().enabled = false;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        tableTop = GameObject.FindGameObjectWithTag("TableTop").transform;
        market = GameObject.FindGameObjectWithTag("Market").transform;
        hand = GameObject.FindGameObjectWithTag("Hand").transform;
        discard = gameController.discardScrollPanelContent.transform;
    }


    // Update is called once per frame
    public void Update()
    {
        if (alreadyPurchased)
        {
            this.GetComponent<Draggable>().enabled = true;
        }
        if (gameController.canDestroyItem&& cardType.Equals("Item"))
        {
            Debug.Log("HI");
        }

        if (transform.parent == tableTop)
        {
            onPlay();
            this.GetComponent<Draggable>().enabled = false;
        }
        if(gameController.turnOver == true)
        {
            Debug.Log("HI");
            if (alreadyPurchased){
                Destroy(this);
            }

        }

    }
    protected virtual void onPlay()
    {

    }
    
    public void purchaseCard()
    {
        totalMana = gameController.getMana();
        if(totalMana>= manaCost)
        {
            this.transform.SetParent(hand);
            this.GetComponent<Draggable>().enabled = true;
            gameController.looseMana(manaCost);
            this.alreadyPurchased = true;
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(cardType);
        Debug.Log(cardType);
        if (this.alreadyPurchased == false)
        {
            this.purchaseCard();
        }
        else if (gameController.canDestroyItem && cardType.Equals("Item"))
        {
            Debug.Log("a");
            Destroy(this);
        }
    }
    public void changeManaCost(int change)
    {

    }

    public void discardRandomCards(int x)
    {
        for (int i = 0; i < x; i++)
        {
            int index = Random.Range(0, GameController.Hand.Count);
            GameController.Hand[index].transform.SetParent(discard);
            GameController.DiscardPile.Add(GameController.Hand[index]);
            GameController.Hand.RemoveAt(index);
        }
    }
}
