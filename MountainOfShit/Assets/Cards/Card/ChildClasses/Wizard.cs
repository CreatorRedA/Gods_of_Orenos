using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wizard : Card, IPointerClickHandler
{

    public Wizard()
    {
        this.cardType = "Creature";
        this.playOnceOnly = false;
        this.alreadyPurchased = true;
    }
    protected override void onPlay()
    {
        manaAdd = 2;
        if (!playOnceOnly)
        {
            gameController.addMana(manaAdd);
            playOnceOnly = true;
            this.transform.SetParent(discard);
        }
    }

}
