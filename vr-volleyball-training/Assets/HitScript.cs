// using UnityEngine;

// public class HitScript : MonoBehaviour
// {
//     [SerializeField] private float hitPower = 5f; // Adjustable in inspector

//     void OnCollisionEnter(Collision collision)
//     {
//         string tag = collision.gameObject.tag;

//         if (tag == "Ball" || tag == "CoachBall")
//         {
//             Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
//             if (rb != null)
//             {
//                 Vector3 hitDirection = collision.relativeVelocity.normalized;
//                 rb.AddForce(hitDirection * hitPower, ForceMode.Impulse);
//             }
//         }
//     }
// }
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HitTriggerScript : MonoBehaviour
{
    public float hitThreshold = 0.5f;
    public float forceMultiplier = 10f;
    public float hapticAmplitude = 0.6f;
    public float hapticDuration = 0.1f;

    private XRBaseController controller;

    void Start()
    {
        controller = GetComponentInParent<XRBaseController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("CoachBall"))
        {
            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            Rigidbody handRb = GetComponent<Rigidbody>();

            if (ballRb == null || handRb == null) return;

            Vector3 handVelocity = handRb.velocity;

            if (handVelocity.magnitude > hitThreshold)
            {
                Vector3 hitDirection = handVelocity.normalized;
                ballRb.AddForce(hitDirection * forceMultiplier, ForceMode.Impulse);

                // Trigger Haptics
                if (controller != null)
                {
                    controller.SendHapticImpulse(hapticAmplitude, hapticDuration);
                }
            }
        }
    }
}
