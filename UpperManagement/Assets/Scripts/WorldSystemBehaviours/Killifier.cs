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
        }
        else
        {
            Destroy(objectToKill, 0.01f);
        }

        if(objectToKill == GameObject.FindGameObjectWithTag("Player"))
        {
            
        }
    }
}
