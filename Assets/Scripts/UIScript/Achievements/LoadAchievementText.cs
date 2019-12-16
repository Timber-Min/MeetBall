using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadAchievementText : MonoBehaviour
{
    void Start()
    {
        Text t=gameObject.GetComponent<Text>();
        t.text="[도전 과제]\n\n";
        string[] list = GetComponent<Achievements_text>().getAchievementsText();
        for(int i=0;i<list.Length;i+=1)
        {
            if(list[i].Equals(SceneManager.GetActiveScene().name))
            {
                t.text+=list[i+1]+"\n\n"+list[i+2];
                break;
            }
        }
    }
}
