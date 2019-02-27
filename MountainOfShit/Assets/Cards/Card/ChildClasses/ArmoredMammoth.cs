using System;
using UnityEngine.EventSystems;

namespace Application
{
    public class ArmoredMammoth: Card, IPointerClickHandler
    {

        int numberOfItemToDestroy = 3;
        public ArmoredMammoth()
        {
            this.manaCost = 7;
            this.playOnceOnly = false;
            this.manaAdd = 3;
        }
        protected override void onPlay()
        {
            if (!playOnceOnly)
            {
                gameController.canDestroyItem = true;
                playOnceOnly = true;
            }

            if (numberOfItemToDestroy > 0)
            {
                gameController.drawToHand(1);
                numberOfItemToDestroy -= 1;
                GameController.mana += 1;
            }
        }
    }
}
