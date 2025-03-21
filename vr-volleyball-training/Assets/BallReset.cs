using System.Collections;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    public Transform handPosition; // Assign the player's hand Transform in Inspector
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target") || other.CompareTag("Ground"))  
        {
            Debug.Log("Ball reset triggered!");
            ResetBall(); // ✅ Instantly reset for both hit & miss
        }
    }

    void ResetBall()
    {
        rb.velocity = Vector3.zero;  // Stop movement
        rb.angularVelocity = Vector3.zero;  // Stop rotation

        transform.position = handPosition.position; // ✅ Move ball to player's hand

        rb.isKinematic = true; 
        rb.isKinematic = false;
    }
}


// using UnityEngine;
// using System.Collections;
// public class BallReset : MonoBehaviour
// {
//     private Vector3 defaultPosition;  // Store the starting position of the ball
//     private Rigidbody rb;  // Reference to Rigidbody component

//     void Start()
//     {
//         defaultPosition = transform.position; // Store initial position
//         rb = GetComponent<Rigidbody>(); // Get Rigidbody component
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Target")) // Make sure your targets are tagged as "Target"
//         {
//             Debug.Log("Ball hit the target! Resetting...");
//             StartCoroutine(ResetBall()); // Start reset process
//         }
//     }

//     IEnumerator ResetBall()
//     {
//         yield return new WaitForSeconds(1f); // Optional delay before reset
//         rb.velocity = Vector3.zero; // Stop ball movement
//         rb.angularVelocity = Vector3.zero; // Stop ball rotation
//         transform.position = defaultPosition; // Reset position
//     }
// }
