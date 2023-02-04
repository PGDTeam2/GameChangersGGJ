using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [HideInInspector]
    public int CurrentHealth;

    public int MaxHealth = 100;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void Heal(int add)
    {
        CurrentHealth = Math.Min(CurrentHealth + add, MaxHealth);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        
        Debug.Log(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            // You Died
        }
    }
}
