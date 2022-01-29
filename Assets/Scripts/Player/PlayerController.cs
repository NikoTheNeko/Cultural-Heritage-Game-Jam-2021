using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    public float movementSpeed = 1f;
    public float jumpForce = 5f;
    public bool reverseHorinzontalMovement = false;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            DoJump();
        }
    }

    private void FixedUpdate()
    {
        DoMovement();
    }


    private void DoMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float xVelocity = !reverseHorinzontalMovement ?
            horizontalInput * movementSpeed :
            horizontalInput * movementSpeed * -1;

        rb.velocity = new Vector2(xVelocity, rb.velocity.y);
    }

    private void DoJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
