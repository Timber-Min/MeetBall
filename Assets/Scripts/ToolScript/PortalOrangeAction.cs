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

    protected override void triggerEnterAction(Collider2D _other)
    {
        manager.teleport(_other);
    }
}
