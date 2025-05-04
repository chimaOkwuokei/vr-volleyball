using UnityEngine;

public class HitScript : MonoBehaviour
{
    [SerializeField] private float hitPower = 5f; // Adjustable in inspector

    void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Ball" || tag == "CoachBall")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 hitDirection = collision.relativeVelocity.normalized;
                rb.AddForce(hitDirection * hitPower, ForceMode.Impulse);
            }
        }
    }
}
