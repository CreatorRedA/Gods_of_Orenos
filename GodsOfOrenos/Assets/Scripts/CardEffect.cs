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

    }

    public void discard(GameObject clickedCard)
    {

    }

    public void move_card_from_deck_to_discard(GameObject clickedCard)
    {

    }

    public void move_card_from_discard_to_hand(GameObject clickedCard)
    {

    }

    //four methods below work together
    public void pick_from_nextHand(int x,GameObject clickedCard)
    {

    }

    //one of three methods below happen after pick_from_nextHand happen
    public void then_go_back_in_certain_order(GameObject clickedCard)
    {

    }

    public void then_go_back_in_random_order(GameObject clickedCard)
    {

    }

    public void then_go_to_discard()
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
