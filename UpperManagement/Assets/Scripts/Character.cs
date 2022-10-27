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
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce, airMoveForce;
    [SerializeField] LayerMask groundLayerMask;
    //Movement Variables
    [SerializeField] float moveSpeed;
    [SerializeField] float moveDampTime;
    float moveDampVel; //Move Damping Velocity
    [SerializeField] float moveDamped;

    [SerializeField] bool grounded;


    public InputVariables ivars;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        grounded = IsGrounded();
        if (grounded)
        {
            moveDamped = Mathf.SmoothDamp(moveDamped, ivars.moveInput, ref moveDampVel, moveDampTime);
            rb.velocity = new Vector2(moveDamped * moveSpeed, rb.velocity.y);
            

            if(ivars.verticalInput >= UnityEngine.InputSystem.InputSystem.settings.defaultButtonPressPoint)
            {
                Jump();
            }

        }
        else
        {
            rb.AddForce(new Vector2(ivars.moveInput * airMoveForce, ivars.verticalInput * airMoveForce));
        }
    }

    bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance);
        bool hit = Physics2D.CircleCast(transform.position, groundCheckRadius, Vector2.down, groundCheckDistance, groundLayerMask).collider;
        Debug.Log($"ground {hit}");
        return hit;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
