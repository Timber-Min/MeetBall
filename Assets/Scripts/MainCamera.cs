using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Pause;
    void Start()
    {
        Pause = GameObject.Find("")
        Pause.SendMessage("pause");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
