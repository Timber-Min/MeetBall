using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherAction : AbstractToolAction
{
    // 발사 장치
    protected override void triggerEnterAction(Collider2D _other)
    {
        Destroy(this.gameObject); // 충돌 후 Destroy
        _other.attachedRigidbody.velocity = 8 * Vector2.up;
    }
}
