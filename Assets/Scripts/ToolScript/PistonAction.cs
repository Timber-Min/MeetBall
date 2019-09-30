using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonAction : MonoBehaviour
{
    public GameObject body;
    public Rigidbody2D plate;
    public Rigidbody2D temp;
    void FixedUpdate()
    {
        
        if (Input.GetMouseButtonDown(0))
            if (Inside(Input.mousePosition))
            MovePlate();
            // else Debug.Log("NO");
    }

    private bool Inside(Vector3 vec)
    {
        Renderer renderer = body.GetComponent<Renderer>();
        float width = renderer.bounds.size.x;
        float height = renderer.bounds.size.y;
        float cenx = renderer.transform.position.x;
        float ceny = renderer.transform.position.y;
        return vec.x > cenx - (width / 2) && vec.x < cenx + (width / 2) && vec.y > ceny - (height / 2) && vec.y < ceny + (height / 2)
            ? true
            : false;
    }

    private void MovePlate()
    {
        plate.AddForce(Vector2.left*100000000);
    }
}
