using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

public class SliderHandler : AbstractUIHandler
{
    void Start()
    {
        hide();
        gameObject.GetComponent<Slider>().onValueChanged.AddListener(timeScaleSet);
    }

    void timeScaleSet(float _value)
    {
        if (!isStarted || isCleared || isPaused) return;
        Time.timeScale = (float)System.Math.Pow(4, _value);
    }
}
