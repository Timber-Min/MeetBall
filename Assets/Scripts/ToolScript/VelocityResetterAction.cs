using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityResetterAction : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        other.attachedRigidbody.velocity=Vector2.zero;
    }
}
