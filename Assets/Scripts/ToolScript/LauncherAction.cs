using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherAction : AbstractToolAction
{
    // 발사 장치
    protected override void triggerEnterAction(Collider2D _other)
    {
        Destroy(this.gameObject); // 충돌 후 Destroy
        float rot = this.transform.rotation.eulerAngles.z * Mathf.PI / 180 + Mathf.PI / 2;
        Vector2 vec2 = new Vector2(Mathf.Cos(rot), Mathf.Sin(rot));
        _other.attachedRigidbody.velocity = 8 * vec2;
    }
}
