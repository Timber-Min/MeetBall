using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageProcessor;

public class BackToPrevStageButton : SceneControllerForBtn
{
    protected override void RequestScene()
    {
        try
        {
            if(prevLevel>0) sceneName = prevLevel.ToString() + "-" + prevStage.ToString();
            else
            {
                sceneName = "GameIntroScene";
            }
        }
        catch (MissingReferenceException)
        {
            sceneName = "GameIntroScene";
        }
        SwitchScene(sceneName);
    }
}
