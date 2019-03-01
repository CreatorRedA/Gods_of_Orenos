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
                discardRandomCards(2);
                gameController.drawToHand(3);
                playOnceOnly = true;
                this.transform.SetParent(discard);
            }
        }
    }
}
