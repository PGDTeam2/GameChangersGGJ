using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected Animator anim;
    protected Rigidbody2D rb;
    [SerializeField]
    private Transform player;

    public BaseState(Animator animator, Rigidbody2D rigidbody)
    {
        anim = animator;
        rb = rigidbody;
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
}
