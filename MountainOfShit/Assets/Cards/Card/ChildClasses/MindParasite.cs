using System;
public class MindParasite: Card
    {
    public MindParasite()
    {
        manaCost = 3;
    }
    protected override void onPlay()
    {
        gameController.drawToHand(1);
    }
}
