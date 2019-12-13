using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageProcessor;

public class EscapeToLevelButton : SceneControllerForBtn
{
    protected override void RequestScene()
    {
        if(currentLevel>0) {
            sceneName="L"+currentLevel.ToString();
        }
        else sceneName="L1";
        SwitchScene(sceneName);
    }
}
