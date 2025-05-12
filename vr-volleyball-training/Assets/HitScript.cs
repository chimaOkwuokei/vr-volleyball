using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class HitScript : MonoBehaviour
{
    [SerializeField] private float hitPower = 5f; // Adjustable in inspector
    public float hapticAmplitude = 0.6f;
    public float hapticDuration = 0.1f;
    public XRBaseController xrController; // Assign in Inspector for haptics

    void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Ball")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 hitDirection = collision.relativeVelocity.normalized;
                rb.AddForce(hitDirection * hitPower, ForceMode.Impulse);
            }
            if (xrController != null)
            {
                xrController.SendHapticImpulse(hapticAmplitude, hapticDuration);
            }
        }
    }
}
