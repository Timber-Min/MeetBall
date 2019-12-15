using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageProcessor : MonoBehaviour
{
    // 변수 모음
    public static bool isStarted; // 게임 시작 버튼을 눌렀는지 여부 (isPaused보다 우선순위 높음)
    public static bool isPaused; // 현재 일시정지 상태 (isStarted, isCleared보다 우선순위 낮음)
    public static bool isCleared; // 두 공이 맞닿았는지 여부 (isPaused보다 우선순위 높음)
    public static int currentLevel = 0, prevLevel; // 레벨 관련 변수
    public static int currentStage = 0, prevStage; // 스테이지 관련 변수
    private static GameObject restartButton; // 해당 스테이지의 resetButton
    private static GameObject levelButton; // 해당 스테이지의 resetButton


    void Awake()
    {
        // Scene이 로드되자마자 호출(Start보다 앞섬)
        // 레벨, 스테이지 관련 변수 업데이트
        if (currentLevel > 0) prevLevel = currentLevel;
        if (currentStage > 0) prevStage = currentStage;
        try
        {
            string[] sceneNames = SceneManager.GetActiveScene().name.Split('-');
            currentLevel = int.Parse(sceneNames[0]);
            currentStage = int.Parse(sceneNames[1]);
        }
        catch
        {
            currentLevel = 0;
            currentStage = 0;
        }
        reset();
    }

    public static void reset()
    {
        // 게임 진행에 필요한 변수 초기화
        Time.timeScale = 1.0f;
        isStarted = isCleared = isPaused = false; // 전부 false
        restartButton = GameObject.Find("ResetStage");
        levelButton = GameObject.Find("EscapeToLevel");
        GameObject stageName = GameObject.Find("StageName"); // 해당 Scene의 이름을 저장
        if (stageName != null) stageName.GetComponent<Text>().text = SceneManager.GetActiveScene().name;
    }

    public static GameObject getRestartBtn()
    {
        return restartButton;
    }

    public static GameObject getLevelBtn()
    {
        return levelButton;
    }
}
