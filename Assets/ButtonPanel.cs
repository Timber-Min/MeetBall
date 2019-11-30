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
    private string thisScene;
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

        thisScene = SceneManager.GetActiveScene().name;
    }

    private void gotoMenu() => SceneManager.LoadScene("MainMenu");

    private void restart()
    {
        StageProcessor.reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void gotoNext()
    {
        string nextScene = "";
        int level, stage;
        try
        {
            level = int.Parse(thisScene[0].ToString());
            stage = int.Parse(thisScene[2].ToString());
            if (stage == 8)
            {
                nextScene = "MainMenu";
            }
            else
            {
                nextScene = string.Format("{0}-{1}", level, stage + 1);
            }
        }
        catch
        {
            nextScene = "MainMenu";
        }
        finally
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
