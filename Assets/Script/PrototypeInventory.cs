using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PrototypeInventory : MonoBehaviour
{
    //private ChestInteraction CI;
    public GameObject[] images;
    public GameObject imagePrefabs;
    // Start is called before the first frame update
    void Start()
    {
        //CI = GameObject.FindWithTag("Chest").GetComponent<ChestInteraction>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(Sprite item)
    {
        for (int a = 0; a < images.Length; a++)
        {
            if (images[a].transform.childCount == 0)
            {
                GameObject newItem = Instantiate(imagePrefabs, images[a].transform);
                newItem.GetComponent<Image>().sprite = item;
                newItem.AddComponent<DragItem>();
                newItem.transform.localPosition = Vector3.zero;
                break;
            }
        }
    }

}
