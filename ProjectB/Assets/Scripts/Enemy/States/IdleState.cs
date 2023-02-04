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
        //base.Update();
        if (stateMachine.player.transform.position != stateMachine.playerSpawn)
        {
            SwitchState();
            return;
        }
        // Add code that updates the MovingState
    }

    public override void OnExit()
    {
        base.OnExit();
        anim.ResetTrigger("Idling");
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
                stateMachine.nextState = new MovingState(anim, rb, trans, playerPos, stateMachine);
            }
            else
            {
                if(stateMachine.playerMoved && stateMachine.canAttack)
                {
                    //Choosing attack 
                    float randomAttack = Random.Range(0, 100);
                    if(randomAttack < 40)
                    {
                        //light attack
                        stateMachine.nextState = new LightAttackState(anim, rb, trans, playerPos, stateMachine);
                    } else if(randomAttack < 85)
                    {
                        //heavy attack
                        stateMachine.nextState = new HeavyAttackState(anim, rb, trans, playerPos, stateMachine);
                    } else
                    {
                        //special move
                        stateMachine.nextState = new LightAttackState(anim, rb, trans, playerPos, stateMachine);
                    }
                    

                } 

            }
        }

    }
}
