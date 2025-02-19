using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject spotToSpawn = null;
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
        int _randomX = Random.Range(0, 15);
        int _randomZ = Random.Range(0, 15);

        Vector3 _randomPosition = new Vector3(_randomX , 0 , _randomZ);
        Instantiate(spotToSpawn, _randomPosition, Quaternion.identity);
    }
}
