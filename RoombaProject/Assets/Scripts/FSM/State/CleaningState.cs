using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "NewItem", menuName = "State/Cleaning State")]
public class CleaningState : State
{
    [SerializeField] NavMeshAgent agent = null;
    [SerializeField] Transform currentTarget = null;
    [SerializeField] private LayerMask layerToDetect;


    //void Start()
    //{
    //    Debug.Log("Entering Cleaning State");
    //}

    // Update is called once per frame

    public override void Update()
    {
        if (!agent) return;
        agent.SetDestination(FindFirstObjectWithLayer().transform.position);
    }

    GameObject FindFirstObjectWithLayer()
    {
        GameObject[] _allObjects = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        foreach (GameObject obj in _allObjects)
        {
            if (obj.layer == layerToDetect) 
            {
                return obj;
            }
        }
        return null; // Aucun objet trouvé
    }
}
