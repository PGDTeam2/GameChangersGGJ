using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected Animator anim;
    protected Rigidbody2D rb;
    protected Transform trans;

    public bool canTransition = true;

    public Transform playerPos;

    public float attackRange = 1.1f;
    public float movementSpeed;

    public StateMachine stateMachine;
    public MoveSet moveSet;
    

    public BaseState(Animator animator, Rigidbody2D rigidbody, Transform transform, Transform playerposition, StateMachine statemachine)
    {
        anim = animator;
        rb = rigidbody;
        trans = transform;
        playerPos = playerposition;
        stateMachine = statemachine;
        movementSpeed = stateMachine.movementSpeed;
        moveSet = stateMachine.GetComponent<MoveSet>();
        
    }

    public virtual void OnEnter()
    {
        // Add code that should be executed when entering the state
    }

    public virtual void Update()
    {
    }

    public virtual void OnExit()
    {
        // Add code that should be executed when exiting the state
    }

    public virtual void SwitchState()
    {
        //if in idle or moving enemy can switch state
    }
}
