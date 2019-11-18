using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractUIHandler : MonoBehaviour
{
    void Awake()
    {
        gameObject.tag = "UI";
    }

    protected void hide() => transform.localScale = new Vector3(0, 0, 0);

    protected void show() => transform.localScale = new Vector3(1, 1, 1);
}
