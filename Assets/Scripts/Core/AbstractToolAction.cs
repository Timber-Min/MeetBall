using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractToolAction : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) // Trigger Start
    {
        Debug.Log(System.DateTime.Now.ToString("HHmmss ") + "Trigger Entered: " + other + " to " + this.name);
        triggerEnterAction(other);
    }

    void OnTriggerStay2D(Collider2D other) // During trigger
    {
        triggerStayAction(other);
    }

    void OnTriggerExit2D(Collider2D other) // Trigger end
    {
        Debug.Log(System.DateTime.Now.ToString("HHmmss ") + "Trigger Exited: " + other + " from " + this.name);
        triggerExitAction(other);
    }

    void OnCollisionEnter2D(Collision2D other) // Collision Start
    {
        Debug.Log(System.DateTime.Now.ToString("HHmmss ") + "Collision Entered: " + other + " to " + this.name);
        collisionEnterAction(other);
    }

    void OnCollisionStay2D(Collision2D other) // During Collision
    {
        collisionStayAction(other);
    }

    void OnCollisionExit2D(Collision2D other) // Collision end
    {
        Debug.Log(System.DateTime.Now.ToString("HHmmss ") + "Collision Exited: " + other + " from " + this.name);
        collisionExitAction(other);
    }

    protected virtual void triggerEnterAction(Collider2D _other) { }

    protected virtual void triggerStayAction(Collider2D _other) { }

    protected virtual void triggerExitAction(Collider2D _other) { }

    protected virtual void collisionEnterAction(Collision2D _other) { }

    protected virtual void collisionStayAction(Collision2D _other) { }

    protected virtual void collisionExitAction(Collision2D _other) { }
}
