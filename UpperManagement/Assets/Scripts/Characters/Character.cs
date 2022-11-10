using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : DamageableEntity
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
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }
   
        
    
    // Update is called once per frame
    void Update()
    {

    }

    override protected void FixedUpdate()
    {
        base.FixedUpdate();

        if (!dead)
        {
            MoveCharacter();

            grounded = false;
        }

        dead = currentHealth <= 0;
    }

    void MoveCharacter()
    {
        moveDamped = Mathf.SmoothDamp(moveDamped, ivars.moveInput, ref moveDampVel, moveDampTime);
        grounded = IsGrounded();
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


        if (grounded)
        {
            currentJumpTime = 0;

            if (ivars.moveInput != 0)
            {
                rb.velocity = new Vector2(moveDamped * moveSpeed, rb.velocity.y);
            }
        }
        else
        {
            rb.AddForce(new Vector2(airMoveForce * moveDamped, 0));
        }



        if(ivars.moveInput >= UnityEngine.InputSystem.InputSystem.settings.defaultButtonPressPoint)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (ivars.moveInput <= -UnityEngine.InputSystem.InputSystem.settings.defaultButtonPressPoint)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }


    }

    /// <summary>
    /// Performs a ground check. Returns true if the circle cast hits the ground, returns false if it hits anything not in the ground LayerMask.
    /// </summary>
    /// <returns></returns>
   public bool IsGrounded()
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



}
