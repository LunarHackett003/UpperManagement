using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour
{

     [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
    public int GetHealth(bool current)
    {
        if (current)
            return maxHealth;
        else
            return currentHealth;
    }
}
