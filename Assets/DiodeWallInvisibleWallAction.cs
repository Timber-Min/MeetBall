using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiodeWallInvisibleWallAction : AbstractToolAction
{
    protected override void triggerExitAction(Collider2D otherCollider)
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), otherCollider, false);
    }
}
