using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Pause;
    public GameObject MainCam;
    public Camera myCamera;
    public Transform myTransform;
    private int interval;
    void Start()
    {
        Pause = GameObject.Find("MenuPanel");
        Pause.SendMessage("pause");
        myTransform = MainCam.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void gameStart()
    {
        float targetY = (float)-1.51, startY = 0;
        float targetSize = 7, startSize = 9;
        float Yinterval, SizeInterval;
        Yinterval = (targetY - startY) / interval;
        SizeInterval = (targetSize - startSize) / interval;
        for (int i = 0; i < interval; i++)
        {
            Vector3 newPos = new Vector3(0, startY + Yinterval * i, 0);
        }
    }
}
