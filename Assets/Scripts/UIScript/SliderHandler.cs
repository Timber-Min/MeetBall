﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

public class SliderHandler : AbstractUIHandler
{
    private bool ModifiedOnce;

    void Start()
    {
        hide();
        ModifiedOnce = false;
        gameObject.GetComponent<Slider>().onValueChanged.AddListener(timeScaleSet);
    }

    void timeScaleSet(float _value)
    {
        ModifiedOnce = true;
        if (!isStarted || isCleared || isPaused) return;
        Time.timeScale = (float)System.Math.Pow(4, _value);
    }

    public bool everModifiedOnce()
    {
        return ModifiedOnce;
    }
}
