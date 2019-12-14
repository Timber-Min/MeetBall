using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

public class GameStartButton : AbstractUIHandler
{
    // 스테이지 플레이 시작 버튼
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(gameStart);
    }

    public void gameStart()
    {
        // 관련 변수 업데이트
        print("Game Start");
        isStarted = true;
        Time.timeScale = 1.0f;

        // 공 콜라이더 활성화
        GameObject[] balls=GameObject.FindGameObjectsWithTag("Ball");
        balls[0].GetComponent<Collider2D>().enabled=true;
        balls[1].GetComponent<Collider2D>().enabled=true;

        // 왼쪽 옆면 버튼 숨기기
        hide();
        getRestartBtn().SendMessage("hide");
        getLevelBtn().SendMessage("hide");

        // 아이템 슬롯 숨기기, 타이머 초기화, 현재 스테이지 없애기
        GameObject.Find("ItemPanel").SendMessage("hide");
        GameObject.Find("Timer").SendMessage("reset");
        Destroy(GameObject.Find("StageName"));

        // 게임 시작 - resume 버튼 누르기
        GameObject.Find("Resume").SendMessage("resume");

        // UI 드러내기
        GameObject.Find("ForceManagerBtn").SendMessage("show");
        GameObject.Find("TimeScaleSlider").SendMessage("show");
        GameObject.Find("ItemPanel").SendMessage("ifGameStart");
    }
}