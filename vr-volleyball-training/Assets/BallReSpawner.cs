using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    public CoachServeSpawner serveSpawner; // Assign in Inspector
    public float respawnDelay = 6f;

    // Tags considered valid targets
    public string[] validTargetTags = { "MainPassTarget", "SecondaryPassTarget" };

    private void OnCollisionEnter(Collision collision)
    {
        string hitTag = collision.gameObject.tag;

        // If it's a valid target, do nothing
        foreach (string tag in validTargetTags)
        {
            if (hitTag == tag)
            {
                Debug.Log("Hit valid target: " + tag);
                return;
            }
        }

        // If it hit the ground, respawn
        if (hitTag == "Ground")
        {
            Debug.Log("Hit the ground — scheduling respawn in " + respawnDelay + " seconds.");
            if (serveSpawner != null)
            {
                Invoke(nameof(RespawnBall), respawnDelay);
            }
            else
            {
                Debug.LogWarning("ServeSpawner not assigned in BallCollisionHandler.");
            }
        }
    }

    void RespawnBall()
    {
        serveSpawner.ServeBall();
    }
}
