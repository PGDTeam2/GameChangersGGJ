using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SlipperMove : Move
{
    public GameObject slipper;
    
    public override void Execute(CombatEntity context)
    {
        Instantiate(slipper);
    }
}
    