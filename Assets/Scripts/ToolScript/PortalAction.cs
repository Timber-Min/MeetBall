using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAction : MonoBehaviour
{
    // "Walls" gameobject could be changed into "SolidBlocks" gameobject.
    public GameObject Template_PortalOrange, Template_PortalBlue, Template_PortalPath;
    public GameObject Walls;
    public GameObject Parent;

    GameObject PortalOrange;
    GameObject PortalBlue;

    void Start()
    {
        Vector2 position = transform.position;
        float rotation = transform.rotation.eulerAngles.z;

        PortalOrange = Instantiate(Template_PortalOrange, position, Quaternion.Euler(0f, 0f, rotation), Parent.transform);

        // pathDirection: 0(left), 1(down), 2(right), 3(up)
        int pathDirection = (int)(rotation / 90f) % 4;
        BoxCollider2D[] walls = Walls.GetComponentsInChildren<BoxCollider2D>();

        Vector2 newPos = position;
        while (true)
        {
            if (pathDirection == 0)
                newPos.x -= 1;
            else if (pathDirection == 1)
                newPos.y += 1;
            else if (pathDirection == 2)
                newPos.x += 1;
            else
                newPos.y -= 1;

            bool flag = false;
            foreach (BoxCollider2D wall in walls)
            {
                Vector2 wallPos = wall.transform.position;
                if (newPos.Equals(wallPos))
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
                Instantiate(Template_PortalPath, newPos, Quaternion.Euler(0f, 0f, rotation), Parent.transform);
            else
                break;
        }
        PortalBlue = Instantiate(Template_PortalBlue, newPos, Quaternion.Euler(0f, 0f, rotation + 180f), Parent.transform);

        Parent.GetComponent<SpriteRenderer>().sprite = null;
    }

    void FixedUpdate()
    {
        PortalOrange.SendMessage("setManager", this);
    }

    public void teleport(Collider2D collider)
    {
        collider.GetComponent<Transform>().position = PortalBlue.transform.position;
    }
}
