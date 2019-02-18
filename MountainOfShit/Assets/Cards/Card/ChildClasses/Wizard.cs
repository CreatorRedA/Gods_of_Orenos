using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wizard : Card, IPointerClickHandler
{

    public Wizard()
    {
        this.playOnceOnly = false;
        this.alreadyPurchased = true;
    }
    protected override void onPlay()
    {
        manaAdd = 1;
        if (!playOnceOnly)
        {
            gameController.addMana(manaAdd);
            playOnceOnly = true;
            this.transform.SetParent(discard);
        }
    }

}
