using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
        InvokeRepeating(nameof(SpawnSpot), 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {

    }

    void SpawnSpot()
    {
        //Spot spot = GameObject.Instantiate<Spot>()
    }
}
