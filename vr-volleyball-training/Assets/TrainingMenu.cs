using UnityEngine;
using UnityEngine.UI;

public class TrainingMenu : MonoBehaviour
{
    public GameObject trainingMenuUI;  // Drag the Training Menu UI Canvas here
    public GameObject servingDrill;    // Drag the "Serving" GameObject here
    public Button servingButton;       // Drag the "Serving Training" button here
    public GameObject servingDrill2;    // Drag the "Serving" GameObject here
    public Button servingButton2;       // Drag the "Serving Training" button here
    public Button endTraining;         // Drag the "End Training" button here
    public GameObject passingDrill;    // Drag the "passing" GameObject here
    public Button passingButton;       // Drag the "Serving Training" button here
    public ScoreManager scoreManagerScript; // Assign in Inspector

    public PassingDrill passDrillScript;
    void Start()
    {
        trainingMenuUI.SetActive(true);   // Show the menu at the start
        servingDrill.SetActive(false);    // Make sure Serving Drill is off
        servingDrill2.SetActive(false);    // Make sure Serving Drill is off
        passingDrill.SetActive(false);    // Make sure Serving Drill is off
        endTraining.gameObject.SetActive(false); // Hide "End Training" at start

        servingButton.onClick.AddListener(StartServingTraining);
        servingButton2.onClick.AddListener(StartServingTraining2);
        passingButton.onClick.AddListener(StartPassingTraining);
        endTraining.onClick.AddListener(EndTraining);
    }

    public void StartServingTraining()
    {
        trainingMenuUI.SetActive(false); // Hide menu
        servingDrill.SetActive(true);    // Show Serving Drill
        endTraining.gameObject.SetActive(true);  // Show End Training button
    }

    public void StartServingTraining2()
    {
        trainingMenuUI.SetActive(false); // Hide menu
        servingDrill2.SetActive(true);    // Show Serving Drill
        endTraining.gameObject.SetActive(true);  // Show End Training button
    }

    public void StartPassingTraining()
    {
        trainingMenuUI.SetActive(false); // Hide menu
        passingDrill.SetActive(true);    // Show Serving Drill
        endTraining.gameObject.SetActive(true);  // Show End Training button
        // Reset the score
        if (passDrillScript != null)
        {
            passDrillScript.StartDrill();
        }
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
        servingDrill2.SetActive(false);
        passingDrill.SetActive(false);
        endTraining.gameObject.SetActive(false); // Hide End Training button
    }
}
