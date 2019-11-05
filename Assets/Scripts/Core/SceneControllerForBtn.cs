using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControllerForBtn : SceneController
{
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(RequestScene);
    }

    void RequestScene()
    {
        SwitchScene(sceneName);
    }
}
