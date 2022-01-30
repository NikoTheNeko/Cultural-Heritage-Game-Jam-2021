using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement variables")]
    [HideInInspector] public Rigidbody2D rb;
    private InputAction movement;

    public float movementSpeed = 1f;
    public bool reverseHorinzontalMovement = false;

    [Space]
    public int maximumJumps = 1;
    [HideInInspector] public int jumpsLeft;
    public float jumpForce = 5f;
    


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


    private void FixedUpdate()
    {
        DoMovement(movement.ReadValue<Vector2>());
    }


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

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        // jumpsLeft--;
    }

    public void ResetJumpCounter()
    {
        jumpsLeft = maximumJumps;
    }
}
