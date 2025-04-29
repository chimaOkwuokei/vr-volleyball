using System.Collections;
using UnityEngine;

public class PassingTarget : MonoBehaviour
{
    public int scoreValue = 2; // 2 for MainPassTarget, 1 for SecondaryPassTarget
    public CoachServeSpawner coachServeSpawner; // Assign in Inspector
    private Renderer targetRenderer;
    private Color originalColor;

    private void Start()
    {
        targetRenderer = GetComponent<Renderer>();
        originalColor = targetRenderer.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ScoreManager.instance.AddScore(scoreValue, true); // ✅ Add points
            StartCoroutine(FlashTarget());
            Invoke(nameof(TriggerNextServe), 1f); // ✅ Delay to give player feedback
        }
    }

    void TriggerNextServe()
    {
        coachServeSpawner.ServeBall(); // ✅ New serve from coach
    }

    private IEnumerator FlashTarget()
    {
        targetRenderer.material.color = scoreValue == 2 ? Color.green : Color.yellow;
        yield return new WaitForSeconds(0.5f);
        targetRenderer.material.color = originalColor;
    }
}
