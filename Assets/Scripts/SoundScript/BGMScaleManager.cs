using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMScaleManager : MonoBehaviour
{
    private Slider BGMScaleGauge;

    void Start()
    {
        BGMScaleGauge = gameObject.GetComponent<Slider>();
        BGMScaleGauge.value = SoundManager.BGMscale;
        BGMScaleGauge.onValueChanged.AddListener(BGMScaleSet);
    }

    void BGMScaleSet(float _value)
    {
        SoundManager.BGMscale = (int)_value;
    }
}
