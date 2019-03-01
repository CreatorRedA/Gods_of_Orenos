using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AegisOfOrenos : Card, IPointerClickHandler
{

    public AegisOfOrenos()
    {
        this.manaCost = 2;
        cardType = "Item";
    }

    protected override void onPlay()
    {
        manaAdd = 1;
        if (!playOnceOnly)
        {
            gameController.addMana(manaAdd);
            playOnceOnly = true;
            GameController.ItemInUse.Add(this.gameObject);
            GameController.Hand.Remove(this.gameObject);
        }
    }
    public override void onDestroyItem()
    {
        discardRandomCards(2);
        gameController.drawToHand(3);
    }
}
