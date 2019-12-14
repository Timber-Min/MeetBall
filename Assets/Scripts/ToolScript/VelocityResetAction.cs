using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityResetAction : AbstractToolAction
{
    protected override void triggerEnterAction(Collider2D _other)
    {
        if (_other.tag == "Ball" && _other.isTrigger == false)
        {
            _other.attachedRigidbody.velocity = Vector2.zero;
        }
    }
}
