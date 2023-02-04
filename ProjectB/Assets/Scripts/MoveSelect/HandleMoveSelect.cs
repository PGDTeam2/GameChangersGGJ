using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandleMoveSelect : MonoBehaviour
{

    [SerializeField] Move Move1;
    [SerializeField] Move Move2;
    [SerializeField] Move NewMove;

    [SerializeField] GameObject confirmationBox;

    // Start is called before the first frame update
    void Start()
    {
        confirmationBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeMove(int Location)
    {
        if (Location == 1)
        {
            Move1 = NewMove;
        }
        else if (Location == 2)
        {
            Move2 = NewMove;
        }
        else
        {
            return;
        }
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
