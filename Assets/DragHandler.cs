using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    // Vector3 
    // Start is called before the first frame update
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData evendData)
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
