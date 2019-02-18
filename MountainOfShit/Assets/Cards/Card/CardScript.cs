using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CardScript : MonoBehaviour
{
    public GameController gameController;

    public GameObject clickedCard;

    public Transform hand;
    public Transform tableTop;
    public Transform market;

    public string cardTitle;
    public string cardType;
    public string manaCostString;
    public string manaAddString;
    public int manaCost;
    public int manaAdd;

    public Text cardTitleText;
    public Text cardTypeText;
    public Text manaCostText;
    public Text manaAddText;

    public void OnMouseDown()
    {
        clickedCard = gameObject;
    }

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        tableTop = GameObject.FindGameObjectWithTag("TableTop").transform;
        market = GameObject.FindGameObjectWithTag("Market").transform;
        hand = GameObject.FindGameObjectWithTag("Hand").transform;

        cardTitle = cardTitleText.text;
        cardType = cardTypeText.text;
        manaCostString = manaCostText.text;
        manaAddString = manaAddText.text;
        manaCost = int.Parse(manaCostString);
        manaAdd = int.Parse(manaAddString);
    }

    void Update()
    {
        if (this.transform.parent == market 
            && clickedCard.transform.parent == market)
        {
            gameController.buyCard(clickedCard);
        }

        //if card is dropped in table top panel, trigger card effect
        else if (this.transform.parent == tableTop)
        {
            
        }

    }

    public void playCard()
    {



    }
}
