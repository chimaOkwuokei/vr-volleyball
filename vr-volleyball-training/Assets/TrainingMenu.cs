using UnityEngine;
using UnityEngine.UI;

public class TrainingMenu : MonoBehaviour
{
    public GameObject trainingMenuUI;  // Drag the Training Menu UI Canvas here
    public GameObject servingDrill;    // Drag the "Serving" GameObject here
    public Button servingButton;       // Drag the "Serving Training" button here
    public Button endTraining;         // Drag the "End Training" button here
    public ScoreManager scoreManagerScript; // Assign in Inspector

    void Start()
    {
        trainingMenuUI.SetActive(true);   // Show the menu at the start
        servingDrill.SetActive(false);    // Make sure Serving Drill is off
        endTraining.gameObject.SetActive(false); // Hide "End Training" at start

        servingButton.onClick.AddListener(StartServingTraining);
        endTraining.onClick.AddListener(EndTraining);
    }

    public void StartServingTraining()
    {
        trainingMenuUI.SetActive(false); // Hide menu
        servingDrill.SetActive(true);    // Show Serving Drill
        endTraining.gameObject.SetActive(true);  // Show End Training button
    }

    public void EndTraining()
    {
        // Reset the score
        if (scoreManagerScript != null)
        {
            scoreManagerScript.ResetScore();
        }
        trainingMenuUI.SetActive(true);  // Show the menu
        servingDrill.SetActive(false);   // Hide any active training drill
        endTraining.gameObject.SetActive(false); // Hide End Training button
    }
}
