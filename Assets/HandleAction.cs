using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAction
{
    private Vector3 pos;
    private Vector3 mouseOrigin;
    private GameObject me;
    private GameObject origin;
    private bool isVisible = false;
    public HandleAction(Vector2 _pos)
    {
        pos = _pos;
        origin = GameObject.Find("Handle");
        me = create();
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

    // private float getAngle()
    // {
    //     Vector3 newMouse;
    //     float angle;

    //     newMouse = Input.mousePosition - pos;
    //     angle = Vector3.Angle(newMouse, mouseOrigin);
    //     return angle;
    // }

    // private void OnMouseDown()
    // {
    //     mouseOrigin = Input.mousePosition - pos;
    //     Debug.Log(mouseOrigin);
    // }

    // private void OnMouseDrag()
    // {
    //     float angle = getAngle();
    //     me.transform.Rotate(0.0f, 0.0f, angle, Space.Self);
    // }
}
