using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Transform myTransform;
    private GameObject menuPanel;

    void Awake()
    {
        myTransform = gameObject.GetComponent<Transform>();
        menuPanel = GameObject.Find("MenuPanel");
        hide();
    }

    void Update()
    {
        if (Input.GetButtonDown("Resume"))
        {
            // Pause.triggerPause();  
            menuPanel.SendMessage("triggerPause");
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
