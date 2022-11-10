using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTimer : MonoBehaviour
{
    [SerializeField] float attackTime;
    bool attackDoing;
    [SerializeField] bool attacking;
    [SerializeField] AttackEvents atkEvents;
    public void ChangeAttack(bool triggerBoolean)
    {
        attacking = triggerBoolean;
    }
    private void FixedUpdate()
    {
        if (attacking)
        {
            if (!attackDoing)
            {
                StartCoroutine(DoAttack());
            }
        }
    }
    IEnumerator DoAttack()
    {
        yield return attackDoing = true;
        atkEvents.InitiateAttack(0);
        yield return new WaitForSeconds(attackTime);
        attackDoing = false;
        yield return null;
    }

}
