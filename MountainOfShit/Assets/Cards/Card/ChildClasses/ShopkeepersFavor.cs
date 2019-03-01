using System;

public class ShopkeepersFavor: Card
    {
    public ShopkeepersFavor()
    {
        this.manaCost = 5;
        cardType = "Item";
    }

    protected override void onPlay()
    {
        if (!playOnceOnly)
        {
            changeManaCost(-1);
            gameController.addMana(manaAdd);
            playOnceOnly = true;
            GameController.ItemInUse.Add(this.gameObject);
            GameController.Hand.Remove(this.gameObject);
        }
    }
    public override void onDestroyItem()
    {

    }
}

