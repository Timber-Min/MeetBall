using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManagerOrange : MonoBehaviour
{
    PortalManager manager;

    void setManager(PortalManager man)
    {
        manager = man;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        manager.teleport(collision);
    }
}
