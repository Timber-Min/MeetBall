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
        myTransform = startBtn.GetComponent<Transform>();
    }
    public void hide() => myTransform.localScale = new Vector3(0, 0, 0);
}
