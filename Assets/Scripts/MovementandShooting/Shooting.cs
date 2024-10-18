using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float Force;
    public float moveSpeed = 5f;                    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = 0;

                                                                
        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = moveSpeed;                                      // Move left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = -moveSpeed;                                     // Move right
        }

                                                                           // Apply movement
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        rb.MovePosition(rb.position + movement * Time.deltaTime);
    }

    void OnMouseDown()
    {
        rb.AddForce(Vector3.back * Force, ForceMode.Impulse);
    }
}