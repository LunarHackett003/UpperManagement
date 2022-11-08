using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableEntity : MonoBehaviour
{

     [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;

    [SerializeField] UnityEvent deathEvent;
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

    protected virtual void FixedUpdate()
    {
        
    }

    void OnDeath()
    {
        
    }
}
