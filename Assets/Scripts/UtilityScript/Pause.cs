using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 일시정지/재생
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
        // esc를 눌렀을 시
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 게임 시작 전이면 리턴
            if (!MainCamera.isGameStarted()) return;
            // 아닐 시 일시정지/재생
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
            pauseMenu.SendMessage("display"); // 메뉴 표시
        print("Paused");
    }

    private void resume()
    {
        if (!isPaused) return; // already resumed(playing)
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SendMessage("hide"); // 메뉴 숨기기
        print("Resumed");
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
