using System;
using UnityEngine.EventSystems;
    public class AngelicIntervention: Card, IPointerClickHandler
    {
        public AngelicIntervention()
        {
            this.manaCost = 8;
            this.playOnceOnly = false;
        }
        protected override void onPlay()
        {
            if (!playOnceOnly)
            {
                destroyItem(2);
                gameController.drawToHand(2);
                playOnceOnly = true;
                this.transform.SetParent(discard);
            }
        }
    }
