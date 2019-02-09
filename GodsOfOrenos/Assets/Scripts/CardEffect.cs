using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardEffect : MonoBehaviour
{
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool block_effect()
    {
        return false;
    }

    public void change_card_cost(int x)
    {

    }

    public void add_mana(int x)
    {
        GameController.mana += x;
    }

    public void mana_next_turn(int x)
    {
        GameController.manaNextTurn = x;
    }

    public void discard_type_of_card(GameObject clickedCard, string type)
    {
        /*if (clickedCard.GetComponent<CardScript>().type = type)
        {
            discard(clickedCard);
        }*/
    }

    public void discard(GameObject clickedCard)
    {
        int cardNumber = GameController.Hand.IndexOf(clickedCard);
        GameController.DiscardPile.Add(GameController.Hand[cardNumber]);
        GameController.Hand.RemoveAt(cardNumber);
    }

    public void move_card_from_deck_to_discard(GameObject clickedCard)
    {
        int cardNumber = GameController.DrawDeck.IndexOf(clickedCard);
        GameController.DiscardPile.Add(GameController.DrawDeck[cardNumber]);
        GameController.DrawDeck.RemoveAt(cardNumber);
    }

    public void move_card_from_discard_to_hand(GameObject clickedCard)
    {
        int cardNumber = GameController.DiscardPile.IndexOf(clickedCard);
        GameController.Hand.Add(GameController.DiscardPile[cardNumber]);
        GameController.DiscardPile.RemoveAt(cardNumber);
    }


    public void pick_from_nextHand(int numberOfCardsToLook, int numberOfCardsToPick, 
        GameObject clickedCard, GameObject Card, string AndThen)
    {

        int numberOfCardsPicked = 0;
        List<GameObject> CardToLook = new List<GameObject>();
        
        //bring cards from next hand to screen
        for (int x = 0; x < numberOfCardsToLook; x++)
        {
            CardToLook[x] = GameController.NextHand[x];
            GameController.NextHand.RemoveAt(x);
            int cardFromDraw = Random.Range(0, GameController.DrawDeck.Count);
            GameController.NextHand.Add(GameController.DrawDeck[cardFromDraw]);
            GameController.DrawDeck.RemoveAt(cardFromDraw);
        }

        //do something to bring cards to look onto screen

        //when clicked
        int indexOfCardSentBack = 0;
        int numberOfCardLeft = 0;

        if (numberOfCardsPicked < numberOfCardsToPick)
        {
            int cardNumber = CardToLook.IndexOf(clickedCard);
            GameController.Hand.Add(GameController.NextHand[cardNumber]);
            CardToLook.RemoveAt(cardNumber);
            numberOfCardsPicked++;
        }

        else
        {
            numberOfCardLeft = numberOfCardsToPick - numberOfCardsPicked;
            if (AndThen == "go back in order")
            {
                if (indexOfCardSentBack < numberOfCardLeft)
                {
                    int indexOfClickedCard = CardToLook.IndexOf(clickedCard);
                    GameController.NextHand.Insert(indexOfCardSentBack, clickedCard);
                    GameController.NextHand.RemoveAt(GameController.NextHand.Count - 1);
                    indexOfCardSentBack++;
                    CardToLook.RemoveAt(indexOfClickedCard);
                }
            }

            else if (AndThen == "go back in random order")
            {
                for (int x = 0; x < numberOfCardLeft; x++)
                {
                    GameController.NextHand.RemoveAt(GameController.NextHand.Count - 1);
                }
                for(int x = 0; x < numberOfCardLeft; x++)
                {
                    GameController.NextHand.Add(CardToLook[x]);
                }

                for (int x = 0; x < GameController.NextHand.Count; x++)
                {
                    GameObject tmp = GameController.NextHand[x];
                    int randomIndex = Random.Range(x, GameController.NextHand.Count);
                    GameController.NextHand[x] = GameController.NextHand[randomIndex];
                    GameController.NextHand[randomIndex] = tmp;
                }
            }

            else if (AndThen == "go to discard")
            {
                for (int x = 0; x < numberOfCardLeft; x++)
                {
                    GameController.DiscardPile.Add(CardToLook[x]);
                }
                CardToLook.Clear();
            }
            
        }
    }


    public void add_item_to_board(GameObject clickedCard)
    {
        int indexOfClickdCard = GameController.Hand.IndexOf(clickedCard);
        GameController.ItemInUse.Add(GameController.Hand[indexOfClickdCard]);
        GameController.Hand.RemoveAt(indexOfClickdCard);
    }

    public void destroy_item(GameObject clickedCard)
    {
        int indexOfClickdCard = GameController.ItemInUse.IndexOf(clickedCard);
        GameController.DiscardPile.Add(GameController.ItemInUse[indexOfClickdCard]);
        GameController.ItemInUse.RemoveAt(indexOfClickdCard);
    }

    public void move_item_to_hand(GameObject clickedCard)
    {
        int indexOfClickdCard = GameController.ItemInUse.IndexOf(clickedCard);
        GameController.Hand.Add(GameController.Hand[indexOfClickdCard]);
        GameController.ItemInUse.RemoveAt(indexOfClickdCard);
    }

    public void complete_quest(GameObject clickedQuest)
    {

    }

    public void get_card_from_market_to_hand(GameObject clickedCard)
    {
        int indexOfClickdCard = GameController.MarketCards.IndexOf(clickedCard);
        GameController.Hand.Add(GameController.MarketCards[indexOfClickdCard]);
        GameController.MarketCards.RemoveAt(indexOfClickdCard);
    }

    public void remove_curse(GameObject clickedCurse)
    {
        
    }

    //methods above are all effects
    //methods below are all conditions to trigger effects

    public int card_discarded(GameObject clickedCard)
    {
        return 0;
    }

    public int counting_type_of_cards_in_hand(string type)
    {
        return 0;
    }

    public int counting_type_of_cards_in_discard(string type)
    {
        return 0;
    }

    public int counting_items_in_play(string type)
    {
        return 0;
    }

    public int counting_type_of_cards_played_this_turn(string type)
    {
        return 0;
    }

    public int counting_card_cost(GameObject clickedCard)
    {
        return 0;
    }

    public bool complete_a_quest(GameObject clickedQuest)
    {
        return true;
    }
}
