using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

public class GameStartButton : AbstractUIHandler
{
    // 게임 시작과 직접적으로 연관된 버튼
    void Start()
    {
        getPausePanel().SendMessage("pause"); // 우선 일시정지
        gameObject.GetComponent<Button>().onClick.AddListener(gameStart);
    }

    public void gameStart()
    {
        // 관련 변수 업데이트
        print("Game Start");
        isStarted = true;
        Time.timeScale = 1.0f;

        // 콜라이더 활성화
        GameObject[] balls=GameObject.FindGameObjectsWithTag("Ball");
        balls[0].GetComponent<Collider2D>().enabled=true;
        balls[1].GetComponent<Collider2D>().enabled=true;

        // 왼쪽 옆면 버튼 숨기기
        hide();
        GameObject.Find("ResetStage").SendMessage("hide");
        GameObject.Find("EscapeToLevel").SendMessage("hide");

        // 아이템 슬롯 숨기기, 타이머 초기화, 현재 스테이지 없애기
        GameObject.Find("ItemPanel").SendMessage("hide");
        GameObject.Find("Timer").SendMessage("reset");
        Destroy(GameObject.Find("StageName"));

        // 게임 시작
        getPausePanel().SendMessage("resume");

        // UI 드러내기
        GameObject.Find("ForceManagerBtn").SendMessage("show");
        GameObject.Find("TimeScaleSlider").SendMessage("show");
        GameObject.Find("ItemPanel").SendMessage("ifGameStart");
    }
}