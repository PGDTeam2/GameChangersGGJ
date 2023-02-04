using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class HandleMoveSelect : MonoBehaviour
{
    bool editing;
    bool deleting;
    [SerializeField] SetMoveNameToButton Button1;
    [SerializeField] SetMoveNameToButton Button2;
    [SerializeField] Move NewMove;
    [SerializeField] SetMoveNameToButton ButtonPrefab;
    [SerializeField] MoveManager MoveManager;

    [SerializeField] TextMeshProUGUI ModeText;

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
        if (!editing && !deleting)
        {
            ModeText.text = " ";
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

    public void setEditing()
    {
        editing = editing ? false : true;
        ModeText.text = "Adding move";
    }
    public void setDelete()
    {
        deleting = deleting ? false : true;
        ModeText.text = "Removing move";
    }

    public void ListNewMove()
    {
        ButtonPrefab.move = MoveManager.getLastMove();
        Instantiate(ButtonPrefab, listLocation.transform.position, Quaternion.identity, listLocation.transform);
    }

    public void ChangeMove(int Slot)
    {
        if (editing)
        {
            if (Slot == 1)
            {
                MoveManager.changeSpecial(1, NewMove);
                editing = false;
            }
            else if (Slot == 2)
            {
                MoveManager.changeSpecial(2, NewMove);
                editing = false;
            }
            else
            {
                return;
            }
        }
    }
    public void DeleteMove(int Slot)
    {
        if (deleting)
        {
            if (Slot == 1)
            {
                MoveManager.changeSpecial(1, null);
                deleting = false;
            }
            else if (Slot == 2)
            {
                MoveManager.changeSpecial(2, null);
                deleting = false;
            }
            else
            {
                return;
            }
        }
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
