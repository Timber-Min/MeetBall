using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNumberCheck : AbstractScoreChecker
{
    public override bool check(float _f)
    {
        return GameObject.Find("ItemImage").GetComponent<DragHandler>().getTotalObjectCnt() <= (int)_f;
    }
}
