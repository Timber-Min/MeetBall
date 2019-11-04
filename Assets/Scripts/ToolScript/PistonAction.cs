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
        if (dist > 0.03f)
            undoPlate();
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
