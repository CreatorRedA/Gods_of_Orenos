using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawButton : MonoBehaviour
{
    GameObject CardPrefab;
    Vector2 CardPos;
    // Start is called before the first frame update
    void Start()
    {
        CardPos = new Vector2(200, -100);
    }

    private void OnMouseDown()
    {
        Instantiate(CardPrefab, CardPos, Quaternion.identity, GameObject.FindGameObjectWithTag("Hand").transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
