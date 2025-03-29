using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Manages the player's inventory, specifically the number of coins collected.
public class PlayerInventory : MonoBehaviour
{
    // Reference to the GameOver screen to trigger when conditions are met.
    public GameOverScreen gameOverScreen;

    // Property to keep track of the number of coins collected.
    public int NumberOfCoins { get; private set; }

    // Event triggered when a coin is collected, allowing UI updates or other reactions.
    public UnityEvent<PlayerInventory> OnCoinCollected;

    // Called when the player collects a coin.
    public void CoinCollected()
    {
        // Increase the coin count.
        NumberOfCoins++;

        // Invoke the event to notify other scripts that a coin was collected.
        OnCoinCollected.Invoke(this);
    }

    // Checks if the game-over condition is met.
    private void Update()
    {
        // If the player collects 7 coins, trigger the game-over event.
        if (NumberOfCoins == 7)
        { 
            GameOver();
        }
    }

    // Displays the game-over screen with the final coin count.
    public void GameOver()
    {
        gameOverScreen.win(NumberOfCoins);
    }
}
