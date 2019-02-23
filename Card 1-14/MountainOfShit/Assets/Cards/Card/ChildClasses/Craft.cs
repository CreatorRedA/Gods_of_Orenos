using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Application
{
    public class Craft : Card, IPointerClickHandler
    {
        private List<GameObject> itemsInMarket;
        public void OnMouseDown()
        {
            GameController.clickedCard = gameController.craft;
        }

        int numberOfItemToDestroy = 2;
        public Craft()
        {
            this.manaCost = 6;
            this.playOnceOnly = false;
        }
        protected override void onPlay()
        {
            if (!playOnceOnly)
            {
                itemsInMarket = new List<GameObject>();
                playOnceOnly = true;
                for (int i = 0; i < GameController.MarketCards.Count; i++)
                {
                    if (GameController.MarketCards[i].GetComponent<Card>().cardType == "item")
                    {
                        itemsInMarket.Add(GameController.MarketCards[i]);
                    }
                    else
                    {

                    }
                }

                GameController.Hand.Add(itemsInMarket[Random.Range(0, itemsInMarket.Count)]);
                Instantiate(GameController.Hand[GameController.Hand.Count - 1], new Vector2(0,0), Quaternion.identity,
                    GameObject.FindGameObjectWithTag("hand").transform);
                itemsInMarket.Clear();
            }


        }
    }
}
