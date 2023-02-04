using System.Collections;
using UnityEngine;

public abstract class Move : ScriptableObject
{
    public string InGameName;
    public int Damage;
    public MoveType Type;
    public string AnimationName;
    public bool ForceStandStill;
    public bool IsCancelable;
    
    public virtual void OnAnimationStart(CombatEntity context) 
    {}
    
    public virtual void OnAnimationEnd(CombatEntity context)
    {}
    
    public abstract void Execute(CombatEntity context);

    public virtual void OnCancel(CombatEntity context)
    {}
}