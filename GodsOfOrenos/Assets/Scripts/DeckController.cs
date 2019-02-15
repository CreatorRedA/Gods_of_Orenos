using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DeckController : MonoBehaviour
{
    public GameObject gameController;
    MonoBehaviour gameControllerScript;
    GameObject cardToDrag;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameControl");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
