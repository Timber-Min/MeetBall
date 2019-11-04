﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherAction : AbstractToolAction
{
    protected override void triggerEnterAction(Collider2D _other)
    {
        _other.attachedRigidbody.velocity = 10000 * Vector2.up;
    }
}
