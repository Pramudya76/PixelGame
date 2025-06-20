using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PrototypeInventory : MonoBehaviour
{
    //private ChestInteraction CI;
    public GameObject[] images;
    public GameObject imagePrefabs;
    //public ItemData itemData;
    // Start is called before the first frame update
    void Start()
    {
        //CI = GameObject.FindWithTag("Chest").GetComponent<ChestInteraction>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(ItemData itemData)
    {
        foreach (GameObject slot in images)
        {
            if (slot.transform.childCount > 0)
            {
                DragItem itemExiting = slot.transform.GetChild(0).GetComponent<DragItem>();
                if (itemExiting != null && itemExiting.itemData == itemData)
                {
                    itemExiting.counts++;
                    itemExiting.UpdateText();
                    return;
                }
            }
        }

        foreach (GameObject slot in images)
        {
            if (slot.transform.childCount == 0)
            {
                GameObject newItem = Instantiate(imagePrefabs, slot.transform);
                Image img = newItem.GetComponent<Image>();
                img.sprite = itemData.Icon;

                DragItem dragItem = newItem.AddComponent<DragItem>();
                dragItem.itemData = itemData;
                dragItem.counts = 1;
                dragItem.stackText = newItem.GetComponentInChildren<TextMeshProUGUI>();
                dragItem.UpdateText();

                newItem.transform.localPosition = Vector3.zero;
                return;
            }
        }
        // for (int a = 0; a < images.Length; a++)
        // {
        //     if (images[a].transform.childCount == 0)
        //     {
        //         GameObject newItem = Instantiate(imagePrefabs, images[a].transform);
        //         newItem.GetComponent<Image>().sprite = itemData.Icon;
        //         newItem.AddComponent<DragItem>();
        //         newItem.transform.localPosition = Vector3.zero;
        //         break;
        //     }
        // }
    }

}
