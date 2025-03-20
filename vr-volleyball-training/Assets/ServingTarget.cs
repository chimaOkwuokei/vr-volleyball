using UnityEngine;
using System.Collections;

public class ServingTarget : MonoBehaviour
{
    public int scoreValue = 10;  
    private Renderer targetRenderer;
    private Color originalColor;

    void Start()
    {
        targetRenderer = GetComponent<Renderer>();
        originalColor = targetRenderer.material.color;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ScoreManager.instance.AddScore(scoreValue, true); // Pass "true" for hit success
            StartCoroutine(FlashTarget());
        }
    }

    IEnumerator FlashTarget()
    {
        targetRenderer.material.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        targetRenderer.material.color = originalColor;
    }
}
