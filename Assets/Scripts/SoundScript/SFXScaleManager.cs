using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXScaleManager : MonoBehaviour
{
    private Slider SFXScaleGauge;

    void Start()
    {
        SFXScaleGauge = gameObject.GetComponent<Slider>();
        SFXScaleGauge.value=SoundManager.SFXscale;
        SFXScaleGauge.onValueChanged.AddListener(SFXScaleSet);
    }

    void SFXScaleSet(float _value)
    {
        SoundManager.SFXscale = (int)_value;
    }
}
