using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorReverseAction : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        other.attachedRigidbody.velocity=-other.attachedRigidbody.velocity;
    }
}
