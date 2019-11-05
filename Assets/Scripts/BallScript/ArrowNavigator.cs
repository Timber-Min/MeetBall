using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowNavigator : MonoBehaviour
{
    private GameObject[] balls;
    public GameObject[] arrows;
    int cnt;
    Vector2[] postVelocities;
    Rigidbody2D[] rbs;

    void Start()
    {
        balls=GameObject.FindGameObjectsWithTag("Ball");
        if (balls.Length != arrows.Length)
            throw new System.ArgumentException("Length of two arrays, 'balls' and 'arrows' must be same.");
        cnt = balls.Length;
        rbs = new Rigidbody2D[cnt];
        postVelocities = new Vector2[cnt];
        for (int i = 0; i < cnt; i++)
        {
            rbs[i] = balls[i].GetComponent<Rigidbody2D>();
            postVelocities[i] = rbs[i].velocity;
        }
    }

    void showGravitationalForce()
    {
        for (int i = 0; i < cnt; i++)
        {
            GameObject a = arrows[i];
            Vector2 force = SpaghettiForce.ballsNetGravitationalForce[i];
            Vector2 velocity = balls[i].GetComponent<Rigidbody2D>().velocity;

            if (force.magnitude > 1e-4)
            {
                a.SetActive(true);
                a.transform.SetPositionAndRotation(balls[i].transform.position, Quaternion.FromToRotation(Vector2.up, force));
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
            GameObject a = arrows[i];
            Vector3 velocity = rbs[i].velocity;
            Vector3 acceleration = (velocity - postVelocities[i]) / Time.fixedDeltaTime;

            if (acceleration.magnitude > 1e-4)
            {
                a.SetActive(true);
                a.transform.SetPositionAndRotation(balls[i].transform.position, Quaternion.FromToRotation(Vector3.up, acceleration));
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
