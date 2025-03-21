using UnityEngine;
using TMPro;
using System.Collections;

public class ServingDrill : MonoBehaviour
{
    public TMP_Text instructionText; // Assign in Inspector

    void OnEnable()
    {
        StartDrill(); // Automatically start drill when activated
    }
    void Start()
    {
        instructionText.gameObject.SetActive(false); // Ensure it's hidden initially
    }

    public void StartDrill()
    {
        StartCoroutine(ShowInstructions());
    }

    IEnumerator ShowInstructions()
    {
        instructionText.gameObject.SetActive(true); // Show the instructions
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        Debug.Log("Hiding Instructions..."); // Debug to check if this runs
        instructionText.gameObject.SetActive(false); // Hide the instructions
    }
}
