using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceOnOffTimesCheck : AbstractScoreChecker
{
    public override bool check(float _f)
    {
        int n=GameObject.Find("ForceManagerBtn").GetComponent<ForceManagerBtn>().getToggledTimes();
        return n<=(int)_f;
    }
}
