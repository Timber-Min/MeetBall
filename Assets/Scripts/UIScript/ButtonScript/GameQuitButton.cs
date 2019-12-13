using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameQuitButton : AbstractUIHandler
{
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(GameQuitScript.Quit);
    }
}
