using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleUnmodifiedCheck : AbstractScoreChecker
{
    public override bool check(float _f)
    {
        return !GameObject.Find("TimeScaleSlider").GetComponent<SliderHandler>().everModifiedOnce();
    }
}
