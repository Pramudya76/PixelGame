using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector] public float HealthEnemy = 100f;
    public LayerMask layer;
    private float moveSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D area = Physics2D.OverlapCircle(transform.position, 2.5f, layer);
        if (area != null)
        {
            Vector2 PlayerPosition = area.transform.position;
            float Distance = Vector2.Distance(transform.position, PlayerPosition);
            transform.position = Vector2.MoveTowards(transform.position, PlayerPosition, moveSpeed * Time.deltaTime);
            if (Distance <= 0.2f)
            {
                transform.position = Vector2.zero;
            }
        }
    }
}
