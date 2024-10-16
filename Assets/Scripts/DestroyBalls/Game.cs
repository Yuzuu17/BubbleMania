using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject Balls;
    private Dictionary<string, int> ballCollisionCount = new Dictionary<string, int>();

    private void OnCollisionEnter(Collision collision)
    {
        string ballTag = collision.gameObject.tag;

        // Check if the collided object has a relevant ball tag
        if (ballTag == "Soccerball" || ballTag == "BasketBall" || ballTag == "Baseball")
        {
            // Increment the count for this ball type
            if (!ballCollisionCount.ContainsKey(ballTag))
            {
                ballCollisionCount[ballTag] = 0;
            }
            ballCollisionCount[ballTag]++;

            // Check if the count has reached 3
            if (ballCollisionCount[ballTag] >= 3)
            {
                // Destroy all balls of this type
                DestroyBallsOfType(ballTag);

                // Reset the count for this ball type
                ballCollisionCount[ballTag] = 0;
            }
        }
    }

    private void DestroyBallsOfType(string ballTag)
    {
        // Find all objects with the specified tag and destroy them
        GameObject[] ballsToDestroy = GameObject.FindGameObjectsWithTag(ballTag);
        foreach (GameObject ball in ballsToDestroy)
        {
            Destroy(ball);
        }
    }
}
