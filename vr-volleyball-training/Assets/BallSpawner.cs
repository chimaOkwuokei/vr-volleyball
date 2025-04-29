using UnityEngine;

public class CoachServeSpawner : MonoBehaviour
{
    public GameObject ball;                // Pre-existing ball in the scene
    public Transform targetTransform;      // Receiver's position (ball drops above this)
    public Transform target1;              // First target on court
    public Transform target2;              // Second target on court
    public float dropHeight = 3f;          // Height above targetTransform
    public float redirectSpeed = 6f;       // Speed for redirection

    private Rigidbody rb;
    private bool isDrillActive = false;    // Tracks if drill is active

    void Start()
    {
        // Validate references and cache Rigidbody
        if (ball == null || targetTransform == null || target1 == null || target2 == null)
        {
            Debug.LogError("Missing references in CoachServeSpawner!");
            return;
        }

        rb = ball.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Ball is missing Rigidbody!");
            return;
        }
    }

    // Called by the training menu button
    public void StartPassingDrill()
    {
        if (ball == null || targetTransform == null || target1 == null || target2 == null || rb == null)
        {
            Debug.LogError("Missing references in CoachServeSpawner!");
            return;
        }

        isDrillActive = true;
        ServeBall();
    }


    public void ServeBall()
    {
        // Move ball above targetTransform
        Vector3 spawnPosition = targetTransform.position + Vector3.up * dropHeight;
        ball.transform.position = spawnPosition;
        ball.transform.rotation = Quaternion.identity;

        // Ensure physics is active
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Debug.Log($"Ball dropped from {spawnPosition}");
    }

    // Called when player hits the ball
    public void RedirectBall()
    {
        if (!isDrillActive || rb == null)
        {
            Debug.LogWarning("Cannot redirect: Drill inactive or no ball.");
            return;
        }

        // Choose random target
        Transform selectedTarget = Random.Range(0, 2) == 0 ? target1 : target2;
        if (selectedTarget == null)
        {
            Debug.LogWarning("Target missing!");
            return;
        }

        // Calculate direction to target
        Vector3 redirectDirection = (selectedTarget.position - ball.transform.position).normalized;
        rb.velocity = redirectDirection * redirectSpeed;

        Debug.Log($"Ball redirected to {selectedTarget.name} at {selectedTarget.position}");
    }

    // Auto-reset if ball hits ground
    void Update()
    {
        if (isDrillActive && ball != null)
        {
            // Reset if ball falls below court (adjust threshold as needed)
            if (ball.transform.position.y < -1f)
            {
                ServeBall(); // Reposition for continuous drill
            }
        }
    }
}