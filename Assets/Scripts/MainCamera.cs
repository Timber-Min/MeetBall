using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Pause;
    public GameObject MainCam;
    public Camera myCamera;
    public Transform myTransform;
    public Button startBtn;
    private static bool isGameStart = false;
    private int cnt = 0;

    private float interval = 20;
    void Start()
    {
        Pause = GameObject.Find("MenuPanel");
        Pause.SendMessage("pause");
        myTransform = MainCam.transform;

        startBtn.onClick.AddListener(gameStart);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStart)
        {
            float targetY = 0, startY = (float)-1.51;
            float targetSize = 7, startSize = 9;
            float Yinterval, SizeInterval;
            Yinterval = (targetY - startY) / interval;
            SizeInterval = (targetSize - startSize) / interval;
            if (cnt < interval)
            {
                Vector3 newPos = new Vector3(0, startY + Yinterval * cnt, -10);
                myTransform.position = newPos;
                // Debug.Log(myTransform.position[1]);
                myCamera.orthographicSize = startSize + SizeInterval * cnt;
                cnt++;
            }
            else
            {
                isGameStart = false;
                cnt = 0;
                Pause.SendMessage("resume");
            }
        }
    }

    public void gameStart()
    {
        startBtn.SendMessage("hide");
        Debug.Log("game start");
        isGameStart = true;
    }
}
