﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Mana = 0;
    public Card wizard;
    public GameObject CardPrefab;
    public List<GameObject> Hand;
    public List<GameObject> DrawDeck;
    public List<GameObject> DiscardDeck;
    public List<GameObject> MarketCard;
    Vector2 CardPos;



    CardEffects cardEffects;
    // Start is called before the first frame update
    void Start()
    {
        CardPrefab.GetComponent<CardScript>().card = wizard;
        cardEffects = GameObject.Find("CardEffects").GetComponent<CardEffects>();
        for (int x = 0; x<5; x++)
        {
            CardPos = new Vector2(x*200, -100);
            Hand.Add(Instantiate(CardPrefab, CardPos, Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform));
            Debug.Log(Hand.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(Mana);
        }
    }
}
