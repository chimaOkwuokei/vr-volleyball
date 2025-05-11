
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallHitResponse : MonoBehaviour
{
    public float hitForceMultiplier = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            var velocityTracker = collision.gameObject.GetComponent<HandVelocityTracker>();
            if (velocityTracker != null)
            {
                Vector3 hitVelocity = velocityTracker.Velocity;
                rb.AddForce(hitVelocity * hitForceMultiplier, ForceMode.Impulse);
                Debug.Log("Ball hit by: " + collision.gameObject.name);
            }
        }
    }
}
