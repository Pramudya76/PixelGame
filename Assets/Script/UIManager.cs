using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameover;
    public GameObject Button;
    private RiceHarvest RH;
    // Start is called before the first frame update
    void Start()
    {
        gameover.gameObject.SetActive(false);
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

    public void HideButton(RiceHarvest RHSource) 
    {
        if (RHSource == RH)
        {
            Button.gameObject.SetActive(false);
            RH = null;
        }
    }

}
