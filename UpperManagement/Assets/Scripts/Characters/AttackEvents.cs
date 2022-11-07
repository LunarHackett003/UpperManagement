using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;

public class AttackEvents : MonoBehaviour
{
    [System.Serializable]
    public class Attack
    {
        public string attackName;

        public Vector3 attackBounds, attackPosition;
        public int attackDamage;
        public float attackTime;

        public Color debugColour;
    }

    [SerializeField] LayerMask attackLayerMask;
    Animator anim;
    public List<Attack> attackList = new List<Attack>();

    [SerializeField] Rigidbody2D excludedRB;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnDrawGizmosSelected()
    {
        foreach (var item in attackList)
        {
            Gizmos.color = item.debugColour;
            Gizmos.DrawWireCube(transform.rotation * (transform.position + item.attackPosition), item.attackBounds);
        }
    }

    public void InitiateAttack(int attackIndex)
    {
        StartCoroutine(AttackBoxcast(attackList[attackIndex]));
    }

    /// <summary>
    /// Performs a box cast that finds all rigidbodies (since objects can be knocked around) and adds a force.
    /// Additionally, checks all rigidbodies found for a character component and applies the correct damage.
    /// </summary>
    /// <param name="thisAtk"></param>
    /// <returns></returns>
    IEnumerator AttackBoxcast(Attack thisAtk)
    {
        Debug.Log($"Performing {thisAtk.attackName}!");
        float currentAttackTime = 0;
        List<Rigidbody2D> rb2ds = new List<Rigidbody2D>();
        while (currentAttackTime < thisAtk.attackTime)
        {

            foreach (var item in Physics2D.OverlapBoxAll(transform.rotation * (thisAtk.attackPosition + transform.position), thisAtk.attackBounds, 0, attackLayerMask))
            {
                if (item.attachedRigidbody && item.attachedRigidbody != excludedRB)
                {
                    if (!rb2ds.Contains(item.attachedRigidbody))
                    {
                        item.attachedRigidbody.AddForce((transform.position - item.transform.position).normalized * thisAtk.attackDamage );
                    }

                    rb2ds.Add(item.attachedRigidbody);
                }
            }
        }

        yield return null;
    }

}
