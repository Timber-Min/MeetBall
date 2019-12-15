using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNumberCheck : AbstractScoreChecker
{
    public override bool check(float _f)
    {
        try
        {
            return GameObject.Find("ItemImage").GetComponent<DragHandler>().getTotalObjectCnt() <= (int)_f;
        }
        catch(System.NullReferenceException)
        {
            return true;
        }
    }
}
