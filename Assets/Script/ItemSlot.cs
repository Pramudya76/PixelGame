using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount <= 1)
        {
            GameObject Dropped = eventData.pointerDrag;
            Dropped.transform.SetParent(transform, false);
            DragItem dragItem = Dropped.GetComponent<DragItem>();
            dragItem.parentAfterDrag = transform;
            
        }
    }
    
}
