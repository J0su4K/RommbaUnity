using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "State/Base State")]
public abstract class State : ScriptableObject
{
    [SerializeField] protected GameObject owner = null;
    // [SerializeField] FSM fsm = null;

    protected virtual void Start()
    {
        Debug.Log("Entering Base State");
    }

    protected virtual void Update()
    {

    }
}
