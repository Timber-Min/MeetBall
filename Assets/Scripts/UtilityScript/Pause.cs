using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause : MonoBehaviour
{
    private static bool isPaused = false;
    private GameObject pauseMenu;

    void Start()
    {
        pauseMenu = GameObject.Find("MenuPanel");
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!MainCamera.isGameStarted()) return;
            if (isPaused) resume();
            else pause();
        }
    }

    private void pause()
    {
        if (isPaused) return; // already pausing
        isPaused = true;
        Time.timeScale = 0f;
        if (MainCamera.isGameStarted())
            pauseMenu.SendMessage("display");
        Utility.LogWithTime("Paused");
    }

    private void resume()
    {
        if (!isPaused) return; // already resumed(playing)
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SendMessage("hide");
        Utility.LogWithTime("Resumed");
    }

    public static void triggerPause()
    {
        isPaused = !isPaused;
    }

    public static bool isPausing()
    {
        return isPaused;
    }
}
