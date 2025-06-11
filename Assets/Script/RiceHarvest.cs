using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceHarvest : MonoBehaviour
{
    public LayerMask layer;
    public GameObject Button;
    [HideInInspector] public bool isNear = false;
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
                isNear = false;
                UIManager.HideButton(this);
                UIManager.ResetAllNear();
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
