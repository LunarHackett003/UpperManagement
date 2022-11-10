using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableEntity : MonoBehaviour
{

     [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;
    [SerializeField] protected bool dead;
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
        dead = true;
    }

    /// <summary>
    /// Applies damage when a positive number is supplied, or heals when a negative number is supplied.
    /// </summary>
    /// <param name="healthChange"></param>
    public void ChangeHealth(int healthChange)
    {
        currentHealth -= healthChange;
    }
}
