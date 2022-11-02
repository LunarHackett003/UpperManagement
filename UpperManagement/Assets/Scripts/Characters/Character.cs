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
    [SerializeField] float jumpForce, airMoveForce;
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        MoveCharacter();




        grounded = false;
    }

    void MoveCharacter()
    {
        
        grounded = IsGrounded();
        if (grounded)
        {
            currentJumpTime = 0;

            moveDamped = Mathf.SmoothDamp(moveDamped, ivars.moveInput, ref moveDampVel, moveDampTime);
            rb.velocity = new Vector2(moveDamped * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.AddForce(new Vector2(ivars.moveInput * airMoveForce, ivars.verticalInput * airMoveForce));
        }

        if (ivars.verticalInput >= UnityEngine.InputSystem.InputSystem.settings.defaultButtonPressPoint)
        {
            if (currentJumpTime < jumpTime)
            {
                Jump();
                currentJumpTime = currentJumpTime + Time.fixedDeltaTime;
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
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckStart.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckStart.position + (Vector3.down * groundCheckDistance), groundCheckRadius);
    }

}
