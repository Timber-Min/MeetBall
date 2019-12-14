using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNumberCheck : AbstractScoreChecker
{
    public override bool check(float _f)
    {
        int n=GameObject.Find("ItemImage").GetComponent<DragHandler>().getObjectCnt();
        return n<=(int)_f;
    }
}
