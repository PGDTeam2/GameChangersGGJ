using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    [SerializeField] MoveSet moveSet;
    [SerializeField] public Move firstSpecial;
    [SerializeField] public Move secondSpecial;
    internal Move pastMove;
    [SerializeReference] internal List<Move> learnedMoves = new();
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveSet.special1 = firstSpecial;
        moveSet.special2 = secondSpecial;
        moveSet.learnedMoves = learnedMoves;
    }

    public void changeSpecial(int Slot, Move NewMove)
    {
        if(Slot == 1)
        {
            pastMove = firstSpecial;
            firstSpecial = NewMove;
        }
        else if(Slot == 2)
        {
            pastMove = secondSpecial;
            secondSpecial = NewMove;
        }
        else
        {
            return;
        }
    }

    public void AddMove(Move move)
    {
        learnedMoves.Add(move);
    }


    public Move getLastMove()
    {
        return learnedMoves[learnedMoves.Count - 1];
    }
}
