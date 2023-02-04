using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private bool playedAnim = false;
    public AttackState(Animator animator, Rigidbody2D rigidbody, Transform transform, Transform playerPosition, StateMachine statemachine) : base(animator, rigidbody, transform, playerPosition, statemachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        stateMachine.canAttack = false;
        // Add additional code that should be executed when entering the MovingState
        
    }

    public override void Update()
    {
        //base.Update();
        // Add code that updates the MovingState
       // Debug.Log("normalized time: " + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        if(anim.GetCurrentAnimatorClipInfo(0).Length > 0)
        {
            if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "m_melee_combat_attack_A")
            {
                playedAnim = true;
            }
            Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        }
         if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && playedAnim)
        {
            Debug.Log("Animation finished");
            SwitchState();
            return;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("On Attack Exit");
        playedAnim = false;
        stateMachine.StartCoroutine(stateMachine.enableAttack());
        // Add additional code that should be executed when exiting the MovingState
    }

    public override void SwitchState()
    {
        base.SwitchState();
        //Canceling Switch if transition still busy

    }


}
