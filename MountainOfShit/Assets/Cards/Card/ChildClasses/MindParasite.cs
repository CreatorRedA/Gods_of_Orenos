using System;
public class MindParasite: Card
    {
    public MindParasite()
    {
        manaCost = 3;
    }
    protected override void onPlay()
    {
        if (!playOnceOnly)
        {
            gameController.drawToHand(1);
            playOnceOnly = true;
        }
    }
}
