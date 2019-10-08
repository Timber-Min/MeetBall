using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    private Slider timeScaleGauge;

    void Start()
    {
        timeScaleGauge=gameObject.GetComponent<Slider>();
        timeScaleGauge.onValueChanged.AddListener(timeScaleSet);
    }

    void timeScaleSet(float _value)
    {
        if(Pause.isPausing()) return;
        Time.timeScale=_value;
    }
}
