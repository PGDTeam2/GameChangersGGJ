using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BasicMove : Move
{
    public override void Execute(CombatEntity context)
    {
        Debug.Log("Execute");
        if (context.TestHit(out var other))
        {
            Debug.Log("register Hit");
            other.health.TakeDamage(Damage);
        }
    }
}
