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

    // 드래그 시작시 호출
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        // 아이템 생성
        currentItem = ItemGenerator.itemFactory(itemNum, newPos);
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
        itemBeingDragged = null;
        transform.position = startPosition;
    }
}
