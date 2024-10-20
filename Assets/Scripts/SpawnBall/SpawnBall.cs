using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject[] BallsPrefabs;                                                               // Array 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Randomly select one of the prefabs from the array
            int randomIndex = Random.Range(0, BallsPrefabs.Length);
            GameObject selectedPrefab = BallsPrefabs[randomIndex];

            // Instantiate the selected prefab
            Instantiate(selectedPrefab, transform.position, Quaternion.identity);
            Debug.Log("Ball");
        }
    }
}