using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySoundManager : MonoBehaviour
{
    private AudioSource bouncySound;

    void Start()
    {
        bouncySound = gameObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other) // Collision Start
    {
        bouncySound.Play();
    }
}
