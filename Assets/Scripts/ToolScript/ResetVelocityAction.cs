using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVelocityAction : AbstractToolAction
{
    protected override void triggerEnterAction(Collider2D _other)
    {
        _other.attachedRigidbody.velocity = Vector2.zero;
    }
}
