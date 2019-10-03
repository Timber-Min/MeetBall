using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    const double EPSILON = 0.00001;
    const int INF = 65535;

    public static Vector2 asVector2(Vector3 _v)
    {
        return new Vector2(_v.x, _v.y);
    }

    public static int intABS(int _num)
    {
        return (_num >= 0 ? _num : -_num);
    }

    public static bool isFloatEqual(float _a, float _b)
    {
        return (Mathf.Abs(_a - _b) < EPSILON);
    }

    public static bool isVector2Equal(Vector2 _a, Vector2 _b)
    {
        return (Mathf.Abs(_a.x - _b.x) < EPSILON && Mathf.Abs(_a.y - _b.y) < EPSILON);
    }

    public static bool isBetween(GameObject _a, GameObject _b, GameObject _x)
    {
        return isVector2Equal(
            asVector2(_a.transform.position - _x.transform.position).normalized,
            asVector2(_b.transform.position - _x.transform.position).normalized);
    }

    public static bool isInside(GameObject _out, GameObject _in)
    {
        return false;
    }
}