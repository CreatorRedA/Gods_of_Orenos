using UnityEngine;
using System.Collections;

public class QuestCard : MonoBehaviour
{
    public bool questComplete;
    public GameController gameController;
    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    public void Update()
    {
        if (gameController.questGorenaDone)
        {
            gameObject.transform.SetParent(gameController.questPanel.transform);
            Debug.Log("gotit");
        }
    }
}
