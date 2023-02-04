using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected Animator anim;
    protected Rigidbody2D rb;
    protected Transform trans;

    public bool canTransition;

    public Transform playerPos;

    public float attackRange = 1.2f;
    public float movementSpeed;

    public StateMachine stateMachine;
    

    public BaseState(Animator animator, Rigidbody2D rigidbody, Transform transform, Transform playerposition, StateMachine statemachine)
    {
        anim = animator;
        rb = rigidbody;
        trans = transform;
        playerPos = playerposition;
        stateMachine = statemachine;
        movementSpeed = stateMachine.movementSpeed;
        
    }

    public virtual void OnEnter()
    {
        // Add code that should be executed when entering the state
    }

    public abstract void Update();

    public virtual void OnExit()
    {
        // Add code that should be executed when exiting the state
    }

    public virtual void SwitchState()
    {
        //if in idle or moving enemy can switch state
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Moving"))
        {
            canTransition = true;
        } 
        //else if current animation is done enemy can switch state
        else if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            canTransition = true;
        } 
        //Else cant transition
        else
        {
            canTransition = false;
            return;
        }
    }
}
