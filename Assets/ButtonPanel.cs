using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPanel : MonoBehaviour
{
    private Button menuBtn, restartBtn, nextBtn;
    private Transform myTransform;
    void Start()
    {
        myTransform = gameObject.transform;
        menuBtn = myTransform.GetChild(0).gameObject.GetComponent<Button>();
        restartBtn = myTransform.GetChild(1).gameObject.GetComponent<Button>();
        nextBtn = myTransform.GetChild(2).gameObject.GetComponent<Button>();

        menuBtn.onClick.AddListener(gotoMenu);
        restartBtn.onClick.AddListener(restart);
        nextBtn.onClick.AddListener(gotoNext);
    }

    private void gotoMenu()
    {
        
    }

    private void restart()
    {

    }

    private void gotoNext()
    {

    }
}
