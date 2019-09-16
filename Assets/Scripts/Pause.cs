using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isPaused = false;
    public GameObject pauseMenu;
    // Update is called once per frame

    void Start()
    {
        gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                pause();
            }
            else
            {
                resume();
            }
        }
    }

    public void pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SendMessage("display");
        isPaused = !isPaused;
    }

    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SendMessage("hide");
        isPaused = !isPaused;
    }
}
