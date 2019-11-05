using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceManager : MonoBehaviour
{
    void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0); // hides itself by resizing to zero
    }

    public void show()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1); // restores the size
    }
}
