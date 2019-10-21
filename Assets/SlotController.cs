using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public static int itemNum;
    private int itemCount;
    private static GameObject myImage;
    private static Transform myTransform;

    private static GameObject[] imageList = new GameObject[10];
    private static GridLayoutGroup Grid;
    void Start()
    {
        Grid = gameObject.GetComponent<GridLayoutGroup>();

        itemCount = PanelController.itemCount;
        for (int i = 1; i <= itemCount; i++)
        {
            imageList[i - 1] = GameObject.Find("Image " + i);
        }

        assignImage(0);
    }

    public void assignImage(int itemNum)
    {
        myImage = Instantiate(imageList[itemNum], Vector3.zero, Quaternion.identity);
        myTransform = myImage.GetComponent<Transform>();
        myTransform.SetParent(Grid.transform);
        myTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        myTransform.localPosition = Vector3.zero;
    }
}
