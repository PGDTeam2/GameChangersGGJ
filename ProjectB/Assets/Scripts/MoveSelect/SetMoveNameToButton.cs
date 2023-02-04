using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetMoveNameToButton : MonoBehaviour
{
    [SerializeField] Move move;
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
        buttonText.text = move.name;
    }
}
