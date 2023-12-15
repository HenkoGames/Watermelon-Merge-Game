using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_FruitSpawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    [Header("Spawn Delta")]
    public float min;
    public float max;
    [Space]
    public GameObject[] Fruits;

    private void Start()
    {
        StartCoroutine(SpawnCycle());
    }
    IEnumerator SpawnCycle()
    {
        while (true) 
        {
            
            Instantiate(
                Fruits[Random.Range(0,Fruits.Length)],
                SpawnPoints[Random.Range(0,SpawnPoints.Length)].position,
                Quaternion.identity,
                transform.parent
                );
            yield return new WaitForSeconds(Random.Range(min,max));
        }
    }
}
