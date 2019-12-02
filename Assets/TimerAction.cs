using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAction : AbstractUIHandler
{
    // Start is called before the first frame update
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
        timerText = gameObject.GetComponent<Text>();
    }
}
