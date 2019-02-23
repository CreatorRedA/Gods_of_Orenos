using System;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace Application
{
    public class GreatDryad : Card, IPointerClickHandler
    {
        CardEffect cardEffect;
        public void OnMouseDown()
        {
            GameController.clickedCard = gameController.greatDryad;
        }

        public GreatDryad()
        {
            this.manaCost = 5;
            this.playOnceOnly = false;
            this.manaAdd = 3;
        }
        protected override void onPlay()
        {
            if (!playOnceOnly)
            {
                cardEffect.discard(clickedCard);
                GameController.manaNextTurn += clickedCard.GetComponent<Card>().manaCost;

            }
        }
    }
}
