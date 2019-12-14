using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceManagerBtn : AbstractUIHandler
{
    private int cnt;

    void Start()
    {
        hide();
        cnt=0;
        gameObject.GetComponent<Button>().onClick.AddListener(counter);
    }

    private void counter()
    {
        cnt+=1;
    }

    public int getToggledTimes()
    {
        return cnt;
    }
}