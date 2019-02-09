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

    //four methods below work together
    public void pick_from_nextHand(int look, int pick, GameObject clickedCard)
    {
        //do something to bring up value of look cards onto screen
        int picked = 0;
        List<GameObject> CardToLook = new List<GameObject>();
        
        for (int x = 0; x < look; x++)
        {
            int cardFromDraw = Random.Range(0, GameController.DrawDeck.Count);
            CardToLook[x] = GameController.NextHand[x];
            GameController.NextHand.RemoveAt(x);
            GameController.NextHand.Add(GameController.DrawDeck[cardFromDraw]);
            GameController.DrawDeck.RemoveAt(cardFromDraw);
        }


        if (picked < pick)
        {
            int cardNumber = GameController.NextHand.IndexOf(clickedCard);
            GameController.Hand.Add(GameController.NextHand[cardNumber]);
            GameController.NextHand.RemoveAt(cardNumber);
            picked++;
        }
        else
        {
            for (int x = 0; x < CardToLook.Count; x++)
            {
                //do one of three things below;
            }
        }
    }

    //one of three methods below happen after pick_from_nextHand happen
    public void then_go_back_in_certain_order(GameObject clickedCard)
    {

    }

    public void then_go_back_in_random_order(GameObject Card)
    {

    }

    public void then_go_to_discard(GameObject Card)
    {

    }
    //four methods above work together

    public void add_item_to_board(GameObject Card)
    {

    }

    public void destroy_item(GameObject Card)
    {

    }

    public void move_item_to_hand(GameObject Card)
    {

    }

    public void complete_quest(GameObject clickedQuest)
    {

    }

    public void get_card_from_market_to_hand(GameObject Card)
    {

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
