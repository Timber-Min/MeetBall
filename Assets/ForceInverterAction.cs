using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceInverterAction : AbstractToolAction
{
    private SpaghettiForce spaghettiForce;

    private void Start()
    {
        spaghettiForce = GameObject.Find("Meatballs").GetComponent<SpaghettiForce>();
    }

    protected override void triggerEnterAction(Collider2D _other)
    {
        Destroy(this.gameObject);
        spaghettiForce.SendMessage("CycleForceType");
    }
}
