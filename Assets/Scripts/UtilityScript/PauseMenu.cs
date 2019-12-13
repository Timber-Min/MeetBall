using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageProcessor;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        hide();
    }

    void Update()
    {
        if (Input.GetButtonDown("Resume"))
        {
            getMenuPanel().SendMessage("triggerPause");
            hide();
        }
    }

    public void hide() => gameObject.transform.localScale = new Vector3(0, 1, 1);

    public void show() => gameObject.transform.localScale = new Vector3(1, 1, 1);
}
