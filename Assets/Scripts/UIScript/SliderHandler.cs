using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

public class SliderHandler : AbstractUIHandler
{
    private Slider timeScaleGauge;

    void Start()
    {
        hide();
        timeScaleGauge = gameObject.GetComponent<Slider>();
        timeScaleGauge.onValueChanged.AddListener(timeScaleSet);
    }

    void timeScaleSet(float _value)
    {
        if (isPaused) return;
        Time.timeScale = (float)System.Math.Pow(4, _value);
    }
}
