using UnityEngine;

public class BallHitResponse : MonoBehaviour
{
    public float forceMultiplier = 5f;
    private Rigidbody rb;
    private bool hasBeenHit = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hasBeenHit) return;

        if (collision.collider.CompareTag("Hand"))
        {
            // Get hand velocity if it's tracked (e.g., using XR controller velocity)
            Rigidbody handRb = collision.collider.attachedRigidbody;
            if (handRb != null)
            {
                Vector3 hitDirection = handRb.velocity;
                rb.AddForce(hitDirection * forceMultiplier, ForceMode.Impulse);
                hasBeenHit = true;
            }
        }
    }

    public void ResetBall()
    {
        hasBeenHit = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
