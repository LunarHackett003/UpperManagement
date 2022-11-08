using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    
    [SerializeField, Tooltip("use the red arrow for the fire direction")] Transform firePoint;
    [SerializeField] float fireForce;
    [SerializeField] GameObject projectile;

    void FireProjectile()
    {
        Rigidbody2D rb = Instantiate(projectile, firePoint.position, firePoint.rotation).GetComponent<Rigidbody2D>();
        rb.AddForce(fireForce * firePoint.right);
    }
}
