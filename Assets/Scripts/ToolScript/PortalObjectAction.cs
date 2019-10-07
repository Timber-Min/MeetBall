using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObjectAction : AbstractToolAction
{
    private PortalAction manager;

    void setManager(PortalAction _manager)
    {
        manager = _manager;
    }

    protected override void collisionEnterAction(Collision2D _collsion)
    {
        manager.teleport(_collsion.collider, _collsion.otherCollider);
    }
}
