using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour
{
    GameController gameController;



    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public bool block_effect()
    {
        return false;
    }

    public void addMana(int x)
    {
        GameController.mana += x;
    }




}
