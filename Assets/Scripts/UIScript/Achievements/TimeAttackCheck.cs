using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttackCheck : AbstractScoreChecker
{
    public override bool check(float _f)
    {
        float t=GameObject.Find("Timer").GetComponent<TimerAction>().getTime();
        return t<=_f;
    }
}
