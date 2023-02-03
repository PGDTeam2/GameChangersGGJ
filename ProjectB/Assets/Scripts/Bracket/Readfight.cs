using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Readfight : MonoBehaviour
{
    Fight currentfight;
    [SerializeField] BracketSystem bracketSystem;
    List<GameObject> winners = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < bracketSystem.fights.Count; i++)
        {
            getFight(i);
            spawnFight();
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("player won");
            bracketSystem.fights[0].winner = 1;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("enemy3 won :D");
            bracketSystem.fights[1].winner = 1;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("UPDATING");
            updateFights();
        }
        Debug.Log("Winner count " + winners.Count);
    }

    void getFight(int fightNr)
    {
        currentfight = bracketSystem.fights[fightNr];
    }
    void spawnFight()
    {
        Instantiate(currentfight.firstFighter);
        Instantiate(currentfight.secondFighter);
    }
    void updateFights()
    {
        int winnersAmount = 0;
        foreach (Fight fight in bracketSystem.fights)
        {
            if (fight.winner != 0)
            {
                winnersAmount++;
                if (fight.winner == 1)
                    winners.Add(fight.firstFighter);
                else if (fight.winner == 2)
                    winners.Add(fight.secondFighter);
                fight.winner = 0;
            }
            if (winnersAmount == 2)
            {
                bracketSystem.fights.Add(new Fight(bracketSystem.fights.Count+1, winners[0], winners[1]));
                winnersAmount = 0;
            }
            Debug.Log(winnersAmount);
        }

    }
}
