using UnityEngine;

public class CoachServeSpawner : MonoBehaviour
{
    public GameObject ball;               // Assign the ball in Inspector
    public Transform targetTransform;     // The player's hand or center point
    public float dropHeight = 3f;         // How high above the target to drop

    private Rigidbody rb;

    void Awake()
    {
        if (ball == null || targetTransform == null)
        {
            Debug.LogError("CoachServeSpawner: Assign ball and targetTransform in Inspector.");
            enabled = false; // Disable this script to avoid further errors
            return;
        }

        rb = ball.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("CoachServeSpawner: Ball is missing Rigidbody!");
            enabled = false;
            return;
        }
    }

    public void ServeBall()
    {
        if (ball == null || targetTransform == null || rb == null)
        {
            Debug.LogError("CoachServeSpawner: Missing references when trying to serve.");
            return;
        }

        // Move ball above targetTransform
        Vector3 spawnPosition = targetTransform.position + Vector3.up * dropHeight;
        ball.transform.position = spawnPosition;
        ball.transform.rotation = Quaternion.identity;

        // Activate physics
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Debug.Log("CoachServeSpawner: Ball served at " + spawnPosition);
    }
}
