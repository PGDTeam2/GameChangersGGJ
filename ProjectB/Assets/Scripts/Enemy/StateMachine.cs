using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform trans;

    public BaseState currentState;
    public BaseState nextState;
    public BaseState previousState;

    public float movementSpeed;

    private Transform playerSpawn;
    public PlayerMovement player;

    public bool playerMoved = false;



    //private float attackRange = 5f;

    private void Start()
    {
        currentState = new IdleState(anim, rb, trans, player.transform, this);
        currentState.OnEnter();
        playerSpawn = player.transform;
        previousState = currentState;
        movementSpeed = player._movementSpeed;
        //nextState = new MovingState(anim, rb, player, this);
    }

    private void Update()
    {
        if(!playerMoved && playerSpawn.position != playerSpawn.position)
        {
            playerMoved = true;
        }

        Debug.Log("Statemachine, currentstate: " + currentState);
        Debug.Log("Current animation clip: " + anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);


       //Dont update state if next state is same as current
       if(nextState == currentState)
        {
            nextState = null;
            Debug.Log("Duplicate state entry");
        }

       //Change current state
       if(nextState != null)
        {
            currentState.OnExit();
            previousState = currentState;
            currentState = nextState;
            nextState = null;
            currentState.OnEnter();
        }
        currentState.Update();
        currentState.SwitchState();
    }

    public Vector3 getPlayerPos()
    {
        return player.transform.position;
    }
}
