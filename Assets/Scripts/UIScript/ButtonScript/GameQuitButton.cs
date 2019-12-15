using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameQuitButton : AbstractUIHandler
{
    // 게임 종료 버튼
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(GameQuitScript.Quit);
    }
}
