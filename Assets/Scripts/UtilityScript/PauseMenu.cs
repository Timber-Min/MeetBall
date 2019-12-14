using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageProcessor;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        hide(); // 우선 숨기고 시작
    }

    void Update()
    {
        if (Input.GetButtonDown("Resume")) // Resume 버튼이 눌렸으면
        {
            gameObject.SendMessage("resume"); // resume함수 호출
        }
    }

    public void hide() => gameObject.transform.localScale = new Vector3(0, 1, 1);

    public void show() => gameObject.transform.localScale = new Vector3(1, 1, 1);
}
