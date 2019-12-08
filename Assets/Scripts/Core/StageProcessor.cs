using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageProcessor : MonoBehaviour
{
    // 변수 모음
    public static bool isStarted;
    public static bool isPaused;
    public static bool isCleared;
    public static int currentLevel;
    public static int currentStage;
    private static GameObject menuPanel;
    private static GameObject mainCamera;

    void Awake()
    {
        Time.timeScale = 0;
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
        isStarted = isCleared = false;
        isPaused = true;
        menuPanel = GameObject.Find("MenuPanel");
        mainCamera = GameObject.Find("Main Camera");
    }

    public static GameObject getMenuPanel() => menuPanel;

    public static GameObject getMainCamera() => mainCamera;
}
