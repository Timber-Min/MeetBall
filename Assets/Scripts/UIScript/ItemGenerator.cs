using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemGenerator : MonoBehaviour
{
    public static Dictionary<string, GameObject> itemList = new Dictionary<string, GameObject>();

    void Awake()
    {
        itemList["Launcher"] = GameObject.Find("Launcher");
        itemList["VelocityResetter"] = GameObject.Find("VelocityResetter");
        itemList["VectorReverser"] = GameObject.Find("VectorReverser");
        itemList["Accelerator"] = GameObject.Find("Accelerator");
        itemList["Piston"] = GameObject.Find("Piston");

        itemList["Launcher"].SendMessage("toggleRotate");
        itemList["Piston"].SendMessage("toggleRotate");
    }

    public static GameObject itemFactory(string itemName, Vector3 startPos)
    {
        // returns instantiated GameObject.
        GameObject retObject;
        retObject = Instantiate(itemList[itemName], startPos, Quaternion.identity);
        retObject.name = itemList[itemName].name;
        return retObject;
    }
}