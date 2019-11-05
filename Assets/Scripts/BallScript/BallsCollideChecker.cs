﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallsCollideChecker : MonoBehaviour
{
    public GameObject OtherBall; // other ball
    private Text WinText; // Text that notifies player won

    void Start()
    {
        WinText = GameObject.Find("WinText").GetComponent<Text>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(OtherBall))
        {
            WinText.text = "You Win!"; // Shows message
        }
    }
}
