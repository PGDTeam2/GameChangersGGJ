using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public int fightNR;
    public GameObject firstFighter;
    public GameObject secondFighter;
    public Fight(int nr, GameObject firstFighter, GameObject secondFighter) {
        fightNR = nr;
        this.firstFighter = firstFighter;
        this.secondFighter = secondFighter;
    }


}
