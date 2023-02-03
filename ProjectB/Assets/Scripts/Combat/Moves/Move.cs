using System.Collections;
using UnityEngine;

public abstract class Move : ScriptableObject
{
    public int Damage;
    public MoveType Type;
    public string AnimationName;
    
    public abstract void Execute(CombatEntity context);
}