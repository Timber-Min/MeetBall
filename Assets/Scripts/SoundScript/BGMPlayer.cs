using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
    private static BGMPlayer audioPlayer=null;

    void Awake()
    {    
        if(audioPlayer!=null && audioPlayer!=this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            audioPlayer=this;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        gameObject.GetComponent<AudioSource>().volume=(float)SoundManager.BGMscale/100;
    }
}
