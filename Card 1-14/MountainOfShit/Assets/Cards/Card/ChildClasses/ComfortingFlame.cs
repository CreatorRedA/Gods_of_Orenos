using System;
using UnityEngine.EventSystems;

namespace Application
{
    public class ComfortingFlame: Card, IPointerClickHandler
    {
        public void OnMouseDown()
        {
            GameController.clickedCard = gameController.comfortingFlame;
        }

        int numberOfCardsToDiscard = 2;
        public ComfortingFlame()
        {
            this.manaCost = 8;
            this.playOnceOnly = false;
        }
        protected override void onPlay()
        {
            if (!playOnceOnly)
            {
                gameController.drawToHand(3);
                playOnceOnly = true;

                if (numberOfCardsToDiscard > 0 && clickedCard.transform.parent == gameController.handPanel)
                {
                    int index = GameController.Hand.IndexOf(clickedCard);
                    GameController.DiscardPile.Add(GameController.Hand[index]);
                    GameController.Hand.RemoveAt(index);
                    gameController.destroyItem(GameController.clickedCard);
                    numberOfCardsToDiscard -= 1;
                }
            } 
        }
    }
}
