using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text accuracyText;
    public TMP_Text servesText;
    public TMP_Text hitsText;
    public TMP_Text rankText;

    private int totalServes = 0;
    private int successfulHits = 0;
    private float accuracy;
    public float accuracyThreshold = 0.7f; // 70% success needed to increase difficulty

    public delegate void OnProgressUpdate(float accuracy);
    public static event OnProgressUpdate ProgressUpdated;

    void Awake()
    {
        if (instance == null) instance = this;
        // instance = this;
    }

    public void AddScore(int points, bool hitTarget)
    {
        score += points;
        totalServes++;

        if (hitTarget)
        {
            successfulHits++;
        }
        UpdateScoreUI();
        CheckForDifficultyIncrease();
    }

    public void ResetScore()
    {
        score = 0;
        totalServes = 0;
        successfulHits = 0;
        accuracy = 0;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
            servesText.text = "Serves: " + totalServes;
            hitsText.text = "Hits: " + successfulHits;
            accuracyText.text = "Accuracy: " + accuracy;
        }

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
        servesText.text = "Serves: " + totalServes;
        hitsText.text = "Hits: " + successfulHits;

        accuracy = (totalServes > 0) ? (float)successfulHits / totalServes : 0f;

        accuracyText.text = "Accuracy: " + (accuracy * 100) + "%";

        // Notify DifficultyManager about player performance
        ProgressUpdated?.Invoke(accuracy);
    }
}
