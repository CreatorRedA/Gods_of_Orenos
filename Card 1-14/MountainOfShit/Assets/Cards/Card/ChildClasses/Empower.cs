using System;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace Application
{
    public class Empower : Card, IPointerClickHandler
    {
        public void OnMouseDown()
        {
            GameController.clickedCard = gameController.empower;
        }

        public Empower()
        {
            this.manaCost = 5;
            this.playOnceOnly = false;
        }
        protected override void onPlay()
        {
            if (!playOnceOnly)
            {
                int i = GameController.DiscardPile.Count/2;
                gameController.drawToHand(i);
                playOnceOnly = true;
            }
        }
    }
}
