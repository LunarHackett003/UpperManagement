using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private GameObject target;
    
    [SerializeField] DamageableEntity entity; //the character or entity this is attached to
    [SerializeField] float followStopDistance;

    //reference to Character script on enemy

    //start

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //get x offset between player and enemy
        if (entity is Character && target)
        {
            if (Vector3.Distance(transform.position, target.transform.position) >= followStopDistance)
            {
                Character ch = entity as Character;
                ch.ivars.moveInput = target.transform.position.x - transform.position.x;
            }
            else
            {
                Character ch = entity as Character;
                ch.ivars.moveInput = 0;
            }

        }
        else
        {
            Character ch = entity as Character;
            ch.ivars.moveInput = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            target = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            target = null; 
        }
    }

}
