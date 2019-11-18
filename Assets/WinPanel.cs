using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : AbstractUIHandler
{
    void Start() => hide();
    protected override void show() => transform.localScale = new Vector3(2, 2, 2);
}
