using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PigInteraction : MonoBehaviour
{
    public GameObject Button;
    public GameObject Dialog;
    private bool Press = false;
    public LayerMask layer;
    //private Vector3 offset = new Vector3(5, -1.5f, 0);
    private bool Active = false;
    public Transform Player;
    private String[] textDialog = new string[] { "Halo Tuan", "Selamat Pagi", "Bagaimana tidur mu?", "Apakah nyenyak?", "Apa yang ingin anda lakukan hari ini?" };
    public TextMeshProUGUI Text;
    private int indexDialog = 0;
    //public bool isTalk = false;
    private PlayerMovement PM;
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        Button.gameObject.SetActive(false);
        Dialog.gameObject.SetActive(false);
        Button.transform.position = Player.transform.position + new Vector3(0.7f, 0, 0);
        Dialog.transform.position = transform.position + new Vector3(5, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {

        Collider2D hit = Physics2D.OverlapCircle(transform.position, 1f, layer);
        if (hit != null && !Active)
        {
            Press = true;
            Button.gameObject.SetActive(true);
        }
        else if (hit == null)
        {
            Button.gameObject.SetActive(false);
            Dialog.gameObject.SetActive(false);
            Press = false;
            Active = false;
        }

        if (Input.GetKeyDown(KeyCode.F) && Press && !Active)
        {
            Button.gameObject.SetActive(false);
            Dialog.gameObject.SetActive(true);
            Active = true;
            indexDialog = 0;
            Text.text = textDialog[indexDialog];
            PM.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Return) && Active)
        {
            indexDialog++;
            if (indexDialog < textDialog.Length)
            {
                Text.text = textDialog[indexDialog];
                PM.enabled = false;
            }
            else
            {
                Dialog.gameObject.SetActive(false);
                Active = false;
                indexDialog = 0;
                PM.enabled = true;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    // public void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         Press = true;
    //         Button.gameObject.SetActive(true);
    //     }
    // }
}
