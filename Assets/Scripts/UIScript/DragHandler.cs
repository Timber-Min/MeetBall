using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 인벤토리에서 아이템 드래그 후 배치
public class DragHandler : AbstractUIHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    private static GameObject currentItem;
    private Transform currentTransform;
    public int itemNum;
    public static GameObject myItem;
    private string[] rotatables = new string[10];
    private GameObject[] objects = new GameObject[100];
    private int objectCnt = 0;

    void Start()
    {
        rotatables[0] = "Piston";
        rotatables[1] = "Launcher";
    }

    // 드래그 시작시 호출
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        // 아이템 생성
        currentItem = ItemGenerator.itemFactory(itemNum, newPos);
        objects[objectCnt] = currentItem;
        objectCnt += 1;
        currentTransform = currentItem.GetComponent<Transform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 이미지 숨기기   
        hide();
        Vector3 currentPos = Input.mousePosition;
        Vector3 newPos = Camera.main.ScreenToWorldPoint(currentPos);
        newPos.z = 0;
        // 아이템 배치
        currentTransform.position = newPos;
    }

    public void OnEndDrag(PointerEventData evendData)
    {
        // 이미지 보이기
        show();
        makeHandle(currentItem);
        // currentItem.SendMessage("makeHandle");
        itemBeingDragged = null;
        transform.position = startPosition;
    }

    private void makeHandle(GameObject tool)
    {
        string name = tool.name;
        if (string.Equals(name, rotatables[0]) || string.Equals(name, rotatables[1]))
        {
            tool.SendMessage("makeHandle");
        }
    }

    public void ifGameStart()
    {
        print(objectCnt);
        for (int i = 0; i < objectCnt; i++)
        {
            string name = objects[i].name;
            if (string.Equals(name, rotatables[0]) || string.Equals(name, rotatables[1]))
            {
                objects[i].SendMessage("destroyHandle");
            }
        }
    }
}
