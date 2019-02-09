using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllCard : MonoBehaviour
{
    GameController gameController;

    public GameObject aegisOfOrenos;
    public GameObject angelicIntervention;
    public GameObject aromoredMammoth;
    public GameObject bladeOfAeons;
    public GameObject chronoLocket;
    public GameObject comfortingFlame;
    public GameObject consumePower;
    public GameObject craft;
    public GameObject divine;
    public GameObject empower;
    public GameObject firewoodSpirt;
    public GameObject grandPurifier;
    public GameObject greatDryad;
    public GameObject hindranceCharm;
    public GameObject jetBlackFlower;
    public GameObject jeweledSerpent;
    public GameObject luckyElf;
    public GameObject manaLeech;
    public GameObject manaVial;
    public GameObject mindParasite;
    public GameObject search;
    public GameObject shopKeepsFavor;
    public GameObject spireOfPower;
    public GameObject spiritIdol;
    public GameObject warBeast;
    public GameObject warp;
    public GameObject wizard;
    public GameObject wormhole;

    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
