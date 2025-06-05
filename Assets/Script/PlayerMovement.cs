using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 3f;
    private Animator animator;
    [HideInInspector] public float lastMoveX;
    [HideInInspector] public float lastMoveY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(moveX * moveSpeed, moveY * moveSpeed);

        animator.SetBool("Walk", moveX != 0);
        animator.SetBool("WalkTop", Input.GetKey(KeyCode.W));
        animator.SetBool("WalkDown", Input.GetKey(KeyCode.S));

        if (moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            lastMoveX = moveX;
            lastMoveY = moveY;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            lastMoveX = moveX;
            lastMoveY = moveY;
        }

        
    }
}
