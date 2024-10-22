using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject[] BallsPrefabs;                                                           // Array of ball prefabs
    public float spawnDelay = 1.0f;                                                            // Delay between spawns

    private bool canSpawn = true;                                                                // Flag to control spawning

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canSpawn)
        {
            StartCoroutine(SpawnBallWithDelay());
        }
    }

    private IEnumerator SpawnBallWithDelay()
    {
        canSpawn = false; // Prevent further spawns until delay is complete

        // Randomly select one of the prefabs from the array
        int randomIndex = Random.Range(0, BallsPrefabs.Length);
        GameObject selectedPrefab = BallsPrefabs[randomIndex];

        // Instantiate the selected prefab
        Instantiate(selectedPrefab, transform.position, Quaternion.identity);
        Debug.Log("Ball");

        // Wait for the specified delay
        yield return new WaitForSeconds(spawnDelay);

        canSpawn = true; // Allow spawning again
    }
}
