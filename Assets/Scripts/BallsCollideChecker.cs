using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallsCollideChecker : MonoBehaviour
{
    public GameObject OtherBall;
    public Text WinText;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(OtherBall))
        {
            WinText.text = "LOL";
        }
    }
}
