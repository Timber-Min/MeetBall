using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAction : AbstractToolAction
{
    public GameObject templatePortalOrange, templatePortalBlue, templatePortalPath;
    public GameObject Walls;
    public GameObject Parent;
    GameObject portalOrange, portalBlue;

    private int pathDirection;

    void Start()
    {
        Walls = GameObject.Find("Walls");

        float rotation = transform.rotation.eulerAngles.z;
        portalOrange = Instantiate(
            templatePortalOrange, transform.position, Quaternion.Euler(0f, 0f, rotation), Parent.transform);
        pathDirection = (Mathf.FloorToInt(rotation / 90) + 4) % 4;
        // pathDirection: 0(left), 1(down), 2(right), 3(up)

        Vector2 tempPos = gameObject.transform.position;
        BoxCollider2D[] allWalls = Walls.GetComponentsInChildren<BoxCollider2D>();
        List<BoxCollider2D> validWalls = new List<BoxCollider2D>();

        int[] xMov = { -1, 0, 1, 0 }, yMov = { 0, -1, 0, 1 };
        int dx = xMov[pathDirection], dy = yMov[pathDirection];
        bool flag;

        foreach (BoxCollider2D i in allWalls)
        {
            Vector2 wallPos = i.transform.position;
            if (vector2Equal(asVector2(wallPos - tempPos).normalized, new Vector2(dx, dy)))
            {
                validWalls.Add(i);
            }
        }

        while (true)
        {
            flag = false;
            tempPos.x += dx;
            tempPos.y += dy;

            foreach (BoxCollider2D i in validWalls)
            {
                Vector2 wallPos = i.transform.position;
                if (vector2Equal(tempPos, wallPos))
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
                Instantiate(templatePortalPath, tempPos, Quaternion.Euler(0f, 0f, rotation), Parent.transform);
            else
                break;
        }

        portalBlue = Instantiate(
            templatePortalBlue, tempPos, Quaternion.Euler(0f, 0f, rotation + 180f), Parent.transform);
        Parent.GetComponent<SpriteRenderer>().sprite = null;
        templatePortalOrange.SetActive(false);
        templatePortalBlue.SetActive(false);
        templatePortalPath.SetActive(false);

        portalOrange.SendMessage("setManager", this);
        portalBlue.SendMessage("setManager", this);
    }

    // 미트볼의 Collider2D와 미트볼과 충돌한 포탈의 Collider2D를 받아 미트볼을 반대쪽 포탈로 이동시킨다.
    public void teleport(Collider2D ball, Collider2D portal)
    {
        int[] xMov = { -1, 0, 1, 0 }, yMov = { 0, -1, 0, 1 };
        int dx = xMov[pathDirection], dy = yMov[pathDirection];

        Vector2 teleportPos;

        if (portal.Equals(portalOrange.GetComponent<Collider2D>()))
        {
            teleportPos = asVector2(portalBlue.transform.position) + new Vector2(dx, dy) * 0.25f;
            ball.GetComponent<Transform>().position = teleportPos;
        }
        else
        {
            teleportPos = asVector2(portalOrange.transform.position) + new Vector2(-dx, -dy) * 0.25f;
            ball.GetComponent<Transform>().position = teleportPos;
        }
    }

    private Vector2 asVector2(Vector3 _v)
    {
        // convert Vector3 to Vector2.
        return new Vector2(_v.x, _v.y);
    }

    private bool floatEqual(float _a, float _b)
    {
        // determine two float object is same; round off error is considered.
        const double EPSILON = 0.00001;
        return (Mathf.Abs(_a - _b) < EPSILON);
    }

    private bool vector2Equal(Vector2 _a, Vector2 _b)
    {
        // determine two Vector2 object is same.
        return (floatEqual(_a.x, _b.x) && floatEqual(_a.y, _b.y));
    }
}
