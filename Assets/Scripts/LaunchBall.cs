using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    GameObject Piston;
    public static bool isPaused = false;
    void Start()
    {
        gameObject.SetActive(true);
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            // if (isPaused)
                readyLaunch();
    }
    public void pause()
    {
        Time.timeScale = 0f;
        isPaused = !isPaused;
    }
    public void resume()
    {
        Time.timeScale = 1f;
        isPaused = !isPaused;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "White Cat" || collision.gameObject.name == "Black Cat")
        {
            Destroy(gameObject);
            pause();
        }
    }
    void readyLaunch()
    {
        resume();
    }
}
