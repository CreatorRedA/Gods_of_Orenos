using System;
using UnityEngine.EventSystems;

namespace Application
{
    public class ArmoredMammoth: Card, IPointerClickHandler
    {
        public void OnMouseDown()
        {
            GameController.clickedCard = gameController.aromoredMammoth;
        }

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
                GameController.canDestroyItem = true;
                gameController.drawToHand(3);
                playOnceOnly = true;
            }

            if (numberOfItemToDestroy > 0 && clickedCard.transform.parent == gameController.tabletop && clickedCard.GetComponent<Card>().cardType == "Item")
            {
                gameController.destroyItem(GameController.clickedCard);
                numberOfItemToDestroy -= 1;
                GameController.mana += 1;
            }
        }
    }
}
