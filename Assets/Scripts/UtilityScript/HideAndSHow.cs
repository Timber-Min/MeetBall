using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HideAndShow
{
    static void hide(GameObject _g)
    {
        _g.GetComponent<Transform>().localScale=new Vector3(0, 0, 0);
    }

    static void show(GameObject _g)
    {
        _g.GetComponent<Transform>().localScale=new Vector3(1, 1, 1);
    }
}
