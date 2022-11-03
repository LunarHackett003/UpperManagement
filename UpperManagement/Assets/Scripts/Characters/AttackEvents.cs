using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;

public class AttackEvents : MonoBehaviour
{


    Animator anim;
    [SerializeField] Vector2 lightAttackBounds, lightAttackPosition, heavyAttackBounds, heavyAttackPosition;
    [SerializeField] int lightAttackDamage, heavyAttackDamage;
    [SerializeField] float lightAttackTime, heavyAttackTime;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position + (Vector3)lightAttackPosition, lightAttackBounds);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position + (Vector3)heavyAttackPosition, heavyAttackBounds);
    }

    public void InitiateAttack(int attackIndex)
    {
        if (attackIndex == 0)
        {
            StartCoroutine(AttackBoxcast(lightAttackBounds, lightAttackPosition, lightAttackTime, lightAttackDamage));
        }
        else
        {
            StartCoroutine(AttackBoxcast(heavyAttackBounds, heavyAttackPosition, heavyAttackTime, heavyAttackDamage));
        }
    }


    IEnumerator AttackBoxcast(Vector2 bounds, Vector2 position, float attackTime, int damage)
    {
        float currentAttackTime = 0;
        List<Rigidbody2D> rb2ds = new List<Rigidbody2D>();
        while (currentAttackTime < attackTime)
        {
            
            foreach (var item in Physics2D.OverlapBoxAll(position + (Vector2)transform.position, bounds, 0))
            {
                if (item.attachedRigidbody)
                {
                    if (!rb2ds.Contains(item.attachedRigidbody))
                    {

                    }

                    rb2ds.Add(item.attachedRigidbody);
                }
            }
        }

        yield return null;
    }

}
