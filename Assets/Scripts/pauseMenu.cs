﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform myTransform;
    public GameObject me;
    void Start()
    {
        myTransform = me.transform;
        hide();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Resume"))
        {
            Debug.Log("asdfasdfasdf");
            hide();
            Pause.isPaused = false;
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
