using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Handles the game over screen UI
public class GameOverScreen : MonoBehaviour
{
    // Reference to the UI text element that displays the player's score
    public TextMeshProUGUI pointsText;

    // Method to display the game over screen with the final score
    public void win(int score)
    {
        // Activate the game over screen
        gameObject.SetActive(true);

        // Update the UI with the player's final score
        pointsText.text = "You earned: " + score.ToString() + " points";
    }
}
