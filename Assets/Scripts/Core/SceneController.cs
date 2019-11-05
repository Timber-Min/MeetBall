using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sceneName;

    public static void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
