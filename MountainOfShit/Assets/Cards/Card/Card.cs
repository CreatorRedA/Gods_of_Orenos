using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

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

    private Transform hand;
    private Transform tableTop;
    private Transform market;
    public Transform discard;

    public string cardTitle;
    public string cardType;
    public string manaCostString;
    public string manaAddString;
    public int manaCost;
    public int manaAdd;

    public bool isItem = false;

    public void Start()
    {
        if (!alreadyPurchased)
        {
            this.GetComponent<Draggable>().enabled = false;
        }
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        tableTop = GameObject.FindGameObjectWithTag("TableTop").transform;
        market = GameObject.FindGameObjectWithTag("Market").transform;
        hand = GameObject.FindGameObjectWithTag("Hand").transform;
        discard = GameObject.FindGameObjectWithTag("Discard").transform;
    }


    // Update is called once per frame
    public void Update()
    {
        if (transform.parent == tableTop)
        {
            onPlay();
            this.GetComponent<Draggable>().enabled = false;
        }
        if(gameController.turnOver == true)
        {
            this.transform.parent = discard; 
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
            this.transform.parent = hand;
            this.GetComponent<Draggable>().enabled = true;
            gameController.looseMana(manaCost);
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("HI");
        this.purchaseCard();
    }
    public void addManaCost()
    {
    }
}
