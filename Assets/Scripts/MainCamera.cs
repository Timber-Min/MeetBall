using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

// 카메라 위치/크기 조정
// 게임 시작
public class MainCamera : MonoBehaviour
{
    private GameObject PanelControl;
    public Camera myCamera;
    private Transform myTransform;
    public Button startBtn, escapeMenuBtn;
    public SliderHandler slider;
    private GameObject forceMan;
    private GameObject timer;
    private int cnt = 0;

    private float interval = 20;
    void Start()
    {
        myTransform = gameObject.transform;
        forceMan = GameObject.Find("ForceManager");
        slider = GameObject.Find("Slider").GetComponent<SliderHandler>();
        startBtn = GameObject.Find("GameStart").GetComponent<Button>();
        escapeMenuBtn = GameObject.Find("EscapeToMenu").GetComponent<Button>();
        PanelControl = GameObject.Find("Panel");
        timer = GameObject.Find("Timer");
        getMenuPanel().SendMessage("pause");
        startBtn.onClick.AddListener(gameStart);
    }

    void Update()
    {
        float targetY = 0, startY = (float)-1.51;
        float targetSize = 7, startSize = 9;
        float Yinterval, SizeInterval;
        Yinterval = (targetY - startY) / interval;
        SizeInterval = (targetSize - startSize) / interval;
        if (isStarted) // start 버튼이 눌렸을 경우
        {
            if (cnt < interval) // 카메라가 완전히 커지지 않았다면 위치/크기 조정
            {
                Vector3 newPos = new Vector3(0, startY + Yinterval * cnt, -10);
                myTransform.position = newPos;
                myCamera.orthographicSize = startSize + SizeInterval * cnt;
                cnt++;
            }
        }
    }

    public void gameStart()
    {
        startBtn.SendMessage("hide");
        escapeMenuBtn.SendMessage("hide");
        print("Game Start");
        isStarted = true;
        getMenuPanel().SendMessage("resume");
        PanelControl.SendMessage("hide");
        forceMan.SendMessage("show");
        slider.SendMessage("show");
        timer.SendMessage("reset");
    }
}
