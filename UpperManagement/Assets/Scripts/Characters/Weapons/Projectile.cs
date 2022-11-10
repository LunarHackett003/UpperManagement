using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] bool isAffectedByGravity;

    [SerializeField] int damage;
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
        if (collision.otherRigidbody)
        {
            if (collision.otherRigidbody.GetComponent<Character>())
            {
                collision.otherRigidbody.AddForceAtPosition(rb.velocity, rb.position, ForceMode2D.Impulse);
            }

            if (collision.otherRigidbody.GetComponent<DamageableEntity>())
            {
                collision.otherRigidbody.GetComponent<DamageableEntity>().ChangeHealth(damage);
            }
        }


        Destroy(gameObject);
    }
}
