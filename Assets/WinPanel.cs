using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    void Start() => hide();
    void show() => gameObject.transform.localScale = new Vector3(2, 2, 2);
    void hide() => gameObject.transform.localScale = new Vector3(0, 0, 0);
}
