using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class Brain : MonoBehaviour
{
    [SerializeField] FSM fsm = null;
    [SerializeField] CleaningState cleaningState = null;
    void Start()
    {
        // InitScriptable();
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
        IdleState _idle = new IdleState(gameObject );
        CleaningState _clean = new CleaningState(gameObject);

        fsm = new FSM();
        fsm.AddTransitions(_idle, _clean, /*Si le clean state a une target */ () => _clean.FindFirstObjectWithLayer());
        fsm.AddTransitions(_clean, _idle, /*Si le */() => _clean.CanNextState);
        fsm.SetNextState(_clean);
    }

    //void InitScriptable()
    //{
    //    // LayerMask.
    //    cleaningState = ScriptableObject.CreateInstance<CleaningState>();
    //    if(cleaningState == null )
    //    {
    //        Debug.Log("NO STATE !!!!");
    //    }
    //    string _path = "assets/item.asset";
    //    AssetDatabase.CreateAsset(cleaningState, _path);
    //    AssetDatabase.SaveAssets();


    //    cleaningState.LayerToDetect = LayerMask.NameToLayer("Spot");
    //    Debug.Log(LayerMask.LayerToName(cleaningState.LayerToDetect));
    //}
}
