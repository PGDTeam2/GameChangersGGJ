using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : BaseState
{

    private Vector3 gizmosCenter;
    private bool startMoving;

    public MovingState(Animator animator, Rigidbody2D rigidbody, Transform transform, Transform playerPosition, StateMachine statemachine) : base(animator, rigidbody, transform, playerPosition, statemachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        // Add additional code that should be executed when entering the MovingState
        anim.SetTrigger("Moving");
    }

    public override void Update()
    {
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "m_walk")
        {
            startMoving = true;
        }

        if (startMoving)
        {
            Vector3 targetpos = stateMachine.getPlayerPos();
            targetpos.y = trans.position.y; ;
            //look at player
            trans.GetChild(0).LookAt(targetpos);
            trans.position += trans.GetChild(0).forward * 2.0f * Time.deltaTime;

            float distance = trans.position.x - stateMachine.getPlayerPos().x;
            if (Mathf.Abs(distance) < attackRange && stateMachine.canAttack)
            {
                SwitchState();
            }
        }
        


        }

    public override void OnExit()
    {
        base.OnExit();
        startMoving = false;
        // Add additional code that should be executed when exiting the MovingState
    }

    public override void SwitchState()
    {
        
            stateMachine.canAttack = false;
            gizmosCenter = trans.position;
            float randomAttack = Random.Range(0, 100);
            if (randomAttack < 40)
            {
                //light attack
                stateMachine.nextState = new LightAttackState(anim, rb, trans, playerPos, stateMachine);
                
            }
            else if (randomAttack < 85)
            {
                //heavy attack
                stateMachine.nextState = new HeavyAttackState(anim, rb, trans, playerPos, stateMachine);
            }
            else
            {
                //special move
                stateMachine.nextState = new LightAttackState(anim, rb, trans, playerPos, stateMachine);
            }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gizmosCenter, attackRange);
    }
}
