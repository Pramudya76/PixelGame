using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            GameObject PlayerObjt = GameObject.FindWithTag("Player");
            if (PlayerObjt != null)
            {
                Player = PlayerObjt.GetComponent<Transform>();
            }
        }
        if (Player != null)
        {
            Vector3 newPos = Player.position;
            newPos.z = -10f;
            transform.position = newPos;
        }
    }
}
