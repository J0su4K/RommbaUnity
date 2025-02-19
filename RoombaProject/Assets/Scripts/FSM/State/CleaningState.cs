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
    [SerializeField] int test = 0;
    [SerializeField] Spot spot = null;



    public LayerMask LayerToDetect { get { return layerToDetect; }  set { layerToDetect = value; } }
    public CleaningState(GameObject _owner) : base(_owner)
    {
        owner = _owner;
    }

    public GameObject CurrentTarget => currentTarget;
    public override void Start()
    {
        Debug.Log("Entering Cleaning State");
        agent = GameObject.FindAnyObjectByType<NavMeshAgent>();
    }


    public override void Update()
    {
        Debug.Log("Update Cleaning State");
        if (!agent)
        {
        Debug.Log("Nop agent !");
            return;
        }
        if (!currentTarget)
        {
            Debug.Log("Try to search a target ");
            FindFirstObjectWithLayer();
            return;
        }
        agent.SetDestination(currentTarget.transform.position);
        if (IsAtDestination())
        {
            Destroy(currentTarget);
            currentTarget = null;
        }
    }

    bool IsAtDestination()
    {
        return Vector3.Distance(agent.transform.position, currentTarget.transform.position) < 0.5f;
    }

    GameObject FindFirstObjectWithLayer()
    {
        GameObject[] _allObjects = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (GameObject obj in _allObjects)
        {
            Debug.Log($"First layer => {LayerMask.LayerToName(layerToDetect)} \n Second Layer {LayerMask.LayerToName(obj.layer)}");
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
