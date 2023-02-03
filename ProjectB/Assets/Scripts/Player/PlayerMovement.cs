using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;


    [SerializeField] private float jumpForce;
    private bool canJump = true;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    public void HandleMovement(InputAction.CallbackContext context){
        Debug.Log(context.ReadValue<float>());
    }

    public void Jump(InputAction.CallbackContext context){
        Debug.Log("jump");
        if(!context.started || !canJump)
            return;

        rb.AddForce(new Vector2(0, jumpForce));

        canJump = false;

    }
}
