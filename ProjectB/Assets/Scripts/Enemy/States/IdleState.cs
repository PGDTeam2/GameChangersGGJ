using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(Animator animator, Rigidbody2D rigidbody) : base(animator, rigidbody)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        // Add additional code that should be executed when entering the MovingState
        //anim.SetTrigger("Moving");
    }

    public override void Update()
    {
        // Add code that updates the MovingState
    }

    public override void OnExit()
    {
        base.OnExit();
        // Add additional code that should be executed when exiting the MovingState
    }
}
