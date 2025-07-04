using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTransaction : MonoBehaviour
{
    public GameObject Button;
    public GameObject TransactionPanel;
    public LayerMask layer;
    private bool aktif = false;
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        Button.gameObject.SetActive(false);
        TransactionPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D area = Physics2D.OverlapCircle(transform.position, 1f, layer);
        if (area != null)
        {
            aktif = true;
            uiManager.ShowButton(transform.position + Vector3.up * 0.5f, this);
            if (Input.GetKeyDown(KeyCode.F))
            {
                TransactionPanel.gameObject.SetActive(true);
            }
        }
        else if (area == null && aktif)
        {
            aktif = false;
            uiManager.HideButton(this);
        }
    }
}
