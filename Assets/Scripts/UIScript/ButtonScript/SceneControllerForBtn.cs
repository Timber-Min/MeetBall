using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 버튼이 눌리면 미리 지정된 Scene으로 변경.
public class SceneControllerForBtn : SceneController
{
    public string sceneName;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(RequestScene);
    }

    protected virtual void RequestScene()
    {
        SwitchScene(sceneName);
    }
}
