using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalForce : AbstractForceCalculator
{
    public GameObject[] objects;
    public static Vector2[] BallsNetGravitationalForce;

    void Start()
    {
        BallsNetGravitationalForce = new Vector2[objects.Length];
    }

    void FixedUpdate()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            Rigidbody2D rb = objects[i].GetComponent<Rigidbody2D>();
            Vector2 force = Vector2.zero;

            foreach (GameObject obj in objects)
            {
                if (obj.Equals(objects[i])) continue;
                Rigidbody2D orb = obj.GetComponent<Rigidbody2D>();
                Vector2 offset = rb.transform.position - obj.transform.position;
                float sqmag = offset.sqrMagnitude;
                Vector2 newForce = offset;
                newForce.Normalize();
                newForce *= -gravitationalConstant * orb.mass * rb.mass / sqmag;
                force += newForce;
            }
            rb.AddForce(force);
            BallsNetGravitationalForce[i] = force;
        }
    }
}
