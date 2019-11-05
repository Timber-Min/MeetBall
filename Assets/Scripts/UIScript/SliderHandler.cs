using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : AbstractUIHandler
{
    private Slider timeScaleGauge;

    void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        timeScaleGauge = gameObject.GetComponent<Slider>();
        timeScaleGauge.onValueChanged.AddListener(timeScaleSet);
    }

    void timeScaleSet(float _value)
    {
        print("Slider value changed: " + _value);
        if (Pause.isPausing()) return;
        Time.timeScale = (float)System.Math.Pow(4, _value);
    }

    public void show()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1); // restores the size
    }
}
