using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float movementSpeed;
    public float _movementSpeed
    {
        get { return movementSpeed; }
    }
    private float inputValue;
    [SerializeField] private float jumpForce;
    private bool isGrounded = true;

    public bool IsGrounded
    {
        get { return isGrounded; }
    }

    Transform groundPoint;
    Transform character;
    Animator animator;
    MoveSet moveSet;

    bool repressedMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundPoint = transform.Find("Groundpoint");
        character = transform.Find("character");
        animator = character.GetComponent<Animator>();
        moveSet = GetComponent<MoveSet>();
    }

    private void Update()
    {
        isGrounded = checkGrounded();
    }

    private void FixedUpdate()
    {
        bool walking = false;
        bool cancel = false;
        if (inputValue != 0)
        {
            if (moveSet.IsExecutingAttack)
            {
                if (!moveSet.currentMove.ForceStandStill)
                {
                    walking = true;
                }
                else if (moveSet.currentMove.IsCancelable)
                {
                    walking = true;
                    cancel = true;
                }
            }
            else
            {
                walking = true;
            }
        }

        if (cancel)
        {
            if (repressedMove)
            {
                moveSet.CancelMove();
                animator.Play("Run", 0);
                animator.Play("Run", 1);
            }
            else
            {
                walking = false;
            }
        }
        animator.SetBool("is_walking", walking);

        if (walking)
        {
            float rotation = inputValue < 0 ? -90 : 90;
            character.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);
            rb.AddForce(new Vector2(inputValue * movementSpeed, 0));
        }

        repressedMove = false;
    }

    public void HandleMovement(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0)
            return;
        var oldInput = inputValue;
        inputValue = context.ReadValue<float>();
        if (oldInput == 0 && inputValue != 0)
        {
            repressedMove = true;
        }
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started || !isGrounded || Time.timeScale == 0)
            return;

        rb.AddForce(new Vector2(0, jumpForce));
    }

    /// <summary>
    /// function that checks if player is grounded
    /// </summary>
    /// <returns>true if player collides with the ground</returns>
    private bool checkGrounded()
    {
        return Physics2D.CircleCast((Vector2) groundPoint.position, 0.15f, Vector2.zero, 0,
            LayerMask.GetMask("Ground"));
    }
}