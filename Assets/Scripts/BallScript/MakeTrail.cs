using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 공의 자취를 점으로 표시한다.
public class MakeTrail : MonoBehaviour
{
    // Trail: 자취를 만들 점이 되는 객체.
    // Parent: 객체가 복제되어 들어갈 빈 GameObject.
    // trailRate: 자취가 찍힐 시간 간격.
    // trailFadetime: 자취가 사라질 시간 간격(자취의 수명).
    public GameObject Trail;
    public GameObject Parent;
    private float trailRate = 0.5f;
    private float trailFadeTime = 4f;

    // trails: 자취의 모음.
    // nextTrail: 다음 자취가 복제될 시간.
    List<TrailClass> trails = new List<TrailClass>();
    float nextTrail = 0f;

    void Update()
    {
        foreach (TrailClass tr in trails)
        {
            tr.update();
        }

        // 복제될 시간이면 자취 객체를 공의 위치에 복제, trails에 추가.
        if (Time.time > nextTrail)
        {
            nextTrail += trailRate;
            GameObject clone = Instantiate(Trail, transform.position, Quaternion.identity, Parent.transform);
            trails.Add(new TrailClass(clone, Time.time, trailFadeTime));
        }
    }
}

// 자취 클래스.
class TrailClass
{
    // obj: 자취 객체.
    // t: 자취가 만들어진 시간.
    // fadingT: 자취가 사라질 시간 간격(자취의 수명).
    GameObject obj;
    private float t;
    private float fadingT;

    public TrailClass(GameObject gameObject, float time, float fadingTime)
    {
        obj = gameObject;
        t = time;
        fadingT = fadingTime;
    }

    public void update()
    {
        // 자취의 투명도(alpha)는 시간이 지날수록 투명해진다.
        float alpha = 1 - (Time.time - t) / fadingT;
        // 투명도가 0 이하이면 수명이 다 되었음을 의미.
        if (alpha <= 0f)
        {
            Object.Destroy(obj);
        }
        else
        {
            Color c = obj.GetComponent<SpriteRenderer>().color;
            obj.GetComponent<SpriteRenderer>().color = new Vector4(c.r, c.g, c.b, alpha);
        }
    }
}
