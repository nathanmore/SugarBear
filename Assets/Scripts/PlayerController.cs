/*
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpPower = 16f;

    [Header("Component References")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Controls")]
    [SerializeField] private KeyCode moveRightKey = KeyCode.D;
    [SerializeField] private KeyCode moveLeftKey = KeyCode.A;
    [SerializeField] private KeyCode jumpKey = KeyCode.W;
    [SerializeField] private KeyCode crouchKey = KeyCode.S;

    private bool isCrouching = false;
    private bool isFacingRight = true;
    private float movementX = 0f;

    public void Start()
    {

    }

    public void Update()
    {
        Move();
        Jump();
        Crouch();
    }

    public void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(movementX * moveSpeed, rigidBody.velocity.y);
    }

    public void Move()
    {
        if (Input.GetKey(moveRightKey))
        {
            movementX = 1f;
            if (!isFacingRight)
            {
                FlipSprite();
            }
        }
        else if (Input.GetKey(moveLeftKey))
        {
            movementX = -1f;
            if (isFacingRight)
            {
                FlipSprite();
            }
        }
        else
        {
            movementX = 0f;
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpPower);
        }
        else if (Input.GetKeyUp(jumpKey))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f);
        }
    }

    // Currently doesn't do anything, still need to implement crouching mechanic
    public void Crouch()
    {
        if (Input.GetKeyDown(crouchKey))
        {
            isCrouching = true;
        }
        else if (Input.GetKeyDown(crouchKey))
        {
            isCrouching = false;
        }
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
