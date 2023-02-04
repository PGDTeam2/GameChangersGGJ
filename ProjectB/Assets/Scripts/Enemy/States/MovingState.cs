using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : BaseState
{

    private Vector3 gizmosCenter;
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
        Vector3 targetpos = stateMachine.getPlayerPos();
        targetpos.y = trans.position.y;
        targetpos.z = 0;
        //look at player
        trans.GetChild(0).LookAt(targetpos);
        trans.position += trans.GetChild(0).forward * 2.0f * Time.deltaTime;
        Debug.Log("Movve");



    }

    public override void OnExit()
    {
        base.OnExit();
        // Add additional code that should be executed when exiting the MovingState
    }

    public override void SwitchState()
    {
        base.SwitchState();
        float distance = trans.position.x - stateMachine.getPlayerPos().x;
        Debug.Log("Distance: " + distance);
        if (Mathf.Abs(distance) < attackRange)
        {
            Debug.Log("In combat range");
            gizmosCenter = trans.position;
            
            //Attack state
            stateMachine.nextState = new IdleState(anim, rb, trans, playerPos, stateMachine);
        }   
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gizmosCenter, attackRange);
    }
}
