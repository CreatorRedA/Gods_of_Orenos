using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComfortingFlame : Card
{
    public ComfortingFlame()
    {
        this.cardType = "Spell";
        this.manaCost = 6;
        this.playOnceOnly = false;
        this.alreadyPurchased = false;
    }
    protected override void onPlay()
    {
        manaAdd = 5;
        if (!playOnceOnly)
        {
            gameController.drawToHand(3);
            discardRandomCards(2);
        }
    }
}
