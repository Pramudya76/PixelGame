using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RiceHarvest : MonoBehaviour
{
    public LayerMask layer;
    private GameObject Button;
    [HideInInspector] public bool isNear = false;
    private UIManager UIManager;
    private PrototypeInventory itemSlotManager;
    public ItemData objectDrop;
    public ItemData seedRice;
    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        UIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        itemSlotManager = GameObject.FindWithTag("InventoryManager").GetComponent<PrototypeInventory>();
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (Button == null)
        {
            GameObject ButtonObjt = GameObject.FindWithTag("ButtonF");
            if (ButtonObjt != null)
            {
                Button = ButtonObjt.GetComponent<GameObject>();
            }
        }
        Button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D areaHarvest = Physics2D.OverlapCircle(transform.position, 0.4f, layer);
        if (areaHarvest != null)
        {
            if (!isNear)
            {
                isNear = true;
                UIManager.ShowButton(transform.position + Vector3.up * 0.5f, this);
            }
            else if (UIManager.IsThisActiveRice(this))
            {
                UIManager.ShowButton(transform.position + Vector3.up * 0.5f, this);
            }
            if (Input.GetKeyDown(KeyCode.F) && UIManager.IsThisActiveRice(this))
            {
                int random = Random.Range(1, 3);
                isNear = false;
                UIManager.HideButton(this);
                UIManager.ResetAllNear();
                itemSlotManager.AddItem(objectDrop);
                if (random == 1)
                {
                    itemSlotManager.AddItem(seedRice);
                }
                GM.RemoveRice(this.gameObject);
                Destroy(gameObject);

                //StartCoroutine(CDDestroy());
            }
        }
        else if (areaHarvest == null && isNear)
        {
            isNear = false;
            UIManager.HideButton(this);
        }
    }

    // IEnumerator CDDestroy()
    // {
    //     UIManager.IsThisNotActiveRice(this);
    //     yield return new WaitForSeconds(0.2f);
    //     Destroy(gameObject);
    // }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.4f);       
    }
}
