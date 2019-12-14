using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

public class ResetStageButton : AbstractUIHandler
{
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(restartStage);
    }

    void restartStage()
    {
        getPausePanel().SendMessage("restart");
    }
}
