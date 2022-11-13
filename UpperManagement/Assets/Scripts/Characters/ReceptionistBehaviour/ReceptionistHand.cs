using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionistHand : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float startXPos;
    [SerializeField] float yOffset;
    [SerializeField] float followSpeed;
    [SerializeField] bool attacking;
    [SerializeField] float attackDelay;
    [SerializeField] bool rightHand;
    [SerializeField] Rigidbody2D handRb;
    [SerializeField] float damage;
    public UnityEngine.Events.UnityEvent dropAttackEvent;
    private void Start()
    {
        startXPos = transform.position.x;
        handRb = GetComponent<Rigidbody2D>();
        StartCoroutine(AttackAfterDelay());
    }

    private void FixedUpdate()
    {
        if (player)
        {

            if (!attacking)
            {
                if (rightHand)
                {
                    if (player.position.x < 0)
                    {
                        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, yOffset, 0), Time.fixedDeltaTime * followSpeed);
                        
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, new Vector3(startXPos, yOffset, 0), Time.fixedDeltaTime * followSpeed);
                    }
                }
                else
                {
                    if (player.position.x > 0)
                    {
                        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, yOffset, 0), Time.fixedDeltaTime * followSpeed);
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, new Vector3(startXPos, yOffset, 0), Time.fixedDeltaTime * followSpeed);
                    }
                }
            }
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
    }

    IEnumerator AttackAfterDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        TriggerAttack(); yield return null; 
    }

    void TriggerAttack()
    {
        attacking = true;
        handRb.isKinematic = false;
        handRb.velocity = Vector2.up * 4;
        dropAttackEvent.Invoke();
        StartCoroutine(ReturnToPosition());
    }

    IEnumerator ReturnToPosition()
    {
        yield return new WaitForSeconds(attackDelay);
        handRb.isKinematic = true;
        StartCoroutine(AttackAfterDelay());
        yield return attacking = false;
    }
    
}
