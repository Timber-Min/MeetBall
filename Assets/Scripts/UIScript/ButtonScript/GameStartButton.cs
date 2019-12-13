using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

public class GameStartButton : AbstractUIHandler
{
    void Start()
    {
        getMenuPanel().SendMessage("pause");
        gameObject.GetComponent<Button>().onClick.AddListener(gameStart);
    }

    public void gameStart()
    {
        print("Game Start");
        isStarted = true;

        hide();
        GameObject.Find("ResetStage").SendMessage("hide");
        GameObject.Find("EscapeToLevel").SendMessage("hide");
        GameObject.Find("ItemPanel").SendMessage("hide");
        GameObject.Find("Timer").SendMessage("reset");
        Destroy(GameObject.Find("StageName"));

        getMenuPanel().SendMessage("resume");
        GameObject.Find("ForceManagerBtn").SendMessage("show");
        GameObject.Find("TimeScaleSlider").SendMessage("show");
    }

}
