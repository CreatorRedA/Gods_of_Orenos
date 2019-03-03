using System;
public class SpireOfPower : Card
{

    public SpireOfPower()
    {
        this.cardType = "Item";
        this.manaCost = 6;
        playOnceOnly = false;
    }

    protected override void onPlay()
    {
        manaAdd = 1;
        if (!playOnceOnly)
        {
            GameController.cardDrawed += 1;
            playOnceOnly = true;
        }
        GameController.ItemInUse.Add(this.gameObject);
        GameController.Hand.Remove(this.gameObject);
    }
    public override void onDestroyItem()
    {
        GameController.cardDrawed += -1;
        discardRandomCards(2);
        gameController.drawToHand(3);
    }
}
