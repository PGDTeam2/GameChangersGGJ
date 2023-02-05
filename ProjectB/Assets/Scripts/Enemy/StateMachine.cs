using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // serialized references to the animator component, rigidbody2D component, and transform component
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform trans;

    // references to the current, next, and previous state of the state machine
    public BaseState currentState;
    public BaseState nextState;
    public BaseState previousState;

    // movement speed of the player
    public float movementSpeed;

    // position of the player spawn and reference to the player movement script
    public Vector3 playerSpawn;
    public PlayerMovement player;

    // flag to indicate if the player has moved
    public bool playerMoved = false;

    // flag to indicate if the player can attack
    public bool canAttack;

    private void Start()
    {
        // set the current state to an idle state
        currentState = new IdleState(anim, rb, trans, player.transform, this);
        currentState.OnEnter();

        // store the player spawn position
        playerSpawn = player.transform.position;

        // set the previous state to the current state
        previousState = currentState;

        // store the player's movement speed
        movementSpeed = player._movementSpeed;

        // set the flag to indicate that the player can attack
        canAttack = true;
    }

    private void Update()
    {
        // set the playerMoved flag to true if the player has moved
        if (!playerMoved && player.transform.position != playerSpawn)
        {
            playerMoved = true;
        }

        // do not update the state if the next state is the same as the current state
        if (nextState == currentState)
        {
            nextState = null;
        }

        // update the current state
        currentState.Update();

        // change the current state if a next state has been set
        if (nextState != null)
        {
            currentState.OnExit();
            previousState = currentState;
            currentState = nextState;
            nextState = null;
            currentState.OnEnter();
        }

        // log the current state to the console
        Debug.Log("current state: " + currentState);
    }

    // method to switch the state of the state machine
    public void SwitchState()
    {
        Debug.Log("Switch state");
        currentState.SwitchState();
    }

    // coroutine to enable the player's attack after a certain time period
    public IEnumerator enableAttack()
    {
        yield return new WaitForSeconds(0.8f);
        canAttack = true;
    }

    // method to return the current position of the player
    public Vector3 getPlayerPos()
    {
        return player.transform.position;
    }
}
