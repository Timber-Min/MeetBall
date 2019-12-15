using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckScore : MonoBehaviour
{
    public AbstractScoreChecker condition1, condition2;
    public float amt1, amt2;

    void checkScore()
    {
        string[] Stars = { "☆  ☆  ☆", "★  ☆  ☆", "★  ★  ☆", "★  ★  ★" };
        Text t = gameObject.GetComponentInChildren<Text>();
        int score = 1;

        try
        {
            score += (condition1.check(amt1) ? 1 : 0);
            score += (condition2.check(amt2) ? 1 : 0);
            print(condition2.check(amt2));
        }
        catch (System.NullReferenceException)
        {
            score = 0;
        }

        t.text = Stars[score];
    }
}
