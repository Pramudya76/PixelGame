using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PrototypeInventory : MonoBehaviour
{
    //private ChestInteraction CI;
    public GameObject[] images;
    public GameObject[] slotTransaksi;
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
        //Debug.Log("Menambahkan item: " + itemData.nameItem);
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

    public bool hasItem(String itemName)
    {
        foreach (GameObject slot in images)
        {
            if (slot.transform.childCount > 0)
            {
                DragItem inventory = slot.transform.GetChild(0).GetComponent<DragItem>();
                if (inventory != null && inventory.itemData.nameItem == itemName)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void RemoveItem(ItemData itemData)
    {
        foreach (GameObject slot in images)
        {
            if (slot.transform.childCount > 0)
            {
                DragItem itemExiting = slot.transform.GetChild(0).GetComponent<DragItem>();
                if (itemExiting != null && itemExiting.itemData == itemData)
                {
                    itemExiting.counts--;
                    itemExiting.UpdateText();
                    if (itemExiting.counts <= 0)
                    {
                        Destroy(itemExiting.gameObject);
                    }
                    return;
                }
            }
        }

        // foreach (GameObject slot in images)
        // {
        //     if (slot.transform.childCount == 0)
        //     {
        //         GameObject newItem = Instantiate(imagePrefabs, slot.transform);
        //         Image img = newItem.GetComponent<Image>();
        //         img.sprite = itemData.Icon;

        //         DragItem dragItem = newItem.AddComponent<DragItem>();
        //         dragItem.itemData = itemData;
        //         dragItem.counts = 1;
        //         dragItem.stackText = newItem.GetComponentInChildren<TextMeshProUGUI>();
        //         dragItem.UpdateText();

        //         newItem.transform.localPosition = Vector3.zero;
        //         return;
        //     }
        // }
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


    public bool itemTransaction(ItemData itemName, int amount)
    {
        foreach (var slot in slotTransaksi)
        {
            if (slot.transform.childCount > 0)
            {
                DragItem dragItem = slot.transform.GetChild(0).GetComponent<DragItem>();
                //Debug.Log("Cek item: " + dragItem.itemData.nameItem + ", jumlah: " + dragItem.counts);
                if (dragItem != null && dragItem.itemData == itemName)
                {
                    if (dragItem.counts >= amount)
                    {
                        dragItem.counts -= amount;
                        dragItem.UpdateText();
                        if (dragItem.counts <= 0)
                        {
                            Destroy(dragItem.gameObject);
                        }
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public int getItemCount(ItemData itemData)
    {
        //Debug.Log("dragItem.counts");
        foreach (GameObject transaksi in slotTransaksi)
        {
            DragItem dragItem = transaksi.GetComponent<DragItem>();
            if (dragItem != null && dragItem.itemData.nameItem == itemData.nameItem)
            {
                return dragItem.counts;
            }
        }
        return 0;
    }



}
