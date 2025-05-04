using UnityEngine;

public class CoachServeSpawner : MonoBehaviour
{
    public GameObject ball;               // Assign the ball prefab or object in Inspector
    public Transform targetTransform;     // Assign the player's hand, chest, or center point in Inspector
    public float dropHeight = 1.2f;       // Optional vertical offset (simulating a toss)

    private Rigidbody rb;

    void Awake()
    {
        if (ball == null || targetTransform == null)
        {
            Debug.LogError("CoachServeSpawner: Assign ball and targetTransform in Inspector.");
            enabled = false;
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

        // Spawn the ball slightly above coach position
        Vector3 spawnPosition = transform.position + Vector3.up * dropHeight;
        ball.SetActive(false);
        ball.transform.position = spawnPosition;
        ball.transform.rotation = Quaternion.identity;
        ball.SetActive(true);

        rb.isKinematic = false;
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Apply force toward the player
        // Vector3 direction = (targetTransform.position - spawnPosition).normalized;
         Vector3 direction = (targetTransform.position).normalized;
        float serveForce = 4f; // Adjust as needed
        rb.AddForce(direction * serveForce, ForceMode.VelocityChange);

        Debug.Log($"Ball served from {spawnPosition} toward {targetTransform.position}");
    }
}
