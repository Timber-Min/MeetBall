using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 게임 일시정지/재생
public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    private GameObject pauseMenu;
    private Button restartBtn, menuBtn;
    private GameObject mCamera;

    void Awake() => mCamera = GameObject.Find("Main Camera");
    void Start()
    {
        pauseMenu = GameObject.Find("MenuPanel");
        gameObject.SetActive(true);
        restartBtn = GameObject.Find("Restart").GetComponent<Button>();
        menuBtn = GameObject.Find("MainMenu").GetComponent<Button>();
        restartBtn.onClick.AddListener(restart);
        menuBtn.onClick.AddListener(gotoMenu);
    }

    void Update()
    {
        // esc를 눌렀을 시
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 게임 시작 전이면 리턴
            if (!mCamera.GetComponent<MainCamera>().isGameStart) return;
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
        if (mCamera.GetComponent<MainCamera>().isGameStart)
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

    public void triggerPause() => isPaused = !isPaused;

    public bool isPausing() => isPaused;

    private void restart()
    {
        mCamera.GetComponent<MainCamera>().isGameStart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void gotoMenu() => SceneManager.LoadScene("MainMenu");
}
