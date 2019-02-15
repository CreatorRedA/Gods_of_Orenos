using System.Collections;
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
                for (int x = 0; x < numberOfCardLeft; x++)
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

    //methods above are effects
    //methods below are conditions to trigger effects

    public int card_discarded(GameObject clickedCard)
    {
        return 0;
    }

    public int counting_type_of_cards_in_hand(string inputType)
    {
        int count = 0;
        for (int x = 0; x < GameController.Hand.Count; x++)
        {
            //if (GameController.Hand[x].GetComponent<CardScript>().type == inputType)
            {
                count++;
            }
        }
        return count;
    }

    public int counting_type_of_cards_in_discard(string inputType)
    {
        int count = 0;
        for (int x = 0; x < GameController.DiscardPile.Count; x++)
        {
            //if (GameController.DiscardPile[x].GetComponent<CardScript>().type == inputType)
            {
                count++;
            }
        }
        return count;
    }

    public int counting_items_in_play(string type)
    {
        return 0;
    }

    public int counting_type_of_cards_played_this_turn(string type)
    {
        return 0;
    }

    public void counting_card_cost(GameObject clickedCard)
    {
        //return clickedCard.GetComponent<CardScript>().cost;
    }

    public bool complete_a_quest(GameObject clickedQuest)
    {
        return true;
    }

    //methods above are conditions
    //methods below are curses

    public void curse1()
    {
        //Curse of the Pauper
        //Cards cost 1 more to buy from the market.
        int tmpMana = GameController.mana;
        if (tmpMana > GameController.mana)
        {
            GameController.mana--;
            tmpMana = GameController.mana;
        }
        else
        {
            tmpMana = GameController.mana;
        }
    }

    public void curse2(GameObject clickedCard)
    {
        //Curse of inane    Discard 1 card at the start of the turn.
        CardEffect cardEffect;
        cardEffect = GameObject.Find("CardEffect").GetComponent<CardEffect>();
        bool turnStart = true;
        if (turnStart == true)
        {
            cardEffect.discard(clickedCard);
            turnStart = false;
        }
    }

    public void curse3()
    {
        //Curse of Somnus   The first 3 mana added to your pool in a turn is not added.
        int effectCountDown = 3;
        int tmpMana = GameController.mana;
        int diff = GameController.mana - tmpMana;

        if (effectCountDown > 0)
        {
            if (GameController.mana > tmpMana && diff >= effectCountDown)
            {
                GameController.mana -= effectCountDown;
                effectCountDown = 0;


            }
            else if (GameController.mana > tmpMana && diff < effectCountDown)
            {
                GameController.mana -= diff;
                effectCountDown -= diff;
            }
        }
    }

    public void curse4()
    {
        //Curse of Malum    The player cannot look at cards in their deck.
        //turn the bool var for look at top cards to false
    }

    public void curse5()
    {
        //Curse of Plaga    You may only buy a maximum of 1 card this round
        bool accessToMarket = true;
        //after buying a card
        if (accessToMarket == true)
        {
            accessToMarket = false;
        }
    }

    public void curse6()
    {
        //Curse of the Magician.    You can't play more than 9 cards
        int cardCount = 0;
        //when play card, cardCount++
        if (cardCount > 9)
        {
            //end turn
        }
    }

    //methods above are curses
    //methods below are quests

    public void quest1()
    {
        //Gorena, Goddess of Power  
        //The quest is completed if you have 20 or more mana during your turn.  
        //Put 2 cards from the market into your discard.

        if (GameController.mana > 20)
        {
            GameController.quest1done = true;
            GameController.numberOfQuestCompleted++;
        }
    }

    public void quest2()
    {
        //Vorcona, God of Craft 
        //The Quest is completed when you play your 5th item of the game 
        //Search your deck for a card and put it into your hand.
        int itemPlaced = 0;
        if (itemPlaced == 5)
        {
            GameController.quest2done = true;
            GameController.numberOfQuestCompleted++;
        }

    }

    public void quest3()
    {
        //Niru, Goddess of Magic
        //The Quest is completed when you draw 5 cards before your discard phase in one turn
        //Draw 5 extra cards at then end of this turn.
        int cardDrawed = 0;
        //if a card is drawed, cardDrawed++
        //value of this variable goes to 0 at each end of turns
        if (cardDrawed == 5)
        {
            GameController.quest3done = true;
            GameController.numberOfQuestCompleted++;
        }

    }

    public void quest4()
    {
        //Sentaal, God of Life
        //The Quest is completed when you play your 7th non-wizard creature of the game.
        // Put 2 target creature cards from your discard pile in your hand.


    }

    public void quest5()
    {
        //Igej, God of Destruction
        //The Quest is completed when you have discarded your 3rd card of the game, 
        //(this does not include cards discarded during the discard phase or cards discarded due to curse effects)
        //You only receive 2 curses next round instead of 3.
        int cardDiscarded = 0;
        //if a card is drawed, cardDrawed++
        //value of this variable goes to 0 at each end of turns
        if (cardDiscarded == 5)
        {
            GameController.quest5done = true;
            GameController.numberOfQuestCompleted++;
        }
    }
}

