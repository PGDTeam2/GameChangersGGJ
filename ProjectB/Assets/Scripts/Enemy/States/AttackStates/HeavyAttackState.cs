using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttackState : AttackState
{
    public HeavyAttackState(Animator animator, Rigidbody2D rigidbody, Transform transform, Transform playerPosition, StateMachine statemachine) : base(animator, rigidbody, transform, playerPosition, statemachine)
    {
    }

    public override void OnEnter()
    {
        // Add additional code that should be executed when entering the MovingState
        anim.SetTrigger("HeavyAttack");
        base.OnEnter();
       
    }

    public override void Update()
    {
        base.Update();
        // Add code that updates the MovingState
    }

    public override void OnExit()
    {
        base.OnExit();
        
        // Add additional code that should be executed when exiting the MovingState
    }

    public override void SwitchState()
    {
        if (!canTransition)
        {
            return;
        }

        float distance = trans.position.x - playerPos.position.x;
        if (Mathf.Abs(distance) > attackRange)
        {
            //moving back to player if out of attack range
            stateMachine.nextState = new MovingState(anim, rb, trans, playerPos, stateMachine);
        }
        else
        {
            //returning to idle
            stateMachine.nextState = new IdleState(anim, rb, trans, playerPos, stateMachine);
        }

    }
}
