using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Testscripts : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent = null;
    [SerializeField] GameObject currentTarget = null;
    [SerializeField] LayerMask layerToDetect;

    void Start()
    {
        Debug.Log("Entering Cleaning State");
    }

    void Update()
    {
        if (!agent) return;

        if (!currentTarget)
        {
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
            if ((layerToDetect.value & (1 << obj.layer)) != 0)
            {
                Debug.Log("Trouvé !");
                currentTarget = obj;
                return obj;
            }
        }
        return null;
    }
}
