using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [System.Serializable]
    public class InputVariables
    {
        public float moveInput;
        public float verticalInput;
        public bool lightInput, heavyInput, rangedInput;
    }
    //Physics Variables
    [SerializeField] float groundCheckDistance;
    [SerializeField] float groundCheckRadius; //Since we're circle-casting, we need a variable radius
    public Rigidbody2D rb { get ; private set; }
    [SerializeField] float jumpVelocity, airMoveForce;
    [SerializeField] LayerMask groundLayerMask;
    //Movement Variables
    [SerializeField] float moveSpeed;
    [SerializeField] float moveDampTime;
    float moveDampVel; //Move Damping Velocity
    [SerializeField] float moveDamped;

    [SerializeField] bool grounded;
    [SerializeField] float jumpTime;
    [SerializeField] float currentJumpTime;

    [SerializeField] Transform groundCheckStart;

    public InputVariables ivars;
    [SerializeField] int maxHealth;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    public int GetHealth(bool current)
    {
        if (current)
            return maxHealth;
        else
            return currentHealth;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (currentHealth > 0)
        {
            MoveCharacter();




            grounded = false;
        }
    }

    void MoveCharacter()
    {
        moveDamped = Mathf.SmoothDamp(moveDamped, ivars.moveInput, ref moveDampVel, moveDampTime);
        grounded = IsGrounded();
        if (grounded)
        {
            currentJumpTime = 0;

            
            rb.velocity = new Vector2(moveDamped * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(airMoveForce * moveDamped, rb.velocity.y);
        }

        if (ivars.verticalInput >= UnityEngine.InputSystem.InputSystem.settings.defaultButtonPressPoint)
        {
            if (currentJumpTime < jumpTime)
            {
                Jump();
                
            }
        }
        else
        {
            if (!grounded)
            {
                currentJumpTime = jumpTime;
            }
        }
    }

    /// <summary>
    /// Performs a ground check. Returns true if the circle cast hits the ground, returns false if it hits anything not in the ground LayerMask.
    /// </summary>
    /// <returns></returns>
   bool IsGrounded()
   {
       bool hit = false;
       RaycastHit2D rh = Physics2D.CircleCast(groundCheckStart.position, groundCheckRadius, Vector2.down, groundCheckDistance, groundLayerMask);
       hit = rh.collider;
       Debug.Log($"ground {hit}");
       
       return hit;
   }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        currentJumpTime += Time.fixedDeltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckStart.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckStart.position + (Vector3.down * groundCheckDistance), groundCheckRadius);
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
