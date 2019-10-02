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
        float dist = Mathf.Abs(Vector2.Distance(body.GetComponent<Renderer>().transform.position, plate.GetComponent<Renderer>().transform.position)) / 32.0f;
        if (Input.GetMouseButtonDown(0))
            if (isInside(Input.mousePosition) && dist < 0.02f && plate.velocity.x <= 0)
                movePlate();
        if (dist > 0.05f)
            undoPlate();
    }

    private bool isInside(Vector3 vec)
    {
        vec = new Vector2(vec.x / Screen.width, vec.y / Screen.height);
        Renderer renderer = body.GetComponent<Renderer>();
        float width = renderer.bounds.size.x / 32.0f;
        float height = renderer.bounds.size.y / 18.0f;
        float cenx = renderer.transform.position.x / 32.0f;
        float ceny = renderer.transform.position.y / 18.0f;
        cenx += 0.5f;
        ceny += 0.5f;
        return vec.x > cenx - (width / 2) && vec.x < cenx + (width / 2) && vec.y > ceny - (height / 2) && vec.y < ceny + (height / 2)
            ? true
            : false;
    }

    private void movePlate()
    {
        plate.AddForce(Vector2.left * 100000000);
    }

    private void undoPlate()
    {
        plate.AddForce(Vector2.right * 100000000);
    }
}
