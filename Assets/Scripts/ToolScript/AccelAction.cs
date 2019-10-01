using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelAction : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        other.attachedRigidbody.velocity=2*other.attachedRigidbody.velocity;
    }
}
