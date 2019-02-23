using System;
using UnityEngine.EventSystems;

namespace Application
{
    public class AngelicIntervention: Card, IPointerClickHandler
    {
        public void OnMouseDown()
        {
            GameController.clickedCard = gameController.angelicIntervention;
        }

        int numberOfItemToDestroy = 2;
        public AngelicIntervention()
        {
            this.manaCost = 8;
            this.playOnceOnly = false;
        }
        protected override void onPlay()
        {
            if (!playOnceOnly)
            {
                GameController.canDestroyItem = true;
                gameController.drawToHand(3);
                playOnceOnly = true;

                if (numberOfItemToDestroy > 0 && clickedCard.transform.parent == gameController.tabletop && clickedCard.GetComponent<Card>().cardType == "Item")
                {
                    gameController.destroyItem(GameController.clickedCard);
                    numberOfItemToDestroy -= 1;
                }
            }


        }
    }
}
