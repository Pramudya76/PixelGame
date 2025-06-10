using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public LayerMask layer;
    public GameObject Button;
    public Transform Player;
    private Vector3 offset = new Vector3(0, 1, 0);
    private PigInteraction PI;
    [HideInInspector] public bool aktif = false;
    // Start is called before the first frame update
    void Start()
    {
        PI = GameObject.FindWithTag("Pig").GetComponent<PigInteraction>();
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
            //Debug.Log("Terdeteksi" + area.gameObject.name);
            Button.gameObject.SetActive(true);

            //Debug.Log("Hollaaaa");
            if (Input.GetKeyDown(KeyCode.F))
            {
                Button.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
        else if (area == null && aktif)
        {
            aktif = false;
            Button.gameObject.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
