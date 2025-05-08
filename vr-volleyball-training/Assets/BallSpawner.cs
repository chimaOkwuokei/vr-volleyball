using UnityEngine;

public class CoachServeSpawner : MonoBehaviour
{
    public GameObject ball;
    public Transform targetTransform;  // Player's center or chest
    public Transform serveOrigin;     // Position on left court (set in Inspector)

    [Header("Serve Settings")]
    public float serveHeight = 2.5f;         // How high the ball arcs
    public float serveTime = 1.2f;           // Time it takes to reach the target
    public float angleVariation = 5f;        // Small left/right randomness

    private Rigidbody ballRb;

    void Awake()
    {
        if (ball == null || targetTransform == null || serveOrigin == null)
        {
            Debug.LogError("CoachServeSpawner: Missing references.");
            enabled = false;
            return;
        }

        ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb == null)
        {
            Debug.LogError("CoachServeSpawner: Ball needs Rigidbody.");
            enabled = false;
        }
    }

    public void ServeBall()
    {
        // Reset
        ballRb.isKinematic = true;
        ballRb.useGravity = false;
        ball.SetActive(false);

        // Set starting point
        ball.transform.position = serveOrigin.position;
        ball.transform.rotation = Quaternion.identity;
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
        ball.SetActive(true);

        // Calculate target with randomness
        Vector3 finalTarget = targetTransform.position;
        finalTarget += new Vector3(Random.Range(-angleVariation, angleVariation), 0, 0); // Random horizontal aim

        // Compute velocity to arc toward the target
        Vector3 velocity = CalculateArcVelocity(serveOrigin.position, finalTarget, serveHeight, serveTime);

        // Apply
        ballRb.isKinematic = false;
        ballRb.useGravity = true;
        ballRb.velocity = velocity;

        Debug.Log("Ball served with arc velocity: " + velocity);
    }

    /// <summary>
    /// Calculates velocity to reach a target using an arc.
    /// </summary>
    Vector3 CalculateArcVelocity(Vector3 start, Vector3 end, float height, float time)
    {
        Vector3 toTarget = end - start;
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0, toTarget.z);

        float yOffset = toTarget.y;
        float xzDistance = toTargetXZ.magnitude;

        float Vy = (height - start.y) * 2f / time + Physics.gravity.y * time / 2f;
        float Vxz = xzDistance / time;

        Vector3 result = toTargetXZ.normalized * Vxz;
        result.y = Vy;
        return result;
    }
}
