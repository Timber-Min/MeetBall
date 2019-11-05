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
            if (Utility.vector2Equal(Utility.asVector2(wallPos - tempPos).normalized, new Vector2(dx, dy)))
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
                if (Utility.vector2Equal(tempPos, wallPos))
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

    public void teleport(Collider2D ball, Collider2D portal)
    {
        int[] xMov = { -1, 0, 1, 0 }, yMov = { 0, -1, 0, 1 };
        int dx = xMov[pathDirection], dy = yMov[pathDirection];

        Vector2 teleportPos;

        if (portal.Equals(portalOrange.GetComponent<Collider2D>()))
        {
            teleportPos = Utility.asVector2(portalBlue.transform.position) + new Vector2(dx, dy) * 0.5f;
            ball.GetComponent<Transform>().position = teleportPos;
        }
        else
        {
            teleportPos = Utility.asVector2(portalOrange.transform.position) + new Vector2(-dx, -dy) * 0.5f;
            ball.GetComponent<Transform>().position = teleportPos;
        }
    }
}
