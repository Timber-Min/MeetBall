using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractToolAction : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) // Trigger Start
    {
        triggerEnterAction(other);
    }

    void OnTriggerStay2D(Collider2D other) // During trigger
    {
        triggerStayAction(other);
    }

    void OnTriggerExit2D(Collider2D other) // Trigger end
    {
        triggerExitAction(other);
    }

    void OnCollisionEnter2D(Collision2D other) // Collision Start
    {
        collisionEnterAction(other);
    }

    void OnCollisionStay2D(Collision2D other) // During Collision
    {
        collisionStayAction(other);
    }

    void OnCollisionExit2D(Collision2D other) // Collision end
    {
        collisionExitAction(other);
    }

    protected virtual void triggerEnterAction(Collider2D _other) { }

    protected virtual void triggerStayAction(Collider2D _other) { }

    protected virtual void triggerExitAction(Collider2D _other) { }

    protected virtual void collisionEnterAction(Collision2D _other) { }

    protected virtual void collisionStayAction(Collision2D _other) { }

    protected virtual void collisionExitAction(Collision2D _other) { }
}
