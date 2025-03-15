using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public float forceMultiplier = 10f; // Adjust this value as needed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand")) // Ensure your VR hands have the "Hand" tag
        {
            Rigidbody handRb = collision.gameObject.GetComponent<Rigidbody>();
            if (handRb != null)
            {
                Vector3 appliedForce = handRb.velocity * forceMultiplier;
                rb.AddForce(appliedForce, ForceMode.Impulse);
            }
        }
    }
}
