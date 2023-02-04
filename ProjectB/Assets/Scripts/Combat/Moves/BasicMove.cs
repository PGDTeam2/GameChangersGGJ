using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BasicMove : Move
{
    public override void Execute(CombatEntity context)
    {
        if (context.TestHit(out var other))
        {
            other.health.TakeDamage(Damage);
        }
    }
}
