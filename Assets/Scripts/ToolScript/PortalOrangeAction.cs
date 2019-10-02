using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOrangeAction : AbstractToolAction
{
    private PortalAction manager;

    void setManager(PortalAction _manager)
    {
        manager = _manager;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        manager.teleport(collision);
    }
}
