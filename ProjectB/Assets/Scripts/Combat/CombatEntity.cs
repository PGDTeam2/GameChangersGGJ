using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class CombatEntity : MonoBehaviour
{
    public GameObject HitCollider;
    [Header("Debug")] 
    public bool drawGizmos;

    internal Animator animator;
    internal Health health;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    public bool TestHit(out CombatEntity other)
    {
        other = null;
        var hit = Physics2D.CircleCast((Vector2) HitCollider.transform.position, HitCollider.transform.localScale.x, Vector2.zero, 0, LayerMask.GetMask("CombatEntity"));
        
        if (hit)
            other = hit.collider.GetComponent<CombatEntity>();
        
        return hit;
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos)
            Gizmos.DrawWireSphere(HitCollider.transform.position, HitCollider.transform.localScale.x);
    }
}
