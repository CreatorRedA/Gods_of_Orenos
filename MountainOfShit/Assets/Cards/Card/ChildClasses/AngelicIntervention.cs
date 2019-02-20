using System;
using UnityEngine.EventSystems;

namespace Application
{
    public class AngelicIntervention: Card, IPointerClickHandler
    {
        public AngelicIntervention()
        {
            this.manaCost = 9;
            this.playOnceOnly = false;
        }
        protected override void onPlay()
        {
            if (!playOnceOnly)
            {
                GameController.canDestroyItem = true;
                gameController.drawToHand(3);
                this.transform.SetParent(discard);
                playOnceOnly = true;
            }
        }
    }
}
