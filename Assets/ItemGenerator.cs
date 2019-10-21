using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemGenerator : MonoBehaviour
{
    public static GameObject[] itemList = new GameObject[10];

    void Start() => itemList[0] = GameObject.Find("Cube");
    public static GameObject itemFactory(int itemNum, Vector3 startPos)
    {
        GameObject retObject;
        retObject = Instantiate(itemList[itemNum], startPos, Quaternion.identity);
        return retObject;
    }
}