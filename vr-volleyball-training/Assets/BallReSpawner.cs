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

        // Check if it's a valid target
        foreach (string tag in validTargetTags)
        {
            if (hitTag == tag)
            {
                Debug.Log("Hit valid target: " + tag + " — scheduling respawn in " + respawnDelay + " seconds.");
                TryScheduleRespawn();
                return;
            }
        }

        // If it hit the ground, also respawn
        if (hitTag == "Ground")
        {
            Debug.Log("Hit the ground — scheduling respawn in " + respawnDelay + " seconds.");
            TryScheduleRespawn();
        }
    }

    void TryScheduleRespawn()
    {
        if (serveSpawner != null)
        {
            Invoke(nameof(RespawnBall), respawnDelay);
        }
        else
        {
            Debug.LogWarning("ServeSpawner not assigned in BallCollisionHandler.");
        }
    }

    void RespawnBall()
    {
        serveSpawner.ServeBall();
    }
}
