using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Rigidbody2D rb;

    public BaseState currentState;
    private BaseState nextState;

    private Transform playerSpawn;
    public Transform player;

    private float attackRange = 5f;

    private void Start()
    {
        currentState = new IdleState(anim, rb);
        currentState.OnEnter();
        playerSpawn = player;
        nextState = new MovingState(anim, rb);
    }

    private void Update()
    {
        Debug.Log(currentState);
        float distance = this.transform.position.x - player.position.x;
        if(nextState == null)
        {
            if (Mathf.Abs(distance) > attackRange)
            {
                Debug.Log("nextstate: moving");
                nextState = new MovingState(anim, rb);
            }
            else
            {
                nextState = new IdleState(anim, rb);
            }
        }
        

        if (currentState == nextState)
        {
            Debug.Log("duplicate state");
            nextState = null;
        } else
        {

        }

        currentState.Update();
    }
}
