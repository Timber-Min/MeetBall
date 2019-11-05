using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : AbstractUIHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    private static GameObject currentItem;
    private Transform currentTransform;
    public int itemNum;
    public static GameObject myItem;

    void Start()
    {
        // itemNum = 0;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        currentItem = ItemGenerator.itemFactory(itemNum, newPos);
        currentTransform = currentItem.GetComponent<Transform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        hide();
        Vector3 currentPos = Input.mousePosition;
        Vector3 newPos = Camera.main.ScreenToWorldPoint(currentPos);
        newPos.z = 0;
        currentTransform.position = newPos;
    }

    public void OnEndDrag(PointerEventData evendData)
    {
        show();
        itemBeingDragged = null;
        transform.position = startPosition;
    }

    private void hide() => transform.localScale = new Vector3(0, 0, 0);

    private void show() => transform.localScale = new Vector3(1, 1, 1);

}
