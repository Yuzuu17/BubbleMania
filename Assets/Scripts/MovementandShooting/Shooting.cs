using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float Force;
    public float moveSpeed = 5f;
    private Rigidbody rb;

    private bool canMove = true;                                                    // Flag to check if the object can move

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canMove)                                                              
        {
            float moveHorizontal = 0;

            if (Input.GetKey(KeyCode.A))
            {
                moveHorizontal = moveSpeed;                                    // Move left
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveHorizontal = -moveSpeed;                                    // Move right
            }

                                                                              // Apply movement
            Vector3 movement = new Vector3(moveHorizontal, 0, 0);
            rb.MovePosition(rb.position + movement * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        if (canMove)                                                        // Only shoot if the object can move
        {
            rb.AddForce(Vector3.back * Force, ForceMode.Impulse);
            canMove = false;                                               // Disable movement after shooting
            SpawnNewBall();                                               // Call the function to spawn a new ball
        }
    }

    void SpawnNewBall()
    {
                                                                                                                                      // Assuming you have a prefab for the new ball
        GameObject newBallPrefab = Resources.Load<GameObject>("NewBallPrefab");                                                      // Replace with your prefab path
        if (newBallPrefab != null)
        {
                                                                                                                                     // Instantiate the new ball
            GameObject newBall = Instantiate(newBallPrefab, transform.position + new Vector3(0, 0, 1), Quaternion.identity);
            newBall.GetComponent<Shooting>().EnableMovement();                                                                      // Enable movement for the new ball
        }
    }

    public void EnableMovement()
    {
        canMove = true;                                                                                                             // Allow the new ball to move
    }
}