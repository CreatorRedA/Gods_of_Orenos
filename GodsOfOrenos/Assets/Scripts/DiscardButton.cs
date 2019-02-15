using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardButton : MonoBehaviour
{

    public void click()
    {
        GameController.Discard();
    }
}
