using System.Collections;
using UnityEngine;

public class ServingTarget : MonoBehaviour
{
    public int scoreValue = 10;
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
            ScoreManager.instance.AddScore(scoreValue, true); // ✅ Counts as a successful hit
            StartCoroutine(FlashTarget());
        }
    }

    private IEnumerator FlashTarget()
    {
        targetRenderer.material.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        targetRenderer.material.color = originalColor;
    }
}
