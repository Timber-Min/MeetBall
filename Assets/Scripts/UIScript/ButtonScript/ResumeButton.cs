using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

public class ResumeButton : MonoBehaviour
{
    // 일시정지 상태를 해제하는 버튼
    private Slider timeScaleSlider;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(resume);
        timeScaleSlider=GameObject.Find("TimeScaleSlider").GetComponent<Slider>();
    }

    void resume()
    {
        if (!isStarted || isCleared || !isPaused) return; // 게임 시작 X or 클리어 or 일시정지 중이 아닐 경우 리턴
        isPaused = false; // 변수 업데이트
        Time.timeScale = (float)System.Math.Pow(4, timeScaleSlider.value); // 시간을 다시 흐르게 한다

        getPausePanel().SendMessage("hide"); // 메뉴 숨기기
        print("Resumed"); 
    }
}
