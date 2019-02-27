using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChronoLocket : Card, IPointerClickHandler
{
    CardEffect cardEffect;
    int numberOfCardsToDiscard;
    bool drawCardNow;

    void start()
    {
        cardEffect = GameObject.Find("CardEffect").GetComponent<CardEffect>();
        numberOfCardsToDiscard = 2;
        drawCardNow = false;
    }

    public ChronoLocket()
    {
        this.manaCost = 5;
    }

    public void OnMouseDown()
    {
        GameController.clickedCard = gameController.aegisOfOrenos;
    }

    protected override void onPlay()
    {
        manaAdd = 0;
        if (!playOnceOnly)
        {
            gameController.addMana(manaAdd);
            playOnceOnly = true;
        }
    }

    private void OnDestroy()
    {
        GameController.clickedCard = null;
        if (numberOfCardsToDiscard > 0)
        {
            cardEffect.discard(GameController.clickedCard);
            numberOfCardsToDiscard -= 1;
        }
        else
        {
            drawCardNow = true;
        }
        
        if(drawCardNow == true)
        {
            gameController.drawToHand(3);
        }
    }
}
