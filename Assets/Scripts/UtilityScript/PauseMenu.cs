using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Transform myTransform;

    void Awake()
    {
        myTransform = gameObject.GetComponent<Transform>();
        hide();
    }

    void Update()
    {
        if (Input.GetButtonDown("Resume"))
        {
            Pause.triggerPause();
            hide();
        }
    }

    public void display()
    {
        Vector3 newTransform = new Vector3(1, 1, 1);
        myTransform.localScale = newTransform;
    }

    public void hide()
    {
        Vector3 newTransform = new Vector3(0, 1, 1);
        myTransform.localScale = newTransform;
    }
}
