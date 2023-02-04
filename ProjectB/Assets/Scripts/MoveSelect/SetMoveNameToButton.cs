using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetMoveNameToButton : MonoBehaviour
{
    public Move move;
    [SerializeField] TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        setName();
    }

    void setName()
    {
        if (move == null || move.InGameName == null)
        {
            buttonText.text = "None";
        }
        else
        {
            buttonText.text = move.InGameName;
        }
    }
}
