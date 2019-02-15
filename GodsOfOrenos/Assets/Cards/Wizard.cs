using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    CardEffect cardEffect;
    bool exe;
    public string type;
    public int cost;
    public int manaAdded;

    public Transform cardsInPlayPanel;
    // Start is called before the first frame update
    void Start()
    {
        cardsInPlayPanel = GameObject.FindGameObjectWithTag("CardsInPlay").transform;
        cardEffect = GameObject.Find("CardEffect").GetComponent<CardEffect>();
        manaAdded = 2;
        exe = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.parent == cardsInPlayPanel && exe == true)
        {
            cardEffect.add_mana(manaAdded);
            Debug.Log("card played");
            exe = false;
        }
    }
}
