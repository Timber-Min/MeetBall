using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiodeWallAction : AbstractToolAction
{
    public Collider2D invisibleWall;

    protected override void triggerStayAction(Collider2D otherCollider)
    {
        Physics2D.IgnoreCollision(invisibleWall, otherCollider, true);
    }
}
