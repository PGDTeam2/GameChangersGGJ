using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using System;

public class UInavigator : MonoBehaviour
{
    [SerializeField] private navableElement activeElement;
    // Start is called before the first frame update
    void Start()
    {
        activeElement.SetActive();
    }

    public void MoveToElement(InputAction.CallbackContext context){
        if(!context.started)
            return;
        Vector2 input = context.ReadValue<Vector2>();

        Direction inputDirection;

        if(Math.Abs(input.x) > Math.Abs(input.y)){
            inputDirection = input.x < 0 ? Direction.left : Direction.right;
        }else{
            inputDirection = input.y > 0 ? Direction.up : Direction.down;
        }

        Debug.Log(inputDirection + " " + input);
        activeElement = activeElement.moveTo(inputDirection);
    }

    public void Select(InputAction.CallbackContext context){
        if(!context.started)
            return;
        activeElement.Activate();
    }
}
