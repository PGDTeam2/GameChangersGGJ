using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFight : MonoBehaviour
{
    [SerializeField] GameObject firstspawn;
    [SerializeField] GameObject secondspawn;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(FightData.firstFighter, firstspawn.transform);
        Instantiate(FightData.secondFighter, secondspawn.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
