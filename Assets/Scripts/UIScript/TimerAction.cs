using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAction : AbstractUIHandler
{
    private Text timerText;
    private float time;

    void Start()
    {
        hide();
        timerText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;
        timerText.text = string.Format("{0:N2}", time);
    }

    void reset()
    {
        show();
        time=0;
        timerText = gameObject.GetComponent<Text>();
    }
}
