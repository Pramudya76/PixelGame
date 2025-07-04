using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PriceItemTransaction : MonoBehaviour, IDropHandler
{
    private PrototypeInventory PI;
    public GameObject ImagePrefabs;
    public ItemData carrot;
    public ItemData wheat;
    public Transform positionResultSlot;
    // Start is called before the first frame update
    void Start()
    {
        PI = GameObject.FindWithTag("InventoryManager").GetComponent<PrototypeInventory>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount <= 1 && PI.itemTransaction(wheat, 5))
        {
            GameObject CarrotObject = Instantiate(ImagePrefabs, positionResultSlot);
            Image img = CarrotObject.GetComponent<Image>();
            img.sprite = carrot.Icon;

            DragItem dragItem = CarrotObject.AddComponent<DragItem>();
            dragItem.itemData = carrot;
            dragItem.counts = 5;
            dragItem.stackText = CarrotObject.GetComponentInChildren<TextMeshProUGUI>();
            dragItem.UpdateText();

            CarrotObject.transform.localPosition = Vector3.zero;
            //return;
            //Debug.Log("Carrot ada");
        }
    }
}
