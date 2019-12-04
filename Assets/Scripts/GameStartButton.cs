using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    private Button myButton;
    private Transform myTransform;

    void Start()
    {
        myButton = gameObject.GetComponent<Button>();
        myTransform = gameObject.GetComponent<Transform>();
    }

    public void hide()
    {
        myTransform.localScale = new Vector3(0, 0, 0);
    }
}
