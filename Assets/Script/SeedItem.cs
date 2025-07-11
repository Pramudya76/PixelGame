using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedItem : MonoBehaviour
{
    private PrototypeInventory PI;
    private UIManager UIManager;
    private GameManager GM;
    public LayerMask layer;
    public ItemData Seeds;
    public GameObject Rice;
    public GameObject Button;
    [HideInInspector] public bool isSeed = false;
    private GameObject RicesTransform;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        PI = GameObject.FindWithTag("InventoryManager").GetComponent<PrototypeInventory>();
        UIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        RicesTransform = GameObject.FindWithTag("Rices");
        Button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D area = Physics2D.OverlapCircle(transform.position, 0.15f, layer);
        if (area != null && PI.hasItem(Seeds.nameItem))
        {
            UIManager.ShowButton(transform.position, this);
            //Button.gameObject.SetActive(true)
;            // if (!isSeed)
            // {
            //     isSeed = true;
            //     UIManager.ShowButton(transform.position, this);
            // }
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject rice = Instantiate(Rice, transform.position, Quaternion.identity, RicesTransform.transform);
                PI.RemoveItem(Seeds);
                GM.AddRice(rice, index);
                //isSeed = false;
                UIManager.HideButton(this);
            }
            //Debug.Log(isSeed);

        }
        else
        {
            //isSeed = false;
            UIManager.HideButton(this);
            //Button.gameObject.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.15f);       
    }
}
