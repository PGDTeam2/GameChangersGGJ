using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class HandleMoveSelect : MonoBehaviour
{
    [SerializeField] SetMoveNameToButton Button1;
    [SerializeField] SetMoveNameToButton Button2;
    [SerializeField] Move NewMove;
    [SerializeField] SetMoveNameToButton ButtonPrefab;
    [SerializeField] MoveManager MoveManager;

    [SerializeField] GameObject confirmationBox;

    // Start is called before the first frame update
    void Start()
    {
        confirmationBox.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (MoveManager != null)
        {
            if (MoveManager.firstSpecial != null)
                Button1.move = MoveManager.firstSpecial;
            if (MoveManager.firstSpecial != null)
                Button2.move = MoveManager.secondSpecial;
            NewMove = MoveManager.getLastMove();
        }

    }

    public void ChangeMove(int Slot)
    {
        if (Slot == 1)
        {
            Button2.move = MoveManager.pastMove;
            MoveManager.changeSpecial(1, NewMove);
        }
        else if (Slot == 2)
        {
            Button1.move = MoveManager.pastMove;
            MoveManager.changeSpecial(2, NewMove);
        }
        else
        {
            return;
        }
    }
    [SerializeField] GameObject listLocation;
    public void ListLearnedMoves()
    {
        for (int i = 0; i < MoveManager.learnedMoves.Count; i++)
        {
            ButtonPrefab.move = MoveManager.learnedMoves[i];
            float spacing = -30;
            Vector3 pos = new Vector3(0, spacing*i, 0);
            Instantiate(ButtonPrefab, listLocation.transform.position + pos, Quaternion.identity, listLocation.transform);
        }
    }

    public void ListNewMove()
    {
        ButtonPrefab.move = MoveManager.getLastMove();
        Instantiate(ButtonPrefab, listLocation.transform.position, Quaternion.identity, listLocation.transform);
    }

    public void DeleteMove()
    {
        
    }

    public void RemoveConfirmationBox()
    {
        confirmationBox.SetActive(false);
    }
    public void ShowConfirmationBox()
    {
        confirmationBox.SetActive(true);
    }
}
