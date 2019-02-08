using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardScript : MonoBehaviour
{
    CardEffects cardEffects;
    public Card card;

    public int ManaCost;
    public int ManaGain;
    public int Draw;
    public int Discard;
    public int LookTopCard;
    Transform oldParent;
    // Start is called before the first frame update
    void Start()
    {
        cardEffects = GameObject.Find("CardEffects").GetComponent<CardEffects>();
    }


    // Update is called once per frame
    void Update()
    {
        oldParent = this.transform.parent;
        if (this.transform.parent != oldParent)
        {
            cardEffects.addMana(ManaGain);
        }
    }
}
