using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void SwitchToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void SwitchToStage1()
    {
        SceneManager.LoadScene("Scene1");
    }
}
