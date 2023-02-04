using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : BaseState
{
    private float speed = 2f;

    public MovingState(Animator animator, Rigidbody2D rigidbody) : base(animator, rigidbody)
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
        // Add code that updates the MovingState
        Vector2 targetPos = new Vector2(anim.transform.position.x + speed, anim.transform.position.y);
        Debug.Log(targetPos);
        rb.MovePosition(targetPos * Time.fixedDeltaTime);
        Debug.Log("Moving update");
    }

    public override void OnExit()
    {
        base.OnExit();
        // Add additional code that should be executed when exiting the MovingState
    }
}
