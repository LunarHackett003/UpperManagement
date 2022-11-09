using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killifier : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Kill(collision.gameObject);
    }
    public void Kill(GameObject objectToKill)
    {
        if(objectToKill.GetComponent<DamageableEntity>())
        {
            DamageableEntity ent = objectToKill.GetComponent<DamageableEntity>();
            ent.ChangeHealth(ent.GetHealth(true));
            ent.GetComponent<Rigidbody2D>().drag = 100;
        }
        else
        {
            Destroy(objectToKill, 0.01f);
        }

        if(objectToKill == GameObject.FindGameObjectWithTag("Player"))
        {
            GameManager.instance.TriggerDeath();
        }
    }
}
