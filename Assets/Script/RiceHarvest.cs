using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceHarvest : MonoBehaviour
{
    public LayerMask layer;
    public GameObject Button;
    private bool isNear = false;
    private UIManager UIManager;
    // Start is called before the first frame update
    void Start()
    {
        UIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        Button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D areaHarvest = Physics2D.OverlapCircle(transform.position, 0.5f, layer);
        if (areaHarvest != null)
        {
            isNear = true;
            UIManager.ShowButton(transform.position + Vector3.up * 0.5f, this);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(gameObject);
            }
        }
        else if (areaHarvest == null && isNear)
        {
            UIManager.HideButton(this);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);       
    }
}
