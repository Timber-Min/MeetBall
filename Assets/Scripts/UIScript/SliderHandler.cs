using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SliderHandler : MonoBehaviour
{
    private Slider timeScaleGauge;

    void Start()
    {
        timeScaleGauge = gameObject.GetComponent<Slider>();
        timeScaleGauge.onValueChanged.AddListener(timeScaleSet);
    }

    void timeScaleSet(float _value)
    {
        Utility.LogWithTime("Slider value changed: " + _value);
        if (Pause.isPausing()) return;
        Time.timeScale = (float)System.Math.Pow(4,_value);
    }
}
