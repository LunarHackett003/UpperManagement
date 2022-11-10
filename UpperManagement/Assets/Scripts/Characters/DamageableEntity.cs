using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableEntity : MonoBehaviour
{

     [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;
    public bool dead;
    
    [SerializeField] UnityEvent deathEvent;
    // Start is called before the first frame update

    [SerializeField] protected List<GameObject> objectsDisabledOnDeath;
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
    public int GetHealth(bool current)
    {
        if (!current)
            return maxHealth;
        else
            return currentHealth;
    }

    protected virtual void FixedUpdate()
    {
        if(currentHealth <= 0 && !dead)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        dead = true;
        Vector2 randomForce = new Vector2(Random.Range(-1, 1), 1) * Random.Range(9.81f, 25);
        rb.AddForce(randomForce);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddTorque(Random.Range(-20, 20));

        foreach (var item in objectsDisabledOnDeath)
        {
            item.SetActive(false);
        }
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
