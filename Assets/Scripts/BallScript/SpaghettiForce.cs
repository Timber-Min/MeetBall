using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaghettiForce : MonoBehaviour
{
    private float gravitationalConstant = 200;
    public GameObject[] Objects;
    public static Vector2[] ballsNetGravitationalForce;

    void Start()
    {
        ballsNetGravitationalForce = new Vector2[Objects.Length];
    }

    void FixedUpdate()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Rigidbody2D rb = Objects[i].GetComponent<Rigidbody2D>();
            Vector2 force = Vector2.zero;

            foreach (GameObject obj in Objects)
            {
                if (obj.Equals(Objects[i])) continue;
                Rigidbody2D orb = obj.GetComponent<Rigidbody2D>();
                Vector2 offset = rb.transform.position - obj.transform.position;
                float sqmag = offset.sqrMagnitude;
                Vector2 newForce = offset;
                newForce.Normalize();
                newForce *= -gravitationalConstant * orb.mass * rb.mass / sqmag;
                force += newForce;
            }
            rb.AddForce(force);
            ballsNetGravitationalForce[i] = force;
        }
    }
}
