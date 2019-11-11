using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherAction : AbstractToolAction
{
    // 발사 장치
    protected override void triggerEnterAction(Collider2D _other)
    {
        Destroy(this.gameObject);
        _other.attachedRigidbody.velocity = 5 * Vector2.up;
    }
}
