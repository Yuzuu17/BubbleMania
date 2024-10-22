using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Dictionary<string, List<GameObject>> ballsByTag = new Dictionary<string, List<GameObject>>();

    private void OnCollisionEnter(Collision collision)
    {
        string ballTag = collision.gameObject.tag;

        // Check if the collided object has a relevant ball tag
        if (ballTag == "Soccerball" || ballTag == "BasketBall" || ballTag == "Baseball")
        {
            Debug.Log("Collision with: " + ballTag); // Debug log

            // Add the ball to the dictionary
            if (!ballsByTag.ContainsKey(ballTag))
            {
                ballsByTag[ballTag] = new List<GameObject>();
            }

            // Add the collided ball to the list
            if (!ballsByTag[ballTag].Contains(collision.gameObject))
            {
                ballsByTag[ballTag].Add(collision.gameObject);
            }

            // Check for chained balls to destroy
            CheckForChainedDestruction(ballTag);
        }
    }

    private void CheckForChainedDestruction(string ballTag)
    {
        List<GameObject> ballsToDestroy = new List<GameObject>();
        HashSet<GameObject> visited = new HashSet<GameObject>();

        foreach (GameObject ball in ballsByTag[ballTag])
        {
            if (!visited.Contains(ball))
            {
                List<GameObject> connectedBalls = new List<GameObject>();
                FindConnectedBalls(ball, ballTag, connectedBalls, visited);

                if (connectedBalls.Count > 2 )
                {
                    ballsToDestroy.AddRange(connectedBalls);
                }
            }
        }

        // Destroy the balls in the connected list
        foreach (GameObject ball in ballsToDestroy)
        {
            Destroy(ball);
            Debug.Log("Destroyed: " + ball.name);
        }

        // Clear the list for this tag after processing
        ballsByTag[ballTag].Clear();
    }

    private void FindConnectedBalls(GameObject ball, string ballTag, List<GameObject> connectedBalls, HashSet<GameObject> visited)
    {
        if (visited.Contains(ball)) return;

        visited.Add(ball);
        connectedBalls.Add(ball);

        // Find adjacent balls within a certain distance
        GameObject[] allBalls = GameObject.FindGameObjectsWithTag(ballTag);
        foreach (GameObject otherBall in allBalls)
        {
            if (otherBall != ball && Vector3.Distance(ball.transform.position, otherBall.transform.position) < 1.5f) // Increased distance
            {
                FindConnectedBalls(otherBall, ballTag, connectedBalls, visited);
            }
        }
    }
}
