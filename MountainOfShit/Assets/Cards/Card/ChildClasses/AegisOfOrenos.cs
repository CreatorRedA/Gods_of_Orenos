using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AegisOfOrenos : Card, IPointerClickHandler
{

    public AegisOfOrenos()
    {
        this.manaCost = 2;
    }

    protected override void onPlay()
    {
        manaAdd = 1;
        if (!playOnceOnly)
        {
            gameController.addMana(manaAdd);
            playOnceOnly = true;
        }
    }
}
