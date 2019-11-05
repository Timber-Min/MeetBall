using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonBodyAction : AbstractToolAction
{
    // Start is called before the first frame update
    private GameObject pistonM;

    void Start()
    {
        pistonM = gameObject.transform.parent.gameObject;
    }

    void OnMouseDown()
    {
        pistonM.SendMessage("movePlate");
    }
}
