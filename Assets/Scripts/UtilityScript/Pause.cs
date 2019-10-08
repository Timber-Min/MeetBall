using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause : MonoBehaviour
{
    private static bool isPaused = false;
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu = GameObject.Find("MenuPanel");
        gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) resume();
            else pause();
        }
    }

    private void pause()
    {
        Time.timeScale = 0f;
        if(MainCamera.isGameStart)
            pauseMenu.SendMessage("display");
        triggerPause();
        Debug.Log("Paused " + System.DateTime.Now.ToString("HHmmss"));
        Debug.Log(isPaused);
    }

    private void resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SendMessage("hide");
        triggerPause();
        Debug.Log("Resumed " + System.DateTime.Now.ToString("HHmmss"));
        Debug.Log(isPaused);
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
