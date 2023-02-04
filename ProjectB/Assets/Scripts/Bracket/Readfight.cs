using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Readfight : MonoBehaviour
{
    [SerializeField] int FightToSpawn;
    Fight currentfight;
    [SerializeField] BracketSystem bracketSystem;

    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //dev check code for fight 1
            bracketSystem.fights[0].winner = 1;
            bracketSystem.fights[1].winner = 1;

            //dev check code for fight 2
            bracketSystem.fights[2].winner = 1;
            bracketSystem.fights[3].winner = 1;

            //dev check code for fight 3
            bracketSystem.fights[4].winner = 1;
            bracketSystem.fights[5].winner = 1;

            //dev check code for fight 4
            bracketSystem.fights[6].winner = 1;
            bracketSystem.fights[7].winner = 1;

            advanceBranch(bracketSystem.fights[0], bracketSystem.fights[1]);
            advanceBranch(bracketSystem.fights[2], bracketSystem.fights[3]);
            advanceBranch(bracketSystem.fights[4], bracketSystem.fights[5]);
            advanceBranch(bracketSystem.fights[6], bracketSystem.fights[7]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //dev check code for fight 5
            bracketSystem.fights[8].winner = 1;
            bracketSystem.fights[9].winner = 1;

            //dev check code for fight 6
            bracketSystem.fights[10].winner = 1;
            bracketSystem.fights[11].winner = 1;

            advanceBranch(bracketSystem.fights[8], bracketSystem.fights[9]);
            advanceBranch(bracketSystem.fights[10], bracketSystem.fights[11]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //dev check code for fight 7
            bracketSystem.fights[12].winner = 1;
            bracketSystem.fights[13].winner = 1;

            advanceBranch(bracketSystem.fights[12], bracketSystem.fights[13]);
        }
    }

    public Fight getFight(int fightNr)
    {
        return bracketSystem.fights[fightNr];
    }
    void advanceBranch(Fight firstFight, Fight secondFight)
    {
        if (firstFight.winner != 0 && firstFight.winner != 0)
        {
            GameObject winnerFirstFight = null;
            GameObject winnerSecondFight = null;
            if (firstFight.winner == 1)
                winnerFirstFight = firstFight.firstFighter;
            else if (bracketSystem.fights[0].winner == 2)
                winnerFirstFight = firstFight.secondFighter;

            if (secondFight.winner == 1)
                winnerSecondFight = secondFight.firstFighter;
            else if (secondFight.winner == 2)
                winnerSecondFight = secondFight.secondFighter;

            bracketSystem.fights.Add(new Fight(winnerFirstFight, winnerSecondFight));
        }



    }
}
