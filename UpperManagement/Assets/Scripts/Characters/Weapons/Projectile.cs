using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] bool isAffectedByGravity;
    [SerializeField] AttackEvents attackEvents;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!isAffectedByGravity)
        {
            if (rb)
            {
                rb.gravityScale = 0;
                transform.right = rb.velocity;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.right = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        attackEvents.InitiateAttack(0);
        Destroy(gameObject);
    }
}
