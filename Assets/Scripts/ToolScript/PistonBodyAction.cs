using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageProcessor;

public class PistonBodyAction : AbstractToolAction
{
    // Start is called before the first frame update
    private GameObject pistonM;

    void Start()
    {
        // Mother Object 설정
        pistonM = gameObject.transform.parent.gameObject;
    }

    // 마우스 클릭 감지
    void OnMouseDown()
    {
        // 피스톤 작동 - 시작 전 or 클리어 후 작동 X
        if(!isStarted || isCleared) return;
        print("piston mouse down");
        pistonM.SendMessage("movePlate");
    }
}
