using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTrail : MonoBehaviour
{
    public GameObject Trail;
    public GameObject Parent;
    private float trailRate = 0.5f;
    private float trailFadeTime = 4f;

    List<TrailClass> trails = new List<TrailClass>();
    float nextTrail = 0f;

    void Update()
    {
        foreach (TrailClass tr in trails)
        {
            tr.update();
        }

        if (Time.time > nextTrail)
        {
            nextTrail += trailRate;
            GameObject clone = Instantiate(Trail, transform.position, Quaternion.identity, Parent.transform);
            trails.Add(new TrailClass(clone, Time.time, trailFadeTime));
        }
    }
}

class TrailClass
{
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
        float alpha = 1 - (Time.time - t) / fadingT;
        if (alpha <= 0f)
        {
            GameObject.Destroy(obj);
        }
        else
        {
            Color c = obj.GetComponent<SpriteRenderer>().color;
            obj.GetComponent<SpriteRenderer>().color = new Vector4(c.r, c.g, c.b, alpha);
        }
    }
}
