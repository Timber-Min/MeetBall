using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private GameObject startBtn;
    private Button myButton;
    private Transform myTransform;

    void Start()
    {
        startBtn = GameObject.Find("GameStart");
        myButton = startBtn.GetComponent<Button>();
    }
    public void hide()
    {
        myTransform = startBtn.GetComponent<Transform>();
        myTransform.localScale = new Vector3(0, 0, 0);
    }
}
