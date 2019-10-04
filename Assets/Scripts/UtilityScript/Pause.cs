using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause : MonoBehaviour
{
    private static bool isPaused = false;
    private GameObject pauseMenu;

    void Start()
    {
        gameObject.SetActive(true);
        pauseMenu = GameObject.Find("MenuPanel");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) pause();
            else resume();
        }
    }

    private void pause()
    {
        Time.timeScale = 0f;
        Debug.Log("Paused " + System.DateTime.Now.ToString("HHmmss"));
        pauseMenu.SendMessage("display");
        triggerPause();
    }

    private void resume()
    {
        Time.timeScale = 1f;
        Debug.Log("Resumed " + System.DateTime.Now.ToString("HHmmss"));
        pauseMenu.SendMessage("hide");
        triggerPause();
    }

    public static void triggerPause()
    {
        isPaused = !isPaused;
    }
}
