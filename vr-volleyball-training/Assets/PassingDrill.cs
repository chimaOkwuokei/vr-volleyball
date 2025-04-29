using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class PassingDrill : MonoBehaviour
{
    public TMP_Text instructionText; // Assign in Inspector
    public GameObject[] targets;     // Assign all target GameObjects in Inspector
    // public GameObject scoreManager;  // Assign the ScoreManager
    public TMP_Text rankText;        // Assign RankText in Inspector
    public TMP_Text countdownText;   // Assign Countdown UI Text
    public Button restartButton;     // Assign Restart Button in Inspector
    public AudioSource timeUpSound;  // Assign an AudioSource (drag an AudioClip)
    public ScoreManager scoreManagerScript; // Assign in Inspector
    public CoachServeSpawner serveSpawner; // Assign in Inspector

    private float drillDuration = 300f; // 5 minutes
    private bool isDrillActive = false;
    private float timeLeft;

    void OnEnable()
    {
        StartDrill(); // Automatically start the drill
    }

    void Start()
    {
        instructionText.gameObject.SetActive(true); // Hide instructions initially
        rankText.gameObject.SetActive(false);       // Hide rank initially
        countdownText.gameObject.SetActive(true);   // Show countdown UI

        restartButton.gameObject.SetActive(false);  // Hide restart button initially
        restartButton.onClick.AddListener(RestartDrill);
    }

    public void StartDrill()
    {
        isDrillActive = true;
        timeLeft = drillDuration;
        StartCoroutine(ShowInstructions());
        StartCoroutine(DrillTimer());
        StartCoroutine(UpdateCountdownUI());
        // 🟢 Start serving after a short delay or immediately
        if (serveSpawner != null)
        {
            Invoke("ServeFirstBall", 3f); // Optional delay to sync with UI
        }
    }

    private void ServeFirstBall()
    {
        Debug.Log("first ball served");
        serveSpawner.ServeBall(); // Call the serve function
    }

    IEnumerator ShowInstructions()
    {
        instructionText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        instructionText.gameObject.SetActive(false);
    }

    IEnumerator DrillTimer()
    {
        yield return new WaitForSeconds(drillDuration); // Wait for 5 min

        // Disable all targets
        foreach (GameObject target in targets)
        {
            target.SetActive(false);
        }

        // Show score, rank, and restart button
        // scoreManager.SetActive(true);
        rankText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        // Play time-up sound
        if (timeUpSound != null)
        {
            timeUpSound.Play();
        }

        isDrillActive = false;
        Debug.Log("Drill Ended! Showing Scores & Rank...");
    }

    IEnumerator UpdateCountdownUI()
    {
        while (isDrillActive)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(timeLeft / 60);
                int seconds = Mathf.FloorToInt(timeLeft % 60);
                countdownText.text = $"Time Left: {minutes:D2}:{seconds:D2}";
            }
            else
            {
                countdownText.text = "00:00";
                break;
            }
            yield return null;
        }
    }

    public void RestartDrill()
    {
        // Reset the score
        if (scoreManagerScript != null)
        {
            scoreManagerScript.ResetScore();
        }

        // Reset targets
        foreach (GameObject target in targets)
        {
            target.SetActive(true);
        }

        // scoreManager.SetActive(false);
        rankText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        StartDrill();
    }
}
