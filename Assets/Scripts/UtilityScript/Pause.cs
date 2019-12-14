using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static StageProcessor;

// 게임 일시정지/재생 (PausePanel에 부착됨)
public class Pause : MonoBehaviour
{
    private Button resumeBtn;

    void Start()
    {
        // gameObject.SetActive(true);
        resumeBtn=gameObject.transform.GetChild(1).gameObject.GetComponent<Button>();
    }

    void Update()
    {
        // esc를 눌렀을 시
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 게임 시작 전이거나 클리어 후면 리턴
            if (!isStarted || isCleared) return;
            // 아닐 시 일시정지/재생 토글
            if (isPaused) resumeBtn.SendMessage("resume"); // resume 버튼 누르는 효과
            else pause(); // 일시정지
        }
    }

    private void pause()
    {
        if (!isStarted || isCleared || isPaused) return; // 게임 시작 X or 클리어 or 일시정지 중일 경우 리턴
        isPaused = true; // 변수 업데이트
        Time.timeScale = 0f; // 시간을 멈춘다

        gameObject.SendMessage("show"); // PausePanel 띄우기
        print("Paused");
    }

    public void restart() // 재시작
    {
        getRestartBtn().SendMessage("restartStage");
    }
}
