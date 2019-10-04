using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    const double EPSILON = 0.00001;
    const int INF = 65535;

    public static Vector2 asVector2(Vector3 _v)
    {
        // convert Vector3 to Vector2.
        return new Vector2(_v.x, _v.y);
    }

    public static int intABS(int _num)
    {
        // absolute value of an integer.
        return (_num >= 0 ? _num : -_num);
    }

    public static Vector2 vector2ABS(Vector2 _v)
    {
        // make components of Vector2 positive.
        _v.x = Mathf.Abs(_v.x);
        _v.y = Mathf.Abs(_v.y);
        return _v;
    }

    public static bool floatEqual(float _a, float _b)
    {
        // determine two float object is same; round off error is considered.
        return (Mathf.Abs(_a - _b) < EPSILON);
    }

    public static bool vector2Equal(Vector2 _a, Vector2 _b)
    {
        // determine two Vector2 object is same.
        return (floatEqual(_a.x, _b.x) && floatEqual(_a.y, _b.y));
    }
}