using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAction : AbstractToolAction
{
    // "Walls" gameobject could be changed into "SolidBlocks" gameobject.
    public GameObject templatePortalOrange, templatePortalBlue, templatePortalPath;
    public GameObject Walls;
    public GameObject Parent;
    GameObject PortalOrange;
    GameObject PortalBlue;

    void Start()
    {
        float rotation = transform.rotation.eulerAngles.z;
        PortalOrange = Instantiate(
            templatePortalOrange, transform.position, Quaternion.Euler(0f, 0f, rotation), Parent.transform);
        int pathDirection = (int)(rotation / 90f) % 4; // pathDirection: 0(left), 1(down), 2(right), 3(up)
        BoxCollider2D[] walls = Walls.GetComponentsInChildren<BoxCollider2D>();
        Vector2 newPos = transform.position;

        while (true)
        {
            switch (pathDirection)
            {
                case 0:
                    newPos.x -= 1;
                    break;
                case 1:
                    newPos.y += 1;
                    break;
                case 2:
                    newPos.x += 1;
                    break;
                case 3:
                    newPos.y -= 1;
                    break;
            }

            bool flag = false;

            foreach (BoxCollider2D i in walls)
            {
                Vector2 wallPos = i.transform.position;
                if (newPos.Equals(wallPos))
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
                Instantiate(templatePortalPath, newPos, Quaternion.Euler(0f, 0f, rotation), Parent.transform);
            else
                break;
        }
        PortalBlue = Instantiate(templatePortalBlue, newPos, Quaternion.Euler(0f, 0f, rotation + 180f), Parent.transform);

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
