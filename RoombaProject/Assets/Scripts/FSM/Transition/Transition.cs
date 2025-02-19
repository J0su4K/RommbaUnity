using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Transition
{
    public Func<bool> Condition { get; private set; }
    public State NextState { get; private set; }


    public Transition(Func<bool> condition, State nextState)
    {
        Condition = condition;
        NextState = nextState;
    }
}
