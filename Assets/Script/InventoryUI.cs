using UnityEngine;
using TMPro;

// Handles the UI for displaying the player's inventory (e.g., coin count)
public class InventoryUI : MonoBehaviour
{
    // Reference to the TextMeshProUGUI component displaying the coin count
    private TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        // Get the TextMeshProUGUI component attached to this GameObject
        coinText = GetComponent<TextMeshProUGUI>();
    }

    // Updates the displayed coin count based on the player's inventory
    public void UpdateCoinText(PlayerInventory playerInventory)
    {
        // Update the UI text with the player's current number of coins
        coinText.text = playerInventory.NumberOfCoins.ToString();
    }
}
