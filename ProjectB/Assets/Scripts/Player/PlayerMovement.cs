using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    private bool isGrounded = true;
    public bool IsGrounded { get { return isGrounded; } }
    Transform groundPoint;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        groundPoint = transform.Find("Groundpoint");
    }

    private void Update(){
        isGrounded = checkGrounded();
        Debug.DrawLine(groundPoint.position, groundPoint.position + new Vector3(0,-0.25f,0), Color.red);
    }
    public void HandleMovement(InputAction.CallbackContext context){
        Debug.Log(context.ReadValue<float>());
    }


    public void Jump(InputAction.CallbackContext context){
        Debug.Log("jump");
        if(!context.started || !isGrounded)
            return;

        rb.AddForce(new Vector2(0, jumpForce));

        isGrounded = false;

    }

    /// <summary>
    /// function that checks if player is grounded
    /// </summary>
    /// <returns>true if player collides with the ground</returns>
    private bool checkGrounded(){
        return Physics2D.CircleCast((Vector2) groundPoint.position, 0.25f, Vector2.zero, 0, LayerMask.GetMask("Ground"));
    }
}
