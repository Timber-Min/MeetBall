using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaghettiForce : MonoBehaviour
{
    public float gravitationalConstant = 200;
    public GameObject[] Objects;
    public Button[] ForceManagers;

    public static Vector2[] ballsNetGravitationalForce;

    private int forceType;  // forceType: 0 for nothing, 1 for attraction, 2 for repulsion

    private GameObject forceManager;

    void Start()
    {
        ballsNetGravitationalForce = new Vector2[Objects.Length];
        forceType = 0;

        forceManager = GameObject.Find("ForceManager");

        ForceManagers[0] = forceManager.transform.GetChild(0).gameObject.GetComponent<Button>();
        ForceManagers[1] = forceManager.transform.GetChild(1).gameObject.GetComponent<Button>();
        ForceManagers[2] = forceManager.transform.GetChild(2).gameObject.GetComponent<Button>();
        changeForceType();


        ForceManagers[0].onClick.AddListener(changeForceTypeToNothing);
        ForceManagers[1].onClick.AddListener(changeForceTypeToAttract);
        ForceManagers[2].onClick.AddListener(changeForceTypeToRepel);
    }

    void FixedUpdate()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            if (forceType == 0)
            {
                ballsNetGravitationalForce[i] = Vector2.zero;
                continue;
            }

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

    void changeForceType(int type)
    {
        forceType = type;
        /*
        Color[] forceTypeColor = { new Color(0.5f, 0.5f, 0.5f), new Color(1f, 1f, 1f), new Color(1f, 0.4f, 0.2f) };
        string[] forceTypeText = { "Nothing", "Attract", "Repel" };

        btnForceManager.GetComponent<Image>().color = forceTypeColor[forceType];
        btnForceManager.GetComponentInChildren<Text>().text = forceTypeText[forceType];
        */
        for (int i = 0; i < ForceManagers.Length; i++)
        {
            ForceManagers[i].GetComponent<Button>().interactable = true;
        }
        ForceManagers[forceType].GetComponent<Button>().interactable = false;

        Debug.Log(System.DateTime.Now.ToString("HHmmss ") + "Current Force Status: " + forceType.ToString());
    }

    void changeForceType()
    {
        forceType = (forceType + 1) % 3;
        changeForceType(forceType);
    }

    void changeForceTypeToNothing()
    {
        changeForceType(0);
    }

    void changeForceTypeToAttract()
    {
        changeForceType(1);
    }

    void changeForceTypeToRepel()
    {
        changeForceType(2);
    }
}
