using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawButton : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject cardsInPlayPanel;
    public void click()
    {
        GameController.DrawCard();
    }

}

