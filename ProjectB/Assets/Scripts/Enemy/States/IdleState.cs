using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(Animator animator, Rigidbody2D rigidbody, Transform transform, Transform playerPosition, StateMachine statemachine) : base(animator, rigidbody, transform, playerPosition, statemachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        // Add additional code that should be executed when entering the MovingState
        anim.SetTrigger("Idling");
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

    public override void SwitchState()
    {
        base.SwitchState();
        //if(player == playerSpa)
        
        
        if(canTransition)
        {
            float distance = trans.position.x - playerPos.position.x;
            //float distance = this.transform.position.x - player.position.x;
            if (Mathf.Abs(distance) > attackRange)
            {
                Debug.Log("nextstate: moving");
                stateMachine.nextState = new MovingState(anim, rb, trans, playerPos, stateMachine);
            }
            else
            {
                Debug.Log("ïn combat range");
                if(stateMachine.playerMoved)
                {
                    //Choosing attack 

                } else
                {
                    stateMachine.nextState = new IdleState(anim, rb, trans, playerPos, stateMachine);
                }

            }
            //Check if enemy is in attack range

            //Determine attack
            //Else move towards player
        }

    }
}
