using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public void GameOver()
    {
        gameOverScreen.win(NumberOfCoins);
    }
    public int NumberOfCoins { get; private set; }

    public UnityEvent<PlayerInventory> OnCoinCollected;

    public void CoinCollected()
    {
        NumberOfCoins++;
        OnCoinCollected.Invoke(this);
    }
    public void Update()
    {
        if (NumberOfCoins == 7)
        { 
            GameOver();
        }
    
    }
}