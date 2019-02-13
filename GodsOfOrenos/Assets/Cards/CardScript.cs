using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public string type;
    public int cost;

    public GameObject cardsInPlayPanel;
    // Start is called before the first frame update
    void Start()
    {
        cardsInPlayPanel = GameObject.Find("Tabletop");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.parent == cardsInPlayPanel)
        {
            Debug.Log("Card Played!");
        }
    }
}
