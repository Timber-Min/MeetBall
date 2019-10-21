using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public static int itemCount = 5;
    public GameObject panel;
    public GameObject slot;
    public static GameObject[] slotList;
    public static GameObject[] itemImageList;
    private GridLayoutGroup grid;
    private Vector3 autoLocalScale;
    private SlotController slotCode;
    public Sprite demoSprite;


    void Start()
    {
        slotList = new GameObject[10];
        panel = GameObject.Find("Panel");
        slot = GameObject.Find("Slot");
        grid = panel.GetComponent<GridLayoutGroup>();
        // Debug.Log(grid.spacing);
        grid.spacing = new Vector2(30, 30);

        autoLocalScale = new Vector3(1.0f, 1.0f, 1.0f);

        // demoSprite = Resources.Load("piston", typeof(Sprite)) as Sprite;

        slotList[0] = slot;
        slotList[0].name = "Slot1";

        for (int i = 1; i < itemCount; i++)
        {
            // GameObject slotList[i];
            slotList[i] = Instantiate(slot, Vector3.zero, Quaternion.identity);
            slotList[i].transform.SetParent(grid.transform);
            slotList[i].transform.localScale = autoLocalScale;
            slotList[i].transform.localPosition = Vector3.zero;
            slotList[i].name = "Slot" + (i + 1);
        }

        for (int i = 0; i < itemCount; i++)
        {
            Debug.Log(i);
            GameObject image = slotList[i].transform.GetChild(0).gameObject;
            Debug.Log(image.transform.localScale);
            image.GetComponent<Image>().sprite = demoSprite;
        }

        // for (int i = 0; i < itemCount; i++)
        // {
        //     Debug.Log(slotList[i].name);
        //     slotCode = slotList[i].GetComponent<SlotController>();
        //     slotCode.assignImage(i);
        // }
    }

    public void hide()
    {
        Transform myTransform = grid.GetComponent<Transform>();
        myTransform.localScale = new Vector3(0, 0, 0);
    }
}
