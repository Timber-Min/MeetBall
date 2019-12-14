using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetStageButton : AbstractUIHandler
{
    // 스테이지를 다시 시작하는 버튼
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(restartStage);
    }

    void restartStage()
    {
        // Scene 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
