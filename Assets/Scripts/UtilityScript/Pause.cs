using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static StageProcessor;

// 게임 일시정지/재생 (PausePanel에 부착됨)
public class Pause : MonoBehaviour
{
    private Button restartBtn, levelBtn;
    private Slider timeScaleSlider;

    void Start()
    {
        gameObject.SetActive(true);
        restartBtn = GameObject.Find("Restart").GetComponent<Button>();
        levelBtn = GameObject.Find("Stages").GetComponent<Button>();
        timeScaleSlider=GameObject.Find("TimeScaleSlider").GetComponent<Slider>();
        restartBtn.onClick.AddListener(restart);
        levelBtn.onClick.AddListener(gotoMenu);
    }

    void Update()
    {
        // esc를 눌렀을 시
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 게임 시작 전이거나 클리어 후면 리턴
            if (!isStarted || isCleared) return;
            // 아닐 시 일시정지/재생 토글
            if (isPaused) resume();
            else pause();
        }
    }

    private void pause()
    {
        if (!isStarted || isCleared || isPaused) return; // 게임 시작 X or 클리어 or 일시정지 중일 경우 리턴
        isPaused = true; // 변수 업데이트
        Time.timeScale = 0f; // 시간을 멈춘다

        gameObject.SendMessage("show"); // PausePanel 띄우기
        timeScaleSlider.gameObject.SendMessage("hide"); // 슬라이더 감추기
        print("Paused");
    }

    private void resume()
    {
        if (!isStarted || isCleared || !isPaused) return; // 게임 시작 X or 클리어 or 일시정지 중이 아닐 경우 리턴
        isPaused = false; // 변수 업데이트
        Time.timeScale = (float)System.Math.Pow(4, timeScaleSlider.value); // 시간을 다시 흐르게 한다

        gameObject.SendMessage("hide"); // 메뉴 숨기기
        timeScaleSlider.gameObject.SendMessage("hide"); // 슬라이더 띄우기
        print("Resumed"); 
    }

    public void restart() // 재시작
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void gotoMenu() => GameObject.Find("EscapeToLevel").SendMessage("RequestScene");
}
