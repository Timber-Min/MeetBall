using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMaker : MonoBehaviour
{
    public GameObject Trail;
    public GameObject Parent;
    public float TrailingRate = 0.5f;
    public float TrailFadingTime = 4f;

    List<TrailClass> trails = new List<TrailClass>();
    float nextTrail = 0f;

    void Update()
    {
        foreach(TrailClass tr in trails)
        {
            tr.update();
        }

        if(Time.time > nextTrail)
        {
            nextTrail += TrailingRate;
            GameObject clone = Instantiate(Trail, transform.position, Quaternion.identity, Parent.transform);
            trails.Add(new TrailClass(clone, Time.time, TrailFadingTime));
        }
    }
}

class TrailClass
{
    GameObject obj;
    float t;
    float fadingT;

    public TrailClass(GameObject gameObject, float time, float fadingTime)
    {
        obj = gameObject;
        t = time;
        fadingT = fadingTime;
    }

    public void update()
    {
        float temp = 1 - (Time.time - t) / fadingT;
        if (temp <= 0f)
        {
            GameObject.Destroy(obj);
        }
        else
        {
            Color c = obj.GetComponent<SpriteRenderer>().color;
            obj.GetComponent<SpriteRenderer>().color = new Vector4(c.r, c.g, c.b, temp);
        }
    }
}
