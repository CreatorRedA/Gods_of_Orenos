using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardEffect : MonoBehaviour
{
    GameController gameController;



    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }


    //card effect

    public bool block_effect()
    {
        return false;
    }


    public void addManaNextTurn(int x)
    {
        GameController.manaNextTurn += x;
    }

    public void changeCardCost(int x)
    {
        for (int i = 0; i < GameController.MarketCards.Count; i ++)
        {
           //GameController.MarketCards[i].GetComponent<CardScript>().manaCost += x;
        }
    }

    public void discard(GameObject clickedCard)
    {
        int cardIndex = GameController.Hand.IndexOf(clickedCard);
        GameController.DiscardPile.Add(GameController.Hand[cardIndex]);
        GameController.Hand.RemoveAt(cardIndex);
        Destroy(clickedCard);
    }



    //public void discardTypeOfCard(GameObject clickedCard, string type)
    //{
    //    if (clickedCard.GetComponent<CardScript>().cardType == type)
    //    {
    //        discard(clickedCard);
    //    }
    //}

    public void moveFromDeckToDiscard(GameObject clickedCard)
    {
        int cardIndex = GameController.DrawDeck.IndexOf(clickedCard);
        GameController.DiscardPile.Add(GameController.DrawDeck[cardIndex]);
        GameController.DrawDeck.RemoveAt(cardIndex);
    }

    public void moveFromDiscardToHand(GameObject clickedCard)
    {
        int cardIndex = GameController.DiscardPile.IndexOf(clickedCard);
        GameController.Hand.Add(GameController.DiscardPile[cardIndex]);
        GameController.DiscardPile.RemoveAt(cardIndex);
        Instantiate(clickedCard, new Vector2(0, 0), Quaternion.identity,
                GameObject.FindGameObjectWithTag("Hand").transform);
    }

    public void pickFromTopXCards(int numberOfCardsToLook, int numberOfCardsToPick, GameObject clickedCard, GameObject card, string andThen)
    {
        int numberOfCardsPicked = 0;
        List<GameObject> CardToLook = new List<GameObject>();

        for (int i = 0; i < numberOfCardsToLook; i++)
        {
            Instantiate(GameController.DrawDeck[i], new Vector2(0, 0), Quaternion.identity,
                GameObject.FindGameObjectWithTag("ViewCards").transform);
        }

        if (numberOfCardsPicked < numberOfCardsToPick)
        {
            //we should remove this function
        }
    }

    public void addItemToTabletop(GameObject clickedCard)
    {
        int cardIndex = GameController.Hand.IndexOf(clickedCard);
        GameController.ItemInUse.Add(GameController.Hand[cardIndex]);
        GameController.Hand.RemoveAt(cardIndex);
    }

    public void destroyItem(GameObject clickedCard)
    {
        int cardIndex = GameController.ItemInUse.IndexOf(clickedCard);
        GameController.DiscardPile.Add(GameController.Hand[cardIndex]);
        GameController.ItemInUse.RemoveAt(cardIndex);
        Destroy(clickedCard);
    }

    public void moveItemToHand(GameObject clickedCard)
    {
        int cardIndex = GameController.ItemInUse.IndexOf(clickedCard);
        GameController.Hand.Add(GameController.Hand[cardIndex]);
        GameController.ItemInUse.RemoveAt(cardIndex);
    }

    public void complete_quest(int questNumber)
    {
        if (questNumber == 1)
        {
        }
        if (questNumber == 2)
        {
            GameController.quest2done = true;
        }
        if (questNumber == 3)
        {
            GameController.quest3done = true;
        }
        if (questNumber == 4)
        {
            GameController.quest4done = true;
        }
        if (questNumber == 5)
        {
            GameController.quest5done = true;
        }
    }

    public void getCardFromMarketToHand(GameObject clickedCard)
    {
        int cardIndex = GameController.MarketCards.IndexOf(clickedCard);
        GameController.Hand.Add(GameController.MarketCards[cardIndex]);
        GameController.MarketCards.RemoveAt(cardIndex);
        Destroy(clickedCard);
    }

    public void removeCurse(int curseNumber)
    {
        //No curse this week
    }

    //conditions
    public int CountDiscarded()
    {
        return 0;
    }


    public int countCardOfTypeInHand(string inputType)
    {
        int count = 0;
        for (int x = 0; x < GameController.Hand.Count; x++)
        {
            //if (GameController.Hand[x].GetComponent<CardScript>().cardType == inputType)
            //{
            //    count++;
            //}
        }
        return count;
    }

    public int countCardOfTypeInDiscard(string inputType)
    {
        int count = 0;
        for (int x = 0; x < GameController.DiscardPile.Count; x++)
        {
            //if (GameController.DiscardPile[x].GetComponent<CardScript>().cardType == inputType)
            //{
            //    count++;
            //}
        }
        return count;
    }

    public int countItemInPlay()
    {
        return GameController.ItemInUse.Count;
    }

    public int countCardOfTypePlayedThisTurn(string type)
    {
        if (type == "spell")
        {
            return GameController.spellPlayedThisTurn;
        }
        else if (type == "creature")
        {
            return GameController.creaturePlayedThisTurn;
        }
        else if (type == "item")
        {
            return GameController.itemPlayedThisTurn;
        }
        else
        {
            return 0;
        }
    }
}
