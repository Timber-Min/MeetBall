using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallsCollideChecker : MonoBehaviour
{
    public GameObject otherBall; // other ball
    private Text winText; // Text that notifies player won

    void Start()
    {
        winText = GameObject.Find("WinText").GetComponent<Text>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(otherBall))
        {
            winText.text = "You Win!"; // Shows message
        }
    }
}
