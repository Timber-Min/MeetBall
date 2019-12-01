using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageProcessor;

public class BallDeathTriggerAction : AbstractToolAction
{
    protected override void triggerEnterAction(Collider2D _other)
    {
        if (_other.gameObject.tag.Equals("Ball"))
        {
            getMenuPanel().SendMessage("restart");
        }
    }
}
