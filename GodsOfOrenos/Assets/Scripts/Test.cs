using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public GameObject prefab;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = TuneVariables.numberCardsDrawn;
        for(int i = 0; i< int.Parse(TuneVariables.numberCardsDrawn); i++) {
            prefab.transform.Translate(2.0f, 0, 0);
            Instantiate(prefab);
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
