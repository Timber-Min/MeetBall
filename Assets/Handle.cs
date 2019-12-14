using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : AbstractUIHandler
{
    private bool isVisible = true;
    private Vector3 mouseOrigin;
    private Vector3 myPos;
    private bool isClick = false;
    void Start()
    {
        show();
        myPos = transform.position;
    }

    private float getAngle()
    {
        Vector3 newMouse;
        float angle;

        newMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - myPos;
        angle = Vector3.Angle(newMouse, mouseOrigin);
        return angle;
    }
    private void OnMouseDown()
    {
        Debug.Log("down");
        isClick = true;
        mouseOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition) - myPos;
    }

    private void OnMouseOver()
    {
        if (isClick)
        {
            float angle = getAngle();
            // Debug.Log("angle " + angle);
            transform.Rotate(0.0f, 0.0f, angle, Space.Self);
            // transform.rotation = new Vector3(0, 0, angle);
        }
    }

    private void OnMouseUp()
    {
        isClick = false;
        mouseOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition) - myPos;
    }

    void Update()
    {
        Vector2 direction;
        if (isClick)
        {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - myPos;
            transform.up = direction;
        }
    }


}
