using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickFunctions : MonoBehaviour
{
    [SerializeField] BracketLocation[] bracket;
    [SerializeField] Readfight read;

    public void spawnFightOnLocation()
    {
        Debug.Log("Spawning in");
        for (int i = 0; i < 14; i++)
        {
            Fight currentfight1 = read.getFight(i);
            Instantiate(currentfight1.firstFighter, bracket[i].spawn1.transform);
            Instantiate(currentfight1.secondFighter, bracket[i].spawn2.transform);
        }

    }

}
