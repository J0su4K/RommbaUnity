using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "State/Base State")]
public abstract class State : ScriptableObject
{
    [SerializeField] protected GameObject owner = null;
    // [SerializeField] FSM fsm = null;

    public State(GameObject _owner)
    {
        owner = _owner;
    }
    public virtual void Start()
    {
        Debug.Log("Entering Base State");
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }
}
