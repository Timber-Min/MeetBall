using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallDeathTriggerAction : AbstractToolAction
{
    private GameObject mCamera;
    void Start()
    {
        mCamera = GameObject.Find("Main Camera");
    }
    protected override void triggerEnterAction(Collider2D _other)
    {
        if (_other.gameObject.tag.Equals("Ball"))
        {
            GameObject.Find("MenuPanel").SendMessage("restart");
        }
    }
}
