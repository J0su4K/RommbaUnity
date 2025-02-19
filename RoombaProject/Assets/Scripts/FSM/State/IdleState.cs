using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "State/Idle State")]
public class IdleState : State
{
    public override void Start()
    {
        Debug.Log("Entering Idle State");
    }

    public override void Update() 
    {
        
    }
    public override void Exit()
    {
        
    }
}
