using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "NewItem", menuName = "State/Cleaning State")]
public class CleaningState : State
{
    [SerializeField] NavMeshAgent agent = null;
    [SerializeField] GameObject currentTarget = null;
    [SerializeField] LayerMask layerToDetect;


    public override void Start()
    {
        Debug.Log("Entering Cleaning State");
    }



    public override void Update()
    {
        if (!agent) return;
        if (!currentTarget)
        {
            FindFirstObjectWithLayer();
            return;
        }
        agent.SetDestination(currentTarget.transform.position);
    }

    GameObject FindFirstObjectWithLayer()
    {
        GameObject[] _allObjects = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (GameObject obj in _allObjects)
        {
            if ((layerToDetect.value & (1 << obj.layer)) != 0)
            {
                Debug.Log("Trouvé !");
                currentTarget = obj;
                return obj;
            }
        }
        return null;
    }

    public override void Exit()
    {

    }
}
