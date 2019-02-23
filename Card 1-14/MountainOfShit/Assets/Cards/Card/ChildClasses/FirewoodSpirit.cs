using System;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace Application
{
    public class FirewoodSpirit : Card, IPointerClickHandler
    {
        CardEffect cardEffect;
        public void OnMouseDown()
        {
            GameController.clickedCard = gameController.firewoodSpirt;
        }

        public FirewoodSpirit()
        {
            this.manaCost = 7;
            this.playOnceOnly = false;
            this.manaAdd = 3;
        }
        protected override void onPlay()
        {
            if (!playOnceOnly)
            {
                gameController.addMana(manaAdd);
                if (clickedCard.GetComponent<Card>().cardType == "item")
                {
                    cardEffect.discard(clickedCard);
                    int i = 1 + (clickedCard.GetComponent<Card>().manaCost) / 2;
                    gameController.drawToHand(i);

                }
            }
        }
    }
}
