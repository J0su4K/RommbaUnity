using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="FSM" ,menuName ="Custom/FSM")]
public class FSM : ScriptableObject
{
    [SerializeField] State currentState = null;


    // [SerializeField] Dictionary<State , >
    //Va stocker des �tats (peut etre des transitions)
    //a une list d'etat
    //dans cette liste va recuperer les donn�es des �tats ? 
    // les conditions d'entrer et de sortie ? 
}
