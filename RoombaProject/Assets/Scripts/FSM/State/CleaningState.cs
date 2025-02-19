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
    [SerializeField] bool canNextState = false;

    public bool CanNextState => canNextState;
    public LayerMask LayerToDetect { get { return layerToDetect; } set { layerToDetect = value; } }
    public CleaningState(GameObject _owner) : base(_owner)
    {
        owner = _owner;
    }

    public GameObject CurrentTarget => currentTarget;
    public override void Start()
    {
        Debug.Log("Entering Cleaning State");
        agent = GameObject.FindAnyObjectByType<NavMeshAgent>();
        layerToDetect = 1 << LayerMask.NameToLayer("Spot");
        FindFirstObjectWithLayer();
    }


    public override void Update()
    {
        // Debug.Log("Update Cleaning State");
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
        return Vector3.Distance(agent.transform.position, currentTarget.transform.position) < 2f;
    }

    public GameObject FindFirstObjectWithLayer()
    {
        GameObject[] _allObjects = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (GameObject obj in _allObjects)
        {
            // Debug.Log($"First layer => {LayerMask.LayerToName(layerToDetect)} \n Second Layer {LayerMask.LayerToName(obj.layer)}");
            if ((layerToDetect.value & (1 << obj.layer)) != 0)
            {
                Debug.Log("Trouvé !");
                currentTarget = obj;
                canNextState = false;
                return obj;
            }
        }
        canNextState = true;
        return null;
    }

    public override void Exit()
    {

    }
}
