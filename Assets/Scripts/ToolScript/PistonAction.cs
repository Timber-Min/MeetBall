using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonAction : MonoBehaviour
{
    public GameObject body;
    public Rigidbody2D plate;

    void FixedUpdate()
    {
        float dist = Mathf.Abs(
            Vector2.Distance(body.GetComponent<Renderer>().transform.position,
            plate.GetComponent<Renderer>().transform.position)) / 32;
        if (Input.GetMouseButtonDown(0)) // when clicked
            if (isInside(Utility.asVector2(Input.mousePosition)) && dist < 0.02f && Utility.floatEqual(plate.velocity.x, 0.0f) && Utility.floatEqual(plate.velocity.y, 0.0f))
            {
                Debug.Log("asdfasgdsd");
                movePlate();
            }

        if (dist > 0.03f)
            undoPlate();
    }

    private bool isInside(Vector2 _vec)
    {
        _vec.x /= Screen.width; _vec.y /= Screen.height;
        Renderer renderer = body.GetComponent<Renderer>();
        float width = renderer.bounds.size.x / 32.0f;
        float height = renderer.bounds.size.y / 18.0f;
        float cenx = renderer.transform.position.x / 32.0f + 0.5f;
        float ceny = renderer.transform.position.y / 18.0f + 0.5f;
        return (_vec.x > cenx - (width / 2)
            && _vec.x < cenx + (width / 2)
            && _vec.y > ceny - (height / 2)
            && _vec.y < ceny + (height / 2))
            ? true : false;
    }

    private void movePlate()
    {
        float rot = plate.transform.rotation.eulerAngles.z * Mathf.PI / 180;
        Vector2 dir = new Vector2(-Mathf.Cos(rot), -Mathf.Sin(rot));
        plate.AddForce(dir * (int)3e8);
    }

    private void undoPlate()
    {
        float rot = plate.transform.rotation.eulerAngles.z * Mathf.PI / 180;
        Vector2 dir = new Vector2(-Mathf.Cos(rot), -Mathf.Sin(rot));
        plate.AddForce(-dir * (int)3e8);
    }
}
