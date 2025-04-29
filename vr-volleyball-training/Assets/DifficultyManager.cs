using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameObject[] targets;
    public float moveSpeed = 2f;
    private bool movingRight = true;
    // private int difficultyLevel = 1;

    // Define movement boundaries (Adjust these values to fit your court size)
    private float minX = -2f;  // Left boundary
    private float maxX = 2f;   // Right boundary

    // void OnEnable()
    // {
    //     ScoreManager.ProgressUpdated += AdjustDifficulty;
    // }

    // void OnDisable()
    // {
    //     ScoreManager.ProgressUpdated -= AdjustDifficulty;
    // }

    // void AdjustDifficulty(float accuracy)
    // {
    //     if (accuracy >= 0.7f) // If player is 70% accurate or more, increase difficulty
    //     {
    //         IncreaseDifficulty();
    //     }
    // }

    // void IncreaseDifficulty()
    // {
    //     difficultyLevel++;
    //     Debug.Log("Increasing difficulty to level: " + difficultyLevel);

    //     moveSpeed += 0.5f; // Increase movement speed only
    // }

    void Update()
    {
        foreach (GameObject target in targets)
        {
            Vector3 pos = target.transform.position;

            // Move targets within the court boundaries
            if (movingRight)
                pos.x += moveSpeed * Time.deltaTime;
            else
                pos.x -= moveSpeed * Time.deltaTime;

            // Keep targets inside the court
            if (pos.x > maxX)
            {
                pos.x = maxX;
                movingRight = false; // Change direction
            }
            else if (pos.x < minX)
            {
                pos.x = minX;
                movingRight = true; // Change direction
            }

            target.transform.position = pos;
        }
    }
}
