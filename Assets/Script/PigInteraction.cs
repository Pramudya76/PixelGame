using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigInteraction : MonoBehaviour
{
    public GameObject Button;
    public GameObject Dialog;
    private bool Press = false;
    // Start is called before the first frame update
    void Start()
    {
        Button.gameObject.SetActive(false);
        Dialog.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Press)
        {
            Button.gameObject.SetActive(false);
            Dialog.gameObject.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Press = true;
            Button.gameObject.SetActive(true);
        }
    }
}
