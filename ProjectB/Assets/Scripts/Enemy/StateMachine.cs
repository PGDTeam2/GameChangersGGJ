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

    public Vector3 playerSpawn;
    public PlayerMovement player;

    public bool playerMoved = false;
    public bool canAttack;



    //private float attackRange = 5f;

    private void Start()
    {
        currentState = new IdleState(anim, rb, trans, player.transform, this);
        currentState.OnEnter();
        playerSpawn = player.transform.position;
        previousState = currentState;
        movementSpeed = player._movementSpeed;
        canAttack = true;
        //nextState = new MovingState(anim, rb, player, this);
    }

    private void Update()
    {
        if(!playerMoved && player.transform.position != playerSpawn)
        {
            playerMoved = true;
        }

        

       //Dont update state if next state is same as current
       if(nextState == currentState)
        {
            nextState = null;
        }
        currentState.Update();

        //Change current state
        if (nextState != null)
        {
            currentState.OnExit();
            previousState = currentState;
            currentState = nextState;
            nextState = null;
            currentState.OnEnter();
        }

        //Debug.Log("Current animation clip: " + anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);


        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"));
        
    }

    public void SwitchState()
    {
        Debug.Log("Switch state");
        currentState.SwitchState();
    }

    public IEnumerator enableAttack()
    {
        yield return new WaitForSeconds(0.8f);
        canAttack = true;
    }

    public Vector3 getPlayerPos()
    {
        return player.transform.position;
    }

}
