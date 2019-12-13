using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameQuitScript : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Quit);
    }

    public static void Quit()
    {
        // 게임 종료
        #if UNITY_EDITOR // 유니티 에디터 모드
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER // 유니티 웹플레이어 모드
            Application.OpenURL("https://google.com");
        #else // 응용프로그램 모드
            Application.Quit();
        #endif
    }
}
