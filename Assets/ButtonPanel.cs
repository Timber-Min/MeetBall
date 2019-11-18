using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPanel : MonoBehaviour
{
    private Button menuBtn, restartBtn, nextBtn;
    private Transform myTransform;
    private GameObject mCamera;
    void Start()
    {
        myTransform = gameObject.transform;
        menuBtn = myTransform.GetChild(0).gameObject.GetComponent<Button>();
        restartBtn = myTransform.GetChild(1).gameObject.GetComponent<Button>();
        nextBtn = myTransform.GetChild(2).gameObject.GetComponent<Button>();

        menuBtn.onClick.AddListener(gotoMenu);
        restartBtn.onClick.AddListener(restart);
        nextBtn.onClick.AddListener(gotoNext);

        mCamera = GameObject.Find("Main Camera");
    }

    private void gotoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void restart()
    {
        mCamera.GetComponent<MainCamera>().isGameStart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void gotoNext()
    {

    }
}
