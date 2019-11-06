using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 화살표가 미트볼이 받는 힘의 방향을 가리키게 한다.
public class ArrowNavigator : MonoBehaviour
{
    private GameObject[] balls;
    public GameObject[] arrows;
    int cnt;

    void Start()
    {
        // 미트볼 GameObject들을 찾고 arrows와 배열의 크기를 비교하여 크기가 다르면 오류를 발생시킨다.
        balls = GameObject.FindGameObjectsWithTag("Ball");
        if (balls.Length != arrows.Length)
            throw new System.ArgumentException("Length of two arrays, 'balls' and 'arrows' must be same.");
        cnt = balls.Length;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < cnt; i++)
        {
            GameObject a = arrows[i];
            Vector2 force = SpaghettiForce.ballsNetGravitationalForce[i];

            if (force.magnitude > 1e-4)
            {
                a.SetActive(true);
                // 화살표를 공의 위치로 이동시키고 힘의 방향으로 회전시킨다.
                a.transform.SetPositionAndRotation(balls[i].transform.position, Quaternion.FromToRotation(Vector2.up, force));
            }
            else
            {
                a.SetActive(false);
            }
        }
    }
}