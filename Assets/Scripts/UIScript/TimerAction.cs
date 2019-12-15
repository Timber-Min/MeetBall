using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

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
        if (!isCleared)
        {
            timerText.text = string.Format("{0:N2}", time);
            time += Time.deltaTime;
        }
    }

    void reset()
    {
        show();
        time = 0;
        timerText = gameObject.GetComponent<Text>();
    }

    public float getTime()
    {
        return time;
    }
}
