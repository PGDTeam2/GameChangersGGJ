using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BracketSystem : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] int rounds;
    public GameObject[] Enemies;
    public List<Fight> fights;
    public GameObject Player;


    void Start()
    {
        fights =  new List<Fight>();
        GenerateFights();
    }

    private void Update()
    {
        Debug.Log(fights.Count);
    }



    void GenerateFights()
    {
        fights.Add(new Fight(Player, Enemies[0]));
        for (int i = 1; i < Enemies.Length; i++)
        {
            fights.Add(new Fight(Enemies[i], Enemies[i]));
        }

    }
}


