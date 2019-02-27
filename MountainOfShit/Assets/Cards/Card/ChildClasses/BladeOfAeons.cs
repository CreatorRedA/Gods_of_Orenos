using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BladeOfAeons : Card, IPointerClickHandler
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

    public BladeOfAeons()
    {
        this.manaCost = 7;
    }

    public void OnMouseDown()
    {
        GameController.clickedCard = gameController.bladeOfAeons;
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

    
}
