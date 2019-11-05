using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorReverseAction : AbstractToolAction
{
    protected override void triggerEnterAction(Collider2D _other)
    {
        _other.attachedRigidbody.velocity *= -1;
    }
}
