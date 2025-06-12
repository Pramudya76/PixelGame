using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ChestInteraction : MonoBehaviour
{
    public LayerMask layer;
    public GameObject Button;
    public Transform Player;
    private Vector3 offset = new Vector3(0, 1, 0);
    private PigInteraction PI;
    [HideInInspector] public bool aktif = false;
    private UIManager UIManager;
    public Sprite dropItem;
    
    private PrototypeInventory ItemSlotManager;
    // Start is called before the first frame update
    void Start()
    {
        PI = GameObject.FindWithTag("Pig").GetComponent<PigInteraction>();
        UIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        ItemSlotManager = GameObject.FindWithTag("InventoryManager").GetComponent<PrototypeInventory>();
        Button.gameObject.SetActive(false);
        Button.transform.position = Player.transform.position + new Vector3(0, 1, 0);;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D area = Physics2D.OverlapCircle(transform.position, 2f, layer);
        if (area != null && !PI.buttonActive)
        {
            aktif = true;
            UIManager.ShowButton(transform.position + Vector3.up * 0.5f, this);
            if (Input.GetKeyDown(KeyCode.F))
            {
                ItemSlotManager.AddItem(dropItem);
                Button.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
        else if (area == null && aktif)
        {
            aktif = false;
            UIManager.HideButton(this);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
