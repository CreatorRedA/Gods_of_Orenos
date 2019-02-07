using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    
    public bool isFacingUp;
    public string type;
    public int cost;
    public string effect;
    public bool isBeingDragged;

    public bool isDragged()
    {
        return isBeingDragged;
    }

}
