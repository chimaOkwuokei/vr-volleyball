using UnityEngine;

public class HitScript : MonoBehaviour
{
    [SerializeField] private float hitPower = 5f; // Adjustable in inspector

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 hitDirection = collision.relativeVelocity.normalized;
            rb.AddForce(hitDirection * hitPower, ForceMode.Impulse);
        }
    }
}
