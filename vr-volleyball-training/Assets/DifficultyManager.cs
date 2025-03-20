using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameObject[] targets;
    public float moveSpeed = 2f;
    private bool movingRight = true;
    private int difficultyLevel = 1;

    void OnEnable()
    {
        ScoreManager.ProgressUpdated += AdjustDifficulty;
    }

    void OnDisable()
    {
        ScoreManager.ProgressUpdated -= AdjustDifficulty;
    }

    void AdjustDifficulty(float accuracy)
    {
        if (accuracy >= 0.7f) // If player is 70% accurate or more, increase difficulty
        {
            IncreaseDifficulty();
        }
    }

    void IncreaseDifficulty()
    {
        difficultyLevel++;
        Debug.Log("Increasing difficulty to level: " + difficultyLevel);

        foreach (GameObject target in targets)
        {
            Vector3 newPos = target.transform.position;
            newPos.z -= 1; // Move targets further
            target.transform.position = newPos;

            target.transform.localScale *= 0.9f; // Reduce size by 10% each level
        }

        moveSpeed += 0.5f; // Make moving targets faster
    }

    void Update()
    {
        foreach (GameObject target in targets)
        {
            Vector3 pos = target.transform.position;
            if (movingRight) pos.x += moveSpeed * Time.deltaTime;
            else pos.x -= moveSpeed * Time.deltaTime;

            target.transform.position = pos;

            if (pos.x > 4) movingRight = false;
            if (pos.x < -4) movingRight = true;
        }
    }
}
