using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour, IPlayerInput
{
    [Header("Movement")]
    [SerializeField] private float flyHorizontalSpeed = 8f;
    [SerializeField] private float flyVerticalSpeed = 8f;

    [Header("Component References")]
    [SerializeField] private Rigidbody2D rigidBody;

    [Header("Controls")]
    [SerializeField] private KeyCode moveRightKey = KeyCode.RightArrow;
    [SerializeField] private KeyCode moveLeftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode moveUpKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode moveDownKey = KeyCode.DownArrow;

    private bool isFacingRight = true;
    private float movementX = 0f;
    private float movementY = 0f;

    public bool InputEnabled { get; set; }

    public void Start()
    {
        InputEnabled = true;
    }

    public void Update()
    {
        Move();
    }

    public void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(movementX * flyHorizontalSpeed, movementY * flyVerticalSpeed);
    }

    public void Move()
    {
        if (Input.GetKey(moveRightKey) && InputEnabled)
        {
            movementX = 1f;
            if (!isFacingRight)
            {
                FlipSprite();
            }
        }
        else if (Input.GetKey(moveLeftKey) && InputEnabled)
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

        if (Input.GetKey(moveUpKey) && InputEnabled)
        {
            movementY = 1f;
        }
        else if (Input.GetKey(moveDownKey) && InputEnabled)
        {
            movementY = -1f;
        }
        else
        {
            movementY = 0f;
        }
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
