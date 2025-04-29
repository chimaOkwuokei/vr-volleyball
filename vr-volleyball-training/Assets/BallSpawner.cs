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

        // Offset the spawn slightly forward (e.g., 0.5 units in front)
        Vector3 basePosition = new Vector3(1.6f, 1.3f, 3.9f);
        Vector3 forwardOffset = new Vector3(0f, 0f, 0.4f); // Adjust z as needed

        Vector3 spawnPosition = basePosition + forwardOffset + Vector3.up * dropHeight;

        ball.transform.position = spawnPosition;
        ball.transform.rotation = Quaternion.identity;

        rb.isKinematic = false;
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Debug.Log($"Ball dropped from {spawnPosition}");
    }
}
