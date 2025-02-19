using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "State/Idle State")]
public class IdleState : State
{
    protected override void Start()
    {
        Debug.Log("Entering Idle State");
    }

    protected override void Update() 
    {
        
    }
}
