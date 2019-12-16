using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 아이템 인벤토리 생성
public class PanelController : MonoBehaviour
{
    public static int itemCount;
    public GameObject slot;
    public static GameObject[] slotList;
    public static GameObject[] itemImageList;
    private GridLayoutGroup grid;
    private Vector3 autoLocalScale;
    private string[] toolsList;

    void Start()
    {
        string[] list = GetComponent<ToolsForStages>().getToolsForStages();
        for (int i = 0; i < list.Length; i += 1)
        {
            if (list[i].Equals(SceneManager.GetActiveScene().name))
            {
                string tools = list[i + 1];
                toolsList = tools.Split(',');
                itemCount = toolsList[0] == "" ? 0 : toolsList.Length;
                break;
            }
        }

        slotList = new GameObject[10];
        slot = GameObject.Find("Slot");

        // GridLayoutGroup 사용으로 자동 크기 조정
        grid = gameObject.GetComponent<GridLayoutGroup>();
        grid.spacing = new Vector2(60, 60);
        autoLocalScale = new Vector3(1.0f, 1.0f, 1.0f);

        if (itemCount == 0)
        {
            slot.SetActive(false);
            return;
        }

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
            GameObject image = slotList[i].transform.GetChild(0).gameObject;
            image.GetComponent<Image>().sprite = ItemGenerator.itemList[toolsList[i]].GetComponent<SpriteRenderer>().sprite;
            image.GetComponent<DragHandler>().itemName = toolsList[i];
        }

    }

    public void hide()
    {
        grid.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ifGameStart()
    {
        for (int i = 0; i < itemCount; i++)
        {
            GameObject itemImage = slotList[i].transform.GetChild(0).gameObject;
            itemImage.SendMessage("ifGameStart");
        }
    }
}
