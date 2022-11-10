using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachedDamager : MonoBehaviour
{
    [SerializeField] DamageableEntity ent;

    public void SendDamage(int damage)
    {
        ent.ChangeHealth(damage);
    }
}
