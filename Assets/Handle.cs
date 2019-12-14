using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : AbstractUIHandler
{
    private bool isVisible = true;
    private Vector3 mouseOrigin;
    private Vector3 myPos;
    void Start()
    {
        show();
        myPos = transform.position;
    }

    private float getAngle()
    {
        Vector3 newMouse;
        float angle;

        newMouse = Input.mousePosition - myPos;
        angle = Vector3.Angle(newMouse, mouseOrigin);
        return angle;
    }
    private void OnMouseDown()
    {
        Debug.Log("down");
        mouseOrigin = Input.mousePosition - myPos;
    }

    private void OnMouseDrag()
    {
        float angle = getAngle();
        transform.Rotate(0.0f, 0.0f, angle, Space.Self);
    }


}
