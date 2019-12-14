using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObjectAction : AbstractToolAction
{
    private PortalAction manager;

    // 인스턴스에 해당하는 PortalManager을 귀속하는 함수.
    void setManager(PortalAction _manager)
    {
        manager = _manager;
    }

    // 충돌이 발생하면 객체를 이동시킨다.
    protected override void triggerEnterAction(Collider2D _other)
    {
        if (_other.tag == "Ball" && _other.isTrigger == false)
        {
            manager.teleport(_other, GetComponent<Collider2D>());
        }
    }
}
