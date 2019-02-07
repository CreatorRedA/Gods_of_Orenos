using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class DeckControl : MonoBehaviour
{
    public GameObject card;
    List<GameObject> allCards;

    void Start()
    {
        allCards = new List<GameObject>();
        int numberOfCardsInDeck = int.Parse(TuneVariables.startingDeckSize);
        for(int i = 0; i<numberOfCardsInDeck; i++)
        {
            allCards.Add(card);
            Instantiate(card);
            card.transform.parent = this.transform;
            card.transform.Translate(0, 0, -.2f);
        }
    }
    void Update()
    {
        drawCard();
    }
    void drawCard()
    {
        GameObject topCard = allCards.FirstOrDefault();

        if (topCard.GetComponent<CardControl>().isDragged())
        {
            allCards.Remove(topCard);
        }
    }

}
