using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 나중에 아마도 지우게 될 파일
public class SlotController : MonoBehaviour
{
    public static int itemNum;
    private int itemCount;
    private static GameObject myImage;
    private static Transform myTransform;

    private static GameObject[] imageList = new GameObject[10];
    private static GridLayoutGroup Grid;
}

