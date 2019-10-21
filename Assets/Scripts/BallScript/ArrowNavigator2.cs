using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowNavigator2 : MonoBehaviour
{
    public GameObject[] Balls, Arrows;

    int cnt;
    Vector2[] postVelocities;
    Rigidbody2D[] rbs;

    void Start()
    {
        if (Balls.Length == Arrows.Length)
        {
            cnt = Balls.Length;
            rbs = new Rigidbody2D[cnt];
            postVelocities = new Vector2[cnt];
            for (int i = 0; i < cnt; i++)
            {
                rbs[i] = Balls[i].GetComponent<Rigidbody2D>();
                postVelocities[i] = rbs[i].velocity;
            }
        }
        else
        {
            throw new System.ArgumentException("Length of two arrays, 'Balls' and 'Arrows' must be same.");
        }
    }

    void showGravitationalForce()
    {
        for (int i = 0; i < cnt; i++)
        {
            GameObject a = Arrows[i];
            Vector2 force = SpaghettiForce.ballsNetGravitationalForce[i];
            Vector2 velocity = Balls[i].GetComponent<Rigidbody2D>().velocity;

            if (force.magnitude > 1e-4)
            {
                a.SetActive(true);
                a.transform.SetPositionAndRotation(Balls[i].transform.position, Quaternion.FromToRotation(Vector2.up, force));
            }
            else
            {
                a.SetActive(false);
            }
        }
    }

    void FixedUpdate()
    {
        showGravitationalForce();
        /*
        for(int i = 0; i < cnt; i++)
        {
            GameObject a = Arrows[i];
            Vector3 velocity = rbs[i].velocity;
            Vector3 acceleration = (velocity - postVelocities[i]) / Time.fixedDeltaTime;

            if (acceleration.magnitude > 1e-4)
            {
                a.SetActive(true);
                a.transform.SetPositionAndRotation(Balls[i].transform.position, Quaternion.FromToRotation(Vector3.up, acceleration));
            }
            else
            {
                a.SetActive(false);
            }

            postVelocities[i] = velocity;
        }
        */
    }
}
