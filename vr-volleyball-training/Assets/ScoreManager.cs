using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text rankText;

    private int totalServes = 0;
    private int successfulHits = 0;
    public float accuracyThreshold = 0.7f; // 70% success needed to increase difficulty

    public delegate void OnProgressUpdate(float accuracy);
    public static event OnProgressUpdate ProgressUpdated;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void AddScore(int points, bool hitTarget)
    {
        score += points;
        totalServes++;

        if (hitTarget) successfulHits++;

        UpdateScoreUI();
        CheckForDifficultyIncrease();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
            CheckForRanking();
    }

    void CheckForRanking()
    {
        if (score >= 101)
            rankText.text = "Rank: Gold 🥇";
        else if (score >= 51)
            rankText.text = "Rank: Silver 🥈";
        else
            rankText.text = "Rank: Bronze 🥉";
    }

    void CheckForDifficultyIncrease()
    {
        float accuracy = (totalServes > 0) ? (float)successfulHits / totalServes : 0f;

        // Notify DifficultyManager about player performance
        ProgressUpdated?.Invoke(accuracy);
    }
}
