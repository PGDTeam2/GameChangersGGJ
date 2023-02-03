using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSet : MonoBehaviour
{
    public Move lightAttack;
    public Move heavyAttack;
    public Move special1;
    public Move special2;

    internal List<Move> learnedMoves = new();
    private Move currentMove;
    
    private CombatEntity context;
    private Animator animator;

    private bool IsExecutingAttack
    {
        get { return currentMove != null; }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        context = GetComponent<CombatEntity>();
    }

    public void DoLightAttack()
    {
        DoMove(lightAttack);
    }

    public void DoHeavyAttack()
    {
        DoMove(heavyAttack);
    }

    public void DoSpecial1Attack()
    {
        DoMove(special1);
    }
    
    public void DoSpecial2Attack()
    {
        DoMove(special2);
    }

    public void OnAttackAnimationEvent()
    {
        currentMove.Execute(context);
    }

    private void DoMove(Move move)
    {
        if (IsExecutingAttack)
            return;
        
        StartCoroutine(PlayAttackAnimation(move));
    }

    private IEnumerator PlayAttackAnimation(Move move)
    {
        currentMove = move;
        
        animator.Play(move.AnimationName);
        while (animator.GetCurrentAnimatorStateInfo(0).IsName(move.AnimationName))
        {
            yield return null;
        }
        
        currentMove = null;
    }
}
