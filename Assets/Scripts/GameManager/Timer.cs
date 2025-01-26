using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // Reference to the Text UI element
    private float timeElapsed = 0f; // Time elapsed since start

    void Update()
    {
        // Update the time elapsed
        timeElapsed += Time.deltaTime;

        // Display the time in minutes:seconds format
        int minutes = Mathf.FloorToInt(timeElapsed / 60f);
        int seconds = Mathf.FloorToInt(timeElapsed % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}