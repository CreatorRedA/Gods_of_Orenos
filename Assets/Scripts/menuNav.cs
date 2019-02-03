using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuNav : MonoBehaviour
{
    public void goToGame()
    {
        SceneManager.LoadScene(1);
    }
    void Start()
    {

    }
}
