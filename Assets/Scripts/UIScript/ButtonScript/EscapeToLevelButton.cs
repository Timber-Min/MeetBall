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
            print("asdfasdf");
        }
        else sceneName="L1";
        SwitchScene(sceneName);
    }

    public void hide() => gameObject.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
}
