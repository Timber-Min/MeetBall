using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static StageProcessor;

// 게임 이기고 나서 뜨는 세 개의 버튼 관련 스크립트
public class ButtonPanel : MonoBehaviour
{
    private Button menuBtn, restartBtn, nextBtn;
    private Transform myTransform;
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

        thisScene = SceneManager.GetActiveScene().name;
    }

    private void gotoMenu() => SceneManager.LoadScene("L" + thisScene[0]);

    private void restart()
    {
        reset();
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
                nextScene = "L" + level.ToString();
            }
            else
            {
                nextScene = string.Format("{0}-{1}", level, stage + 1);
            }
        }
        catch
        {
            nextScene = "GameIntroScene";
        }
        finally
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
