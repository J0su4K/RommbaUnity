using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "State/Idle State")]
public class IdleState : State
{
    [SerializeField] float wait = 3.0f;
    [SerializeField] bool isWaiting = false;

    public IdleState(GameObject _owner) : base(_owner)
    {
     owner = _owner;
    }

    public float Wait => wait;
    public bool IsWaiting => isWaiting;
    public override void Start()
    {
        Debug.Log("Entering Idle State");
    }

    public override void Update() 
    {
        Debug.Log("Update Idle State");
    }


    public override void Exit()
    {

    }
}
