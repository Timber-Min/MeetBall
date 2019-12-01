using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallsCollideChecker : MonoBehaviour
{
    public GameObject otherBall; // other ball
    private GameObject winPanel;
    private Text winText; // Text that notifies player won
    public GameObject firework;

    void Start()
    {
        winText = GameObject.Find("WinText").GetComponent<Text>();
        winPanel = GameObject.Find("WinPanel");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(otherBall))
        {
            winText.text = "You Win!"; // Shows message
            winPanel.SendMessage("show"); //Hides WinPanel
            firework.SetActive(true);
        }
    }
}
