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
    public ItemData Gold;
    public ItemData Iron;
    public Transform positionResultSlot;
    // Start is called before the first frame update
    void Start()
    {
        PI = GameObject.FindWithTag("InventoryManager").GetComponent<PrototypeInventory>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount <= 1)
        {
            if (PI.itemTransaction(wheat, 5))
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
            else if (PI.itemTransaction(carrot, 5))
            {
                GameObject IronObject = Instantiate(ImagePrefabs, positionResultSlot);
                Image img = IronObject.GetComponent<Image>();
                img.sprite = Iron.Icon;

                DragItem dragItem = IronObject.AddComponent<DragItem>();
                dragItem.itemData = Iron;
                dragItem.counts = 1;
                dragItem.stackText = IronObject.GetComponentInChildren<TextMeshProUGUI>();
                dragItem.UpdateText();

                IronObject.transform.localPosition = Vector3.zero;
            }
            else if (PI.itemTransaction(wheat, 10))
            {
                GameObject GoldObject = Instantiate(ImagePrefabs, positionResultSlot);
                Image img = GoldObject.GetComponent<Image>();
                img.sprite = Gold.Icon;

                DragItem dragItem = GoldObject.AddComponent<DragItem>();
                dragItem.itemData = Gold;
                dragItem.counts = 1;
                dragItem.stackText = GoldObject.GetComponentInChildren<TextMeshProUGUI>();
                dragItem.UpdateText();

                GoldObject.transform.localPosition = Vector3.zero;
            }
            else if (PI.itemTransaction(carrot, 1))
            {
                GameObject WheatObject = Instantiate(ImagePrefabs, positionResultSlot);
                Image img = WheatObject.GetComponent<Image>();
                img.sprite = wheat.Icon;

                DragItem dragItem = WheatObject.AddComponent<DragItem>();
                dragItem.itemData = wheat;
                dragItem.counts = 1;
                dragItem.stackText = WheatObject.GetComponentInChildren<TextMeshProUGUI>();
                dragItem.UpdateText();

                WheatObject.transform.localPosition = Vector3.zero;
            }
                
            
        }
    }
}
