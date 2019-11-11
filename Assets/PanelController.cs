using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 아이템 인벤토리 생성
public class PanelController : MonoBehaviour
{
    public static int itemCount = 4;
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

        // GridLayoutGroup 사용으로 자동 크기 조정
        grid = panel.GetComponent<GridLayoutGroup>();
        grid.spacing = new Vector2(60, 60);
        autoLocalScale = new Vector3(1.0f, 1.0f, 1.0f);

        slotList[0] = slot;
        slotList[0].name = "Slot1";

        // 슬롯 만들기
        for (int i = 1; i < itemCount; i++)
        {
            slotList[i] = Instantiate(slot, Vector3.zero, Quaternion.identity);
            slotList[i].transform.SetParent(grid.transform);
            slotList[i].transform.localScale = autoLocalScale;
            slotList[i].transform.localPosition = Vector3.zero;
            slotList[i].name = "Slot" + (i + 1);
        }

        // 슬롯에 아이템 이미지 집어넣기
        for (int i = 0; i < itemCount; i++)
        {
            Debug.Log(i);
            GameObject image = slotList[i].transform.GetChild(0).gameObject;
            image.GetComponent<Image>().sprite = demoSprite;
            image.GetComponent<DragHandler>().itemNum = i;
        }

    }

    public void hide()
    {
        Transform myTransform = grid.GetComponent<Transform>();
        myTransform.localScale = new Vector3(0, 0, 0);
    }
}
