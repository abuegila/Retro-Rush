using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public void win(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "You earned: " + score.ToString() + " points";
    
    }
}