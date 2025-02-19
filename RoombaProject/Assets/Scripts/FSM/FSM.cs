using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="FSM" ,menuName ="Custom/FSM")]
public class FSM : ScriptableObject
{
    [SerializeField] State currentState = null;
    [SerializeField] Dictionary<State , List<Transition>> transitions = new Dictionary<State , List<Transition>>();
    //[SerializeField] List<State> states = new List<State>();

    public State CurrentState {  get { return currentState; }  set { currentState = value; } }


public void AddTransitions(State _from , State _to , Func<bool> _condition )
    {
        if(!transitions.ContainsKey(_from))
        {
            transitions[_from] = new  List<Transition> ();
        }

        transitions[_from].Add(new(_condition, _to));

    }

    private void SetNextState(State _state)
    {
        if(currentState != null)
        {
           currentState.Exit();

        }
            currentState = _state;
            currentState.Start();
            
    }
    public void Update()
    {
        if (currentState == null) return;
        foreach (Transition _transition in transitions.GetValueOrDefault(currentState, new List<Transition>()))
        {
            if (_transition.Condition())
            {
                SetNextState(_transition.NextState);
                return;

            }
        }
        currentState.Update();
    }

    //Va stocker des états (peut etre des transitions)
    //a une list d'etat
    //dans cette liste va recuperer les données des états ? 
    // les conditions d'entrer et de sortie ? 
}
