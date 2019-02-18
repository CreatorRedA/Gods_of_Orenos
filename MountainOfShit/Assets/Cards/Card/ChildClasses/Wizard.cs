using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Card
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
            gameController.addOneMana(manaAdd);
            playOnceOnly = true;
        }
    }

}
