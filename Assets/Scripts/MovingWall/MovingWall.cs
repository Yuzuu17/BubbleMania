using System.Collections;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MovePlatformCoroutine());
    }

    private IEnumerator MovePlatformCoroutine()
    {
        while (true) // Loop indefinitely
        {
            if (!isMoving)
            {
                MovingPlatform();
                isMoving = true; // Set the flag to indicate the platform is moving
                yield return new WaitForSeconds(0.5f); // Allow the platform to move for 1 second
                rb.velocity = Vector3.zero; // Stop the platform after moving
                yield return new WaitForSeconds(15f); // Wait for 10 seconds before moving again
                isMoving = false; // Reset the flag to allow moving again
            }
            yield return null; // Wait for the next frame
        }
    }

    void MovingPlatform()
    {
        rb.velocity = Vector3.forward * speed; // Move the platform
    }
}
