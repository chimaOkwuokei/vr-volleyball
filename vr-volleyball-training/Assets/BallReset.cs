using UnityEngine;

public class BallReset : MonoBehaviour
{
    public Transform servePosition; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Ground"))
        {
            Debug.Log("Ball hit ground!");
            ScoreManager.instance.AddScore(0, false); // ✅ Count serve, no points
            ResetBall();
        }else if (other.CompareTag("Target")){
            Debug.Log("Ball Hit Target");
            ResetBall();
        }
    }

    void ResetBall()
    {
        rb.velocity = Vector3.zero;  // Stop movement
        rb.angularVelocity = Vector3.zero;  // Stop rotation

        transform.position = servePosition.position; // ✅ Move ball to player's hand

        rb.isKinematic = true;
        rb.isKinematic = false;

    }
}
