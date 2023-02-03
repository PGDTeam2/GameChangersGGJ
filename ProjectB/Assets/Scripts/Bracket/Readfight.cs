using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Readfight : MonoBehaviour
{
    [SerializeField] int fightNR;
    Fight currentfight;
   [SerializeField] BracketSystem bracketSystem;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            getFight();
            spawnFight();
        }

    }

    void getFight()
    {
        currentfight = bracketSystem.fights[fightNR];
    }
    void spawnFight()
    {
        Instantiate(currentfight.firstFighter);
        Instantiate(currentfight.secondFighter);
    }
}
