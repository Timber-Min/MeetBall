﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelAction : AbstractToolAction
{
    protected override void triggerEnterAction(Collider2D _other)
    {
        _other.attachedRigidbody.velocity *= 2;
    }
}
