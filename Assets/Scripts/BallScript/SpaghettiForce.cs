using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

public class SpaghettiForce : AbstractForceCalculator
{
    // objects: 미트볼 Gameobject.
    // forcemanagers: 힘을 제어하는 버튼들.
    // ballsNetGravitationalForce: 미트볼에 작용하는 힘을 저장하는 public static 변수. ArrowNavigator에 힘을 전해주기 위함.
    // forceType: 미트볼에 작용할 힘의 종류. 0 for nothing, 1 for attraction, 2 for repulsion
    // forceManager: Canvas 안의 ForceManager GameObject.
    public GameObject[] objects;
    private Button[] forceManagers = new Button[3];
    public static Vector2[] ballsNetGravitationalForce;
    private int forceType = 0;
    private GameObject forceManager;

    void Start()
    {
        ballsNetGravitationalForce = new Vector2[objects.Length];
        forceManager = GameObject.Find("ForceManager");

        forceManagers[0] = forceManager.transform.GetChild(0).gameObject.GetComponent<Button>();
        forceManagers[1] = forceManager.transform.GetChild(1).gameObject.GetComponent<Button>();
        forceManagers[2] = forceManager.transform.GetChild(2).gameObject.GetComponent<Button>();

        // 버튼들이 눌리면 실행될 함수 지정.
        forceManagers[0].onClick.AddListener(changeForceTypeToNothing);
        forceManagers[1].onClick.AddListener(changeForceTypeToAttract);
        forceManagers[2].onClick.AddListener(changeForceTypeToRepel);

        changeForceTypeToAttract();
    }

    void FixedUpdate()
    {
        if(!isStarted) return;
        for (int i = 0; i < objects.Length; i++)
        {
            // forceType이 0이면 힘이 작용하지 않음.
            if (forceType == 0)
            {
                ballsNetGravitationalForce[i] = Vector2.zero;
                continue;
            }

            Rigidbody2D rb = objects[i].GetComponent<Rigidbody2D>();
            Vector2 force = Vector2.zero;

            // 거리의 역제곱에 비례하게 힘 작용.
            foreach (GameObject obj in objects)
            {
                if (obj.Equals(objects[i])) continue;
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

    // 힘의 종류가 매개변수로 들어오면 지정.
    void changeForceType(int type)
    {
        forceType = type;
        for (int i = 0; i < forceManagers.Length; i++)
        {
            forceManagers[i].GetComponent<Button>().interactable = true;
        }
        forceManagers[forceType].GetComponent<Button>().interactable = false;

        print("Current Force Status: " + forceType.ToString());
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
