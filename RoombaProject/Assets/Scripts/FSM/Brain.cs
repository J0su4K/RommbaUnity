using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    FSM fsm = null;
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(fsm !=  null)
            fsm.Update();
    }

    void Init()
    {
        IdleState _idle = new IdleState( );
        CleaningState _clean = new CleaningState( );
        fsm.AddTransitions(_idle , _clean , /*Si le clean state a une target */ () => 0 == 0);
        fsm.AddTransitions(_clean , _idle , /*Si le */() => 0 == 0);
    }
}
