using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

public class SpaghettiForce : AbstractForceCalculator
{
    // objects: 미트볼 Gameobject.
    // forceManagerBtn: Canvas 안의 ForceManagerBtn 버튼.
    // forceManagerBtnToggle: 버튼의 토글 상태.
    // forceType: 미트볼에 작용할 힘의 종류. 0 for attraction, 1 for repulsion
    public GameObject[] objects;
    private GameObject forceManagerBtn;
    private bool forceManagerBtnToggle = false;
    private int forceType = 0;

    // ballsNetGravitationalForce: 미트볼에 작용하는 힘을 저장하는 변수. ArrowNavigator에 힘을 전해주기 위해 존재.
    private Vector2[] ballsNetGravitationalForce;

    void Start()
    {
        ballsNetGravitationalForce = new Vector2[objects.Length];
        forceManagerBtn = GameObject.Find("ForceManagerBtn");
        forceManagerBtn.GetComponent<Button>().onClick.AddListener(ToggleForceBtn);
        forceManagerBtnToggle = false;
        ChangeForceType(0);
    }

    void FixedUpdate()
    {
        if (!isStarted) return;
        for (int i = 0; i < objects.Length; i++)
        {
            PointEffector2D pe = objects[i].GetComponent<PointEffector2D>();

            // forceMangerBtnToggle이 false이면 힘이 작용하지 않음.
            if (!forceManagerBtnToggle)
            {
                ballsNetGravitationalForce[i] = Vector2.zero;
                pe.enabled = false;
                continue;
            }
            else
            {
                pe.enabled = true;
                if(forceType == 0)
                {
                    pe.forceMagnitude = -200;
                }
                else
                {
                    pe.forceMagnitude = 200;
                }
            }

            Rigidbody2D rb = objects[i].GetComponent<Rigidbody2D>();
            Vector2 force = Vector2.zero;

            // 거리의 역제곱에 비례하게 힘 작용.
            foreach (GameObject obj in objects)
            {
                if (obj.Equals(objects[i])) continue;
                Rigidbody2D orb = obj.GetComponent<Rigidbody2D>();
                Vector2 offset = Vector3to2(rb.transform.position) + rb.velocity*Time.fixedDeltaTime - Vector3to2(obj.transform.position) - obj.GetComponent<Rigidbody2D>().velocity*Time.fixedDeltaTime;
                float sqmag = offset.sqrMagnitude;
                Vector2 newForce = offset;
                newForce.Normalize();
                newForce *= -gravitationalConstant * orb.mass * rb.mass / sqmag;
                if (forceType == 1) newForce *= -1;
                force += newForce;
            }
            //rb.AddForce(force);
            ballsNetGravitationalForce[i] = force;
        }
    }

    Vector2 Vector3to2(Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }

    public Vector2[] GetForces()
    {
        return ballsNetGravitationalForce;
    }

    // 힘의 종류가 매개변수로 들어오면 지정.
    void ChangeForceType(int type)
    {
        forceType = type;
        Text btnText = forceManagerBtn.GetComponentInChildren<Text>();
        if (forceType == 0)
        {
            btnText.text = "Attract";
        }
        else if (forceType == 1)
        {
            btnText.text = "Repel";
        }
        else
        {
            throw new System.ArgumentException("force type argument must be 0 or 1.");
        }
        UpdateForceBtnColor();

        print("Current Force Status: " + forceType.ToString());
    }
    void CycleForceType()
    {
        forceType = (forceType + 1) % 2;
        ChangeForceType(forceType);
    }

    void ToggleForceBtn()
    {
        forceManagerBtnToggle = !forceManagerBtnToggle;
        UpdateForceBtnColor();
    }

    void UpdateForceBtnColor()
    {
        Image btnImage = forceManagerBtn.GetComponent<Image>();
        if (forceType == 0)
        {
            if (forceManagerBtnToggle)
            {
                forceManagerBtn.GetComponent<Image>().color = new Color(189f / 255f, 188f / 255f, 167f / 255f);
            }
            else
            {
                forceManagerBtn.GetComponent<Image>().color = new Color(252f / 255f, 251f / 255f, 223f / 255f);
            }
        }
        else if (forceType == 1)
        {
            if (forceManagerBtnToggle)
            {
                forceManagerBtn.GetComponent<Image>().color = new Color(175f / 255f, 59f / 255f, 19f / 255f);
            }
            else
            {
                forceManagerBtn.GetComponent<Image>().color = new Color(234f / 255f, 79f / 255f, 25f / 255f);
            }
        }
        else
        {
            throw new System.ArgumentException("force type argument must be 0 or 1.");
        }
    }
}
