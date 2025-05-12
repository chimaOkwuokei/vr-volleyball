
using UnityEngine;

public class BallHitResponse : MonoBehaviour
{
    public float hitForceMultiplier = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            Rigidbody handRb = collision.gameObject.GetComponent<Rigidbody>();
            if (handRb != null)
            {
                Vector3 appliedForce = handRb.velocity * hitForceMultiplier;
                rb.AddForce(appliedForce, ForceMode.Impulse);
                Debug.Log("Ball hit by: " + collision.gameObject.name);
            }
        }
    }
}
