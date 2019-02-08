using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class Card : ScriptableObject
{
    public string CardTitle;
    public string description;
    public string cardType;

    public Sprite picture;

    public int ManaCost;
    public int ManaGain;
    public int Draw;
    public int Discard;


    public void LookTopCards()
    {

    }

    public void addItem()
    {

    }


}
   