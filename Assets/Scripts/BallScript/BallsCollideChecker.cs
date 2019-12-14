using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StageProcessor;

public class BallsCollideChecker : MonoBehaviour
{
    public GameObject otherBall; // 다른 공
    private GameObject winPanel; // 게임 이겼을 때 뜨는 Panel
    private Text winText; // 게임 승리 텍스트
    private AudioSource winSound; // 게임 승리 효과음
    public GameObject firework; // 폭죽 VFX

    void Start()
    {
        winText = GameObject.Find("WinText").GetComponent<Text>();
        winText.gameObject.SetActive(false); // 활성화 되어 있으면 Resume 버튼이 안 눌림
        winPanel = GameObject.Find("WinPanel");
        winSound = gameObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(otherBall))
        {
            // 승리 효과
            winText.gameObject.SetActive(true); // 승리 메시지 활성화
            winText.text = "You Win!"; // 승리 메시지 띄우고
            firework.SetActive(true); // 폭죽 ON
            winPanel.SendMessage("show"); // WinPanel 보여줌

            // 효과음 출력
            winSound.volume = (float)SoundManager.SFXscale / 100;
            winSound.Play();

            // 변수 업데이트
            isCleared=true;
            isPaused=false;
            Time.timeScale = 0f; // 시간 멈추기
        }
    }
}
