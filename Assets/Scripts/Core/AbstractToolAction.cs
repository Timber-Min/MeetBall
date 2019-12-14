using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HandleAction;

public abstract class AbstractToolAction : MonoBehaviour
{
    private bool isRotatable = false;
    private HandleAction myHandle;

    void Awake()
    {
        gameObject.tag = "Tool";
    }

    public void makeHandle()
    {
        myHandle = new HandleAction(gameObject.transform.position);
    }

    public void toggleHandle()
    {
        if (isRotatable) myHandle.toggleShow();
    }

    protected void toggleRotate()
    {
        isRotatable = !isRotatable;
    }

    void OnTriggerEnter2D(Collider2D other) // Trigger Start
    {
        print("Trigger Entered: " + other + " to " + this.name);
        triggerEnterAction(other);
    }

    void OnTriggerStay2D(Collider2D other) // During trigger
    {
        triggerStayAction(other);
    }

    void OnTriggerExit2D(Collider2D other) // Trigger end
    {
        print("Trigger Exited: " + other + " from " + this.name);
        triggerExitAction(other);
    }

    void OnCollisionEnter2D(Collision2D other) // Collision Start
    {
        print("Collision Entered: " + other + " to " + this.name);
        collisionEnterAction(other);
    }

    void OnCollisionStay2D(Collision2D other) // During Collision
    {
        collisionStayAction(other);
    }

    void OnCollisionExit2D(Collision2D other) // Collision end
    {
        print("Collision Exited: " + other + " from " + this.name);
        collisionExitAction(other);
    }


    protected virtual void triggerEnterAction(Collider2D _other) { }

    protected virtual void triggerStayAction(Collider2D _other) { }

    protected virtual void triggerExitAction(Collider2D _other) { }

    protected virtual void collisionEnterAction(Collision2D _other) { }

    protected virtual void collisionStayAction(Collision2D _other) { }

    protected virtual void collisionExitAction(Collision2D _other) { }
}
