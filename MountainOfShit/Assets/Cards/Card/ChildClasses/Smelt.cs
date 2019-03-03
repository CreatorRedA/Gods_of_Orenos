using System;
public class Smelt : Card
{
    public Smelt(){
        this.manaCost = 3;
        this.playOnceOnly = false;
        this.alreadyPurchased = false;
    }

    protected override void onPlay()
    {
        if (!playOnceOnly)
        {
            gameController.drawToHand(1);
            discardRandomCards(1);
            playOnceOnly = true;
        }
    }
}
