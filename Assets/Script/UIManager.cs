using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameover;
    public GameObject Button;
    private RiceHarvest RH;
    private PigInteraction PI;
    private ChestInteraction CI;
    private SeedItem SI;
    private NpcTransaction NT;
    public GameObject Inventory;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        gameover.gameObject.SetActive(false);
        Inventory.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        gameover.gameObject.SetActive(true);
    }

    public IEnumerator CDGameOver()
    {
        yield return new WaitForSeconds(0.1f);
        GameOver();
    }

    public void ShowButton(Vector3 pos, RiceHarvest RHSource)
    {
        RH = RHSource;
        Button.gameObject.SetActive(true);
        Button.transform.position = pos;
    }

    public void ShowButton(Vector3 pos, PigInteraction pigInteraction)
    {
        PI = pigInteraction;
        Button.gameObject.SetActive(true);
        Button.transform.position = pos;
    }

    public void ShowButton(Vector3 pos, ChestInteraction chestInteraction)
    {
        CI = chestInteraction;
        Button.gameObject.SetActive(true);
        Button.transform.position = pos;
    }

    public void ShowButton(Vector3 pos, SeedItem seedItem)
    {
        SI = seedItem;
        Button.gameObject.SetActive(true);
        Button.transform.position = pos;
    }

    public void ShowButton(Vector3 pos, NpcTransaction npcTransaction)
    {
        NT = npcTransaction;
        Button.gameObject.SetActive(true);
        Button.transform.position = pos;
    }

    public void HideButton(RiceHarvest RHSource)
    {
        if (RHSource == RH)
        {
            Button.gameObject.SetActive(false);
            RH = null;
        }
    }

    public void HideButton(PigInteraction pigInteraction)
    {
        if (pigInteraction == PI)
        {
            Button.gameObject.SetActive(false);
            PI = null;
        }
    }

    public void HideButton(ChestInteraction chestInteraction)
    {
        if (chestInteraction == CI)
        {
            Button.gameObject.SetActive(false);
            CI = null;
        }
    }

    public void HideButton(SeedItem seedItem)
    {
        if (seedItem == SI)
        {
            Button.gameObject.SetActive(false);
            SI = null;
        }
    }

    public void HideButton(NpcTransaction npcTransaction)
    {
        if (npcTransaction == NT)
        {
            Button.gameObject.SetActive(false);
            NT = null;
        }
    }

    public bool IsThisActiveRice(RiceHarvest riceHarvest)
    {
        return RH == riceHarvest;
    }

    // public void IsThisNotActiveRice(RiceHarvest riceHarvest)
    // {
    //     if (RH == riceHarvest)
    //     {
    //         RH = null;
    //     }
    // }

    public void ResetAllNear()
    {
        RiceHarvest[] allRices = FindObjectsOfType<RiceHarvest>();
        foreach (var rice in allRices)
        {
            rice.isNear = false;
            rice.isHarvest = false;
        }
    }

    public void MainInventory()
    {
        if (!isOpen)
        {
            Inventory.gameObject.SetActive(true);
            isOpen = true;
        }
        else
        {
            Inventory.gameObject.SetActive(false);
            isOpen = false;
        }
    }

}
