using UnityEngine;

public class CoachServeSpawner : MonoBehaviour
{
    public GameObject ball;
    public Transform serveOrigin;      // Where the ball should spawn

    [Header("Serve Settings")]
    public float lateralForce = 1f;    // Small side curve
    public float serveForceDown = -2f; // Initial downward nudge

    // [Header("Auto Serve")]
    // public float serveInterval = 5f;

    private Rigidbody ballRb;

    void Awake()
    {
        if (ball == null || serveOrigin == null)
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

    // void Start()
    // {
    //     InvokeRepeating(nameof(ServeBall), 1f, serveInterval);
    // }

    public void ServeBall()
    {
        if (ball == null || serveOrigin == null)
            return;

        // Reset position and physics
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
        ball.transform.position = serveOrigin.position;

        // Enable gravity
        ballRb.useGravity = true;
        ballRb.isKinematic = false;

        // Slight side curve only
        Vector3 lateralOnly = new Vector3(Random.Range(-lateralForce, lateralForce), 0f, 0f);
        ballRb.AddForce(lateralOnly, ForceMode.Impulse); // natural and slower

        Debug.Log("Ball dropped with side curve: " + lateralOnly);
    }

}
