using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] rices;
    public GameObject[] seeds;
    public GameObject TransactionPanel;
    // Start is called before the first frame update
    void Start()
    {
        for (int a = 0; a < seeds.Length; a++)
        {
            seeds[a].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int a = 0; a < rices.Length; a++)
        {
            if (rices[a] == null)
            {
                if (seeds[a] != null)
                {
                    seeds[a].gameObject.SetActive(true);
                }
            }
            else if (rices[a] != null)
            {
                seeds[a].gameObject.SetActive(false);

            }
        }
    }

    public void AddRice(GameObject newRice)
    {
        for (int a = 0; a < rices.Length; a++)
        {
            if (rices[a] == null)
            {
                rices[a] = newRice;
                return;
            }
        }
    }

    public void RemoveRice(GameObject Rices)
    {
        for (int a = 0; a < rices.Length; a++)
        {
            if (rices[a] == Rices)
            {
                Destroy(rices[a]);
                rices[a] = null;
                return;
            }
        }
    }

    public void TransactionPanelOff()
    {
        TransactionPanel.gameObject.SetActive(false);
    }

}
