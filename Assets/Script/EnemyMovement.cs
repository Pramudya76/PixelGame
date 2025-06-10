using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector] public float HealthEnemy = 100f;
    public LayerMask layer;
    private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool EnemyAttack = false;
    //private PlayerMovement PM;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //PM = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D area = Physics2D.OverlapCircle(transform.position, 2.5f, layer);
        if (area != null)
        {
            PlayerMovement PM = area.gameObject.GetComponent<PlayerMovement>();
            Vector2 PlayerPosition = area.transform.position;
            float Distance = Vector2.Distance(transform.position, PlayerPosition);
            if (Distance >= 1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, PlayerPosition, moveSpeed * Time.deltaTime);
            }
            else if (Distance < 1f)
            {
                rb.velocity = Vector2.zero;
                if (!EnemyAttack)
                {
                    Debug.Log(area.gameObject.name + " terkena serangan ");
                    EnemyAttack = true;
                    PM.healthPlayer -= 25f;
                    StartCoroutine(CDAttack());
                }
            }

        }
    }

    IEnumerator CDAttack()
    {
        yield return new WaitForSeconds(2f);
        EnemyAttack = false;
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.5f);
    }
}
