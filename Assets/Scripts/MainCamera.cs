using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class MainCamera : MonoBehaviour
{
    private GameObject Pause;
    public GameObject MainCam;
    public GameObject PanelControl;
    public Camera myCamera;
    public Transform myTransform;
    public Button startBtn;
    private GameObject forceMan;
    private static bool isGameStart = false;
    private int cnt = 0;

    private float interval = 20;
    void Start()
    {
        forceMan = GameObject.Find("ForceManager");
        Pause = GameObject.Find("MenuPanel");
        Pause.SendMessage("pause");
        myTransform = MainCam.transform;
        startBtn = GameObject.Find("GameStart").GetComponent<Button>();
        PanelControl = GameObject.Find("Panel");
        startBtn.onClick.AddListener(gameStart);
    }

    void Update()
    {
        float targetY = 0, startY = (float)-1.51;
        float targetSize = 7, startSize = 9;
        float Yinterval, SizeInterval;
        Yinterval = (targetY - startY) / interval;
        SizeInterval = (targetSize - startSize) / interval;
        if (isGameStart)
        {
            if (cnt < interval)
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
        Debug.Log("game start");
        isGameStart = true;
        Pause.SendMessage("resume");
        PanelControl.SendMessage("hide");
        forceMan.SendMessage("show");
    }

    public static bool isGameStarted()
    {
        return isGameStart;
    }
}
