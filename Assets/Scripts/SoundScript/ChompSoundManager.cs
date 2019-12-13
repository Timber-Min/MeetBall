using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChompSoundManager : MonoBehaviour
{
    void Awake()
    {
        gameObject.GetComponent<AudioSource>().volume = (float)SoundManager.SFXscale / 100;
    }
}
