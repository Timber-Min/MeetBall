using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scene의 이름을 매개변수로 받아 Scene을 변경.
public class SceneController : MonoBehaviour
{
    public static void SwitchScene(string _sceneName)
    {
        print("Scene loaded: " + _sceneName);
        SceneManager.LoadScene(_sceneName);
    }
}
