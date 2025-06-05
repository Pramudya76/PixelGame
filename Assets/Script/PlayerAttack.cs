using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement PM;
    private float visionAngle = 60f;
    private float visionRange = 1f;
    private int rayCount = 6;
    public LayerMask layer;
    //private EnemyMovement EM;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        PM = GetComponent<PlayerMovement>();
        //EM = GameObject.FindWithTag("Enemy").GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PM.lastMoveX > 0 || PM.lastMoveX < 0 || PM.lastMoveX == 0 && PM.lastMoveY == 0)
            {
                animator.SetTrigger("PlayerAttackSide");
            }
            else if (PM.lastMoveY < 0)
            {
                animator.SetTrigger("AttackPlayer");
            }
            else if (PM.lastMoveY > 0)
            {
                animator.SetTrigger("PlayerAttackTop");
            }
        }

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // if (input != Vector2.zero)
        // {
        //     float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
        //     transform.rotation = Quaternion.Euler(0, 0, angle);
        // }
        float baseAngle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;

        float halfAngle = visionAngle / 2;
        float angleStep = visionAngle / (rayCount - 1);
        float startAngle = baseAngle - halfAngle;
        for (int a = 0; a < rayCount; a++)
        {
            float sudutZ = transform.eulerAngles.z;
            float angle = startAngle + a * angleStep + sudutZ;
            float angleRad = Mathf.Deg2Rad * angle;

            Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, visionRange, layer);
            Debug.DrawRay(transform.position, direction * visionRange, Color.red);
            if (hit.collider != null && Input.GetMouseButtonDown(0))
            {
                EnemyMovement EM = hit.collider.GetComponent<EnemyMovement>();
                if (EM != null)
                {
                    EM.HealthEnemy -= 25f;
                    if (EM.HealthEnemy <= 0)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    Debug.Log("Nyala");
                    break;
                }
            }
        }

    }
}
