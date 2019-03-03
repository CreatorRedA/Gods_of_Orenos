using System;
public class ManaVial: Card
{
    public ManaVial()
    {
        this.cardType = "Item";
        this.manaCost = 2;
        playOnceOnly = false;
    }

    protected override void onPlay()
    {
        if (!playOnceOnly)
        {
            gameController.addMana(1);
            playOnceOnly = true;
        }
        GameController.ItemInUse.Add(this.gameObject);
        GameController.Hand.Remove(this.gameObject);
    }
    public override void onDestroyItem()
    {
        gameController.addMana(2);
    }


}
