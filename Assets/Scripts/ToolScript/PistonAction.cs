using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonAction : AbstractToolAction
{
    // body는 본체, plate는 미는 부분
    public GameObject body;
    public Rigidbody2D plate;
    
    void FixedUpdate()
    {
        // dist는 piston의 미는 부분과 본체 부분 사이의 거리
        float dist = Mathf.Abs(
            Vector2.Distance(body.GetComponent<Renderer>().transform.position,
            plate.GetComponent<Renderer>().transform.position)) / 32;
        // dist가 일정 값 이상으로 커지면
        if (dist > 0.03f)
            // 미는 부분과 본체 사이에 인력이 작용
            undoPlate();
    }

    // 피스톤의 본체와 미는 부분 사이에 척력이 작용
    private void movePlate()
    {
        // rot은 피스톤이 회전한 각을 의미, DEGREE 사용
        float rot = plate.transform.rotation.eulerAngles.z * Mathf.PI / 180;
        // dir 벡터는 rot을 이용한 적당한 단위벡터
        Vector2 dir = new Vector2(-Mathf.Cos(rot), -Mathf.Sin(rot));
        // 피스톤이 정지해있을 때
        if (vector2Equal(plate.velocity, Vector2.zero))
            // dir 방향으로 척력이 작용
            plate.AddForce(dir * (int)3e8);
    }

    // 피스톤의 본체와 미는 부분 사이에 인력이 작용
    private void undoPlate()
    {
        float rot = plate.transform.rotation.eulerAngles.z * Mathf.PI / 180;
        Vector2 dir = new Vector2(-Mathf.Cos(rot), -Mathf.Sin(rot));
        // dir 반대 방향으로 인력이 작용
        plate.AddForce(-dir * (int)3e8);
    }

    private bool floatEqual(float _a, float _b)
    {
        // determine two float object is same; round off error is considered.
        const double EPSILON = 0.00001;
        return (Mathf.Abs(_a - _b) < EPSILON);
    }

    private bool vector2Equal(Vector2 _a, Vector2 _b)
    {
        // determine two Vector2 object is same.
        return (floatEqual(_a.x, _b.x) && floatEqual(_a.y, _b.y));
    }
}
