using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractUIHandler : MonoBehaviour
{
    void Awake()
    {
        gameObject.tag = "UI";
    }
}
