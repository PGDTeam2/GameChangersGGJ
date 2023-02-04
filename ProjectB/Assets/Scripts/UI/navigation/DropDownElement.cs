using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Dropdown))]
public class DropDownElement : navableElement
{
    TMP_Dropdown dropdown;
    bool selected = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        dropdown = GetComponent<TMP_Dropdown>();
    }

    private void Update(){
        if(selected)
        dropdown.Show();
    }

    public override void Activate()
    {
        if(!selected){
            selected = true;
        }
    }
    public override navableElement moveTo(Direction direction)
    {   
        if(!selected)
            return base.moveTo(direction);

        return this;
    }
}
