using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallDeathTriggerAction : AbstractToolAction
{
    protected override void triggerEnterAction(Collider2D _other)
    {
        if (_other.gameObject.tag.Equals("Ball"))
        {
            SceneManager.LoadScene("RetryScene");
        }
    }
}
