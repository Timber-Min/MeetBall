using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAction
{
    private Vector3 pos;
    private Vector3 mouseOrigin;
    private GameObject me;
    private GameObject origin;
    private GameObject parent;
    private bool isVisible = false;
    public HandleAction(Vector2 _pos, GameObject _parent)
    {
        pos = _pos;
        parent = _parent;
        origin = GameObject.Find("Handle");
        me = create();
        me.transform.parent = parent.transform;
    }

    private GameObject create()
    {
        GameObject me;
        me = MonoBehaviour.Instantiate(origin, pos, Quaternion.identity);
        return me;
    }

    public void toggleShow()
    {
        if (isVisible) me.SendMessage("hide");
        else me.SendMessage("show");
        isVisible = !isVisible;
    }

    public void selfDestruct()
    {
        Object.Destroy(me);
    }
}
