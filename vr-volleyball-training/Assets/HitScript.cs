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
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HitTriggerScript : MonoBehaviour
{
    public float hitThreshold = 0.5f;
    public float forceMultiplier = 15f;
    public float hapticAmplitude = 0.6f;
    public float hapticDuration = 0.1f;
    public XRNode controllerNode; // LeftHand or RightHand
    public XRBaseController xrController; // Assign in Inspector for haptics

    private InputDevice device;

    void Start()
    {
        device = InputDevices.GetDeviceAtXRNode(controllerNode);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("CoachBall"))
        {
            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            if (ballRb == null || !device.isValid) return;

            if (device.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity))
            {
                if (velocity.magnitude > hitThreshold)
                {
                    Vector3 hitDirection = velocity.normalized;
                    ballRb.AddForce(hitDirection * velocity.magnitude * forceMultiplier, ForceMode.Impulse);

                    // ✅ Trigger Haptics
                    if (xrController != null)
                    {
                        xrController.SendHapticImpulse(hapticAmplitude, hapticDuration);
                    }
                }
            }
        }
    }
}
