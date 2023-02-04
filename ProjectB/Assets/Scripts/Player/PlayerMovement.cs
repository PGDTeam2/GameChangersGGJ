using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float movementSpeed;
    private float inputValue;
    [SerializeField] private float jumpForce;
    private bool isGrounded = true;
    public bool IsGrounded { get { return isGrounded; } }
    Transform groundPoint;
    Transform character;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        groundPoint = transform.Find("Groundpoint");
        character = transform.Find("character");
    }

    private void Update(){
        isGrounded = checkGrounded();
    }

    private void FixedUpdate(){
        if(inputValue != 0){
            float rotation = inputValue < 0 ? -90 : 90;
            character.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);
            rb.AddForce( new Vector2(inputValue * movementSpeed,0));
        }
    }
    public void HandleMovement(InputAction.CallbackContext context){
        inputValue = context.ReadValue<float>();
    }


    public void Jump(InputAction.CallbackContext context){
        if(!context.started || !isGrounded)
            return;

        rb.AddForce(new Vector2(0, jumpForce));
    }

    /// <summary>
    /// function that checks if player is grounded
    /// </summary>
    /// <returns>true if player collides with the ground</returns>
    private bool checkGrounded(){

        return Physics2D.CircleCast((Vector2) groundPoint.position, 0.25f, Vector2.zero, 0, LayerMask.GetMask("Ground"));
    }
}
