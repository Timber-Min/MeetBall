using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOrangeAction : MonoBehaviour
{
    PortalAction manager;

    void setManager(PortalAction man)
    {
        manager = man;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        manager.teleport(collision);
    }
}
