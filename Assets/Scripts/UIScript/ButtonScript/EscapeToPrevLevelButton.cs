using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageProcessor;

public class EscapeToPrevLevelButton : SceneControllerForBtn
{
    protected override void RequestScene()
    {
        if(prevLevel>0) {
            sceneName="L"+prevLevel.ToString();
        }
        else sceneName="L1";
        SwitchScene(sceneName);
    }
}
