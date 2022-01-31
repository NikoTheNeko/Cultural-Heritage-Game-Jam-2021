using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Triggers")]
    public BoxCollider2D GroundChecker;


    [Header("Movement variables")]
    [HideInInspector] public Rigidbody2D rb;
    private InputAction movement;

    public float movementSpeed = 1f;
    public bool reverseHorinzontalMovement = false;

    [Space]
    public int maximumJumps = 1;
    [HideInInspector] public int jumpsLeft;
    public float jumpForce = 5f;
    private bool groundTouched = false;
    private bool isJumping = false;


    #region Initialization Functions
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        jumpsLeft = maximumJumps;
    }

    private void Start()
    {
        movement = InputManager.Instance.playerControls.Player.Move;
        InputManager.Instance.OnJump += DoJump;
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnJump -= DoJump;
    }
    #endregion


    #region Update Functions
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        DoMovement(movement.ReadValue<Vector2>());

        //Resets the jump if the following conditions are met
        //No more jumps, You touched grass(the ground), and you're not jumping already
        if (jumpsLeft == 0 && groundTouched && !isJumping)
        {
            ResetJumpCounter();
        }
    }
    #endregion


    #region Movement Functions
    private void DoMovement(Vector2 input)
    {
        float horizontalInput = input.x;
        float xVelocity = !reverseHorinzontalMovement ?
            horizontalInput * movementSpeed :
            horizontalInput * movementSpeed * -1;

        rb.velocity = new Vector2(xVelocity, rb.velocity.y);
    }

    private void DoJump()
    {
        // Do nothing if no jumps left
        if (jumpsLeft < 1)
        {
            return;
        }

        // Creates the jump vector and decrements jumpsLeft
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpsLeft--;

        //Sets it so that it's now jumping you hoppity fuck
        isJumping = true;
    }

    public void ResetJumpCounter(){
        jumpsLeft = maximumJumps;
    }
    #endregion


    #region Grounded/In Air Triggers
    /**
    Checks if it enters the trigger, it does 2 things
    ground touched will become true
        - This allows the player to reset their jumps
    is jumping will become false
        - This will also allow the player to reset their
        jumps
        -except this is what stops them from double jumping
        -i hate logic and code
    **/
    private void OnTriggerEnter2D(Collider2D other)
    {
        groundTouched = true;
        isJumping = false;
    }

    /**
    Checks if it exits the trigger, it does 1 thing
    groudn touched will be false
        - basically the player can't reset their jumps
        because they're in the air lmaoo weeewoo
    **/
    private void OnTriggerExit2D(Collider2D other)
    {
        groundTouched = false;
    }
    #endregion
}
