using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BracketSystem : MonoBehaviour
{
    [SerializeField] int amount;
    public GameObject[] Enemies;
    public Fight[] fights;
    public GameObject Player;


    void Start()
    {
        fights = new Fight[amount];
        GenerateFights();
    }



    void GenerateFights()
    {
        for (int i = 0; i < fights.Length; i++)
        {
            if (i == 0)
                fights[i] = new Fight(0, Player, Enemies[0]);
        }

    }
}


