using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceInverterAction : AbstractToolAction
{
    private SpaghettiForce spaghettiForce;

    private void Start()
    {
        spaghettiForce = GameObject.Find("MeatBalls").GetComponent<SpaghettiForce>();
    }

    protected override void triggerEnterAction(Collider2D _other)
    {
        if(_other.tag == "Ball" && _other.isTrigger == false)
        {
            Destroy(this.gameObject);
            spaghettiForce.SendMessage("CycleForceType");
        }
    }
}
