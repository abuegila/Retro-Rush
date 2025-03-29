using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    // UI element to display the countdown timer.
    [SerializeField] private TextMeshProUGUI timerText;

    // The total remaining time in seconds.
    [SerializeField] private float remainingTime;

    // UI elements to show/hide when time runs out.
    [SerializeField] private GameObject imageInstance;
    [SerializeField] private GameObject textInstance;

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime; // Decrease time each frame.
        }
        else
        {
            remainingTime = 0; // Ensure time doesn't go negative.

            // Activate the image and hide the text when the timer reaches zero.
            if (imageInstance != null) imageInstance.SetActive(true);
            if (textInstance != null) textInstance.SetActive(false);
        }

        // Change the timer text color to red when 10 seconds remain.
        if (remainingTime <= 10)
        {
            timerText.color = Color.red;
        }

        // Convert remaining time to minutes and seconds format.
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        // Update the timer UI text.
        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
