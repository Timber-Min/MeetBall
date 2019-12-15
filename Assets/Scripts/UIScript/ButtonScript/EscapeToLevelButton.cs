using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageProcessor;

public class EscapeToLevelButton : SceneControllerForBtn
{
    // 해당 스테이지가 속한 레벨로 이동
    protected override void RequestScene()
    {
        if (currentLevel > 0)
        {
            sceneName = "L" + currentLevel.ToString();
        }
        else if (prevLevel > 0) sceneName = "L" + prevLevel.ToString();
        else sceneName = "GameIntroScene";
        SwitchScene(sceneName);
    }
}
