using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonAction : MonoBehaviour
{
    public GameObject body;
    public Rigidbody2D plate;
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            // if (inside(Input.mousePosition))
            MovePlate();
            // else Debug.Log("NO");
    }
    /*bool inside(Vector3 vec)
    {
        var renderer = body.GetComponent<Renderer>();
        float width = renderer.bounds.size.x;
        float height = renderer.bounds.size.y;
        float cenx = renderer.transform.position.x;
        float ceny = renderer.transform.position.y;
        if (vec.x > cenx - width / 2 && vec.x < cenx + width / 2 && vec.y > ceny - height / 2 && vec.y < ceny + height / 2)
            return true;
        return false;
    }
    */
    void MovePlate()
    {
        plate.AddForce(Vector2.left*100000000);
    }
}
