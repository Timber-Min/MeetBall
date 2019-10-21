using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaghettiForce : MonoBehaviour
{
    public float gravitationalConstant = 200;
    public GameObject[] Objects;
    public Button btnForceManager;

    public static Vector2[] ballsNetGravitationalForce;

    private int forceType;  // forceType: 0 for nothing, 1 for attraction, 2 for repulsion

    void Start()
    {
        ballsNetGravitationalForce = new Vector2[Objects.Length];
        forceType = 0;
        changeForceType();
    }

    void FixedUpdate()
    {
        if (forceType == 0)
            return;
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
                if (forceType == 2) newForce *= -1;
                force += newForce;
            }
            rb.AddForce(force);
            ballsNetGravitationalForce[i] = force;
        }
    }
    
    void changeForceType()
    {
        forceType = (forceType + 1) % 3;

        if (forceType == 0)
        {
            btnForceManager.GetComponent<Image>().color = new Color(128, 128, 128);
            btnForceManager.GetComponentInChildren<Text>().text = "Nothing";
        }
        else if (forceType == 1)
        {
            btnForceManager.GetComponent<Image>().color = new Color(255, 255, 255);
            btnForceManager.GetComponentInChildren<Text>().text = "Attract";
        }
        else if (forceType == 2)
        {
            btnForceManager.GetComponent<Image>().color = new Color(255, 128, 128);
            btnForceManager.GetComponentInChildren<Text>().text = "Repel";
        }
    }
}
